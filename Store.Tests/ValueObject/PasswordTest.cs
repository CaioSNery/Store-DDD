using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.ValueObjects;
using Store.Application.Handlers;
using Xunit;

namespace Store.Tests.ValueObject
{
    public class PasswordTest
    {
        [Fact]
        public void ShouldReturnSuccessIfPasswordIsValid()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.True(password.Challenge("ValidPassword123!"));
        }

        [Fact]
        public void ShouldReturnFailureIfPasswordIsInvalid()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.False(password.Challenge("InvalidPassword"));
        }

        [Fact]
        public void ShouldFailChallengeWithEmptyPassword()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.False(password.Challenge(string.Empty));
        }

        [Fact]
        public void ShouldFailChallengeWithWrongPassword()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.False(password.Challenge("WrongPassword"));
        }

        [Fact]
        public void ShouldGeneratePasswordWhenNoneProvidered()
        {
            var password = Password.Create();
            Assert.False(string.IsNullOrEmpty(password.Hash));
        }
    }
}