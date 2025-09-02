using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Store.Domain.Entities;
using Store.Domain.UseCases.Create.Contracts;
using Store.Domain.ValueObjects;
using static Store.Domain.UseCases.Create.Response;

namespace Store.Domain.UseCases.Create
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IService _service;
        private readonly IRepository _repository;

        public Handler(IService service, IRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            //Validar as Requisições
            try
            {
                var res = Specification.Ensure(request);
                if (!res.IsValid)
                    return new Response("Invalid request", 400, res.Notifications);

            }
            catch
            {

                return new Response("Invalid Request", 500, null);
            }

            //Gerar os objetos

            Email email;
            Password password;
            User user;

            try
            {
                email = new Email(request.Email);
                password = new Password(request.Password);
                user = new User(request.Name, email, password);
            }
            catch (Exception ex)
            {

                return new Response(ex.Message, 400);
            }

            //Verificar Usuário

            try
            {
                var hasUser = await _repository.AnyAsync(request.Email, cancellationToken);
                if (hasUser)
                    return new Response("User already exists", 400);
            }
            catch
            {

                return new Response("Error checking user", 500);
            }

            //Persistir Dados no Banco

            try
            {
                await _repository.AddAsync(user, cancellationToken);
            }
            catch
            {
                return new Response("Error saving user", 500);
            }


            //Enviar email de ativação
            try
            {
                await _service.SendEmailAsync(user, cancellationToken);
            }
            catch
            {

            }

            return new Response("User created successfully",
            new ResponseData(user.Id, user.Name, user.Email));
        }
    }
}