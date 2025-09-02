using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Enums;
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
            var exists = await _context.Orders.AnyAsync(o => o.Id == order.Id);

            if (exists)
                _context.Update(order);
            else
                await _context.AddAsync(order);

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

        public async Task<IEnumerable<Order>> GetAllAsync(int skip = 0, int take = 25)
        {
            return await _context.Orders.AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetWaitingPaymentOlderThanAsync(TimeSpan timeSpan)
        {
            var limit = DateTime.Now.Subtract(timeSpan);
            return await _context.Orders
            .Where(o => o.Status == EOrderStatus.WaitingPayment && o.Date < limit)
            .ToListAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}