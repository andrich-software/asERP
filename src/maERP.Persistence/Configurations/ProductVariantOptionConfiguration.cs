using maERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace maERP.Persistence.Configurations;

public class ProductVariantOptionConfiguration : IEntityTypeConfiguration<ProductVariantOption>
{
    public void Configure(EntityTypeBuilder<ProductVariantOption> builder)
    {
        builder.HasIndex(e => new { e.ProductId, e.ProductAttributeValueId })
            .IsUnique();

        builder.HasOne(e => e.Product)
            .WithMany(p => p.VariantOptions)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProductAttributeValue)
            .WithMany()
            .HasForeignKey(e => e.ProductAttributeValueId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
