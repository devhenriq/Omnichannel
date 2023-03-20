using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Aggregates.Customers.ValueObjects;

namespace Customers.Domain.Aggregates.Customers
{
    public class Customer
    {
        public Customer(string email,
            string name, string phone, Address deliveryAddress) : this(name)
        {
            Email = new Email(email);
            Phone = new Phone(phone);
            DeliveryAddress = deliveryAddress;
        }
        protected Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public Email? Email { get; private set; }
        public Document? Document { get; private set; }
        public bool IsPerson => Document?.Value.Length == 1;
        public string Name { get; private set; }
        public Phone? Phone { get; private set; }
        public Guid DeliveryAddressId { get; private set; }
        public Address? DeliveryAddress { get; private set; }
        public void SetDocument(Document document) => Document = document;
    }
}
