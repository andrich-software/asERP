using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ChannelSyncLogConfiguration : IEntityTypeConfiguration<ChannelSyncLog>
{
    public void Configure(EntityTypeBuilder<ChannelSyncLog> builder)
    {
        // Primary read pattern: newest entries for a channel.
        builder.HasIndex(e => new { e.SalesChannelId, e.Timestamp })
            .IsDescending(false, true);

        // Group all lines of one run together.
        builder.HasIndex(e => e.CorrelationId);

        // Backs the 24h retention purge.
        builder.HasIndex(e => e.Timestamp);

        builder.Property(e => e.Message).HasMaxLength(4000);
        builder.Property(e => e.Exception).HasMaxLength(8000);

        builder.HasOne(e => e.SalesChannel)
            .WithMany()
            .HasForeignKey(e => e.SalesChannelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
