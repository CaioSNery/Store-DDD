using System.ComponentModel;
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

    public OrderCancellationService(IServiceProvider serviceProvider, ILogger<OrderCancellationService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OrderCancellationService iniciado.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();


                var orders = await orderRepository.GetWaitingPaymentOlderThanAsync(TimeSpan.FromHours(24));

                foreach (var order in orders)
                {
                    order.Cancel();
                    await orderRepository.SaveAsync(order);
                    _logger.LogInformation($"Pedido {order.Id} cancelado por timeout.");
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
