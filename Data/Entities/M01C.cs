namespace MyProject.API.Data.Entities
{
    /// <summary>
    /// Master product
    /// </summary>
    public class M01C : BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid B3Id { get; set; }

        public ICollection<K02T> K02T { get; set; }
        public K11T K11T { get; set; }
        public B03T B03T { get; set; }
        public M02T M02T { get; set; }
    }
}
