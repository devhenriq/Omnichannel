using Customers.Domain.Aggregates.Customers.Strategies;

namespace Customers.UnitTests
{
    public class CpfValidatorStrategyTests : UnitTest
    {
        [Theory(DisplayName = "Valid CPF Validation should return true")]
        [InlineData("70612674029")]
        [InlineData("68955458088")]
        [InlineData("64328164082")]
        [InlineData("76809771000")]
        public void ValidCpfValidationShouldReturnTrue(string cpf)
        {
            //Arrange
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var isValid = cpfValidator.Validate(cpf);

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
