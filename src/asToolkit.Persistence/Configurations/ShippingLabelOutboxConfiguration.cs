using asToolkit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asToolkit.Persistence.Configurations;

public class ShippingLabelOutboxConfiguration : IEntityTypeConfiguration<ShippingLabelOutbox>
{
    public void Configure(EntityTypeBuilder<ShippingLabelOutbox> builder)
    {
        // Drainer's hot path: pick rows that are ready to attempt now.
        builder.HasIndex(e => new { e.Status, e.NextAttemptAt });

        // Idempotency: one active label request per shipment.
        builder.HasIndex(e => new { e.ShippingId, e.IdempotencyKey })
            .IsUnique();

        builder.Property(e => e.IdempotencyKey)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(e => e.LastError).HasMaxLength(2000);

        builder.HasOne(e => e.Shipping)
            .WithMany()
            .HasForeignKey(e => e.ShippingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
