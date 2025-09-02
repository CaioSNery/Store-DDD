using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.UseCases.Active.Contracts;
using Store.Infra.Context;

namespace Store.Infra.UseCases.Active
{
    public class Repository : IRepository
    {
        private readonly StoreDbContext _context;

        public Repository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                 .Include(u => u.Email)
                 .ThenInclude(e => e.Verification)
                 .FirstOrDefaultAsync(u => u.Email.Address == email, cancellationToken);
        }

        public async Task<bool> IsActiveAsync(string email, string code)
        {
            var user = await _context.Users
                 .Include(u => u.Email)
                 .ThenInclude(e => e.Verification)
                 .FirstOrDefaultAsync(u => u.Email.Address == email);

            if (user == null)
                return false;

            return user.Email.Verification.Code == code;
        }

        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}