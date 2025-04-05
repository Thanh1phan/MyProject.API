using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using MyProject.API.Data;
using MyProject.API.Data.Entities;
using MyProject.API.Models;
using MyProject.API.Models.Dto;
using MyProject.API.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace MyProject.API.Repository
{
    public class K01TRepository : Repositoty<K01T>, IK01TRepository
    {
        
        public K01TRepository(ApplicationDbContext db, IConfiguration configuration, IMapper mapper) : base(db)
        {

        }

        public bool IsUniqueUser(string userName)
        {
            var user = _db.K01T.FirstOrDefault(x => x.UserName == userName);

            if (user == null)
            {
                return true;
            }
            return false;
        }

        
    }
}
