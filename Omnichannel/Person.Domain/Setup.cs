using Microsoft.Extensions.DependencyInjection;
using People.Domain.Aggregates;
using People.Domain.Services;

namespace People.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}