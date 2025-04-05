namespace MyProject.API.UnitOfWork.IUOW
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveAsync();
        void Dispose();
    }
}
