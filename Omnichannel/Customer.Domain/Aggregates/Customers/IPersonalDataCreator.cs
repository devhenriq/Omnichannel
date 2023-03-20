using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers
{
    public interface IPersonalDataCreator
    {
        IDocumentValidator Create(ICustomerRepository repository, CreateCustomerRequest request, Guid customerId);
    }
}
