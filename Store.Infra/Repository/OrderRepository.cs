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

        public async Task DeleteAsync(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
            .AsNoTracking()
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }




    }
}