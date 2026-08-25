using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class CategorySalesChannelConfiguration : IEntityTypeConfiguration<CategorySalesChannel>
{
    public void Configure(EntityTypeBuilder<CategorySalesChannel> builder)
    {
        builder.HasIndex(e => new { e.TenantId, e.CategoryId, e.SalesChannelId })
            .IsUnique();

        builder.Property(e => e.RemoteCategoryId)
            .HasMaxLength(128);

        builder.Property(e => e.LastErrorMessage)
            .HasMaxLength(1000);

        builder.HasOne(e => e.Category)
            .WithMany(c => c.SalesChannels)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SalesChannel)
            .WithMany()
            .HasForeignKey(e => e.SalesChannelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
