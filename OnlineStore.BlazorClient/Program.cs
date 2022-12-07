using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineStore.ApiClient;
using OnlineStore.ApiClient.Fake;
using OnlineStore.BlazorClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IShopClient>(new ShopClient("http://localhost:5008"));
//builder.Services.AddSingleton<IShopClient> (new ShopClientFake(TimeSpan.FromSeconds(20)));
await builder.Build().RunAsync();
