using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Repository.IRepository;
using System.Linq.Expressions;

namespace MyProject.API.Repository
{
    public class TokenRepository : Repositoty<RefreshToken>, ITokenRepository
    {
        public TokenRepository(ApplicationDbContext db) : base(db)
        {
        }
        public async Task ExecuteUpdateAsync(Expression<Func<RefreshToken, bool>> filter,
            Expression<Func<SetPropertyCalls<RefreshToken>, SetPropertyCalls<RefreshToken>>> setPropertyCalls)
        {
            await _db.RefreshToken.Where(filter).ExecuteUpdateAsync(setPropertyCalls);
        }
    }
}
