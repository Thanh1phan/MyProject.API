using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;
using System.Linq.Expressions;

namespace MyProject.API.Repository
{
    public class K02TRepository : Repositoty<K02T>, IK02TRepository
    {
        public K02TRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<K02T>> CreateRangeAsync(IEnumerable<K02T> range)
        {
            await _dbSet.AddRangeAsync(range);
            return range;
        }

        public async Task<int> RemoveRangeAsync(Expression<Func<K02T, bool>> expression)
        {
            return await _dbSet.Where(expression).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<K02T>> UpdateRangeAsync(IEnumerable<K02T> range)
        {
            _dbSet.UpdateRange(range);
            return range;
        }


    }
}
