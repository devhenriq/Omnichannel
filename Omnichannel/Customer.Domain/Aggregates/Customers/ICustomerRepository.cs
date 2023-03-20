namespace Customers.Domain.Aggregates.Customers
{
    public interface ICustomerRepository
    {
        Customer? Get(Guid id);
        Customer? Get(string document, string email);
        IEnumerable<Customer> GetAll();
        Task CreateAsync(Customer customer);
        void CreatePersonalData(object message, string exchange);
    }
}
