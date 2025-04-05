using Microsoft.EntityFrameworkCore.Query;
using MyProject.API.Data.Entities;
using System.Linq.Expressions;

namespace MyProject.API.Repository.IRepository
{
    public interface ITokenRepository : IRepository<RefreshToken>
    {
        Task ExecuteUpdateAsync(Expression<Func<RefreshToken, bool>> filter,
           Expression<Func<SetPropertyCalls<RefreshToken>, SetPropertyCalls<RefreshToken>>> setPropertyCalls);
    }
}
