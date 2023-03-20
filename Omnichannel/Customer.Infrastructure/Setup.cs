using Customers.Domain.Aggregates.Addresses;
using Customers.Domain.Aggregates.Customers;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.MessageClients;
using Customers.Infrastructure.Providers.Cep;
using Customers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Net;

namespace Customers.Infrastructure
{
    public static class Setup
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCache(configuration);
            services.AddViaCepClient(configuration);
            services.AddDbContext();
            services.AddMessageQueues();
            services.AddRepositories();
        }
        private static void AddMessageQueues(this IServiceCollection services)
        {
            services.AddScoped<IMessageQueueClient, RabbitMQClient>();
        }
        private static void AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options => options.Configuration = configuration["RedisConnectionString"]);
        }
        private static void AddViaCepClient(this IServiceCollection services, IConfiguration configuration)
        {
            var challengeApiUrl = GetChallengeApiUrl(configuration);
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);
            services.AddHttpClient(nameof(IViaCepClient), client => client.BaseAddress = new Uri(challengeApiUrl))
                            .AddPolicyHandler(GetRetryPolicy(delay))
                            .AddTypedClient(Refit.RestService.For<IViaCepClient>);
        }
        private static Func<IServiceProvider, HttpRequestMessage, IAsyncPolicy<HttpResponseMessage>> GetRetryPolicy(IEnumerable<TimeSpan> delay)
        {
            return (provider, msg) =>
            {
                return Policy.HandleResult<HttpResponseMessage>(message =>
                            message.StatusCode == HttpStatusCode.RequestTimeout ||
                            message.StatusCode == HttpStatusCode.BadGateway ||
                            message.StatusCode == HttpStatusCode.GatewayTimeout ||
                            message.StatusCode == HttpStatusCode.InternalServerError)
                        .WaitAndRetryAsync(delay);
            };
        }

        private static string GetChallengeApiUrl(IConfiguration configuration)
        {
            var challengeApiUrl = configuration["ChallengeApi"];
            if (string.IsNullOrEmpty(challengeApiUrl)) throw new ArgumentNullException(nameof(configuration), "Challenge API URL not found.");
            return challengeApiUrl;
        }

        private static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase("CustomersDb"));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}