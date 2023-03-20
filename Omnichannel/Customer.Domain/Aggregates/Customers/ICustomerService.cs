using CrossCutting.Requests;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers
{
    public interface ICustomerService
    {
        Customer Get(Guid id);
        IEnumerable<Customer> GetAll();
        Task<Guid> Create(CreateCustomerRequest request);
    }
}
