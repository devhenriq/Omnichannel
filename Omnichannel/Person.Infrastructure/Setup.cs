using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using People.Domain.Aggregates;
using People.Infrastructure.Data;
using People.Infrastructure.MessageClients;
using People.Infrastructure.Repositories;

namespace People.Infrastructure
{
    public static class Setup
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddHostedService<CreatePersonSubscriber>();
            services.AddDbContext<PersonContext>(options => options.UseInMemoryDatabase("PeopleDb"));
        }
    }
}