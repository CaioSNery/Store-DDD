using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;

public class OrderCancellationService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrderCancellationService> _logger;
    private readonly IWebHostEnvironment _env;

    public OrderCancellationService(
        IServiceProvider serviceProvider,
        ILogger<OrderCancellationService> logger,
        IWebHostEnvironment env)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _env = env;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Não roda no ambiente de desenvolvimento
        if (_env.IsDevelopment())
        {
            _logger.LogInformation("OrderCancellationService desativado no ambiente de desenvolvimento.");
            return;
        }

        _logger.LogInformation("OrderCancellationService iniciado.");

        // Aguarda alguns segundos para garantir que a aplicação esteja pronta
        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                var orders = await orderRepository.GetWaitingPaymentOlderThanAsync(TimeSpan.FromHours(24));

                foreach (var order in orders)
                {
                    try
                    {
                        order.Cancel();
                        await orderRepository.SaveAsync(order);
                        _logger.LogInformation($"Pedido {order.Id} cancelado por timeout.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Erro ao cancelar pedido {order.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar cancelamentos automáticos.");
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}

