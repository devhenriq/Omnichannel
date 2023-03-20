using Bogus;
using Customers.Domain.Aggregates.Customers;

namespace Customers.UnitTests.Factories
{
    public static class CustomerFactory
    {
        public static Customer CreateCustomerMock()
        {
            var faker = new Faker();
            return new Customer(
                    faker.Person.Email,
                    faker.Person.FullName,
                    faker.Phone.PhoneNumber("##########"),
                    AddressFactory.CreateAddressMock()
                );
        }
    }
}
