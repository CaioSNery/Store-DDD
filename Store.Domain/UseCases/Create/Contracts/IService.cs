using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.UseCases.Create.Contracts
{
    public interface IService
    {
        Task SendEmailAsync(User user, CancellationToken cancellationToken);
    }
}