using Microsoft.Identity.Client;

namespace MyProject.API.Data.Entities
{
    public class M02T
    {
        public Guid Id { get; set; }
        public Guid M01CID { get; set; }
        public int SEQ { get; set; }
        public int Count { get; set; }
        public decimal ZOBAIKA { get; set; }
        public decimal ZIBAIKA { get; set; }

        public M01C M01C { get; set; }
    }
}
