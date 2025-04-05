using Microsoft.AspNetCore.Identity;
using MyProject.API.Models.Dto;

namespace MyProject.API.Services.IService
{
    public interface IUserService
    {
        Task<ServiceResponseDto<TokenDto>> Login(LoginRequestDto user);
        Task<ServiceResponseDto<UserDto>> Register(RegisterationDto user);
        Task<TokenDto> RefreshAccessToken(TokenDto tokenDto);
        Task RevokeRefreshToken(TokenDto tokenDTO);
    }
}
