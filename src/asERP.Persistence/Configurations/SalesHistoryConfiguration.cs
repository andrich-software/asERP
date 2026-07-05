using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesHistoryConfiguration : IEntityTypeConfiguration<SalesHistory>
{
    public void Configure(EntityTypeBuilder<SalesHistory> builder)
    {
        // Per-shipment timeline lookups on the shipping detail view.
        builder.HasIndex(e => e.ShippingId);

        // Every query carries the tenant filter — index TenantId so list endpoints don't full-scan.
        builder.HasIndex(e => e.TenantId);
    }
}
