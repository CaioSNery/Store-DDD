using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Application.Dtos;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>,
    IHandler<DeleteOrderCommand>
    {
        private readonly ICustomerRepository _customerrepositoty;
        private readonly IDeliveryFeeRepository _deliveryfeerepositoty;
        private readonly IDiscountRepository _discountrepositoty;
        private readonly IOrderRepository _orderrepositoty;
        private readonly IProductRepository _productrepositoty;

        public OrderHandler(ICustomerRepository customerrepositoty,
        IDeliveryFeeRepository deliveryfeerepositoty,
        IDiscountRepository discountrepositoty,
        IOrderRepository orderrepositoty,
        IProductRepository productrepositoty)
        {
            _customerrepositoty = customerrepositoty;
            _deliveryfeerepositoty = deliveryfeerepositoty;
            _discountrepositoty = discountrepositoty;
            _orderrepositoty = orderrepositoty;
            _productrepositoty = productrepositoty;
        }

        public async Task<ICommandResult> Handle(CreateOrderCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Order", command.Notifications);

            var customer = await _customerrepositoty.GetByIdAsync(command.Customer);
            if (customer == null)
                return new GenericCommandResult(false, "Customer not found", null);


            var deliveryfee = await _deliveryfeerepositoty.Get(command.ZipCode);

            var discount = await _discountrepositoty.Get(command.PromoCode);

            var products = await _productrepositoty.GetAsync(ExtractGuids.Extract(command.Items));
            var productlist = products.ToList();

            var order = new Order(customer.Id, deliveryfee, discount);



            foreach (var item in command.Items)
            {
                var product = productlist.FirstOrDefault(x => x.Id == item.Product);
                if (product == null)
                    return new GenericCommandResult(false, "Invalid Product", command.Notifications);
                order.AddItem(product, item.Quantity);
            }

            AddNotifications(order.Notifications);

            if (command.Invalid)
                return new GenericCommandResult(false, "Order Fail", Notifications);

            await _orderrepositoty.SaveAsync(order);

            var dto = new OrderDto
            {
                Id = order.Id,
                Number = order.Number,
                CustomerName = customer.Name,

            };
            return new GenericCommandResult(true, $"Order {order.Number} is Sucess", dto);
        }

        public async Task<ICommandResult> Handle(DeleteOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Id", command.Notifications);

            var order = await _orderrepositoty.GetByIdAsync(command.Id);
            if (order == null)
                return new GenericCommandResult(false, "Not Found", command.Notifications);

            await _orderrepositoty.DeleteAsync(order);
            return new GenericCommandResult(true, "Deleted sucessfully", null);


        }


    }
}