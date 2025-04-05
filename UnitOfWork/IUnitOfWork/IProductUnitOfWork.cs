
using MyProject.API.Repository.IRepository;
using MyProject.API.UnitOfWork.IUOW;

namespace MyProject.API.UOW.IUOW
{
    public interface IProductUnitOfWork : IUnitOfWork
    {
        IM01CRepository M01C { get; }
        IK02TRepository K02T { get; }
        IK11TRepository K11T { get; }
        IB03TRepository B03T { get; }

    }
}
