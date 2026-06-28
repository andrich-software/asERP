using asToolkit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asToolkit.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(e => new { e.TenantId, e.Sku })
            .IsUnique();

        builder.HasIndex(e => e.Gtin);

        builder.HasIndex(e => e.ParentProductId);

        builder.HasIndex(e => e.ProductType);

        builder.HasOne(e => e.ParentProduct)
            .WithMany(p => p.Variants)
            .HasForeignKey(e => e.ParentProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Price)
            .HasPrecision(18, 2);

        builder.Property(e => e.Msrp)
            .HasPrecision(18, 2);

        builder.Property(e => e.Weight)
            .HasPrecision(18, 4);

        builder.Property(e => e.Width)
            .HasPrecision(18, 4);

        builder.Property(e => e.Height)
            .HasPrecision(18, 4);

        builder.Property(e => e.Depth)
            .HasPrecision(18, 4);
    }
}