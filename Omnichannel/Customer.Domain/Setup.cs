using CrossCutting.Handlers;
using Customers.Domain.Aggregates.Customers;
using Customers.Domain.Aggregates.Customers.Factories;
using Customers.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Customers.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPersonalDataCreatorFactory, PersonalDataCreatorFactory>();
        }
        public static void UseDomain(this IApplicationBuilder app, ILogger logger)
        {
            app.AddExceptionHandler(logger);
        }
    }
}