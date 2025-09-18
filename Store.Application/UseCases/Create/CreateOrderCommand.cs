

using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Application.Commands.Interfaces;

namespace Store.Application.Commands
{
    public class CreateOrderCommand : Notifiable<Notification>, ICommand
    {

        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(Guid customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }
        public Guid Customer { get; set; }

        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }





        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(Customer == Guid.Empty, "Customer", "Customer is mandatory")
            .IsNotNullOrEmpty(ZipCode, "ZipCode", "ZipCode is mandatory")

            );
        }
        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}