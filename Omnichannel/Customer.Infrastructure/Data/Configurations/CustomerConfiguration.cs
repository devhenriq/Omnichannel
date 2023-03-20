using Customers.Domain.Aggregates.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.OwnsOne(customer => customer.Email).Property(email => email.Value);
            builder.OwnsOne(customer => customer.Phone).Property(phone => phone.Value);
            builder.OwnsOne(customer => customer.Document).Property(document => document.Value);
            builder.HasOne(customer => customer.DeliveryAddress).WithMany(address => address.Customers).HasForeignKey(customer => customer.DeliveryAddressId);
        }
    }
}
