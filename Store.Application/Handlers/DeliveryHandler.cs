using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;

namespace Store.Application.Handlers
{
    public class DeliveryHandler : Notifiable<Notification>, IHandler<CreateDeliveryCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryHandler(IOrderRepository orderRepository, IDeliveryRepository deliveryRepository)
        {
            _orderRepository = orderRepository;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<ICommandResult> Handle(CreateDeliveryCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Delivery", command.Notifications);

            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order == null)
                return new GenericCommandResult(false, "Order Not Found", null);

            var delivery = new Delivery(order.Id, order, command.Payment);

            await _deliveryRepository.SaveAsync(delivery);

            await _orderRepository.SaveAsync(order);

            return new GenericCommandResult(true, "Delivery Created", delivery);

        }

    }
}