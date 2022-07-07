using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.OrderConfirmationScreen.Interface;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.OrderConfirmationScreen
{
    public class ViewOrderConfirmationUseCase : IViewOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrderConfirmationUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Execute(string uniqueID)
        {
            return orderRepository.GetOrderByUniqueID(uniqueID);
        }
    }
}
