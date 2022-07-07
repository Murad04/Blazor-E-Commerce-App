using Blazor_E_Commerce.CoreBusiness.Models;
using System.Collections.Generic;

namespace Blazor_E_Commerce.UseCases.SearchProductScreen.Interface
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}