using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Customers.Infrastructure.MessageClients
{
    public class RabbitMQClient : IMessageQueueClient
    {
        private readonly RabbitMQ.Client.IModel _channel;

        public RabbitMQClient(IConfiguration configuration)
        {
            var connection = new ConnectionFactory
            {
                HostName = configuration["RabbitMq:Host"],
                Port = Convert.ToInt32(configuration["RabbitMq:Port"]),
                UserName = configuration["RabbitMq:User"],
                Password = configuration["RabbitMq:Password"]
            }.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void Publish(object message, string exchange)
        {
            var jsonMessage = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);
            _channel.BasicPublish(exchange, string.Empty, null, body);

        }
    }
}
