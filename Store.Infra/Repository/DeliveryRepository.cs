using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;
using Store.Infra.Context;

namespace Store.Infra.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly StoreDbContext _context;

        public DeliveryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync(int skip = 0, int take = 25)
        {
            return await _context.Deliveries
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .Include(x => x.Order)
            .ToListAsync();
        }

        public async Task<Delivery> GetByIdAsync(Guid id)
        {
            return await _context.Deliveries
            .AsNoTracking()
            .Include(x => x.Order)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Delivery delivery)
        {
            await _context.AddAsync(delivery);
            await _context.SaveChangesAsync();
        }
    }
}