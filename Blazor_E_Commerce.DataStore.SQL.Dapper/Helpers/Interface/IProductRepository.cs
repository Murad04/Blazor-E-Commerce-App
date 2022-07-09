using Blazor_E_Commerce.CoreBusiness.Models;

namespace Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers.Interface
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts(string filter);
    }
}