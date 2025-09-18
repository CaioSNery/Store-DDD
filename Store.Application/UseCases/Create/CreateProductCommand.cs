using System;
using System.Diagnostics.Contracts;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Application.Commands.Interfaces;

namespace Store.Application.Commands
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand
    {

        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Title, "Title", "Invalid Title")
            .IsGreaterThan(Price, 0, "Price", "Invalid -Price < 0")

            );
        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}