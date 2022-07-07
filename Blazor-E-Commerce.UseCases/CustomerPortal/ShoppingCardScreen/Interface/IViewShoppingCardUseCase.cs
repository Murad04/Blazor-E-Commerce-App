using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.ShoppingCardScreen.Interface
{
    public interface IViewShoppingCardUseCase
    {
        Task<Order> Execute();
    }
}