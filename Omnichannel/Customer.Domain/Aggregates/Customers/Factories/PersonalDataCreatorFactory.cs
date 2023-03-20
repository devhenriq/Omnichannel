using Customers.Domain.Aggregates.Customers.Strategies;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public class PersonalDataCreatorFactory : IPersonalDataCreatorFactory
    {
        public IPersonalDataCreator Create(string document)
        {
            return (document.Length == 11) ? new CreatePersonStrategy() : new CreateCompanyStrategy();
        }
    }
}
