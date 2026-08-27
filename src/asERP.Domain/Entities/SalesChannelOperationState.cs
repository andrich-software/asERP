using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// Durable scheduling + progress state for one (channel, import operation) pair — one row per pair,
/// created lazily by the orchestrator. <see cref="NextDueAt"/> drives the orchestrator's indexed
/// due-query (replacing the load-every-channel-each-tick poll); <see cref="Watermark"/> is the durable
/// incremental baseline (replacing the MAX() scan over the run history); the cursor columns hold each
/// operation's resume position so a restart continues instead of starting over.
/// </summary>
/// <remarks>
/// Deliberately NOT <see cref="IConcurrencyStamped"/>, mirroring <see cref="SalesChannelSyncState"/>:
/// concurrent operations of one channel each write only their own row, and within a row the scheduler
/// and the running import write disjoint columns — a concurrency token would only re-introduce the
/// parallel-sync <c>DbUpdateConcurrencyException</c> the sync-state split fixed. Never move these
/// columns onto <see cref="SalesChannel"/>.
/// </remarks>
public class SalesChannelOperationState : BaseEntity, IBaseEntity
{
    public Guid SalesChannelId { get; set; }

    public SalesChannel? SalesChannel { get; set; }

    /// <summary>The import operation this row schedules. Unique together with <see cref="SalesChannelId"/>.</summary>
    public ChannelSyncOperation Operation { get; set; }

    public ChannelSyncPhase Phase { get; set; }

    /// <summary>When the operation should run next. Indexed — the scheduler's range-scan key.</summary>
    public DateTime NextDueAt { get; set; }

    /// <summary>
    /// Current adaptive interval in seconds: shrinks to the operation's minimum while deltas keep
    /// arriving, stretches toward the maximum while runs come back empty. 0 = not yet computed.
    /// </summary>
    public int CurrentIntervalSeconds { get; set; }

    /// <summary>Consecutive failed runs — drives exponential retry backoff; reset on success.</summary>
    public int ConsecutiveFailures { get; set; }

    /// <summary>
    /// Durable incremental baseline (UTC): the <c>StartedAt</c> of the last fully successful run of this
    /// operation. Only clean successes advance it — a failed or partial run keeps the previous baseline
    /// so the next run re-pulls the same window (idempotent upserts) instead of cementing a gap.
    /// </summary>
    public DateTime? Watermark { get; set; }

    /// <summary>Date-based resume cursor (e.g. the sales backfill's oldest-first date_created position).</summary>
    public DateTime? CursorDateTime { get; set; }

    /// <summary>Page-based resume cursor (e.g. the REST customer/product walk). 0 = start.</summary>
    public int CursorPage { get; set; }

    /// <summary>Free-form resume cursor (e.g. a keyset id on the direct-DB walks). Max length 400.</summary>
    public string? CursorText { get; set; }

    public DateTime? LastStartedAt { get; set; }

    /// <summary>Last structurally clean completion (walked off the end of the remote data set).</summary>
    public DateTime? LastSuccessAt { get; set; }

    /// <summary>Last completed full sweep — drives the rare full-reconciliation runs of delta operations.</summary>
    public DateTime? LastFullSweepAt { get; set; }
}
