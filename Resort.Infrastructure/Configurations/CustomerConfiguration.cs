using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Customers;

namespace Resort.Infrastructure.Configurations;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(o => o.Address);
        builder.OwnsOne(o => o.Contact);
        builder.HasKey(o => o.Id);
    }
}