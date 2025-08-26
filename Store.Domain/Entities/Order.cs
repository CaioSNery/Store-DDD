

using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity

    {
        public Order(Guid customerId, decimal deliveryFee, Discount discount)
        {

            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(customerId, "Customer", "Cliente inválido")
            );
            CustomerId = customerId;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
            Discount = discount;
            Items = new List<OrderItem>();
        }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Discount Discount { get; private set; }

        protected Order() { }


        public void AddItem(Product product, int quantity)
        {

            var item = new OrderItem(product, quantity);
            if (item.IsValid)
                Items.Add(item);

        }

        public decimal Total()
        {
            decimal total = 0;
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    total += item.Total();
                }
            }
            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;
            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0)
                return;

            if (amount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {

            Status = EOrderStatus.Canceled;
        }

        public void Ship()
        {
            if (Status != EOrderStatus.WaitingDelivery)
                throw new InvalidOperationException("O pedido não pode ser enviado antes do pagamento.");

            Status = EOrderStatus.Shipped;
        }



    }
}