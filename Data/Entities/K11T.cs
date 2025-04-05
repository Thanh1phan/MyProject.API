namespace MyProject.API.Data.Entities
{
    public class K11T : BaseEntity
    {
        public Guid M01CId { get; set; }
        public decimal ZOBAIKA { get; set; }
        public decimal ZIBAIKA { get; set; }

        public M01C M01C { get; set; }
    }
}
