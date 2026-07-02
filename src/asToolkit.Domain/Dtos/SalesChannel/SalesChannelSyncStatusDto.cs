using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Dtos.SalesChannel;

/// <summary>
/// Aggregated, at-a-glance synchronization status for a single channel. Combines the channel's
/// scheduling state with the latest <c>ChannelSyncRun</c> per import operation, so the Client's
/// Sync-Status tab can show "last/next run + status" without paging the raw run stream.
/// </summary>
public class SalesChannelSyncStatusDto
{
    public Guid SalesChannelId { get; set; }

    /// <summary>Master kill-switch. When false, nothing is scheduled (<see cref="NextScheduledPollAt"/> is null).</summary>
    public bool IsEnabled { get; set; }

    /// <summary>Orchestrator poll cadence in seconds.</summary>
    public int SyncIntervalSeconds { get; set; }

    /// <summary>When the orchestrator's next poll is due: <c>(LastSyncStartedAt ?? now) + interval</c>. Null if disabled.</summary>
    public DateTime? NextScheduledPollAt { get; set; }

    /// <summary>Export jobs stuck in DeadLetter for this channel.</summary>
    public int DeadLetterCount { get; set; }

    /// <summary>Export jobs waiting in the outbox (the "stock push queue" depth).</summary>
    public int OutboxPendingCount { get; set; }

    /// <summary>Export jobs currently being dispatched.</summary>
    public int OutboxInFlightCount { get; set; }

    /// <summary>Age of the oldest waiting export job in seconds — the push-latency health signal. Null when the queue is empty.</summary>
    public double? OldestPendingOutboxAgeSeconds { get; set; }

    /// <summary>True once the order backfill has walked the whole remote history (then orders run incrementally).</summary>
    public bool InitialSalesImportCompleted { get; set; }

    /// <summary>How far back the oldest-first order backfill has reached (UTC date_created). Null = not started.</summary>
    public DateTime? SalesImportBackfillCursor { get; set; }

    /// <summary>Stock-ledger movements booked in the last 24 hours (channel's warehouse scope not applied — tenant-wide).</summary>
    public int StockMovementsLast24h { get; set; }

    /// <summary>Products with a negative mirrored stock level — the "sold without stock" data-quality alarm.</summary>
    public int NegativeStockCount { get; set; }

    public SyncOperationStatusDto Products { get; set; } = new();
    public SyncOperationStatusDto Customers { get; set; } = new();
    public SyncOperationStatusDto Saless { get; set; } = new();

    /// <summary>Stock mirror (only meaningful for the stock-master channel).</summary>
    public SyncOperationStatusDto Stock { get; set; } = new();
}

/// <summary>Status of one import operation (products / customers / orders) for a channel.</summary>
public class SyncOperationStatusDto
{
    public ChannelSyncOperation Operation { get; set; }

    /// <summary>The channel's Import flag for this operation (ImportProducts / ImportCustomers / ImportSaless).</summary>
    public bool IsImportEnabled { get; set; }

    /// <summary>
    /// Products/customers run their full import only once (gated by InitialXImportCompleted), then become
    /// manual-only. True once that initial import has completed. Not meaningful for orders (always false).
    /// </summary>
    public bool InitialImportCompleted { get; set; }

    /// <summary>True if a future scheduled poll will actually dispatch this operation.</summary>
    public bool WillRunOnSchedule { get; set; }

    /// <summary>Next scheduled run, or null when the operation is manual-only or the channel is paused.</summary>
    public DateTime? NextRunAt { get; set; }

    // Latest run for this operation (all null when there has never been a run).
    public ChannelSyncRunStatus? LastStatus { get; set; }
    public DateTime? LastStartedAt { get; set; }
    public DateTime? LastFinishedAt { get; set; }

    /// <summary>True if the latest run is still Running (Status == Running and no FinishedAt) — the hang detector.</summary>
    public bool IsRunning { get; set; }

    public int LastItemsProcessed { get; set; }
    public int LastItemsFailed { get; set; }

    /// <summary>Total items the run expects, when the remote reported it (enables a percentage display).</summary>
    public int? LastItemsTotal { get; set; }

    public string? LastErrorSummary { get; set; }
    public ChannelSyncTriggerSource? LastTriggerSource { get; set; }
}
