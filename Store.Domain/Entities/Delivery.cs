using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Delivery : Entity
    {
        public Delivery(Guid orderId, bool payment)
        {
            OrderId = orderId;
            Payment = payment;

        }
        protected Delivery() { }
        public Guid OrderId { get; set; }
        public Order Order { get; private set; }
        public bool Payment { get; set; }
    }
}