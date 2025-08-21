using Microsoft.EntityFrameworkCore;
using Store.Api.Repository;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Infra.Context;
using Store.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductHandler>();
builder.Services.AddScoped<CustomerHandler>();
builder.Services.AddScoped<OrderHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();





app.Run();

