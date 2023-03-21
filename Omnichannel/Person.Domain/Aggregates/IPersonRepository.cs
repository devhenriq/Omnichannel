namespace People.Domain.Aggregates
{
    public interface IPersonRepository
    {
        void Create(Person person);
        IEnumerable<Person> GetAll();
    }
}
