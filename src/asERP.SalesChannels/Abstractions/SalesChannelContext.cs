using System.Net.Http;
using asERP.Domain.Entities;

namespace asERP.SalesChannels.Abstractions;

/// <summary>
/// Per-run context handed to a connector. Stateless connectors read everything they need from
/// here — credentials are already decrypted, the typed HttpClient already has Polly + auth set up,
/// and the audit row (<see cref="ChannelSyncRun"/>) is open and waiting for ItemsProcessed updates.
/// </summary>
public sealed class SalesChannelContext
{
    public required SalesChannel SalesChannel { get; init; }

    /// <summary>Decrypted Password (legacy field). Empty for OAuth-only channels.</summary>
    public string Password { get; init; } = string.Empty;

    /// <summary>Decrypted current OAuth access token. May be null/expired — connector should refresh as needed.</summary>
    public string? AccessToken { get; init; }

    /// <summary>Decrypted refresh token. Long-lived; rotated when the channel issues a new one.</summary>
    public string? RefreshToken { get; init; }

    /// <summary>HttpClient pre-configured with Polly retry/circuit-breaker and the channel's base URL.</summary>
    public required HttpClient HttpClient { get; init; }

    /// <summary>Sync-run audit row this dispatch logs against. Connector writes ItemsProcessed/Failed.</summary>
    public required ChannelSyncRun SyncRun { get; init; }

    /// <summary>
    /// Mid-run progress checkpoint: <c>(processed, failed, ct)</c>. A long import (e.g. a full order
    /// backfill that walks years of history in one run) should call this periodically so the audit row's
    /// item counts — and any cursor the connector advanced on the channel entity — are persisted *during*
    /// the run instead of only at <c>CloseRun</c>. Without it the Sync-Status dashboard shows 0 processed
    /// for hours. Null when no checkpoint sink is wired (the connector must null-check). Throttle calls
    /// (the dispatcher persists on every invocation); a few-seconds cadence is plenty.
    /// </summary>
    public Func<int, int, CancellationToken, Task>? ReportProgressAsync { get; init; }

    public Guid? TenantId { get; init; }

    /// <summary>
    /// Incremental-sync watermark: when set, the connector pulls only records modified at or after this
    /// UTC instant (e.g. WooCommerce <c>modified_after</c>) instead of re-fetching the full set every run.
    /// Null means a full import (first run, or operations without an incremental mode). Derived from the
    /// previous successful sync run, so failed runs do not advance it and the next run safely re-pulls.
    /// </summary>
    public DateTime? IncrementalSince { get; init; }

    public CancellationToken CancellationToken { get; init; }
}
