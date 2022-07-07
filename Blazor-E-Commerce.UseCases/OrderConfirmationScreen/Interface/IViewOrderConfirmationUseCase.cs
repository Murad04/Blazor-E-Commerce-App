using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.OrderConfirmationScreen.Interface
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueID);
    }
}