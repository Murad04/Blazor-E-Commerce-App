using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore.Interface;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI.Interface;
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
        private readonly IShoppingCardStateStore shoppingCardStateStore;

        public AddProductToCardUseCase(IProductRepository productRepository, IShoppingCard shoppingCard,IShoppingCardStateStore shoppingCardStateStore)
        {
            this.productRepository = productRepository;
            this.shoppingCard = shoppingCard;
            this.shoppingCardStateStore = shoppingCardStateStore;
        }

        public void Execute(int productID)
        {
            var product = productRepository.GetProduct(productID);
            shoppingCard.AddProductAsync(product);

            shoppingCardStateStore.UpdateLineItemsCount();
        }
    }
}
