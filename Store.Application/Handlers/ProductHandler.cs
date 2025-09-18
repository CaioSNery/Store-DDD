

using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Application.Commands;
using Store.Application.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Application.Handlers.Interfaces;
using Store.Domain.Repositories;
namespace Store.Application.Handlers
{
    public class ProductHandler : Notifiable<Notification>, IHandler<CreateProductCommand>,
    IHandler<DeleteProductCommand>, IHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Product", command.Notifications);

            var product = new Product(command.Title, command.Price, command.Active);

            await _repository.SaveAsync(product);

            return new GenericCommandResult(true, "Product created", product);
        }

        public async Task<ICommandResult> Handle(DeleteProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Product", command.Notifications);

            var product = await _repository.GetByIdAsync(command.Id);
            if (product == null)
                return new GenericCommandResult(false, "Not Found", null);

            await _repository.DeleteAsync(product);
            return new GenericCommandResult(true, "Product deleted", product);

        }

        public async Task<ICommandResult> Handle(UpdateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Product Invalid", command.Notifications);

            var product = await _repository.GetByIdAsync(command.Id);
            if (product == null)
                return new GenericCommandResult(false, "Not Found", null);

            product.Update(command.Title, command.Price, command.Active);

            await _repository.UpdateAsync(product);
            return new GenericCommandResult(true, "Update Product", product);
        }
    }
}