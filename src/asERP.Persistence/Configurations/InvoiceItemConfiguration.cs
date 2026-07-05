using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.Property(e => e.UnitPrice)
            .HasPrecision(18, 2);

        builder.Property(e => e.TotalPrice)
            .HasPrecision(18, 2);

        builder.Property(e => e.TaxAmount)
            .HasPrecision(18, 2);

        // Every query carries the tenant filter — index TenantId so list endpoints don't full-scan.
        builder.HasIndex(e => e.TenantId);
    }
}
