using Customers.Domain.Aggregates.Customers;

namespace Customers.Domain.Aggregates.Addresses
{
    public class Address
    {
        public Address(string zipCode, string city, string state, string street, string neighbourhood)
        {
            Id = Guid.NewGuid();
            ZipCode = zipCode;
            City = city;
            State = state;
            Street = street;
            Neighbourhood = neighbourhood;
        }
        public Guid Id { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Street { get; private set; }
        public string Neighbourhood { get; private set; }
        public string Number { get; private set; } = "";
        public string Identification { get; private set; } = "";
        public string Complement { get; private set; } = "";
        public string Reference { get; private set; } = "";
        public IEnumerable<Customer> Customers { get; private set; } = new List<Customer>();
        public void SetAdditionalInformation(string number, string identification, string complement, string reference)
        {
            Number = number;
            Identification = identification;
            Complement = complement;
            Reference = reference;
        }
    }
}
