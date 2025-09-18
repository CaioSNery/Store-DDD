
using MediatR;

namespace Store.Application.UseCases.Authenticate
{


    public record Request(string Email, string Password) : IRequest<Response>;

}