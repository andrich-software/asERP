using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ReturnShipmentItemConfiguration : IEntityTypeConfiguration<ReturnShipmentItem>
{
    public void Configure(EntityTypeBuilder<ReturnShipmentItem> builder)
    {
        builder.Property(e => e.ReasonText).HasMaxLength(1000);

        // Hot path: summing already-returned quantities per order line.
        builder.HasIndex(e => e.SalesItemId);

        builder.HasOne(e => e.ReturnShipment)
            .WithMany(r => r.Items)
            .HasForeignKey(e => e.ReturnShipmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.SalesItem)
            .WithMany()
            .HasForeignKey(e => e.SalesItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
