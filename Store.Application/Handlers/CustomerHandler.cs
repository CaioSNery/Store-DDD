using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Flunt.Notifications;
using Store.Application.Commands.Interfaces;
using Store.Application.Handlers.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Application.Commands;

namespace Store.Application.Handlers
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

             var customer = Customer.Create(command.FirstName, command.LastName, command.Email, command.Address, command.Cpf);

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

            customer.Update(command.FirstName, command.LastName, command.Email, command.Address, command.Cpf);
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