using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.ViewProductScreen.Interfaces
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}