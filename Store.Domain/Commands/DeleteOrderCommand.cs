using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;


namespace Store.Domain.Commands
{
    public class DeleteOrderCommand : Notifiable<Notification>, ICommand
    {

        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(Id, "Id", "Id is mandatory")
            .IsTrue(Id != Guid.Empty, "Id", "Id cannot be empty")
            );
        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }
}