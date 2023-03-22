using Bogus.Extensions.Brazil;
using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.Domain.Aggregates.Customers.ValueObjects;

namespace Customers.UnitTests
{
    public class DocumentTests : UnitTest
    {
        [Fact(DisplayName = "Valid CPF should set value")]
        public void ValidCpfShouldSetValue()
        {
            //Arrange
            var cpf = _faker.Person.Cpf(false);
            var cpfValidator = new CpfValidatorStrategy();

            //Act
            var document = new Document(cpf, cpfValidator);

            //Assert
            document.Value.Should().Be(cpf);
        }

        [Fact(DisplayName = "Invalid document should throw InvalidInputException")]
        public void InvalidDocumentShouldThrowInvalidInputException()
        {
            //Arrange
            var cpf = _faker.Random.String2(11);
            var cpfValidator = new CpfValidatorStrategy();
            //Act
            var onCreate = () => new Document(cpf, cpfValidator);

            //Assert
            onCreate.Should().Throw<InvalidInputException>();
        }
    }
}
