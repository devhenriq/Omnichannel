using Bogus;
using Customers.Domain.Aggregates.Addresses;

namespace Customers.UnitTests.Factories
{
    public static class AddressFactory
    {
        public static Address CreateAddressMock()
        {
            var faker = new Faker();
            return new Address(faker.Address.ZipCode(), faker.Address.City(), faker.Address.State(), faker.Address.StreetName(), faker.Address.StreetAddress());
        }
    }
}
