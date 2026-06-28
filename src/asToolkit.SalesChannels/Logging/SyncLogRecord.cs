using asToolkit.Domain.Enums;

namespace asToolkit.SalesChannels.Logging;

/// <summary>
/// In-memory carrier for a captured sync log line, sitting between the Serilog sink (producer) and
/// the <c>SyncLogDrainer</c> (consumer that persists it). Deliberately free of any Serilog types so
/// the SalesChannels layer needs no Serilog reference.
/// </summary>
public sealed record SyncLogRecord(
    Guid SalesChannelId,
    Guid? TenantId,
    Guid CorrelationId,
    ChannelSyncOperation Operation,
    ChannelSyncLogLevel Level,
    string Message,
    string? Exception,
    DateTime Timestamp);
