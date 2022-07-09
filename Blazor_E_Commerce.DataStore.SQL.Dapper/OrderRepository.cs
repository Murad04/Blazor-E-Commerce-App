using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.DataStore.SQL.Dapper
{
    public class OrderRepository
    {
        private readonly IDataAccess dataAccess;

        public OrderRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public int CreateOrder(Order order)
        {
            var sql =
                @"INSERT INTO [dbo].[Order]
                        ([DatePlaced],[DateProcessing],
                         [DateProcessed],[CustomerName],
                         [CustomerAddress],[CustomerCity],
                         [CustomerStateProvince],[CustomerCountrey],
                         [AdminUser],[UniqID])
                OUTPUT INSERTED.OrderID
                VALUES
                         (@DatePlaced,
                          @DateProcessing,
                          @DateProcessed,
                          @CustomerName,
                          @CustomerAddress,
                          @CustomerCity,
                          @CustomerStateProvince,       
                          @CustomerCountry,
                          @AdminUser,
                          @UniqID)";

            var orderID = dataAccess.QuerySingle<int, Order>(sql, order);

            sql =
                @"INSERT INTO [dbo].[OrderLineItem]
                              ([ProductID],
                               [OrderID],
                               [Quantity],
                               [Price])
                VALUES
                               (@ProductID,
                                @OrderID,
                                @Quantity,
                                @Price)";

            order.LineItems.ForEach(item => item.OrderID = orderID);
            dataAccess.ExecuteCommand(sql, order.LineItems);

            return orderID;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderID(int orderID)
        {
            var sql = "SELECT *FROM OrderLineItems WHERE OrderID=@OrderID";
            var lineitems = dataAccess.Query<OrderLineItem, dynamic>(sql, new { OrderID = orderID });

            sql = "SELECT *FROM Product WHERE ProductID==@ProductID";
            lineitems.ForEach(item => item.Product = dataAccess.QuerySingle<Product, dynamic>(sql, new { ProductId = item.ProductID }));

            return lineitems;
        }

        public Order GetOrder(int id)
        {
            var sql = "SELECT * FROM [ORDER] WHERE OrderId = @OrderId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sql, new { OrderId = id });
            order.LineItems = GetLineItemsByOrderID(order.OrderID.Value).ToList();

            return order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            var sql = "SELECT * FROM [ORDER] WHERE UniqueId = @UniqueId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sql, new { UniqueId = uniqueId });
            order.LineItems = GetLineItemsByOrderID(order.OrderID.Value).ToList();

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return dataAccess.Query<Order, dynamic>("SELECT * FROM [ORDER]", new { });
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var sql = "SELECT * FROM [ORDER] WHERE DateProcessed is null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var sql = "SELECT * FROM [ORDER] WHERE DateProcessed is not null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public void UpdateOrder(Order order)
        {
            // update order
            var sql = @"UPDATE [Order]
                          SET [DatePlaced] = @DatePlaced
                          ,[DateProcessing] = @DateProcessing
                          ,[DateProcessed] = @DateProcessed
                          ,[CustomerName] = @CustomerName
                          ,[CustomerAddress] = @CustomerAddress
                          ,[CustomerCity] = @CustomerCity
                          ,[CustomerStateProvince] = @CustomerStateProvince
                          ,[CustomerCountry] = @CustomerCountry
                          ,[AdminUser] = @AdminUser
                          ,[UniqID] = @UniqID
                      WHERE OrderID = @OrderID";

            dataAccess.ExecuteCommand<Order>(sql, order);

            // update line items
            sql = @"UPDATE [OrderLineItem]
                       SET [ProductID] = @ProductId
                          ,[OrderID] = @OrderId
                          ,[Quantity] = @Quantity
                          ,[Price] = @Price
                     WHERE ID = @ID";

            dataAccess.ExecuteCommand<List<OrderLineItem>>(sql, order.LineItems);
        }
    }
}

