using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class FeedLogConfiguration : IEntityTypeConfiguration<FeedLog>
{
    public void Configure(EntityTypeBuilder<FeedLog> builder)
    {
        // Both "last accessed" and the Log tab read newest-first per feed.
        builder.HasIndex(e => new { e.FeedId, e.DateCreated })
            .IsDescending(false, true);

        builder.Property(e => e.IpAddress)
            .HasMaxLength(45); // IPv6 max textual length

        builder.Property(e => e.UserAgent)
            .HasMaxLength(512);

        builder.HasOne(e => e.Feed)
            .WithMany(f => f.FeedLogs)
            .HasForeignKey(e => e.FeedId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
