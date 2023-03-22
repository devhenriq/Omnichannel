using Bogus.Extensions.Brazil;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.UnitTests.Factories;

namespace Customers.UnitTests
{
    public class CreatePersonStrategyTests : UnitTest
    {
        [Fact(DisplayName = "Create should return cpf validator")]
        public void CreateShouldReturnCpfValidator()
        {
            //Arrange
            var createPersonStrategy = new CreatePersonStrategy();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            //Act

            var validator = createPersonStrategy.Create(customerRepositoryMock.Object, CustomerMockFactory.CreateCustomerRequestMock(_faker.Person.Cpf(false)), Guid.NewGuid());
            //Assert
            validator.Should().BeOfType<CpfValidatorStrategy>();
        }
    }
}
