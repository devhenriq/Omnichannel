using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Customers.ValueObjects;

namespace Customers.UnitTests
{
    public class EmailTests : UnitTest
    {
        [Fact(DisplayName = "Valid email should set value")]
        public void ValidEmailShouldSetValue()
        {
            //Arrange
            var expectedEmail = _faker.Person.Email;

            //Act
            var email = new Email(expectedEmail);

            //Assert
            email.Value.Should().Be(expectedEmail);
        }

        [Fact(DisplayName = "Invalid email should throw InvalidInputException")]
        public void InvalidPhoneShouldThrowInvalidInputException()
        {
            //Arrange
            var expectedEmail = _faker.Random.String2(12);

            //Act
            var onCreate = () => new Email(expectedEmail);

            //Assert
            onCreate.Should().Throw<InvalidInputException>();
        }
    }
}
