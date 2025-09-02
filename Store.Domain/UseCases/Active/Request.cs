
using MediatR;

namespace Store.Domain.UseCases.Active
{
    public record Request(string Email, string Code) : IRequest<Response>;
}