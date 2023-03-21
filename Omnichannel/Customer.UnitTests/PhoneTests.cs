using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Customers.ValueObjects;

namespace Customers.UnitTests
{
    public class PhoneTests : UnitTest
    {
        [Fact(DisplayName = "Valid phone should set value")]
        public void ValidPhoneShouldSetValue()
        {
            //Arrange
            var expectedPhone = _faker.Phone.PhoneNumber("##########");

            //Act
            var phone = new Phone(expectedPhone);

            //Assert
            phone.Value.Should().Be(expectedPhone);
        }

        [Fact(DisplayName = "Invalid phone should throw InvalidInputException")]
        public void InvalidPhoneShouldThrowInvalidInputException()
        {
            //Arrange
            var expectedPhone = _faker.Phone.PhoneNumber("#########");

            //Act
            var onCreate = () => new Phone(expectedPhone);

            //Assert
            onCreate.Should().Throw<InvalidInputException>();
        }
    }
}
