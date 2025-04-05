namespace MyProject.API.Data.Entities
{
    /// <summary>
    /// Master category
    /// </summary>
    public class B03T : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<M01C> M01C { get; set; }
    }
}
