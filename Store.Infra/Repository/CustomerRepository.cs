using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Api.Repository
{
    public class CustomerRepository : ICustomerRepository

    {
        private readonly StoreDbContext _context;

        public CustomerRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);

        }

        public async Task SaveAsync(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}