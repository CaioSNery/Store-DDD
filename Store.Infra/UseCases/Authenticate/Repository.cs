using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Application.UseCases.Authenticate.Contracts;
using Store.Infra.Context;

namespace Store.Infra.UseCases.Authenticate
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
                .AsNoTracking()
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Email.Address == email, cancellationToken);
        }
    }
}