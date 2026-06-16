using maERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maERP.Persistence.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasIndex(e => new { e.ProductId, e.SortOrder });

        builder.Property(e => e.FileName).HasMaxLength(128);
        builder.Property(e => e.RelativePath).HasMaxLength(256);
        builder.Property(e => e.ThumbnailPath).HasMaxLength(256);
        builder.Property(e => e.OriginalFileName).HasMaxLength(512);
        builder.Property(e => e.AltText).HasMaxLength(512);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
