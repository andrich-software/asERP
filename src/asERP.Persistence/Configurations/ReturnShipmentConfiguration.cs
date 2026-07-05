using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ReturnShipmentConfiguration : IEntityTypeConfiguration<ReturnShipment>
{
    public void Configure(EntityTypeBuilder<ReturnShipment> builder)
    {
        builder.Property(e => e.RefundAmount).HasPrecision(18, 2);

        builder.Property(e => e.TrackingNumber).HasMaxLength(100);
        builder.Property(e => e.TrackingUrl).HasMaxLength(512);
        builder.Property(e => e.CarrierShipmentId).HasMaxLength(128);
        builder.Property(e => e.LabelFormat).HasMaxLength(32);
        builder.Property(e => e.LastCarrierStatusRaw).HasMaxLength(512);
        builder.Property(e => e.Note).HasMaxLength(2000);

        builder.HasIndex(e => e.SalesId);
        builder.HasIndex(e => new { e.TrackingNumber, e.TenantId });
        builder.HasIndex(e => e.Status);

        builder.HasOne(e => e.Sales)
            .WithMany()
            .HasForeignKey(e => e.SalesId)
            .OnDelete(DeleteBehavior.Restrict);

        // Informational link — deleting a (cancelled) outbound parcel must not delete returns.
        builder.HasOne(e => e.OriginalShipping)
            .WithMany()
            .HasForeignKey(e => e.OriginalShippingId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ShippingProvider)
            .WithMany()
            .HasForeignKey(e => e.ShippingProviderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
