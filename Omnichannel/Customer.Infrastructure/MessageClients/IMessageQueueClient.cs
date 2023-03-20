namespace Customers.Infrastructure.MessageClients
{
    public interface IMessageQueueClient
    {
        void Publish(object message, string exchange);
    }
}
