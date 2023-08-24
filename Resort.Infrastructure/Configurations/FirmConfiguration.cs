using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resort.Domain.Firms;

namespace Resort.Infrastructure.Configurations
{
	public class FirmConfiguration : IEntityTypeConfiguration<Firm>
	{
		public void Configure(EntityTypeBuilder<Firm> builder)
		{
			builder.OwnsOne(p => p.Contact);
			builder.OwnsOne(p => p.Address);
			builder.HasKey(k => k.Id);
			builder.OwnsMany(p => p.Rooms, r =>
			{
				r.OwnsOne(y => y.Features);
				r.OwnsOne(y => y.Rate);
			});
			builder.OwnsMany(o => o.Foods, r =>
			{
				r.OwnsOne((o => o.Price));
				r.OwnsOne((o => o.Type));
			});
			
		}
	}
}

