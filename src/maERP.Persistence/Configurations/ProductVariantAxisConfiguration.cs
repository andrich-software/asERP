using maERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maERP.Persistence.Configurations;

public class ProductVariantAxisConfiguration : IEntityTypeConfiguration<ProductVariantAxis>
{
    public void Configure(EntityTypeBuilder<ProductVariantAxis> builder)
    {
        builder.HasIndex(e => new { e.ParentProductId, e.ProductAttributeId })
            .IsUnique();

        builder.HasOne(e => e.ParentProduct)
            .WithMany(p => p.VariantAxes)
            .HasForeignKey(e => e.ParentProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProductAttribute)
            .WithMany()
            .HasForeignKey(e => e.ProductAttributeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
