using Microsoft.EntityFrameworkCore.Storage;
using MyProject.API.Data;
using MyProject.API.Repository.IRepository;
using MyProject.API.UnitOfWork.IUOW;

namespace MyProject.API.UOW
{
    public class OrderUnitOfWork : UnitOfWork, IOrderUnitOfWork
    {
        public IK03TRepository K03T { get; set; }
        public ID03TRepository D03T { get; set ; }
        public ID03THRepository D03TH { get; set; }
        public OrderUnitOfWork(ApplicationDbContext db, IK03TRepository k03t, ID03TRepository d03t, ID03THRepository d03th) : base(db)
        {
            K03T = k03t;
            D03T = d03t;
            D03TH = d03th;
        }  
    }
}
