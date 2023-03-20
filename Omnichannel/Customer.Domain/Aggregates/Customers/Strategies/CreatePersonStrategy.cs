using CrossCutting;
using CrossCutting.Requests;
using Customers.Domain.Requests;

namespace Customers.Domain.Aggregates.Customers.Strategies
{
    public class CreatePersonStrategy : IPersonalDataCreator
    {
        public IDocumentValidator Create(ICustomerRepository repository, CreateCustomerRequest request, Guid customerId)
        {
            repository.CreatePersonalData(new CreatePersonMessage(customerId, request.Person.Gender, request.Person.BirthDate), MessageQueues.CreatePerson);
            return new CpfValidatorStrategy();
        }
    }
}
