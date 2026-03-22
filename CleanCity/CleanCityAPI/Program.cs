using CleanCity.Application.Contract;
using CleanCity.Application.Service;
using CleanCity.Domain.Repository;
using CleanCity.Infrastructure.Context;
using CleanCity.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CleanCityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<IC_RouteRepository, C_routeRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();

// Registrar servicios
builder.Services.AddScoped<IOperatorService, OperatorService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();