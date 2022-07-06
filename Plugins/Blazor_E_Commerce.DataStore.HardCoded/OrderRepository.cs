using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.OrderID = orders.Count + 1;
            orders.Add(order.OrderID.Value, order);
            return order.OrderID.Value;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderID(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int ID)
        {
            return orders[ID];
        }

        public Order GetOrderByUniqueID(string uniqueID)
        {
            foreach (var order in orders)
            {
                if (order.Value.UniqID == uniqueID) return order.Value;
            }
            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(order => order.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(order => order.DateProcessed.HasValue);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderID.HasValue) return;

            var ord = orders[order.OrderID.Value];
            if(ord==null) return;

            orders[order.OrderID.Value] = order;
        }
    }
}
