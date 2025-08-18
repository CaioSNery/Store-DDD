
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNull(product, "Product", "Produto inválido")
            .IsGreaterThan(quantity, 0, "Quantity", "A Quantidade precisa ser maior que 0")
            );
            Product = product;
            Price = product != null ? product.Price : 0;
            Quantity = quantity;

        }

        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Product Product { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}