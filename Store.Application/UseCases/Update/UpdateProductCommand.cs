using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Application.Commands.Interfaces;

namespace Store.Application.Commands
{
    public class UpdateProductCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(Id, "Id", "Id is mandadory")
            .IsNotNullOrEmpty(Title, "Title", "Title is mandatory")

            );
        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}