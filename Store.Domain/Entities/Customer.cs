using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            Orders = new List<Order>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public List<Order> Orders { get; private set; }

        protected Customer() { }



        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}