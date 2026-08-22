using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ShopDomainConfiguration : IEntityTypeConfiguration<ShopDomain>
{
    public void Configure(EntityTypeBuilder<ShopDomain> builder)
    {
        builder.Property(d => d.Host)
            .IsRequired()
            .HasMaxLength(255);

        // A hostname resolves to exactly one channel across ALL tenants — the host is the
        // security boundary of anonymous tenant resolution, so this unique index deliberately
        // has no TenantId component. Port 0 is the "any port" sentinel (not null, so the unique
        // index semantics are identical across MSSQL/PostgreSQL/SQLite).
        builder.HasIndex(d => new { d.Host, d.Port }).IsUnique();

        builder.HasOne(d => d.SalesChannel)
            .WithMany(c => c.ShopDomains)
            .HasForeignKey(d => d.SalesChannelId)
            // Backstop only — SalesChannelDelete removes the rows explicitly (repo rule; InMemory
            // provider used in tests does not cascade).
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(d => d.SalesChannelId);

        // The tenant filter is applied automatically (BaseEntity) — index TenantId to match the rest.
        builder.HasIndex(d => d.TenantId);
    }
}
