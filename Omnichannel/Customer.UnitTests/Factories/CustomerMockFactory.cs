using Bogus;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Requests;

namespace Customers.UnitTests.Factories
{
    public static class CustomerMockFactory
    {
        public static Customer CreateCustomerMock(string email = "teste@teste.com")
        {
            var faker = new Faker();
            return new Customer(
                    email,
                    faker.Person.FullName,
                    faker.Phone.PhoneNumber("##########"),
                    AddressFactory.CreateAddressMock()
                );
        }

        public static CreateCustomerRequest CreateCustomerRequestMock(string document = "70612674029", string email = "teste@teste.com")
        {
            var faker = new Faker();
            return new CreateCustomerRequest(
                    document,
                    faker.Person.FullName,
                    email,
                    faker.Phone.PhoneNumber("##########"),
                    new DeliveryAddressRequest(
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10),
                            faker.Random.String2(10)
                        ),
                    new PersonRequest(faker.Random.String2(10), faker.Person.DateOfBirth),
                    new CompanyRequest(faker.Random.String2(10), faker.Random.String2(10))
                );
        }
    }
}
