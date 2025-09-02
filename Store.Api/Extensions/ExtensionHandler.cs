using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Application.Handlers;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Handlers.Interfaces;

namespace Store.Api.Extensions
{
    public static class ExtensionHandler
    {
        public static void AddHandleExtensions(this IServiceCollection services)
        {
            // Implementation for handling extensions

            services.AddScoped<CustomerHandler>();
            services.AddScoped<OrderHandler>();
            services.AddScoped<ProductHandler>();
            services.AddScoped<DeliveryHandler>();

        }

        public static void AddIHandlerCommandExtensions(this IServiceCollection services)
        {
            // Implementation for handling IHandler commands

            services.AddScoped<IHandler<CreateDeliveryCommand>, DeliveryHandler>();

            services.AddScoped<IHandler<CreateProductCommand>, ProductHandler>();
            services.AddScoped<IHandler<DeleteProductCommand>, ProductHandler>();
            services.AddScoped<IHandler<UpdateProductCommand>, ProductHandler>();

            services.AddScoped<IHandler<CreateCustomerCommand>, CustomerHandler>();
            services.AddScoped<IHandler<DeleteCustomerCommand>, CustomerHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerHandler>();

            services.AddScoped<IHandler<CreateOrderCommand>, OrderHandler>();
            services.AddScoped<IHandler<DeleteOrderCommand>, OrderHandler>();
        }
    }
}