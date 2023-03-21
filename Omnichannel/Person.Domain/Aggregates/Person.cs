namespace People.Domain.Aggregates
{
    public class Person
    {
        public Person(Guid customerId, DateTime birthDate, string gender)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            BirthDate = birthDate;
            Gender = gender;
        }

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
    }
}
