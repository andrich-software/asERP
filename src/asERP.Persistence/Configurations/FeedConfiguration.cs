using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class FeedConfiguration : IEntityTypeConfiguration<Feed>
{
    public void Configure(EntityTypeBuilder<Feed> builder)
    {
        builder.Property(e => e.ConcurrencyToken)
            .IsConcurrencyToken();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Currency)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(e => e.DefaultDeliveryTime)
            .HasMaxLength(100);

        builder.Property(e => e.DefaultShippingCost)
            .HasPrecision(18, 2);

        // Optional link to a Shopware6/WooCommerce channel, used only to build product deep-links.
        // SetNull (not Cascade): deleting the channel must not delete the feed — just clear the link.
        builder.HasOne(e => e.SalesChannel)
            .WithMany()
            .HasForeignKey(e => e.SalesChannelId)
            .OnDelete(DeleteBehavior.SetNull);

        // Every query carries the tenant filter — index TenantId so list endpoints don't full-scan.
        builder.HasIndex(e => e.TenantId);
    }
}
