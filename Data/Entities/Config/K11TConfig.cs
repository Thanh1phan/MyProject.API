using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.API.Data.Entities.Config
{
    public class K11TConfig : IEntityTypeConfiguration<K11T>
    {
        public void Configure(EntityTypeBuilder<K11T> builder)
        {
            builder.HasKey(x => x.M01CId);
            builder.HasData(
                new K11T()
                {
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    ZIBAIKA = (decimal)(17000000 * 1.1),
                    ZOBAIKA = 17000000
                },
                new K11T()
                {
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    ZIBAIKA = (decimal)(33000000 * 1.1),
                    ZOBAIKA = 33000000
                }
                );
        }
    }
}
