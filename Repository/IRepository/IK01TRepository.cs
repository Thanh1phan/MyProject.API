using Microsoft.EntityFrameworkCore.Query;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;
using System.Linq.Expressions;

namespace MyProject.API.Repository.IRepository
{
    public interface IK01TRepository : IRepository<K01T>
    {
        bool IsUniqueUser(string userName);
        
    }
}
