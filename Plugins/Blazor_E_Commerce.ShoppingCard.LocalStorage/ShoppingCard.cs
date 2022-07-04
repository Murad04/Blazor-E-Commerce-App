using Blazor_E_Commerce.CoreBusiness.Models;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.ShoppingCard.LocalStorage
{
    public class ShoppingCard : IShoppingCard
    {
        private const string cstrShoppingCart = "Blazor_E_Commerce.ShoppingCart";
        private readonly IJSRuntime jSRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCard(IJSRuntime jSRuntime, IProductRepository productRepository)
        {
            this.jSRuntime = jSRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductID, 1, product.ProductPrice);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productID)
        {
            var order = await GetOrder();
            order.RemoveProduct(productID);
            await SetOrder(order);

            return order;
        }

        public Task EmpytAsync()
        {
            return this.SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await this.SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productID, int quantity)
        {
            var order = await GetOrder();
            if (quantity < 0)
                return order;
            else if (quantity == 0)
                return await DeleteProductAsync(productID);

            var lineItem = order.LineItems.SingleOrDefault(item => item.ProductID == productID);
            if (lineItem is not null) lineItem.Quantity = quantity;
            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;
            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);

            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductID);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
