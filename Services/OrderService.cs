using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyProject.API.Commom;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;
using MyProject.API.Services.IService;
using MyProject.API.UnitOfWork.IUOW;

namespace MyProject.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderUnitOfWork _orderUnitOfWork;
        public OrderService(IOrderUnitOfWork orderUnitOfWork)
        {
            _orderUnitOfWork = orderUnitOfWork;
        }
        public async Task<ServiceResponseDto<OrderCreateDto>> Create(OrderCreateDto model)
        {
            var response = new ServiceResponseDto<OrderCreateDto>();
            var id = Guid.NewGuid();
            var d03T = new D03T()
            {
                Id = id,
                UserId = id,
                Status = CConstant.Status.Pending,
                OrderDate = DateTime.Now,
                TotalAmount = model.TotalAmount,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            var k03t = new K03T()
            {
                Id = id,
                Address = model.Address,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            var d03th = new D03TH() 
            {
                D03TId = id,
                M01CId = model.M01CId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            await _orderUnitOfWork.BeginTransactionAsync();
            try
            {
                await _orderUnitOfWork.D03T.CreateAsync(d03T);
                await _orderUnitOfWork.D03TH.CreateAsync(d03th);
                await _orderUnitOfWork.K03T.CreateAsync(k03t);
                await _orderUnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _orderUnitOfWork.RollbackAsync();
                _orderUnitOfWork.Dispose();
                response.Iscucess = false;
                response.Message = ex.Message;
            }
            response.Result = model;
            return response;
        }
    }
}
