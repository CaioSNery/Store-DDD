using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities
{
    public class User : Entity
    {

        public User(string name, Email email, Password password)
        {
            Email = email;
            Password = password;
        }
        public User(string email, string password = null)
        {
            Email = email;
            Password = new Password(password);
        }
        protected User() { }

        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new List<Role>();

        public void UpdatePassword(string plainTextPassword, string code)
        {
            if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Invalid reset code");

            var password = new Password(plainTextPassword);
            Password = password;

        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void ChangePassword(string plainTextPassword)
        {
            Password = new Password(plainTextPassword);
        }

    }

}