using Customers.Domain.Aggregates.Customers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Customers.Infrastructure.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}