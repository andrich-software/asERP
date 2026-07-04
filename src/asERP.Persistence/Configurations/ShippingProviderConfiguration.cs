using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ShippingProviderConfiguration : IEntityTypeConfiguration<ShippingProvider>
{
    public void Configure(EntityTypeBuilder<ShippingProvider> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => new { e.Name, e.TenantId })
            .IsUnique();

        builder.Property(e => e.Username).HasMaxLength(255);

        // Encrypted at rest — stored ciphertext is much longer than the plain credential.
        builder.Property(e => e.Password).HasMaxLength(4096);
        builder.Property(e => e.ApiKey).HasMaxLength(4096);
        builder.Property(e => e.ApiSecret).HasMaxLength(4096);

        builder.Property(e => e.AccountNumber).HasMaxLength(64);

        builder.HasMany(e => e.ShippingRates)
            .WithOne(r => r.ShippingProvider)
            .HasForeignKey(r => r.ShippingProviderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
