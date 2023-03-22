using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Aggregates.Customers.ValueObjects;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonalDataFactory _personalDataFactory;
        public CustomerFactory(IAddressRepository addressRepository, IPersonalDataFactory personalDataFactory)
        {
            _addressRepository = addressRepository;
            _personalDataFactory = personalDataFactory;
        }

        public async Task<Customer> CreateAsync(CreateCustomerRequest request)
        {
            var address = await _addressRepository.GetAddressAsync(request.Address.ZipCode);
            address.SetAdditionalInformation(request.Address.Number, request.Address.Identifier, request.Address.Complement, request.Address.Reference);

            var customer = new Customer(request.Email, request.Name, request.Phone, address);

            var documentValidator = _personalDataFactory.Create(customer.Id, request);
            customer.SetDocument(new Document(request.Document, documentValidator));

            return customer;
        }
    }
}
