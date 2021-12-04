using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Combine("Configuration", "ocelotconfig.json"));
builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot();
app.UseHttpsRedirection();

app.MapGet("/health", () => "healthy");

app.Run();
