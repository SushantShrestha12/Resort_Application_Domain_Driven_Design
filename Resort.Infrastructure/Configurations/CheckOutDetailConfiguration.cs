using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Bookings;
using Resort.Domain.RoomHistory;

namespace Resort.Infrastructure.Configurations;

public class CheckOutDetailConfiguration: IEntityTypeConfiguration<CheckOutDetail>
{
    public void Configure(EntityTypeBuilder<CheckOutDetail> builder)
    {
        builder.OwnsOne(r => r.Rate);
    }
}