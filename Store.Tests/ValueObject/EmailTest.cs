using System;
using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.ValueObject
{
    public class EmailTest
    {
        [Theory]
        [InlineData("caio@balta.com")]
        [InlineData("test@example.com")]
        [InlineData("invalid@email.com")]
        public void ShouldReturnSucessIfEmailIsValid(string email)
        {
            var result = Email.Create(email);
            Assert.Equal(email, result.Address);
        }

        [Theory]
        [InlineData("caio")]
        [InlineData("test@")]
        [InlineData("invalid.com")]
        [InlineData("a@b.c")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnExceptionIfEmailIsInvalid(string email)
        {
            Assert.Throws<ArgumentException>(() => Email.Create(email));
        }

        [Fact]
        public void ShouldReturnExceptionIfEmailIsNull()
        {
            Assert.Throws<ArgumentException>(() => Email.Create(null));
        }
        [Fact]
        public void ShouldReturnExceptionIfEmailIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => Email.Create(string.Empty));
        }

        [Fact]
        public void ShouldFailToCreateAnEmailWithInvalidFormat()
        {
            Assert.Throws<ArgumentException>(() => Email.Create("invalidemail.com"));
        }

        
    }
}