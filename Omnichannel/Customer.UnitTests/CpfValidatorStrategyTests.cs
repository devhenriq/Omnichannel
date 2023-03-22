using Bogus.Extensions.Brazil;
using Customers.Domain.Aggregates.Customers.Strategies;

namespace Customers.UnitTests
{
    public class CpfValidatorStrategyTests : UnitTest
    {
        [Fact(DisplayName = "Valid CPF Validation should return true")]
        public void ValidCpfValidationShouldReturnTrue()
        {
            //Arrange
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var isValid = cpfValidator.Validate(_faker.Person.Cpf(false));

            //Assert
            isValid.Should().BeTrue();
        }

        [Fact(DisplayName = "CPF with wrong size Validation should return false")]
        public void CpfWithWrongSizeValidationShouldReturnFalse()
        {
            //Arrange
            var cpf = _faker.Random.String2(11, "0123456789");
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var isValid = cpfValidator.Validate(cpf);
            //Assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "CPF with alphanumeric Validation should return false")]
        public void CpfWithAlphanumericValidationShouldReturnFalse()
        {
            //Arrange
            var cpf = _faker.Random.String2(11);
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var isValid = cpfValidator.Validate(cpf);
            //Assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "CPF with invalid digit Validation should return false")]
        public void CpfWithInvalidDigitValidationShouldReturnFalse()
        {
            //Arrange
            var cpf = "01234567891";
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var isValid = cpfValidator.Validate(cpf);
            //Assert
            isValid.Should().BeFalse();
        }
    }
}
