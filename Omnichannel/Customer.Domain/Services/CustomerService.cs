using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Factories;
using Customers.Domain.Requests;

namespace Customers.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;
        public CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public Customer Get(Guid id)
        {
            var customer = _customerRepository.Get(id);
            if (customer is null)
                throw new EntityNotFoundException(nameof(customer));

            return customer;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public async Task<Guid> Create(CreateCustomerRequest request)
        {
            var customer = _customerRepository.Get(request.Document, request.Email);
            if (customer is not null) throw new InvalidInputException("Customer creation. Customer already registered");

            customer = await _customerFactory.CreateAsync(request);

            await _customerRepository.CreateAsync(customer);
            return customer.Id;
        }
    }
}
