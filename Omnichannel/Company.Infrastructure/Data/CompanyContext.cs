using Companies.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Companies.Infrastructure.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Company> Companies => Set<Company>();
    }
}
