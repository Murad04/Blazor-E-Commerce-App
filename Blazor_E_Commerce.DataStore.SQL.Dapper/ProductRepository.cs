using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers.Interface;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;

namespace Blazor_E_Commerce.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Product GetProduct(int id)
        {
            return dataAccess.QuerySingle<Product, dynamic>("SELECT *FROM Product WHERE ProductID=@ProductId", new { ProductId = id });
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            List<Product> list;
            if (string.IsNullOrWhiteSpace(filter))
                list = dataAccess.Query<Product, dynamic>("SELECT *FROM Product", new { });
            else
                list = dataAccess.Query<Product, dynamic>("SELECT *FROM Product WHERE ProductName like '%'+@Filter+'%'", new { Filter = filter });
            return list.AsEnumerable();
        }
    }
}
