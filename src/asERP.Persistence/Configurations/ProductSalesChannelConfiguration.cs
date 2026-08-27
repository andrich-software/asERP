using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ProductSalesChannelConfiguration : IEntityTypeConfiguration<ProductSalesChannel>
{
    public void Configure(EntityTypeBuilder<ProductSalesChannel> builder)
    {
        builder.HasIndex(e => new { e.TenantId, e.ProductId, e.SalesChannelId })
            .IsUnique();

        // Hot lookup of the imports/exports: resolve a shop's remote product id to the local link
        // (stock mirror, variant matching, export hydration). Non-unique — remote ids can be empty
        // and, across re-created shop products, transiently duplicated.
        builder.HasIndex(e => new { e.SalesChannelId, e.RemoteProductId });

        builder.Property(e => e.Price)
            .HasPrecision(18, 2);

        builder.Property(e => e.MinPrice)
            .HasPrecision(18, 2);

        builder.Property(e => e.MaxPrice)
            .HasPrecision(18, 2);

        builder.Property(e => e.MinimumProfit)
            .HasPrecision(18, 2);

        builder.Property(e => e.Currency)
            .HasMaxLength(3);

        builder.Property(e => e.RemoteProductId)
            .HasMaxLength(128);

        builder.Property(e => e.ExternalListingId)
            .HasMaxLength(128);

        builder.Property(e => e.LastExportHash)
            .HasMaxLength(64);

        builder.Property(e => e.LastErrorMessage)
            .HasMaxLength(1000);
    }
}
