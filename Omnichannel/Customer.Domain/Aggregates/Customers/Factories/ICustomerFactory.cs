using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public interface ICustomerFactory
    {
        Task<Customer> CreateAsync(CreateCustomerRequest request);
    }
}