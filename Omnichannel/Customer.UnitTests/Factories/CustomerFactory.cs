using Bogus;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.Domain.Aggregates.Customers.ValueObjects;

namespace Customers.UnitTests.Factories
{
    public static class CustomerFactory
    {
        public static Customer CreateCustomerMock()
        {
            var faker = new Faker();
            return new Customer(
                    faker.Person.Email,
                    new Document(faker.Random.String2(11), new CpfValidatorStrategy()),
                    faker.Person.FullName,
                    faker.Phone.PhoneNumber("##########"),
                    AddressFactory.CreateAddressMock()
                );
        }
    }
}
