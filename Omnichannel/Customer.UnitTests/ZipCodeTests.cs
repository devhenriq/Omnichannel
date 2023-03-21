using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Addresses.ValueObjects;

namespace Customers.UnitTests
{
    public class ZipCodeTests : UnitTest
    {
        [Fact(DisplayName = "Valid zip code should set value")]
        public void ValidZipCodeShouldSetValue()
        {
            //Arrange
            var expectedZipCode = _faker.Address.ZipCode("########");

            //Act
            var zipCode = new ZipCode(expectedZipCode);

            //Assert
            zipCode.Value.Should().Be(expectedZipCode);
        }

        [Fact(DisplayName = "Invalid zip code should throw InvalidInputException")]
        public void InvalidZipCodeShouldThrowInvalidInputException()
        {
            //Arrange
            var expectedZipCode = _faker.Address.ZipCode("#######");

            //Act
            var onCreate = () => new ZipCode(expectedZipCode);

            //Assert
            onCreate.Should().Throw<InvalidInputException>();
        }
    }
}
