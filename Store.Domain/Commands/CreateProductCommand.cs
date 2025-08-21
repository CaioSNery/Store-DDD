using System;
using System.Diagnostics.Contracts;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand
    {

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }


        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Title, "Title", "Invalid Title")

            );
        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}