using CrossCutting.Exceptions;
using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Factories;
using Customers.Domain.Aggregates.Customers.ValueObjects;
using Customers.Domain.Requests;

namespace Customers.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonalDataCreatorFactory _personalDataCreatorFactory;
        public CustomerService(ICustomerRepository customerRepository, IAddressRepository addressRepository, IPersonalDataCreatorFactory personalDataCreatorFactory)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _personalDataCreatorFactory = personalDataCreatorFactory;
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

            var address = await _addressRepository.GetAddressAsync(request.Address.ZipCode);
            address.SetAdditionalInformation(request.Address.Number, request.Address.Identifier, request.Address.Complement, request.Address.Reference);

            customer = new Customer(request.Email, request.Name, request.Phone, address);
            var personalDataCreator = _personalDataCreatorFactory.Create(request.Document);
            var documentValidator = personalDataCreator.Create(_customerRepository, request, customer.Id);
            customer.SetDocument(new Document(request.Document, documentValidator));

            await _customerRepository.CreateAsync(customer);
            return customer.Id;
        }
    }
}
