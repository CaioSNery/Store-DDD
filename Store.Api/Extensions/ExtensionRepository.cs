using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Repository;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;
using Store.Infra.Repository;

namespace Store.Api.Extensions
{
    public static class ExtensionRepository
    {
        public static void AddRepositoriesExtensions(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IDeliveryFeeRepository, DeliveryFeeRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        }
    }
}