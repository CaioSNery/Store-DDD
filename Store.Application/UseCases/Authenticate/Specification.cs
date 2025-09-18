using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Application.UseCases.Authenticate
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request) =>
            new Contract<Notification>()
                .Requires()
                .IsEmail(request.Email, "Email", "O email é inválido")
                .IsNotNullOrEmpty(request.Password, "Password", "A senha deve ser informada")
                .IsLowerOrEqualsThan(request.Password.Length, 40, "Password", "Password must be at least 40 characters long")
                .IsGreaterOrEqualsThan(request.Password.Length, 6, "Password", "Password must be at least 6 characters long")
                ;
    }
}