namespace Customers.Domain.Aggregates.Addresses
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(string zipCode);
    }
}
