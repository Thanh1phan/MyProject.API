
using MyProject.API.Repository.IRepository;

namespace MyProject.API.UOW.IUOW
{
    public interface IUnitOfWork
    {
        IM01CRepository M01C { get; }
        IK02TRepository K02T { get; }
        IK11TRepository K11T { get; }
        IB03TRepository B03T { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveAsync();
        void Dispose();
    }
}
