using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ShippingProviderRateConfiguration : IEntityTypeConfiguration<ShippingProviderRate>
{
    public void Configure(EntityTypeBuilder<ShippingProviderRate> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => new { e.ShippingProviderId, e.Name, e.TenantId })
            .IsUnique();

        builder.Property(e => e.MaxLength)
            .HasPrecision(18, 4);

        builder.Property(e => e.MaxWidth)
            .HasPrecision(18, 4);

        builder.Property(e => e.MaxHeight)
            .HasPrecision(18, 4);

        builder.Property(e => e.MaxWeight)
            .HasPrecision(18, 4);

        builder.Property(e => e.Price)
            .HasPrecision(18, 2);

        builder.HasMany(e => e.AllowedCountries)
            .WithOne(c => c.ShippingProviderRate)
            .HasForeignKey(c => c.ShippingProviderRateId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
