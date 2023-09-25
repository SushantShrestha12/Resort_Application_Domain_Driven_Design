using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Bookings;

namespace Resort.Infrastructure.Configurations;

public class BookingsConfiguration: IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(o => o.Id);
    }
}