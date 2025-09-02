using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Store.Domain.Entities;
using Store.Domain.UseCases.Authenticate.Contracts;
using static Store.Domain.UseCases.Authenticate.Response;

namespace Store.Domain.UseCases.Authenticate
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            //Validar a requisição
            try
            {
                var res = Specification.Ensure(request);
                if (!res.IsValid)
                    return new Response("Invalid request", 400, res.Notifications);
            }
            catch
            {

                return new Response("Failed to login", 500);
            }

            //Recupera o perfil

            User user;
            try
            {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user == null)
                    return new Response("User not found", 404);

            }
            catch
            {
                return new Response("Failed to login", 500);
            }

            //Validar a senha

            if (!user.Password.Challenge(request.Password))
                return new Response("Invalid password", 401);

            //Verificar se a conta eta ativada
            try
            {
                if (!user.Email.Verification.IsActive)
                    return new Response("User account is not active", 403);
            }
            catch
            {
                return new Response("Failed to login", 500);
            }

            //Retornar os Dados

            try
            {
                var data = new ResponseData
                {
                    Id = user.Id.ToString(),
                    Email = user.Email.Address,
                    Name = user.Name,
                    Roles = Array.Empty<string>()
                };

                return new Response("User authenticated", data);
            }
            catch
            {

                return new Response("Failed to login", 500);
            }

        }
    }

}