using Microsoft.EntityFrameworkCore.Storage;
using MyProject.API.Data;
using MyProject.API.UnitOfWork.IUOW;

namespace MyProject.API.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork (ApplicationDbContext db)
        {
            _db = db;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await RollbackAsync();
                throw ex;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
