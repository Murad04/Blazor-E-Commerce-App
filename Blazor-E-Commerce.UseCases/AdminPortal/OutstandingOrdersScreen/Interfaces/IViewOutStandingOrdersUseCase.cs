using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces
{
    public interface IViewOutStandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}