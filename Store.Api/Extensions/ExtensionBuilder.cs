using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Domain;
using Store.Infra.Context;

namespace Store.Api.Extensions
{
    public static class ExtensionServices
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {

            Configuration.Database.ConnectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

            Configuration.Secrets.ApiKey = builder.Configuration
            .GetSection("Secrets")
            .GetValue<string>("ApiKey") ?? string.Empty;

            Configuration.Secrets.JwtPrivateKey = builder.Configuration
            .GetSection("Secrets")
            .GetValue<string>("JwtPrivateKey") ?? string.Empty;

            Configuration.Secrets.PasswordSaltKey = builder.Configuration
            .GetSection("Secrets")
            .GetValue<string>("PasswordSaltKey") ?? string.Empty;

            Configuration.SendGrid.ApiKey =
            builder.Configuration.GetSection("SendGrid")
            .GetValue<string>("ApiKey") ?? string.Empty;

            Configuration.Email.DefaultFromName = builder.Configuration
            .GetSection("Email")
            .GetValue<string>("DefaultFromName") ?? string.Empty;

            Configuration.Email.DefaultFromEmail = builder.Configuration
            .GetSection("Email")
            .GetValue<string>("DefaultFromEmail") ?? string.Empty;
        }

        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(Configuration.Database.ConnectionString));
        }

        public static void AddMediator(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
        }
    }
}