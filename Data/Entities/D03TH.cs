namespace MyProject.API.Data.Entities
{
    public class D03TH
    {
        public Guid D03TId { get; set; }
        public Guid M01CId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
