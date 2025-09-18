
using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Application.Commands.Interfaces;

namespace Store.Application.Commands;

public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderItemCommand() { }

    public CreateOrderItemCommand(Guid product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public Guid Product { get; set; }

    public int Quantity { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
        .Requires()
        .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade inválida")

        );
    }
}
