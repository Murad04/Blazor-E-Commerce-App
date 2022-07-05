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
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCard card;
        private readonly IShoppingCardStateStore shoppingCardStateStore;

        public UpdateQuantityUseCase(IShoppingCard card, IShoppingCardStateStore shoppingCardStateStore)
        {
            this.card = card;
            this.shoppingCardStateStore = shoppingCardStateStore;
        }

        public async Task<Order> Execute(int quantity, int productID)
        {
            var order = await card.UpdateQuantityAsync(productID, quantity);
            shoppingCardStateStore.UpdateProductQuantity();

            return order;
        }
    }
}
