using Microsoft.EntityFrameworkCore;
using People.Domain.Aggregates;

namespace People.Infrastructure.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People => Set<Person>();
    }
}
