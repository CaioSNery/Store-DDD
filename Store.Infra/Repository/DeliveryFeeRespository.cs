using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Infra.Repository
{
    public class DeliveryFeeRespository : IDeliveryFeeRepository
    {
        private readonly StoreDbContext _context;

        public DeliveryFeeRespository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Get(string zipCode)
        {
            var fee = await _context.DeliveryFees
            .FirstOrDefaultAsync(x => x.ZipCode == zipCode);

            return fee?.Fee ?? 0m;
        }
    }
}