using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class K03TRepository : Repositoty<K03T>, IK03TRepository
    {
        public K03TRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
