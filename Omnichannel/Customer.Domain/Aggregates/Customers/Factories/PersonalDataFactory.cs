using CrossCutting;
using CrossCutting.Requests;
using Customers.Domain.Aggregates.Customers.Strategies;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Factories
{
    public class PersonalDataFactory : IPersonalDataFactory
    {
        private readonly ICustomerRepository _customerRepository;

        public PersonalDataFactory(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public IDocumentValidator Create(Guid customerId, CreateCustomerRequest request) => request.Document.Length == 11 ? CreatePerson(customerId, request) : CreateCompany(customerId, request);

        private IDocumentValidator CreatePerson(Guid customerId, CreateCustomerRequest request)
        {
            _customerRepository.CreatePersonalData(new CreatePersonMessage(customerId, request.Person.Gender, request.Person.BirthDate), MessageExchanges.CreatePerson);
            return new CpfValidatorStrategy();
        }

        private IDocumentValidator CreateCompany(Guid customerId, CreateCustomerRequest request)
        {
            _customerRepository.CreatePersonalData(new CreateCompanyMessage(customerId, request.Company.SocialReason, request.Company.StateSubscription), MessageExchanges.CreateCompany);
            return new CnpjValidatorStrategy();
        }
    }
}
