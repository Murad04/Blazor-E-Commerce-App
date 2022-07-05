using Blazor_E_Commerce.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore
{
    public interface IOrderRepository
    {
        Order GetOrder(int ID);
        Order GetOrderByUniqueID(string uniqueID);
        int CreateOrder(Order order);   
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOutstandingOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<OrderLineItem> GetLineItemsByOrderID(int orderID);
    }
}
