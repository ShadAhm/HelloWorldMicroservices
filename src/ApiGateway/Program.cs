using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Combine("Configuration", "ocelotconfig.json"));
builder.Services.AddOcelot();

var corsPolicyName = "_allowHelloWorldWeb";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7183");
                      });
});

var app = builder.Build();

app.UseCors(corsPolicyName);
app.UseOcelot();
app.UseHttpsRedirection();

app.MapGet("/health", () => "healthy");

app.Run();
