using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesChannelSyncStateConfiguration : IEntityTypeConfiguration<SalesChannelSyncState>
{
    public void Configure(EntityTypeBuilder<SalesChannelSyncState> builder)
    {
        // 1:1 with SalesChannel via a unique FK; the sync state is fully owned by its channel and
        // cascade-deleted with it (a channel never outlives, nor is outlived by, its sync state).
        builder.HasOne(s => s.SalesChannel)
            .WithOne(c => c.SyncState)
            .HasForeignKey<SalesChannelSyncState>(s => s.SalesChannelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => s.SalesChannelId).IsUnique();

        // The tenant filter is applied automatically (BaseEntity) — index TenantId to match the rest.
        builder.HasIndex(s => s.TenantId);

        // Sync state for the demo "Kasse Ladengeschäft" POS channel seeded in SalesChannelConfiguration.
        builder.HasData(new SalesChannelSyncState
        {
            Id = new Guid("99999999-9999-9999-9999-999999999999"),
            SalesChannelId = new Guid("88888888-8888-8888-8888-888888888888"),
            TenantId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), // Demo tenant ID
        });
    }
}
