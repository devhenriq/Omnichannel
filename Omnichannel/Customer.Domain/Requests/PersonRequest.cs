namespace Customers.Domain.Requests
{
    public class PersonRequest
    {
        public PersonRequest(string gender, DateOnly birthDate)
        {
            Gender = gender;
            BirthDate = birthDate;
        }

        public string Gender { get; private set; }
        public DateOnly BirthDate { get; private set; }
    }
}