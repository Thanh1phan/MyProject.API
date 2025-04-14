using MyProject.API.Models.Dto;

namespace MyProject.API.Services.IService
{
    public interface IOrderService
    {
        Task<ServiceResponseDto<OrderCreateDto>> Create(OrderCreateDto dto);
    }
}
