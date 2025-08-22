using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Infra.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly StoreDbContext _context;

        public DiscountRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Discount> Get(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            return await _context.Discounts
                .FirstOrDefaultAsync(x => x.Code == code && x.ExpireDate == DateTime.Now);
        }
    }
}