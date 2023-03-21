using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer Create(CreateCustomerRequest request, Address address)
        {
            return new Customer(request.Email, request.Name, request.Phone, address);
        }
    }
}
