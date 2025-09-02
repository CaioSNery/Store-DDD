using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Store.Domain.UseCases.Create
{
    public record Request(string Name, string Email, string Password) : IRequest<Response>;
}