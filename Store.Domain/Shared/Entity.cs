using System;
using System.Linq;
using Flunt.Notifications;

namespace Store.Domain.Entities
{
    public class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();

        }

        public bool Invalid => Notifications.Any();
        public bool Valid => !Invalid;

        public Guid Id { get; private set; }
    }
}