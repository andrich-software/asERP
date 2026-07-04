using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// A single synchronization log line for a sales channel, captured from the structured logs
/// emitted during an import/export dispatch. Lets the Client surface the concrete problems of a
/// sync (e.g. "no tax class for rate 19", "import failed for SKU X") to the user, not just the
/// coarse counters on <see cref="ChannelSyncRun"/>. Retained for 24h; pruned by the orchestrator.
/// </summary>
public class ChannelSyncLog : BaseEntity, IBaseEntity
{
    public Guid SalesChannelId { get; set; }
    public SalesChannel? SalesChannel { get; set; }

    /// <summary>Ties the entry to the <see cref="ChannelSyncRun.CorrelationId"/> that produced it.</summary>
    public Guid CorrelationId { get; set; }

    public ChannelSyncOperation Operation { get; set; }
    public ChannelSyncLogLevel Level { get; set; }

    /// <summary>Rendered log message (truncated).</summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>Full exception text when the log event carried one (truncated). Null otherwise.</summary>
    public string? Exception { get; set; }

    /// <summary>Timestamp of the original log event (UTC), independent of <see cref="BaseEntity.DateCreated"/>.</summary>
    public DateTime Timestamp { get; set; }
}
