using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.SalesChannels.Orchestration;

/// <summary>
/// Persists captured sync log lines from the in-memory <see cref="ISalesChannelSyncLogBuffer"/> into
/// <c>channel_sync_log</c>, and enforces the retention (configurable via the
/// <c>SalesChannel.SyncLogRetentionHours</c> setting, default 24h) by deleting expired rows. Runs in
/// the orchestrator's per-tick scope, mirroring <see cref="OutboxDrainer"/>.
/// </summary>
public sealed class SyncLogDrainer
{
    private const int BatchSize = 500;
    public const string RetentionSettingKey = "SalesChannel.SyncLogRetentionHours";
    private static readonly TimeSpan DefaultRetention = TimeSpan.FromHours(24);

    private readonly ApplicationDbContext _context;
    private readonly ISalesChannelSyncLogBuffer _buffer;
    private readonly ILogger<SyncLogDrainer> _logger;

    public SyncLogDrainer(ApplicationDbContext context, ISalesChannelSyncLogBuffer buffer, ILogger<SyncLogDrainer> logger)
    {
        _context = context;
        _buffer = buffer;
        _logger = logger;
    }

    /// <summary>
    /// Flushes buffered log records to the database, looping until the buffer is empty. Returns the total
    /// number persisted. Draining the whole buffer per tick (rather than a single 500-row batch) keeps a
    /// burst — e.g. a chatty order backfill emitting thousands of lines between ticks — from lagging behind
    /// and eventually overflowing the bounded in-memory buffer.
    /// </summary>
    public async Task<int> DrainOnceAsync(CancellationToken cancellationToken)
    {
        var total = 0;

        while (true)
        {
            var records = new List<SyncLogRecord>(BatchSize);
            if (_buffer.Drain(records, BatchSize) == 0)
            {
                break;
            }

            foreach (var r in records)
            {
                _context.ChannelSyncLog.Add(new ChannelSyncLog
                {
                    Id = Guid.NewGuid(),
                    // Set the tenant explicitly: this scope has no tenant context, and the DbContext's
                    // auto-assignment only fills TenantId when it is null.
                    TenantId = r.TenantId,
                    SalesChannelId = r.SalesChannelId,
                    CorrelationId = r.CorrelationId,
                    Operation = r.Operation,
                    Level = r.Level,
                    Message = r.Message,
                    Exception = r.Exception,
                    Timestamp = r.Timestamp,
                });
            }

            await _context.SaveChangesAsync(cancellationToken);
            total += records.Count;

            // Stop the change tracker from accumulating every flushed row across batches (this scope only
            // ever inserts logs, so clearing is safe) and end once the buffer returned a short batch.
            _context.ChangeTracker.Clear();
            if (records.Count < BatchSize)
            {
                break;
            }
        }

        return total;
    }

    /// <summary>Deletes log rows older than the retention window across all tenants.</summary>
    public async Task<int> PurgeExpiredAsync(CancellationToken cancellationToken)
    {
        var cutoff = DateTime.UtcNow - await ResolveRetentionAsync();
        return await _context.ChannelSyncLog
            .IgnoreQueryFilters()
            .Where(x => x.Timestamp < cutoff)
            .ExecuteDeleteAsync(cancellationToken);
    }

    /// <summary>
    /// Retention from the settings table (hours, 1–720), defaulting to 24h when unset/invalid. Read per
    /// purge (~1/minute) so a changed setting applies without a restart.
    /// </summary>
    private async Task<TimeSpan> ResolveRetentionAsync()
    {
        try
        {
            var raw = await _context.Setting
                .Where(s => s.Key == RetentionSettingKey)
                .Select(s => s.Value)
                .FirstOrDefaultAsync();

            if (int.TryParse(raw, out var hours) && hours is >= 1 and <= 720)
            {
                return TimeSpan.FromHours(hours);
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Could not read {Key}; using default retention", RetentionSettingKey);
        }

        return DefaultRetention;
    }
}
