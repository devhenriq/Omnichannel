using Companies.Domain.Aggregates;
using Companies.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Companies.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}