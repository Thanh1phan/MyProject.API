using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class B03TRepository : Repositoty<B03T>, IB03TRepository
    {
        public B03TRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
