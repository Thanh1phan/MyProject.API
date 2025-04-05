using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class K11TRepository : Repositoty<K11T>, IK11TRepository
    {
        public K11TRepository(ApplicationDbContext db) : base(db)
        {
        }

        public K11T Update(K11T entity) 
        { 
            _dbSet.Update(entity);
            return entity;
        }
    }
}
