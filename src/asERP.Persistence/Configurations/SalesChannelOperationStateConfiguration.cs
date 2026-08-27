using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class SalesChannelOperationStateConfiguration : IEntityTypeConfiguration<SalesChannelOperationState>
{
    public void Configure(EntityTypeBuilder<SalesChannelOperationState> builder)
    {
        // Owned by its channel, cascade-deleted with it. No reverse collection on SalesChannel — the
        // orchestrator/dispatcher always address a single (channel, operation) row directly.
        builder.HasOne(s => s.SalesChannel)
            .WithMany()
            .HasForeignKey(s => s.SalesChannelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => new { s.SalesChannelId, s.Operation }).IsUnique();

        // The scheduler's hot path: one range scan over "NextDueAt <= now" per tick.
        builder.HasIndex(s => s.NextDueAt);

        // The tenant filter is applied automatically (BaseEntity) — index TenantId to match the rest.
        builder.HasIndex(s => s.TenantId);

        builder.Property(s => s.CursorText).HasMaxLength(400);

        // No seed rows: the orchestrator self-heals missing rows every tick (including the seeded demo
        // POS channel), so tests and fresh databases need no fixture data here.
    }
}
