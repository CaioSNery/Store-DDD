
using MediatR;

namespace Store.Application.UseCases.Active
{
    public record Request(string Email, string Code) : IRequest<Response>;
}