using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Factories;
using Customers.Domain.Services;
using Customers.UnitTests.Factories;

namespace Customers.UnitTests
{
    public class CustomerServiceTests : UnitTest
    {
        [Fact(DisplayName = "Get with id should return customer")]
        public void GetWithIdShouldReturnCustomer()
        {
            //Arrange
            var expectedCustomer = CustomerFactory.CreateCustomerMock();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(expectedCustomer.Id)).Returns(expectedCustomer);

            var addressRepositoryMock = new Mock<IAddressRepository>();

            var personalDataCreatorFactory = new Mock<IPersonalDataCreatorFactory>();

            var customerService = new CustomerService(customerRepositoryMock.Object, addressRepositoryMock.Object, personalDataCreatorFactory.Object);
            //Act

            var customer = customerService.Get(expectedCustomer.Id);

            //Assert
            customer.Email.Should().Be(expectedCustomer.Email);
        }
        [Fact(DisplayName = "Get with incorrect id should throw EntityNotFoundException")]
        public void GetWithIncorrectIdShouldThrowEntityNotFoundException()
        {
            //Arrange
            var customer = CustomerFactory.CreateCustomerMock();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var personalDataCreatorFactory = new Mock<IPersonalDataCreatorFactory>();

            var customerService = new CustomerService(customerRepositoryMock.Object, addressRepositoryMock.Object, personalDataCreatorFactory.Object);
            //Act
            var onGet = () => customerService.Get(customer.Id);

            //Assert
            onGet.Should().Throw<EntityNotFoundException>();
        }
        [Fact(DisplayName = "Get all should return all customers")]
        public void GetAllShouldReturnAllCustomers()
        {
            //Arrange
            var expectedCustomers = new List<Customer>
            {
                CustomerFactory.CreateCustomerMock(),
                CustomerFactory.CreateCustomerMock()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var personalDataCreatorFactory = new Mock<IPersonalDataCreatorFactory>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.GetAll()).Returns(expectedCustomers);

            var customerService = new CustomerService(customerRepositoryMock.Object, addressRepositoryMock.Object, personalDataCreatorFactory.Object);

            //Act
            var customers = customerService.GetAll();

            //Assert
            customers.Count().Should().Be(expectedCustomers.Count);
        }
    }
}
