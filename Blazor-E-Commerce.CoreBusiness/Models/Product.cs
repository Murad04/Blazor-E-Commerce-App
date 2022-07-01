using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.CoreBusiness.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ImageLink { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
