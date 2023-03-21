using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public interface ICustomerFactory
    {
        Customer Create(CreateCustomerRequest request, Address address);
    }
}