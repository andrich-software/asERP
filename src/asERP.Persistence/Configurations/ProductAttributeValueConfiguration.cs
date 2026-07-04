using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.Property(e => e.Value)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(e => new { e.TenantId, e.ProductAttributeId, e.Value })
            .IsUnique();

        builder.HasOne(e => e.ProductAttribute)
            .WithMany(a => a.Values)
            .HasForeignKey(e => e.ProductAttributeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
