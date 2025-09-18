using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Store.Domain.Shared;


namespace Store.Domain.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+[^@\s]+@[^@\s]+\.[^@\s]+$";

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email address is required.");

            Address = address.Trim().ToLower();

            if (!EmailRegex().IsMatch(Address))
                throw new ArgumentException("Invalid email address format.");

            if (address.Length < 5)
                throw new ArgumentException("Email address is too short.");
        }

        public static Email Create(string address) => new Email(address);

        protected Email() { }
        public string Address { get; private set; } = string.Empty;
        public string Hash => Address.ToBase64();
        public Verification Verification { get; private set; } = new();



        public void ResendVerification()
        {
            Verification = new Verification();
        }

        public static implicit operator string(Email email) => email.Address;

        public static implicit operator Email(string address) => new Email(address);

        public override string ToString() => Address;

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

    }
}