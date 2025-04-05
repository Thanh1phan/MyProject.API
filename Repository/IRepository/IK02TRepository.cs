using MyProject.API.Data.Entities;
using System.Linq.Expressions;

namespace MyProject.API.Repository.IRepository
{
    public interface IK02TRepository : IRepository<K02T>
    {
        Task<IEnumerable<K02T>> CreateRangeAsync(IEnumerable<K02T> range);
        Task<IEnumerable<K02T>> UpdateRangeAsync(IEnumerable<K02T> range);
        Task<int> RemoveRangeAsync(Expression<Func<K02T, bool>> expression);
    }
}
