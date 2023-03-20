namespace Customers.Domain.Requests
{
    public class DeliveryAddressRequest
    {
        public DeliveryAddressRequest(string identifier, string zipCode, string address, string number, string neighbourhood, string complement, string city, string state, string reference)
        {
            Identifier = identifier;
            ZipCode = zipCode;
            Address = address;
            Number = number;
            Neighbourhood = neighbourhood;
            Complement = complement;
            City = city;
            State = state;
            Reference = reference;
        }

        public string Identifier { get; private set; }
        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string Number { get; private set; }
        public string Neighbourhood { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Reference { get; private set; }
    }
}