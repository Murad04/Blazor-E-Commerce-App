using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.UseCases.ViewProductScreen
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}