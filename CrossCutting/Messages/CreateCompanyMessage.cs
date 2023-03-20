namespace CrossCutting.Requests
{
    public class CreateCompanyMessage
    {
        public CreateCompanyMessage(Guid customerId, string socialReason, string stateSubscription)
        {
            CustomerId = customerId;
            SocialReason = socialReason;
            StateSubscription = stateSubscription;
        }
        public Guid CustomerId { get; private set; }
        public string SocialReason { get; private set; }
        public string StateSubscription { get; private set; }
    }
}