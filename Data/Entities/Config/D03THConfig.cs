using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.API.Data.Entities.Config
{
    public class D03THConfig : IEntityTypeConfiguration<D03TH>
    {
        public void Configure(EntityTypeBuilder<D03TH> builder)
        {
            builder.HasKey(x => new {x.D03TId, x.M01CId});
        }
    }
}
