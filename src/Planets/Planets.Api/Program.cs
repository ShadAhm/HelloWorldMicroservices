using MediatR;
using Microsoft.EntityFrameworkCore;
using Planets.Application;
using Planets.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IPlanetsContext, PlanetsContext>(options => options.UseInMemoryDatabase(databaseName: "Planets"));
builder.Services.AddMediatR(typeof(Program), typeof(ApplicationInfo));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
