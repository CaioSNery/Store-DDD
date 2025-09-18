using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Application.UseCases.Active
{
    public static class Specification
    {
        public static Contract<Notification> EnsureIsActive(Request request)
        {
            return new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(request.Email, "Email", "Email is required")
                .IsNotNullOrEmpty(request.Code, "Code", "Code is required");
        }
    }
}