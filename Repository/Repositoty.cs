using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using MyProject.API.Repository.IRepository;
using System.Linq.Expressions;

namespace MyProject.API.Repository
{
    public class Repositoty<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _db;
        protected DbSet<T> _dbSet;

        public Repositoty(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="tracked"></param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetListAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string? includeProperties = null, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// RemoveAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// SaveAsync
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
