using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;

namespace MyProject.API.Repository.IRepository
{
    public interface IM01CRepository : IRepository<M01C>
    {
        Task<M01C> UpdateAsync(M01C model);
        Task<IEnumerable<InfoProductDto>> GetInfoProduct(int pageSize = 0, int pageNumber = 1, string keyword = null);
    }
}
