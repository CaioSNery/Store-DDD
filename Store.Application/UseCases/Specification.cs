
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Application.UseCases.Create
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
        {
            return new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(request.Name, "Name", "Name is required")
                .IsNotNullOrEmpty(request.Email, "Email", "Email is required")
                .IsEmail(request.Email, "Email", "Email is invalid")
                .IsNotNullOrEmpty(request.Password, "Password", "Password is required")
                .IsLowerOrEqualsThan(request.Name.Length, 160, "Name", "Name must be at least 6 characters long")
                .IsGreaterOrEqualsThan(request.Name.Length, 6, "Name", "Name must be at least 6 characters long")
                .IsLowerOrEqualsThan(request.Password.Length, 40, "Password", "Password must be at least 40 characters long")
                .IsGreaterOrEqualsThan(request.Password.Length, 6, "Password", "Password must be at least 6 characters long")
                ;
        }
    }
}