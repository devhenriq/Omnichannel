﻿using Bogus.Extensions.Brazil;
using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Factories;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.Domain.Aggregates.Customers.ValueObjects;
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
            var expectedCustomer = CustomerMockFactory.CreateCustomerMock();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(expectedCustomer.Id)).Returns(expectedCustomer);

            var customerService = new CustomerService(customerRepositoryMock.Object, Mock.Of<ICustomerFactory>());
            //Act

            var customer = customerService.Get(expectedCustomer.Id);

            //Assert
            customer.Email.Should().Be(expectedCustomer.Email);
        }
        [Fact(DisplayName = "Get with incorrect id should throw EntityNotFoundException")]
        public void GetWithIncorrectIdShouldThrowEntityNotFoundException()
        {
            //Arrange
            var customer = CustomerMockFactory.CreateCustomerMock();
            var customerService = new CustomerService(Mock.Of<ICustomerRepository>(), Mock.Of<ICustomerFactory>());
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
                CustomerMockFactory.CreateCustomerMock(),
                CustomerMockFactory.CreateCustomerMock()
            };
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.GetAll()).Returns(expectedCustomers);

            var customerService = new CustomerService(customerRepositoryMock.Object, Mock.Of<ICustomerFactory>());

            //Act
            var customers = customerService.GetAll();

            //Assert
            customers.Count().Should().Be(expectedCustomers.Count);
        }

        [Fact(DisplayName = "Create customer should throw InvalidInputException when customer already registered")]
        public async Task CreateCustomerShouldThrowInvalidInputExceptionWhenCustomerIsAlreadyRegisteredAsync()
        {
            //Arrange
            var expectedCustomer = CustomerMockFactory.CreateCustomerMock(_faker.Person.Email);
            var document = expectedCustomer.Document?.Value ?? string.Empty;
            var request = CustomerMockFactory.CreateCustomerRequestMock(document, email: _faker.Person.Email);
            var email = expectedCustomer.Email?.Value ?? string.Empty;

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(document, email)).Returns(expectedCustomer);


            var customerFactoryMock = new Mock<ICustomerFactory>();
            customerFactoryMock.Setup(mock => mock.CreateAsync(request)).ReturnsAsync(expectedCustomer);

            var customerService = new CustomerService(customerRepositoryMock.Object, customerFactoryMock.Object);

            //Act

            var onCreate = async () => await customerService.Create(request);

            //Assert
            await onCreate.Should().ThrowAsync<InvalidInputException>();
        }

        [Fact(DisplayName = "Create customer should call customer repository Get method")]
        public async Task CreateCustomerShouldCallCustomerRepositoryGetMethodAsync()
        {
            //Arrange

            var expectedCustomer = CustomerMockFactory.CreateCustomerMock(_faker.Person.Email);
            expectedCustomer.SetDocument(new Document(_faker.Person.Cpf(false), new CpfValidatorStrategy()));
            var document = expectedCustomer.Document?.Value ?? string.Empty;
            var email = expectedCustomer.Email?.Value ?? string.Empty;

            var request = CustomerMockFactory.CreateCustomerRequestMock(document, email);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(document, email));

            var customerFactoryMock = new Mock<ICustomerFactory>();
            customerFactoryMock.Setup(mock => mock.CreateAsync(request)).ReturnsAsync(expectedCustomer);

            var customerService = new CustomerService(customerRepositoryMock.Object, customerFactoryMock.Object);

            //Act
            await customerService.Create(request);

            //Assert
            customerRepositoryMock.Verify(mock => mock.Get(document, email), Times.Once());
        }

        [Fact(DisplayName = "Create customer should call customer repository CreateAsync method")]
        public async Task CreateCustomerShouldCallCustomerRepositoryCreateAsyncMethodAsync()
        {
            var expectedCustomer = CustomerMockFactory.CreateCustomerMock(_faker.Person.Email);
            expectedCustomer.SetDocument(new Document(_faker.Person.Cpf(false), new CpfValidatorStrategy()));
            var document = expectedCustomer.Document?.Value ?? string.Empty;
            var email = expectedCustomer.Email?.Value ?? string.Empty;

            var request = CustomerMockFactory.CreateCustomerRequestMock(document, email);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(document, email));

            var customerFactoryMock = new Mock<ICustomerFactory>();
            customerFactoryMock.Setup(mock => mock.CreateAsync(request)).ReturnsAsync(expectedCustomer);

            var customerService = new CustomerService(customerRepositoryMock.Object, customerFactoryMock.Object);


            //Act
            await customerService.Create(request);

            //Assert
            customerRepositoryMock.Verify(mock => mock.CreateAsync(expectedCustomer), Times.Once());
        }

        [Fact(DisplayName = "Create customer should return customer id")]
        public async Task CreateCustomerShouldReturnCustomerIdAsync()
        {
            var expectedCustomer = CustomerMockFactory.CreateCustomerMock(_faker.Person.Email);
            expectedCustomer.SetDocument(new Document(_faker.Person.Cpf(false), new CpfValidatorStrategy()));
            var document = expectedCustomer.Document?.Value ?? string.Empty;
            var email = expectedCustomer.Email?.Value ?? string.Empty;

            var request = CustomerMockFactory.CreateCustomerRequestMock(document, email);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.Get(document, email));

            var customerFactoryMock = new Mock<ICustomerFactory>();
            customerFactoryMock.Setup(mock => mock.CreateAsync(request)).ReturnsAsync(expectedCustomer);

            var customerService = new CustomerService(customerRepositoryMock.Object, customerFactoryMock.Object);


            //Act
            var customerId = await customerService.Create(request);

            //Assert
            customerId.Should().Be(expectedCustomer.Id);
        }
    }
}
