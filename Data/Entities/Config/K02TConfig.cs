using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.API.Data.Entities.Config
{
    public class K02TConfig : IEntityTypeConfiguration<K02T>
    {
        public void Configure(EntityTypeBuilder<K02T> builder)
        {
            builder.HasKey(x => new {x.Seq, x.M01CId});
            builder.HasData(
                new K02T()
                {
                    Seq = 1,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/44d7d59b-297e-43fb-1ed7-c402c3fce500/storedata"
                },
                new K02T()
                {
                    Seq = 2,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/b9749b99-0ce3-42e3-c1ac-25cfb033b100/storedata"
                },
                new K02T()
                {
                    Seq = 3,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/ab09dca0-c22d-46df-a563-99fb11d08f00/storedata"
                },

                new K02T()
                {
                    Seq = 1,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Url = "https://kyma.vn/StoreData/images/Product/may-anh-sony-alpha-ilce6700-a6700-body.jpg"
                },
                new K02T()
                {
                    Seq = 2,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/1fb59980-67f3-49cb-4060-1eb1dc10f400/storedata"
                },
                new K02T()
                {
                    Seq = 3,
                    M01CId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/4e622b29-115b-4ab3-cf7c-9816f1d2fb00/storedata"
                }
                );
        }
    }
}
