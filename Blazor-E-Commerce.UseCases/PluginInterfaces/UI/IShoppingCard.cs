using Blazor_E_Commerce.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.PluginInterfaces.UI
{
    public interface IShoppingCard
    {
        Task<Order> GetOrderAsync();
        Task<Order> AddProductAsync(Product product);
        Task<Order> UpdateQuantityAsync(int productID, int quantity);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteProductAsync(int productID);
        Task<Order> PlaceOrderAsync();
        Task EmpytAsync();
    }
}
