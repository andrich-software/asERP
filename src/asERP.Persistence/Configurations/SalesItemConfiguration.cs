using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesItemConfiguration : IEntityTypeConfiguration<SalesItem>
{
    public void Configure(EntityTypeBuilder<SalesItem> builder)
    {
        builder.Property(e => e.Price)
            .HasPrecision(18, 2);

        // Every query carries the tenant filter — index TenantId so list endpoints don't full-scan.
        builder.HasIndex(e => e.TenantId);
    }
}
