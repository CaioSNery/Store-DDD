using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.UseCases.Authenticate.Contracts
{
    public interface IRepository
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}