using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class D03THRepository : Repositoty<D03TH>, ID03THRepository
    {
        public D03THRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
