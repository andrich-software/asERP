using asToolkit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asToolkit.Persistence.Configurations;

public class SalesHistoryConfiguration : IEntityTypeConfiguration<SalesHistory>
{
    public void Configure(EntityTypeBuilder<SalesHistory> builder)
    {
        // Per-shipment timeline lookups on the shipping detail view.
        builder.HasIndex(e => e.ShippingId);
    }
}
