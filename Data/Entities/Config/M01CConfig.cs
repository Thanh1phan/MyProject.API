using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.API.Data.Entities;

namespace MyProject.API.Data.Entities.Config
{
    public class M01CConfig : IEntityTypeConfiguration<M01C>
    {
        public void Configure(EntityTypeBuilder<M01C> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60);
            builder.HasMany(x => x.K02T).WithOne(x => x.M01C).HasForeignKey(x => x.M01CId);
            builder.HasOne(x => x.K11T).WithOne(x => x.M01C);

            builder.HasData(
               new M01C()
               {
                   Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                   Name = "Canon EOS R6 Mark II Kit RF24-105mm F4 L IS USM",
                   B3Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                   CreateDate = new DateTime(2025, 03, 20, 0, 0, 0),
                   UpdateDate = new DateTime(2025, 03, 20, 0, 0, 0)
               },
               new M01C()
               {
                   Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                   Name = "Sony Alpha ILCE-6700 / A6700 Body",
                   B3Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                   CreateDate = new DateTime(2025, 03, 20, 0, 0, 0),
                   UpdateDate = new DateTime(2025, 03, 20, 0, 0, 0)
               });
        }
    }
}
