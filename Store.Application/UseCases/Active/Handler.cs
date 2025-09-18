using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Store.Application.UseCases.Active.Contracts;

namespace Store.Application.UseCases.Active
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
            // 1. Validar a requisição
            var validation = Specification.EnsureIsActive(request);
            if (!validation.IsValid)
                return new Response("Invalid request", 400, validation.Notifications);

            // 2. Verificar se o usuário existe e se o código confere
            bool isActive;
            try
            {
                isActive = await _repository.IsActiveAsync(request.Email, request.Code);
                if (!isActive)
                    return new Response("Invalid email or activation code", 400);
            }
            catch
            {
                return new Response("Error activating user", 500);
            }

            // 3. Retornar dados do usuário ativado
            var user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (user == null)
                return new Response("User not found", 404);

            try
            {
                user.Email.Verification.Verify(request.Code);
                await _repository.UpdateUserAsync(user, cancellationToken);

                var data = new Response.ResponseData
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Email = user.Email.Address,
                    Roles = Array.Empty<string>(),
                    Token = "" // JWT se implementar
                };

                return new Response("User activated successfully", data);
            }
            catch (InvalidOperationException ex)
            {
                return new Response(ex.Message, 400);
            }
            catch
            {
                return new Response("Error retrieving user data", 500);
            }


        }
    }
}