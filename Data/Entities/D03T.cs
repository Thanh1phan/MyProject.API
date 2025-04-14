using MyProject.API.Commom;

namespace MyProject.API.Data.Entities
{
    public class D03T : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public CConstant.Status Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
