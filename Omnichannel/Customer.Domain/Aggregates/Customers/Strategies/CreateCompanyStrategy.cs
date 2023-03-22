using CrossCutting;
using CrossCutting.Requests;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Strategies
{
    public class CreateCompanyStrategy : IPersonalDataCreator
    {
        public IDocumentValidator Create(ICustomerRepository repository, CreateCustomerRequest request, Guid customerId)
        {
            repository.CreatePersonalData(new CreateCompanyMessage(customerId, request.Company.SocialReason, request.Company.StateSubscription), MessageExchanges.CreateCompany);
            return new CnpjValidatorStrategy();
        }
    }
}
