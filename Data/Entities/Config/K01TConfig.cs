using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.API.Data.Entities;

namespace MyProject.API.Data.Entities.Config
{
    public class K01TConfig : IEntityTypeConfiguration<K01T>
    {
        public void Configure(EntityTypeBuilder<K01T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.Property(x => x.UserName).HasMaxLength(50);
        }
    }
}
