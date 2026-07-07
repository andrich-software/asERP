using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class FeedProductConfiguration : IEntityTypeConfiguration<FeedProduct>
{
    public void Configure(EntityTypeBuilder<FeedProduct> builder)
    {
        // At most one inclusion-override row per (feed, product).
        builder.HasIndex(e => new { e.FeedId, e.ProductId })
            .IsUnique();

        builder.HasOne(e => e.Feed)
            .WithMany(f => f.FeedProducts)
            .HasForeignKey(e => e.FeedId)
            .OnDelete(DeleteBehavior.Cascade);

        // Removing a product clears its stale feed overrides. Independent cascade root (no cycle with Feed).
        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
