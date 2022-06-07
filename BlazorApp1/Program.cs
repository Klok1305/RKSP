using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;
using BlazorApp1.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IAuthorProvider, AuthorsProvider>();
builder.Services.AddScoped<IBookProvider, BooksProvider>();
builder.Services.AddScoped<IOrderProvider, OrdersProvider>();
builder.Services.AddScoped<IShopProvider, ShopsProvider>();
builder.Services.AddScoped<IUserProvider, UsersProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
