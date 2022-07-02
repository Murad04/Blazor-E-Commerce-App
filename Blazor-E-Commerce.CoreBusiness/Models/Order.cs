using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.CoreBusiness.Models
{
    public class Order
    {
        public Order()
        {
            LineItems = new List<OrderLineItem>();
        }

        public int? OrderID { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessing { get; set; }
        public DateTime? DateProcessed { get; set; }   
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerStateProvince { get; set; }
        public string? CustomerCountry { get; set; }
        public string? AdminUser { get; set; }
        public List<OrderLineItem> LineItems { get; set; }
        public string? UniqID { get; set; }

        #region Insertion and removing processes for Products
        public void AddProduct(int productID, int quantity, double price)
        {
            var item = LineItems.FirstOrDefault(product => product.ProductID == productID);
            if(item is not null)
                item.Quantity += quantity;
            else
                LineItems.Add(new OrderLineItem { ProductID=productID,Quantity=quantity,ProductPrice=price,OrderID=item.OrderID});
        }

        public void RemoveProduct(int productID)
        {
            var item = LineItems.FirstOrDefault(product => product.ProductID == productID);
            if (item is not null) LineItems.Remove(item); 
        }
        #endregion Insertion and removing processes for Products
    }
}
