using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesConfiguration : IEntityTypeConfiguration<Sales>
{
    public void Configure(EntityTypeBuilder<Sales> builder)
    {
        builder.Property(e => e.ConcurrencyToken)
            .IsConcurrencyToken();

        builder.Property(e => e.Subtotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.ShippingCost)
            .HasPrecision(18, 2);

        builder.Property(e => e.TotalTax)
            .HasPrecision(18, 2);

        builder.Property(e => e.Total)
            .HasPrecision(18, 2);

        // Configure CustomerId as int
        builder.Property(e => e.CustomerId)
            .HasColumnType("int");

        // Configure the relationship with Customer entity
        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Saless)
            .HasForeignKey(e => e.CustomerId)
            .HasPrincipalKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.SalesId, e.TenantId })
            .IsUnique();

        // Hot path: the sales import checks idempotency per order via GetByRemoteSalesIdAsync
        // (WHERE SalesChannelId AND RemoteSalesId). Without this the lookup seq-scans the whole
        // (growing) sales table on every imported order. Non-unique: a channel never repeats a
        // RemoteSalesId, but keeping it non-unique avoids a migration failure on any legacy dupes.
        builder.HasIndex(e => new { e.SalesChannelId, e.RemoteSalesId });
    }
}
