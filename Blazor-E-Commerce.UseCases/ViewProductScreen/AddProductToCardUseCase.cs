using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI;
using Blazor_E_Commerce.UseCases.ViewProductScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.ViewProductScreen
{
    public class AddProductToCardUseCase : IAddProductToCardUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShoppingCard shoppingCard;

        public AddProductToCardUseCase(IProductRepository productRepository, IShoppingCard shoppingCard)
        {
            this.productRepository = productRepository;
            this.shoppingCard = shoppingCard;
        }

        public void Execute(int productID)
        {
            var product = productRepository.GetProduct(productID);
            shoppingCard.AddProductAsync(product);
        }
    }
}
