using System.Linq.Expressions;

namespace MyProject.API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true, string? includeProperties = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string? includeProperties = null, int pageSize = 0, int pageNumber = 1);
        Task SaveAsync();
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
