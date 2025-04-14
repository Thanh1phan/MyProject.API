using Microsoft.AspNetCore.Mvc;
using MyProject.API.Models;
using MyProject.API.Models.Dto;
using MyProject.API.Repository.IRepository;
using MyProject.API.Services.IService;
using System.Net;

namespace MyProject.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private APIResponse _response;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _response = new APIResponse();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            if (!ModelState.IsValid) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Invalid Input");
                return BadRequest(_response);
            }

            var serviceResponse = await _userService.Login(request);

            if (!serviceResponse.Iscucess)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName or password is incorrect!");
                return BadRequest(_response);
            }
            _response.Result = serviceResponse.Result;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterationDto registeration)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Invalid Input");
                return BadRequest(_response);
            }

            var serviceResponse = await _userService.Register(registeration);
            if (!serviceResponse.Iscucess)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(serviceResponse.Message);
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = serviceResponse.Result;
            return Ok(_response);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> GetNewTokenFromRefreshToken([FromBody] TokenDto tokenDto)
        {
            if (ModelState.IsValid)
            {
                var tokenDTOResponse = await _userService.RefreshAccessToken(tokenDto);
                if (tokenDTOResponse == null || string.IsNullOrEmpty(tokenDTOResponse.AccessToken))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Token Invalid");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = tokenDTOResponse;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Result = "Invalid Input";
                return BadRequest(_response);
            }
        }

        [HttpPost("Revoke")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] TokenDto tokenDto)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.Result = "Invalid Input";
                return BadRequest(_response);
            }
            
            await _userService.RevokeRefreshToken(tokenDto);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
