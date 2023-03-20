using Customers.Domain.Aggregates.Customers;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.MessageClients;

namespace Customers.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        private readonly IMessageQueueClient _messageQueueClient;
        public CustomerRepository(CustomerContext context, IMessageQueueClient messageQueueClient)
        {
            _context = context;
            _messageQueueClient = messageQueueClient;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            _context.SaveChanges();
        }

        public Customer? Get(Guid id)
        {
            return _context.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public Customer? Get(string document, string email)
        {
            return _context.Customers.FirstOrDefault(customer => (customer.Document != null && customer.Document.Value == document) || (customer.Email != null && customer.Email.Value == email));
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void CreatePersonalData(object message, string exchange)
        {
            _messageQueueClient.Publish(message, exchange);
        }
    }
}
