using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public interface IPersonalDataFactory
    {
        IDocumentValidator Create(Guid customerId, CreateCustomerRequest request);
    }
}
