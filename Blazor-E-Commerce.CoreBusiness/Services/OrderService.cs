using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.CoreBusiness.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.CoreBusiness.Services
{
    public class OrderService : IOrderService
    {
        #region ValidateCustomerInformation
        public bool ValidateCustomerInformation(string name, string address, string city, string province, string country)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(province) ||
                string.IsNullOrWhiteSpace(country))
                return false;

            return true;
        }
        #endregion ValidateCustomerInformation

        #region ValidateOrderCreation
        public bool ValidateCreateOrder(Order order)
        {
            //order must not be null
            if (order == null) return false;

            //order must have order line items
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            //validating the line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductID <= 0 ||
                    item.ProductPrice < 0 ||
                    item.Quantity < 0) return false;
            }

            //validate customer info
            if (!ValidateCustomerInformation(order.CustomerName, order.CustomerAddress, order.CustomerCity, order.CustomerStateProvince, order.CustomerCountry)) return false;

            return true;
        }
        #endregion ValidateOrderCreation

        #region ValidateUpdateOrder
        public bool ValidateUpdateOrder(Order order)
        {
            //order must be exist
            if (order is null) return false;
            if (!order.OrderID.HasValue) return false;

            //order must have order line items
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            //placed date must be valid
            if (!order.DatePlaced.HasValue) return false;

            //other dates 
            if (order.DateProcessed.HasValue || order.DateProcessing.HasValue) return false;

            //validate UniqID
            if (string.IsNullOrWhiteSpace(order.UniqID)) return false;

            //validating line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductID <= 0 ||
                    item.ProductPrice < 0 ||
                    item.OrderID == order.OrderID) return false;
            }

            //validate customer info
            if (!ValidateCustomerInformation(order.CustomerName, order.CustomerAddress, order.CustomerCity, order.CustomerStateProvince, order.CustomerCountry)) return false;

            return true;
        }
        #endregion ValidateUpdateOrder

        #region ValidateProccessOrder
        public bool ValidateProccessOrder(Order order)
        {
            if (!order.DateProcessed.HasValue ||
                string.IsNullOrWhiteSpace(order.AdminUser)) return false;

            return true;
        }
        #endregion ValidateProccessOrder
    }
}
