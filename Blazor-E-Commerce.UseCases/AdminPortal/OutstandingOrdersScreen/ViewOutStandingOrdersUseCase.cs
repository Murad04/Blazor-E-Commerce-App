using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutStandingOrdersUseCase : IViewOutStandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOutStandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutstandingOrders();
        }
    }
}
