using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.API.Commom;
using MyProject.API.Models;
using MyProject.API.Models.Dto;
using MyProject.API.Services.IService;
using System.Net;

namespace MyProject.API.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private APIResponse _response;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            _response = new APIResponse();
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder(OrderCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(CConstant.NotValid);
                return BadRequest(_response);
            }

            var serviceResponse = await _orderService.Create(model);

            if(!serviceResponse.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(serviceResponse.Message);
                return BadRequest(_response);
            }
            _response.Result = serviceResponse.Result;
            return Ok(_response);
        }
    }
}
