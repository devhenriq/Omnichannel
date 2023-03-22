using Bogus.Extensions.Brazil;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.UnitTests.Factories;

namespace Customers.UnitTests
{
    public class CreateCompanyStrategyTests : UnitTest
    {
        [Fact(DisplayName = "Create should return cnpj validator")]
        public void CreateShouldReturnCnpjValidator()
        {
            //Arrange
            var createCompanyStrategy = new CreateCompanyStrategy();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            //Act

            var validator = createCompanyStrategy.Create(customerRepositoryMock.Object, CustomerMockFactory.CreateCustomerRequestMock(_faker.Company.Cnpj(false)), Guid.NewGuid());
            //Assert
            validator.Should().BeOfType<CnpjValidatorStrategy>();
        }
    }
}
