using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;
using MyProject.API.Repository.IRepository;
using MyProject.API.Services.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyProject.API.UnitOfWork
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IConfigurationSection? _authSetting;
        private readonly IK01TRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        public UserService(IConfiguration configuration, IMapper mapper, IK01TRepository userRepository, ITokenRepository tokenRepository)
        {
            _mapper = mapper;
            _authSetting = configuration.GetSection("AuthSettings");
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<ServiceResponseDto<UserDto>> Register(RegisterationDto registerationDto)
        {
            var response = new ServiceResponseDto<UserDto>();
            if (!_userRepository.IsUniqueUser(registerationDto.UserName))
            {
                response.Iscucess = false;
                response.Message = "Username already exists";
                return response;
            }

            var user = _mapper.Map<K01T>(registerationDto);
            user.Id = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveAsync();
            response.Result = _mapper.Map<UserDto>(user);

            return response;
        }

        public async Task<TokenDto> RefreshAccessToken(TokenDto tokenDto)
        {
            // Find an existing refresh token
            var existingRefreshToken = await _tokenRepository.GetAsync(u => u.Refresh_Token == tokenDto.RefreshToken);
            if (existingRefreshToken == null)
            {
                return new TokenDto();
            }

            // Compare data from existing refresh and access token provided and if there is any missmatch then consider it as a fraud
            var isTokenValid = GetAccessTokenData(tokenDto.AccessToken, existingRefreshToken.UserId.ToString(), existingRefreshToken.JwtTokenId.ToString());
            if (!isTokenValid)
            {
                await MarkTokenAsInvalid(existingRefreshToken);
                return new TokenDto();
            }

            // When someone tries to use not valid refresh token, fraud possible
            if (!existingRefreshToken.IsValid)
            {
                await MarkAllTokenInChainAsInvalid(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);
            }
            // If just expired then mark as invalid and return empty
            if (existingRefreshToken.ExpiresAt < DateTime.Now)
            {
                await MarkTokenAsInvalid(existingRefreshToken);
                return new TokenDto();
            }

            // replace old refresh with a new one with updated expire date
            var newRefreshToken = await CreateNewRefreshToken(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);


            // revoke existing refresh token
            await MarkTokenAsInvalid(existingRefreshToken);

            // generate new access token
            var user = _userRepository.GetAsync(u => u.Id == existingRefreshToken.UserId);
            if (user == null)
                return new TokenDto();

            var curUse = _mapper.Map<UserDto>(user);
            var newAccessToken = await GetAccessToken(curUse, existingRefreshToken.JwtTokenId);

            return new TokenDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }

        public async Task<ServiceResponseDto<TokenDto>> Login(LoginRequestDto loginRequestDto)
        {
            var response = new ServiceResponseDto<TokenDto>();

            var user = await _userRepository.GetAsync(x => x.UserName == loginRequestDto.UserName
                                                            && x.Password == loginRequestDto.Password);
            if (user == null)
            {
                response.Iscucess = false;
                response.Result = new TokenDto { AccessToken = string.Empty, RefreshToken = string.Empty };
                return response;
            }

            var curUser = _mapper.Map<UserDto>(user);
            var jwtTokenId = $"JTI{Guid.NewGuid()}";
            var accessToken = await GetAccessToken(curUser, jwtTokenId);
            var refreshToken = await CreateNewRefreshToken(user.Id, jwtTokenId);
            TokenDto tokenDto = new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            response.Result = tokenDto;
            return response;
        }

        private async Task<string> GetAccessToken(UserDto user, string jwtTokenId)
        {
            //if user was found generate JWT Token
            var role = user.Role;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSetting["Secretkey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, jwtTokenId),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud, _authSetting["Audience"])
                }),
                Expires = DateTime.Now.AddMinutes(5),
                Issuer = _authSetting["Issuer"],
                Audience = _authSetting["Audience"],
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }

        private async Task<string> CreateNewRefreshToken(Guid userId, string tokenId)
        {
            RefreshToken refreshToken = new()
            {
                Id = Guid.NewGuid(),
                IsValid = true,
                UserId = userId,
                JwtTokenId = tokenId,
                ExpiresAt = DateTime.Now.AddHours(15),
                Refresh_Token = Guid.NewGuid() + "-" + Guid.NewGuid(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _tokenRepository.CreateAsync(refreshToken);
            await _tokenRepository.SaveAsync();
            return refreshToken.Refresh_Token;
        }
        private bool GetAccessTokenData(string accessToken, string expectedUserId, string expectedTokenId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(accessToken);
                var jwtTokenId = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value;
                var userId = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value;
                return userId == expectedUserId && jwtTokenId == expectedTokenId;

            }
            catch
            {
                return false;
            }
        }
        private async Task MarkTokenAsInvalid(RefreshToken refreshToken)
        {
            refreshToken.IsValid = false;
            _tokenRepository.Remove(refreshToken);
            await _tokenRepository.SaveAsync();
        }

        private async Task MarkAllTokenInChainAsInvalid(Guid userId, string tokenId)
        {
            await _tokenRepository.ExecuteUpdateAsync(u => u.UserId == userId && u.JwtTokenId == tokenId,
                   u => u.SetProperty(refreshToken => refreshToken.IsValid, false));

        }

        public async Task RevokeRefreshToken(TokenDto tokenDto)
        {
            var existingRefreshToken = await _tokenRepository.GetAsync(x => x.Refresh_Token == tokenDto.RefreshToken);

            if (existingRefreshToken == null)
                return;

            // Compare data from existing refresh and access token provided and
            // if there is any missmatch then we should do nothing with refresh token

            var isTokenValid = GetAccessTokenData(tokenDto.AccessToken, existingRefreshToken.UserId.ToString(), existingRefreshToken.JwtTokenId.ToString());
            if (!isTokenValid)
            {
                return;
            }

            await MarkAllTokenInChainAsInvalid(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);

        }
    }
}
