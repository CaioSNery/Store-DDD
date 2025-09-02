using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.UseCases.Create.Contracts;
using Store.Infra.Context;

namespace Store.Infra.UseCases.Create
{
    public class Repository : IRepository
    {
        private readonly StoreDbContext _context;

        public Repository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().AnyAsync(u => u.Email.Address == email, cancellationToken: cancellationToken);
        }
    }
}