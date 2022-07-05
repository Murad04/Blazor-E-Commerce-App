using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore.Interface;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI.Interface;
using Blazor_E_Commerce.UseCases.ShoppingCardScreen.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.ShoppingCardScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCard card;
        private readonly IShoppingCardStateStore shoppingCardStateStore;

        public DeleteProductUseCase(IShoppingCard card, IShoppingCardStateStore shoppingCardStateStore)
        {
            this.card = card;
            this.shoppingCardStateStore = shoppingCardStateStore;
        }

        public async Task<Order> Execute(int productID)
        {
            var order = await this.card.DeleteProductAsync(productID);
            this.shoppingCardStateStore.UpdateLineItemsCount();

            return order;
        }
    }
}
