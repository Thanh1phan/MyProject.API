using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;

namespace MyProject.API.Repository
{
    public class M02TReporsitory : Repositoty<M02T>, IM02TRepository
    {
        public M02TReporsitory(ApplicationDbContext db) : base(db)
        {
        }
    }
}
