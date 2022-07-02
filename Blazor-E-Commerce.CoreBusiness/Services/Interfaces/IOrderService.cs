using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.CoreBusiness.Services.Interfaces
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInformation(string name, string address, string city, string province, string country);
        bool ValidateProccessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}