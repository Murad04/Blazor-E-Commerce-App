using Blazor_E_Commerce.Data;
using Blazor_E_Commerce.UseCases.PluginInterfaces.DataStore;
using Blazor_E_Commerce.UseCases.SearchProductScreen;
using Blazor_E_Commerce.UseCases.ViewProductScreen;
using Blazor_E_Commerce.UseCases.ViewProductScreen.Interfaces;
using DataStoreHardCode;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
