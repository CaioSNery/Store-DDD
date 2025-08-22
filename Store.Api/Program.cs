using Microsoft.EntityFrameworkCore;
using Store.Api.Repository;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Handlers.Interfaces;
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
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDeliveryFeeRepository, DeliveryFeeRespository>();



builder.Services.AddScoped<IHandler<CreateProductCommand>, ProductHandler>();
builder.Services.AddScoped<IHandler<DeleteProductCommand>, ProductHandler>();
builder.Services.AddScoped<IHandler<UpdateProductCommand>, ProductHandler>();


builder.Services.AddScoped<IHandler<CreateCustomerCommand>, CustomerHandler>();
builder.Services.AddScoped<IHandler<DeleteCustomerCommand>, CustomerHandler>();
builder.Services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerHandler>();

builder.Services.AddScoped<IHandler<CreateOrderCommand>, OrderHandler>();
builder.Services.AddScoped<IHandler<DeleteOrderCommand>, OrderHandler>();





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

