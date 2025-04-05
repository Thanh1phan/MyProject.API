using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyProject.API.Data;
using MyProject.API.Repository.IRepository;
using MyProject.API.UOW.IUOW;

namespace MyProject.API.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private IDbContextTransaction _transaction;
        public IM01CRepository M01C { get; }
        public IK02TRepository K02T { get;  }
        public IK11TRepository K11T { get; }
        public IB03TRepository B03T { get; }

        public UnitOfWork(ApplicationDbContext db, IM01CRepository m01CRepository, 
            IK02TRepository k02TRepository, IK11TRepository k11TRepository, IB03TRepository b03TRepository)
        {
            _db = db;
            M01C = m01CRepository;
            K02T = k02TRepository;
            K11T = k11TRepository;
            B03T = b03TRepository;
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
            catch(Exception ex) 
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
