using MediatR;
using Planets.Application;
using Planets.Domain.Entities;
using Planets.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program), typeof(ApplicationInfo));

builder.Services.AddScoped<Planets.Persistence.Io.IDataAccessor, Planets.Persistence.Io.DataAccessor>();
builder.Services.AddScoped<IDataFile<Planet>, DataFile<Planet>>();

builder.Services.Configure<WebHostOptions>(o => o.RootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));

var corsPolicyName = "_allowHelloWorldApiGateway";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      o =>
                      {
                          o.WithOrigins(builder.Configuration["ApiGatewayBaseUrl"]);
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors(corsPolicyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
