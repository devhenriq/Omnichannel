using CrossCutting.Requests;
using People.Domain.Aggregates;

namespace People.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Create(CreatePersonMessage request)
        {
            _personRepository.Create(new Person(request.CustomerId, request.BirthDate, request.Gender));
        }
    }
}
