using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Application.Commands.Interfaces;

namespace Store.Application.Commands
{
    public class UpdateCustomerCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Name, "Name", "Name is mandatory!")
            .IsEmail(Email, "Email", "Invalid Email")
            );


        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }

}