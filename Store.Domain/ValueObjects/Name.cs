using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects
{
    public partial class Name : ValueObject
    {
        #region Constants
        public const int MinLength = 2;
        public const int MaxLength = 50;

        #endregion

        #region Constructors
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;


        }
        #endregion

        #region Factory Method
        public static Name Create(string firstName, string lastName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            if (firstName.Length < MinLength || firstName.Length > MaxLength)
                throw new ArgumentException($"First name must be between {MinLength} and {MaxLength} characters.");

            if (lastName.Length < MinLength || lastName.Length > MaxLength)
                throw new ArgumentException($"Last name must be between {MinLength} and {MaxLength} characters.");

            return new Name(firstName, lastName);
        }
        #endregion

        #region Properties
        public string FirstName { get; }
        public string LastName { get; }

        public static implicit operator string(Name name) => name.ToString();

        public override string ToString() => $"{FirstName} {LastName}";
        #endregion
    }
    
}
