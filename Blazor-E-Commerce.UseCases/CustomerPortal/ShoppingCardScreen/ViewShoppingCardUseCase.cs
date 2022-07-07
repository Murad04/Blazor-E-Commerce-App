using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI.Interface;
using Blazor_E_Commerce.UseCases.ShoppingCardScreen.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.ShoppingCardScreen
{
    public class ViewShoppingCardUseCase : IViewShoppingCardUseCase
    {
        private readonly IShoppingCard shoppingCard;

        public ViewShoppingCardUseCase(IShoppingCard shoppingCard)
        {
            this.shoppingCard = shoppingCard;
        }

        public Task<Order> Execute()
        {
            return shoppingCard.GetOrderAsync();
        }
    }
}
