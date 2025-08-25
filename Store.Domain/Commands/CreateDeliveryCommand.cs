using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CreateDeliveryCommand : Notifiable<Notification>, ICommand
    {
        public CreateDeliveryCommand()
        {
            Order = new List<CreateOrderCommand>();
        }
        public CreateDeliveryCommand(Guid orderId, IList<CreateOrderCommand> order, bool payment)
        {
            OrderId = orderId;
            Order = order;
            Payment = payment;
        }

        public Guid OrderId { get; set; }
        public IList<CreateOrderCommand> Order { get; set; }
        public bool Payment { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(OrderId == Guid.Empty, "OrderId", "Order Id is mandatory"))
            ;

        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}