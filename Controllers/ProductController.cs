using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.API.Commom;
using MyProject.API.Data.Entities;
using MyProject.API.Models;
using MyProject.API.Models.Dto;
using MyProject.API.Services.IService;
using System.Net;

namespace MyProject.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private APIResponse _response;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _response = new APIResponse();
            _mapper = mapper;
        }


        [HttpGet("Get/{id:Guid}", Name = "Get")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var responseService = await _productService.GetInfoProduct(id);

            if (!responseService.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages.Add(responseService.Message);
                return NotFound();
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var responseService = await _productService.GetAllCategories();
            if (!responseService.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages.Add(responseService.Message);
                return NotFound();
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);
        }

        [AllowAnonymous]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListProduct([FromQuery]string? search)
        {
            var responce = await _productService.GetInfoProducts(keyword: search);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responce.Result;
            return Ok(_response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("Update/{id:Guid}", Name = "GetProductToUpdate")]
        public async Task<IActionResult> GetProductToUpdate(Guid id)
        {
            var responseService = await _productService.GetProductToUpdate(id);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{id:Guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var responseService = await _productService.DeleteProduct(id);
            if (!responseService.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(responseService.Message);
                return NotFound();
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(CConstant.NotValid);
                return BadRequest(_response);
            }

            var responseService = await _productService.CreateProduct(model);

            if (!responseService.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(responseService.Message);
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);

        }

        [Authorize(Roles = "admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromForm]ProductUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(CConstant.NotValid);
                return BadRequest(_response);
            }
            var responseService = await _productService.UpdateProduct(model);

            if (!responseService.Iscucess)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(responseService.Message);
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = responseService.Result;
            return Ok(_response);
        }
    }
}
