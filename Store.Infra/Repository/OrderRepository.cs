using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }


    }
}