using People.Domain.Aggregates;
using People.Infrastructure.Data;

namespace People.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _personContext;

        public PersonRepository(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public void Create(Person person)
        {
            _personContext.Add(person);
            _personContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _personContext.People;
        }
    }
}
