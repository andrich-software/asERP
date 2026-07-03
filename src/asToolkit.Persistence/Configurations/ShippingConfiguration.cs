using asToolkit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asToolkit.Persistence.Configurations;

public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder.Property(e => e.ShippingCost)
            .HasPrecision(18, 2);

        builder.Property(e => e.WeightKg).HasPrecision(18, 4);
        builder.Property(e => e.LengthCm).HasPrecision(18, 4);
        builder.Property(e => e.WidthCm).HasPrecision(18, 4);
        builder.Property(e => e.HeightCm).HasPrecision(18, 4);

        builder.Property(e => e.TrackingNumber).HasMaxLength(100);
        builder.Property(e => e.TrackingUrl).HasMaxLength(512);
        builder.Property(e => e.CarrierShipmentId).HasMaxLength(128);
        builder.Property(e => e.LabelFormat).HasMaxLength(32);
        builder.Property(e => e.LastCarrierStatusRaw).HasMaxLength(512);

        builder.HasIndex(e => e.SalesId);
        builder.HasIndex(e => new { e.TrackingNumber, e.TenantId });

        // Tracking-poller hot path: fetch non-terminal shipments.
        builder.HasIndex(e => e.Status);

        builder.HasOne(e => e.Sales)
            .WithMany(s => s.Shippings)
            .HasForeignKey(e => e.SalesId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ShippingProvider)
            .WithMany()
            .HasForeignKey(e => e.ShippingProviderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ShippingProviderRate)
            .WithMany()
            .HasForeignKey(e => e.ShippingProviderRateId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
