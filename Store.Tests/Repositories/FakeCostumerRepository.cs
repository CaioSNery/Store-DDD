using Store.Domain.Entities;
using Store.Domain.Repositories;


namespace Store.Tests.Repositories
{
    public class FakeCostumerRepository : ICustomerRepository
    {
        public Task DeleteAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Caio Nery", "caio@caio.com");
            return null;
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}