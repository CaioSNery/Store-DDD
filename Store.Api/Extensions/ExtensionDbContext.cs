using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Infra.Context;

namespace Store.Api.Extensions
{
    public static class ExtensionDbContext
    {
        public static void AddDbContextExtensions(this IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("Default")));
        }
    }
}