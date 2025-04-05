using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.API.Data.Entities.Config
{
    public class B03TConfig : IEntityTypeConfiguration<B03T>
    {
        public void Configure(EntityTypeBuilder<B03T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.M01C).WithOne(x => x.B03T).HasForeignKey(x => x.B3Id);

            builder.HasData(
                new B03T()
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "Canon",
                    CreateDate = new DateTime(2025, 03, 20, 0, 0, 0),
                    UpdateDate = new DateTime(2025, 03, 20, 0, 0, 0)
                },
                new B03T()
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Name = "Sony",
                    CreateDate = new DateTime(2025, 03, 20, 0, 0, 0),
                    UpdateDate = new DateTime(2025, 03, 20, 0, 0, 0)
                });
        }
    }
}
