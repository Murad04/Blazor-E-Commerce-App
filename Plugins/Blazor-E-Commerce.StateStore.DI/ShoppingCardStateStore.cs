using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.StateStore.DI
{
    public class ShoppingCardStateStore : StateStoreBase, IShoppingCardStateStore
    {
        private readonly IShoppingCard shoppingCard;

        public ShoppingCardStateStore(IShoppingCard shoppingCard)
        {
            this.shoppingCard = shoppingCard;
        }

        public async Task<int> GetItemsCount()
        {
            var order = await shoppingCard.GetOrderAsync();
            if (order != null && order.LineItems != null && order.LineItems.Count > 0)
                return order.LineItems.Count;
            return 0;
        }

        public void UpdateLineItemsCount()
        {
            base.BroadCastStateChange();
        }

        public void UpdateProductQuantity()
        {
            base.BroadCastStateChange();
        }
    }
}
