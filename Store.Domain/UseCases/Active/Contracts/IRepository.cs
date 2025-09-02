using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.UseCases.Active.Contracts
{
    public interface IRepository
    {
        Task<bool> IsActiveAsync(string email, string code);

        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

        Task UpdateUserAsync(User user, CancellationToken cancellationToken);
    }
}