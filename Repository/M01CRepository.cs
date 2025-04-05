using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class M01CRepository : Repositoty<M01C>, IM01CRepository
    {
        public M01CRepository(ApplicationDbContext db) : base(db)
        {
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<M01C> UpdateAsync(M01C model)
        {
            model.UpdateDate = DateTime.Now;
            _dbSet.Update(model);
            await SaveAsync();
            return model;
        }

        /// <summary>
        /// GetInfoProduct
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<IEnumerable<InfoProductDto>> GetInfoProduct(int pageSize = 0, int pageNumber = 1, string keyword = null)
        {
            var listData = _dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(keyword))
            {
                listData = listData.Where(x => x.Name.Contains(keyword));
            }

            var resultQuery = listData.GroupJoin(_db.B03T, m01c => m01c.B3Id, b03t => b03t.Id, (m01c, b03t) => new { m01c, b03t })
                                        .SelectMany(x => x.b03t.DefaultIfEmpty(),
                                                     (x, b03t) => new
                                                     {
                                                         id = x.m01c.Id,
                                                         name = x.m01c.Name,
                                                         b3name = b03t.Name
                                                     }
                                                    )
                                        .GroupJoin(_db.K11T, x => x.id, y => y.M01CId, (m01c, k11t) => new { m01c, k11t })
                                        .SelectMany(x => x.k11t.DefaultIfEmpty(),
                                                    (x, k11t) => new InfoProductDto()
                                                    {
                                                        M01CId = x.m01c.id,
                                                        Name = x.m01c.name,
                                                        B3Name = x.m01c.b3name,
                                                        ZIBAIKA = k11t.ZIBAIKA,
                                                        ZOBAIKA = k11t.ZOBAIKA,
                                                        ListUrlImage = _db.K02T.Where(k => k.M01CId == x.m01c.id).OrderBy(o => o.Seq).Select(k => k.Url).ToList()
                                                    }
                                                    );

            if (pageSize > 0)
            {
                if (pageSize > 100)
                { 
                    pageSize = 100;
                }
                resultQuery = resultQuery.Skip(pageSize*(pageNumber - 1)).Take(pageSize);
            }
            return await resultQuery.ToListAsync();
        }
    }
}
