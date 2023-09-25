using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Bookings;
using Resort.Domain.Firms;

namespace Resort.Infrastructure.Configurations;

public class PaymentConfiguration: IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(o => o.Id);
    }
}