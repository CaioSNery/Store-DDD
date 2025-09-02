
using MediatR;

namespace Store.Domain.UseCases.Authenticate
{


    public record Request(string Email, string Password) : IRequest<Response>;

}