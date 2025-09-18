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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Cpf { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "FirstName", "FirstName is mandatory!")
            .IsNotNullOrEmpty(LastName, "LastName", "LastName is mandatory!")
            .IsEmail(Email, "Email", "Invalid Email")
            );


        }

        public bool Valid => !Notifications.Any();
        public bool Invalid => Notifications.Any();
    }

}