using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyProject.API.Data;
using MyProject.API.Repository.IRepository;
using MyProject.API.UOW.IUOW;

namespace MyProject.API.UOW
{
    public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
    {
        
        public IM01CRepository M01C { get; }
        public IK02TRepository K02T { get;  }
        public IK11TRepository K11T { get; }
        public IB03TRepository B03T { get; }

        public ProductUnitOfWork(ApplicationDbContext db, IDbContextTransaction transaction, IM01CRepository m01CRepository,
            IK02TRepository k02TRepository, IK11TRepository k11TRepository, IB03TRepository b03TRepository) : base(db, transaction)
        {
            M01C = m01CRepository;
            K02T = k02TRepository;
            K11T = k11TRepository;
            B03T = b03TRepository;
        }
    }
}
