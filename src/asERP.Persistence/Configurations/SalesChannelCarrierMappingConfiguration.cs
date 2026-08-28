using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesChannelCarrierMappingConfiguration : IEntityTypeConfiguration<SalesChannelCarrierMapping>
{
    public void Configure(EntityTypeBuilder<SalesChannelCarrierMapping> builder)
    {
        builder.Property(m => m.RemoteCarrierCode)
            .IsRequired()
            .HasMaxLength(100);

        // One translation per (channel, remote code). Codes are normalized to lower case on write so
        // the uniqueness holds identically on the case-sensitive (PostgreSQL) and case-insensitive
        // (MSSQL default collation) providers.
        builder.HasIndex(m => new { m.SalesChannelId, m.RemoteCarrierCode }).IsUnique();

        builder.HasOne(m => m.SalesChannel)
            .WithMany(c => c.CarrierMappings)
            .HasForeignKey(m => m.SalesChannelId)
            // Backstop only — SalesChannelDelete removes the rows explicitly (repo rule; the InMemory
            // provider used in tests does not cascade).
            .OnDelete(DeleteBehavior.Cascade);

        // A provider that is still referenced by a mapping must not vanish underneath the importer;
        // deleting it is a deliberate operator action that has to clear the mapping first.
        builder.HasOne(m => m.ShippingProvider)
            .WithMany()
            .HasForeignKey(m => m.ShippingProviderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => m.ShippingProviderId);

        // The tenant filter is applied automatically (BaseEntity) — index TenantId to match the rest.
        builder.HasIndex(m => m.TenantId);
    }
}
