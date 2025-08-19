using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Customer Get(string name)
        {
            return _context.Customers.FirstOrDefault(x => x.Name == name);
        }
    }
}