using HelloWorld.Web;
using HelloWorld.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IGreetingService, GreetingService>();
builder.Services.AddHttpClient<IPlanetService, PlanetService>();
builder.Services.AddTransient<IHelloWorldService, HelloWorldService>();

await builder.Build().RunAsync();
