using Bogus;

namespace Customers.UnitTests
{
    public class UnitTest
    {
        protected readonly Faker _faker;
        public UnitTest()
        {
            _faker = new Faker("pt_BR");
        }
    }
}