using MyProject.API.Models.Dto;

namespace MyProject.API.Services.IService
{
    public interface IProductService
    {
        Task<ServiceResponseDto<ProductCreateDto>> CreateProduct(ProductCreateDto model);
        Task<ServiceResponseDto<ProductUpdateDto>> UpdateProduct(ProductUpdateDto model);
        Task<ServiceResponseDto<ProductDto>> DeleteProduct(Guid id);
        Task<ServiceResponseDto<InfoProductDto>> GetInfoProduct(Guid id);
        Task<ServiceResponseDto<DetailProductDto>> GetProductToUpdate(Guid id);
        Task<ServiceResponseDto<IEnumerable<InfoProductDto>>> GetInfoProducts(int pageSize = 0, int pageNumber = 1, string keyword = null);
        Task<ServiceResponseDto<IEnumerable<CategoryDto>>> GetAllCategories();
    }
}
