using MyProject.API.Repository.IRepository;

namespace MyProject.API.UnitOfWork.IUOW
{
    public interface IOrderUnitOfWork : IUnitOfWork
    {
        public IK03TRepository K03T { get; set; }
        public ID03TRepository D03T { get; set; }
        public ID03THRepository D03TH { get; set; }
    }
}
