namespace CrossCutting.Requests
{
    public class CreatePersonMessage
    {
        public CreatePersonMessage(Guid customerId, string gender, DateOnly birthDate)
        {
            CustomerId = customerId;
            Gender = gender;
            BirthDate = birthDate;
        }
        public Guid CustomerId { get; set; }
        public string Gender { get; private set; }
        public DateOnly BirthDate { get; private set; }
    }
}