namespace MyProject.API.Data.Entities
{
    public class K02T : BaseEntity
    {
        public int Seq { get; set; }
        public Guid M01CId { get; set; }
        public string Url { get; set; }

        public M01C M01C { get; set; }

    }
}
