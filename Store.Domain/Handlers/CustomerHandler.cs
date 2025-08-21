using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
    public class CustomerHandler : Notifiable<Notification>, IHandler<CreateCustomerCommand>,
    IHandler<UpdateCustomerCommand>, IHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Customer", command.Notifications);

            var customer = new Customer(command.Name, command.Email);

            await _repository.SaveAsync(customer);

            return new GenericCommandResult(true, "Customer created sucessfully", customer);

        }

        public async Task<ICommandResult> Handle(UpdateCustomerCommand command)
        {
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Customer", command.Notifications);

            var customer = await _repository.GetByIdAsync(command.Id);
            if (customer == null)
                return new GenericCommandResult(false, "Not Found", null);

            customer.Update(command.Name, command.Email);
            await _repository.UpdateAsync(customer);
            return new GenericCommandResult(true, "Customer update sucessfully", customer);
        }

        public async Task<ICommandResult> Handle(DeleteCustomerCommand command)
        {
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid Customer", command.Notifications);

            var customer = await _repository.GetByIdAsync(command.Id);
            if (customer == null)
                return new GenericCommandResult(false, "Not Found", null);


            await _repository.DeleteAsync(customer);
            return new GenericCommandResult(true, "Deleted", customer);
        }
    }
}