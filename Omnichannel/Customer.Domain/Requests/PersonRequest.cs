namespace Customers.Domain.Requests
{
    public class PersonRequest
    {
        public PersonRequest(string gender, DateTime birthDate)
        {
            Gender = gender;
            BirthDate = birthDate;
        }

        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}