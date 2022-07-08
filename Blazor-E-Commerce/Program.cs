using Blazor_E_Commerce.CoreBusiness.Services;
using Blazor_E_Commerce.CoreBusiness.Services.Interfaces;
using Blazor_E_Commerce.DataStore.HardCoded;
using Blazor_E_Commerce.ShoppingCard.LocalStorage;
using Blazor_E_Commerce.StateStore.DI;
using Blazor_E_Commerce.UseCases.AdminPortal.OrderDetailScreen;
using Blazor_E_Commerce.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using Blazor_E_Commerce.UseCases.AdminPortal.OutstandingOrdersScreen;
using Blazor_E_Commerce.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces;
using Blazor_E_Commerce.UseCases.AdminPortal.ProcessedOrdersScreen;
using Blazor_E_Commerce.UseCases.AdminPortal.ProcessedOrdersScreen.Interfaces;
using Blazor_E_Commerce.UseCases.OrderConfirmationScreen;
using Blazor_E_Commerce.UseCases.OrderConfirmationScreen.Interface;
using Blazor_E_Commerce.UseCases.PlaceOrderScreen;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore.Interface;
using Blazor_E_Commerce.UseCases.PluginInterfaces.UI.Interface;
using Blazor_E_Commerce.UseCases.SearchProductScreen;
using Blazor_E_Commerce.UseCases.SearchProductScreen.Interface;
using Blazor_E_Commerce.UseCases.ShoppingCardScreen;
using Blazor_E_Commerce.UseCases.ShoppingCardScreen.Interface;
using Blazor_E_Commerce.UseCases.ViewProductScreen;
using Blazor_E_Commerce.UseCases.ViewProductScreen.Interfaces;
using DataStoreHardCode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication("Blazor_E_Commerce.CookieAuth").AddCookie("Blazor_E_Commerce.CookieAuth", config =>
{
    config.Cookie.Name = "Blazor_E_Commerce.CookieAuth";
    config.LoginPath = "/authenticate";
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCard, ShoppingCard>();
builder.Services.AddScoped<IShoppingCardStateStore, ShoppingCardStateStore>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IAddProductToCardUseCase, AddProductToCardUseCase>();
builder.Services.AddTransient<IViewShoppingCardUseCase, ViewShoppingCardUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

builder.Services.AddTransient<IViewOutStandingOrdersUseCase, ViewOutStandingOrdersUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
