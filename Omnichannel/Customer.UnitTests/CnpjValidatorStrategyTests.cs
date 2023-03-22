using Bogus.Extensions.Brazil;
using Customers.Domain.Aggregates.Customers.Strategies;

namespace Customers.UnitTests
{
    public class CnpjValidatorStrategyTests : UnitTest
    {
        [Fact(DisplayName = "Valid CNPJ Validation should return true")]
        public void ValidCnpjValidationShouldReturnTrue()
        {
            //Arrange
            var cnpjValidator = new CnpjValidatorStrategy();
            //Act
            var isValid = cnpjValidator.Validate(_faker.Company.Cnpj(false));

            //Assert
            isValid.Should().BeTrue();
        }

        [Fact(DisplayName = "CNPJ with wrong size Validation should return false")]
        public void CnpjWithWrongSizeValidationShouldReturnFalse()
        {
            //Arrange
            var cnpj = _faker.Random.String2(13, "0123456789");
            var cnpjValidator = new CnpjValidatorStrategy();
            //Act
            var isValid = cnpjValidator.Validate(cnpj);
            //Assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "CNPJ with alphanumeric Validation should return false")]
        public void CnpjWithAlphanumericValidationShouldReturnFalse()
        {
            //Arrange
            var cnpj = _faker.Random.String2(14);
            var cnpjValidator = new CnpjValidatorStrategy();
            //Act
            var isValid = cnpjValidator.Validate(cnpj);
            //Assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "CNPJ with invalid digit Validation should return false")]
        public void CnpjWithInvalidDigitValidationShouldReturnFalse()
        {
            //Arrange
            var cnpj = "01234567891234";
            var cnpjValidator = new CnpjValidatorStrategy();
            //Act
            var isValid = cnpjValidator.Validate(cnpj);
            //Assert
            isValid.Should().BeFalse();
        }
    }
}
