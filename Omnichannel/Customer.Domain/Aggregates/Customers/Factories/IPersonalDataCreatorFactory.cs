namespace Customers.Domain.Aggregates.Customers.Factories
{
    public interface IPersonalDataCreatorFactory
    {
        IPersonalDataCreator Create(string document);
    }
}
