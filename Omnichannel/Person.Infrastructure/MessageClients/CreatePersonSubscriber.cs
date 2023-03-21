using CrossCutting;
using CrossCutting.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using People.Domain.Aggregates;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace People.Infrastructure.MessageClients
{
    public class CreatePersonSubscriber : BackgroundService
    {
        private readonly string _queueName;
        private readonly RabbitMQ.Client.IModel _channel;
        private readonly IServiceProvider _services;
        public CreatePersonSubscriber(IConfiguration configuration, IServiceProvider services)
        {
            var connection = new ConnectionFactory
            {
                HostName = configuration["RabbitMq:Host"],
                Port = Convert.ToInt32(configuration["RabbitMq:Port"]),
                UserName = configuration["RabbitMq:User"],
                Password = configuration["RabbitMq:Password"]
            }.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(MessageQueues.CreatePerson, ExchangeType.Fanout);

            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(_queueName, MessageQueues.CreatePerson, string.Empty);
            _services = services;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                using (var scope = _services.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IPersonService>();
                    repository.Create(JsonConvert.DeserializeObject<CreatePersonMessage>(message));
                }

            };
            _channel.BasicConsume(_queueName, true, consumer);

            return Task.CompletedTask;
        }
    }
}
