using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models.Dto
{
    public class DetailProductDto
    {
        public Guid Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
        public Guid B3Id { get; set; }

        [DataType("decimal(15,0)")]
        public Decimal ZIBAIKA { get; set; }
        [DataType("decimal(15,0)")]
        public Decimal ZOBAIKA { get; set; }
        public IEnumerable<string> ListUrlImage { get; set; }
    }
}
