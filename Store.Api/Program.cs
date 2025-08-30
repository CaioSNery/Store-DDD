using Microsoft.EntityFrameworkCore;
using Store.Api.Extensions;
using Store.Api.Repository;
using Store.Application.Handlers;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;
using Store.Infra.Context;
using Store.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers();



builder.Services.AddDbContextExtensions();

builder.Services.AddRepositoriesExtensions();

builder.Services.AddHandleExtensions();





var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryFast API v1");
    c.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();


app.Run();

