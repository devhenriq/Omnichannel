namespace Customers.Domain.Requests
{
    public class CompanyRequest
    {
        public CompanyRequest(string socialReason, string stateSubscription)
        {
            SocialReason = socialReason;
            StateSubscription = stateSubscription;
        }

        public string SocialReason { get; private set; }
        public string StateSubscription { get; private set; }
    }
}