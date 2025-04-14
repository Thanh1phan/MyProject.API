using Microsoft.EntityFrameworkCore;
using MyProject.API.Data.Entities;
using MyProject.API.Data.Entities.Config;
using System.Reflection.Metadata;

namespace MyProject.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Add entities
        public DbSet<M01C> M01C { get; set; }
        public DbSet<K01T> K01T { get; set; }
        public DbSet<B03T> B03T { get; set; }
        public DbSet<K11T> K11T { get; set; }
        public DbSet<K02T> K02T { get; set; }
        public DbSet<M02T> M02T { get; set; }

        public DbSet<K03T> K03T { get; set; }
        public DbSet<D03T> D03T { get; set; }
        public DbSet<D03TH> D03TH { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new M01CConfig());
            modelBuilder.ApplyConfiguration(new K01TConfig());
            modelBuilder.ApplyConfiguration(new K02TConfig());
            modelBuilder.ApplyConfiguration(new K11TConfig());
            modelBuilder.ApplyConfiguration(new B03TConfig());

            modelBuilder.ApplyConfiguration(new D03THConfig());
        }
    }
}
