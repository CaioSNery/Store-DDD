using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.ValueObject
{
    public class AddressTest
    {
        [Theory]
        [InlineData("123 Main St", "Springfield", "IL", "62701")]
        [InlineData("456 Elm St", "Metropolis", "NY", "10001")]
        public void Should_Create_Address_With_Valid_Data(string street, string city, string state, string zipCode)
        {
            var address = Address.Create(street, city, state, zipCode);

            Assert.NotNull(address);
            Assert.Equal(street, address.Street);
            Assert.Equal(city, address.City);
            Assert.Equal(state, address.State);
            Assert.Equal(zipCode, address.ZipCode);
            Assert.True(address.IsValid);
        }
    }
}