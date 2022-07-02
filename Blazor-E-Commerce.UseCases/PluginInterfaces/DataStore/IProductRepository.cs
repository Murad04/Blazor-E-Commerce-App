using Blazor_E_Commerce.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore
{
    public interface IProductRepository
    {
        Product? GetProduct(int id);
        IEnumerable<Product> GetProducts(string filter = null);
    }
}
