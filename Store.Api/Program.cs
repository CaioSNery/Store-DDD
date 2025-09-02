using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Store.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Store API",
        Version = "v1"
    });

    // Usa o nome completo (namespace + classe) como schemaId
    c.CustomSchemaIds(type => type.FullName);
});


builder.Services.AddControllers();

builder.AddConfiguration();
builder.AddDbContext();
builder.AddJwtAuthentication();
builder.AddMediator();

builder.Services.AddRepositoriesExtensions();
builder.Services.AddHandleExtensions();
builder.Services.AddIHandlerCommandExtensions();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHostedService<OrderCancellationService>();
}



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryFast API v1");
    c.RoutePrefix = "swagger";
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();

