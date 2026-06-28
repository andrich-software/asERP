using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.SalesChannels.Orchestration;

/// <summary>
/// Persists captured sync log lines from the in-memory <see cref="ISalesChannelSyncLogBuffer"/> into
/// <c>channel_sync_log</c>, and enforces the 24h retention by deleting expired rows. Runs in the
/// orchestrator's per-tick scope, mirroring <see cref="OutboxDrainer"/>.
/// </summary>
public sealed class SyncLogDrainer
{
    private const int BatchSize = 500;
    private static readonly TimeSpan Retention = TimeSpan.FromHours(24);

    private readonly ApplicationDbContext _context;
    private readonly ISalesChannelSyncLogBuffer _buffer;
    private readonly ILogger<SyncLogDrainer> _logger;

    public SyncLogDrainer(ApplicationDbContext context, ISalesChannelSyncLogBuffer buffer, ILogger<SyncLogDrainer> logger)
    {
        _context = context;
        _buffer = buffer;
        _logger = logger;
    }

    /// <summary>Flushes buffered log records to the database. Returns the number persisted.</summary>
    public async Task<int> DrainOnceAsync(CancellationToken cancellationToken)
    {
        var records = new List<SyncLogRecord>(BatchSize);
        if (_buffer.Drain(records, BatchSize) == 0)
        {
            return 0;
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
        return records.Count;
    }

    /// <summary>Deletes log rows older than the 24h retention window across all tenants.</summary>
    public async Task<int> PurgeExpiredAsync(CancellationToken cancellationToken)
    {
        var cutoff = DateTime.UtcNow - Retention;
        return await _context.ChannelSyncLog
            .IgnoreQueryFilters()
            .Where(x => x.Timestamp < cutoff)
            .ExecuteDeleteAsync(cancellationToken);
    }
}
