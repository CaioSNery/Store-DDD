using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task SaveAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Customer customer);

        Task<Customer> GetByIdAsync(Guid id);

    }
}