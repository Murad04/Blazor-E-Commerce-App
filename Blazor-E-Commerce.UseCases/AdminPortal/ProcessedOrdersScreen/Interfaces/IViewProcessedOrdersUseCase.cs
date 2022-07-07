using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.AdminPortal.ProcessedOrdersScreen.Interfaces
{
    public interface IViewProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}