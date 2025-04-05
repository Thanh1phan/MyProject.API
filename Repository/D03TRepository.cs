using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class D03TRepository : Repositoty<D03T>, ID03TRepository
    {
        public D03TRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
