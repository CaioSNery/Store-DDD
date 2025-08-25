using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Delivery : Entity
    {
        public Delivery(Guid orderId, Order order, bool payment)
        {
            OrderId = orderId;
            Order = order;
            Payment = payment;

            if (Payment)
                Order.Pay(Order.Total());

        }
        protected Delivery() { }
        public Guid OrderId { get; set; }
        public Order Order { get; private set; }
        public bool Payment { get; set; }
    }
}