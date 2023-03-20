namespace Companies.Domain.Aggregates
{
    public class Company
    {
        public Company(Guid customerId, string socialReasonName, string stateSubscription)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            SocialReasonName = socialReasonName;
            StateSubscription = stateSubscription;
        }
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public string SocialReasonName { get; private set; }
        public string StateSubscription { get; private set; }
    }
}
