using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Tracks;

namespace Resort.Infrastructure.Configurations;

public class ChangeTrackerConfiguration : IEntityTypeConfiguration<ChangeTracker>
{
    public void Configure(EntityTypeBuilder<ChangeTracker> builder)
    {
        builder.HasKey(t => t.Id);
       
    }
}
