using Companies.Domain.Aggregates;
using Companies.Infrastructure.Data;
using Companies.Infrastructure.MessageClients;
using Companies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Companies.Infrastructure
{
    public static class Setup
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddHostedService<CreateCompanySubscriber>();
            services.AddDbContext<CompanyContext>(options => options.UseInMemoryDatabase("CompaniesDb"));
        }


    }
}