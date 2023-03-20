using Companies.Domain.Aggregates;
using CrossCutting.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Companies.Infrastructure.MessageClients
{
    public class CreateCompanySubscriber : BackgroundService
    {
        private readonly string _queueName;
        private readonly IModel _channel;
        private readonly IServiceProvider _services;
        public CreateCompanySubscriber(IConfiguration configuration, IServiceProvider services)
        {
            var connection = new ConnectionFactory
            {
                HostName = configuration["RabbitMq:Host"],
                Port = Convert.ToInt32(configuration["RabbitMq:Port"]),
                UserName = configuration["RabbitMq:User"],
                Password = configuration["RabbitMq:Password"]
            }.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare("CreateCompany", ExchangeType.Fanout);

            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(_queueName, "CreateCompany", string.Empty);
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
                    var repository = scope.ServiceProvider.GetRequiredService<ICompanyService>();
                    repository.Create(JsonConvert.DeserializeObject<CreateCompanyMessage>(message));
                }

            };
            _channel.BasicConsume(_queueName, true, consumer);

            return Task.CompletedTask;
        }
    }
}
