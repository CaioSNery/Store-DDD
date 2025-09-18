    
using Store.Api.Repository;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;
using Store.Application.UseCases.Create.Contracts;
using Store.Infra.Repository;
using Store.Infra.UseCases.Create;

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



            //Jwt Configutations
            //Create
            services.AddScoped<IRepository, Infra.UseCases.Create.Repository>();
            services.AddScoped<IService, Service>();
            //Authenticate
            services.AddScoped<Application.UseCases.Authenticate.Contracts.IRepository, Infra.UseCases.Authenticate.Repository>();


        }
    }
}