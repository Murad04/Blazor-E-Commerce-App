using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.CoreBusiness.Services;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
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
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly OrderService orderService;
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCard shoppingCard;
        private readonly IShoppingCardStateStore shoppingCardStateStore;

        public PlaceOrderUseCase(OrderService orderService, IOrderRepository orderRepository, IShoppingCard shoppingCard, IShoppingCardStateStore shoppingCardStateStore)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCard = shoppingCard;
            this.shoppingCardStateStore = shoppingCardStateStore;
        }

        public async Task<string> Execute(Order order)
        {
            if (orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqID = Guid.NewGuid().ToString();
                orderRepository.CreateOrder(order);

                await shoppingCard.EmpytAsync();
                shoppingCardStateStore.UpdateLineItemsCount();

                return order.UniqID;
            }
            return null;
        }
    }
}
