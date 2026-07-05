using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ReturnLabelOutboxConfiguration : IEntityTypeConfiguration<ReturnLabelOutbox>
{
    public void Configure(EntityTypeBuilder<ReturnLabelOutbox> builder)
    {
        // Drainer's hot path: pick rows that are ready to attempt now.
        builder.HasIndex(e => new { e.Status, e.NextAttemptAt });

        // Idempotency: one active return-label request per return.
        builder.HasIndex(e => new { e.ReturnShipmentId, e.IdempotencyKey })
            .IsUnique();

        builder.Property(e => e.IdempotencyKey)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(e => e.LastError).HasMaxLength(2000);

        builder.HasOne(e => e.ReturnShipment)
            .WithMany()
            .HasForeignKey(e => e.ReturnShipmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
