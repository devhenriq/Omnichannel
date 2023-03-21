using Customers.Domain.Aggregates.Customers.Strategies;

namespace Customers.UnitTests
{
    public class CnpjValidatorStrategyTests : UnitTest
    {
        [Theory(DisplayName = "Valid CNPJ Validation should return true")]
        [InlineData("95775776000190")]
        [InlineData("77031787000183")]
        [InlineData("95914411000107")]
        [InlineData("84752078000152")]
        public void ValidCnpjValidationShouldReturnTrue(string cnpj)
        {
            //Arrange
            var cnpjValidator = new CnpjValidatorStrategy();
            //Act
            var isValid = cnpjValidator.Validate(cnpj);

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
