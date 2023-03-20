namespace Customers.Domain.Requests
{
    public class CreateCustomerRequest
    {
        public CreateCustomerRequest(string document, string name, string email, string phone, DeliveryAddressRequest address, PersonRequest person, CompanyRequest company)
        {
            Document = document;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Person = person;
            Company = company;
        }

        public string Document { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DeliveryAddressRequest Address { get; private set; }
        public PersonRequest Person { get; private set; }
        public CompanyRequest Company { get; private set; }
    }
}
