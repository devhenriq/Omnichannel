namespace CrossCutting.Requests
{
    public class CreatePersonMessage
    {
        public CreatePersonMessage(Guid customerId, string gender, DateTime birthDate)
        {
            CustomerId = customerId;
            Gender = gender;
            BirthDate = birthDate;
        }
        public Guid CustomerId { get; set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}