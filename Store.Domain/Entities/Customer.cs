using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = Email.Create(email);
            Orders = new List<Order>();
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }

        public List<Order> Orders { get; private set; }

        protected Customer() { }



        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}