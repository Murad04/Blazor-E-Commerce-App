namespace Blazor_E_Commerce.CoreBusiness.Models
{
    public class OrderLineItem
    {
        public int? ID { get; set; }
        public int ProductID { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int? OrderID { get; set; }
        public Product Product { get; set; } = null!;
    }
}