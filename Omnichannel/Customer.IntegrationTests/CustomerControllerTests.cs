using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace Customers.IntegrationTests
{
    public class CustomerControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Faker _faker;
        public CustomerControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _faker = new Faker();
        }

        [Fact(DisplayName = "Post customer should return created status code")]
        public async Task PostCustomerShouldReturnCreatedStatusCode()
        {
            //Arrange
            var request = new CreateCustomerRequest(
                _faker.Person.FullName,
                new CompanyRequest(_faker.Random.String2(10), _faker.Random.String2(10)),
                null,
                new DeliveryAddressRequest(
                    _faker.Random.String2(5),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10),
                    _faker.Random.String2(10)),
                _faker.Phone.PhoneNumber("##########"),
                _faker.Person.Email,
                _faker.Random.String2(11)
            );
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(mock => mock.Create(request)).ReturnsAsync(Guid.NewGuid());
            var client = _factory.WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(provider => customerServiceMock.Object);
                })
            ).CreateClient();

            //Act
            var response = await client.PostAsJsonAsync("/customer", request);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}