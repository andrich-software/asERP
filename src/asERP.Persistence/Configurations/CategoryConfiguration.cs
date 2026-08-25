using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Slug)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .HasMaxLength(4000);

        // Sibling names must be unique per tenant (same rule as Shopware/WooCommerce trees).
        builder.HasIndex(e => new { e.TenantId, e.ParentCategoryId, e.Name })
            .IsUnique();

        builder.HasIndex(e => e.ParentCategoryId);

        builder.HasOne(e => e.ParentCategory)
            .WithMany(p => p.Children)
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
