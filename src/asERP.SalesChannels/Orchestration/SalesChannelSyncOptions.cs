using asERP.Domain.Enums;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Tunables of the sales-channel sync engine, bound from the <c>"SalesChannelSync"</c> appsettings
/// section. Every value has a production-ready default, so the section is optional; ops can override
/// individual knobs without redeploying code. Per-channel settings (the Import*/Export* flags,
/// <c>SyncIntervalSeconds</c> as the order-import base interval and global floor, <c>IsEnabled</c>,
/// <c>WebhookSecret</c>) stay on the <c>SalesChannel</c> row — this class holds engine-wide policy.
/// </summary>
public sealed class SalesChannelSyncOptions
{
    public const string Section = "SalesChannelSync";

    /// <summary>Orchestrator tick. The scheduler's reaction latency, not a sync interval.</summary>
    public int TickSeconds { get; set; } = 10;

    /// <summary>Max operations launched per tick — bounds fan-out, prevents per-op starvation.</summary>
    public int MaxLaunchesPerTick { get; set; } = 8;

    /// <summary>
    /// Re-check delay for a due operation held back by gating (e.g. sales waiting for the initial
    /// product import) — keeps gated rows from re-surfacing in the due-query every tick.
    /// </summary>
    public int GatingRecheckSeconds { get; set; } = 30;

    /// <summary>
    /// A Running run whose heartbeat is older than this is marked failed by the live orphan sweep.
    /// Must stay comfortably above the longest silent stretch of a healthy run (page retries ≈ 3-4 min).
    /// </summary>
    public int OrphanRunTimeoutMinutes { get; set; } = 15;

    /// <summary>
    /// Hard ceiling per connector invocation, enforced via a linked cancellation token. Converts a
    /// hung connector call ("blocked until process restart") into a failed run that frees the
    /// per-(channel, operation) lock. Must exceed every operation's time box plus retry headroom.
    /// </summary>
    public int RunHardTimeoutMinutes { get; set; } = 45;

    /// <summary>
    /// Delay between chained chunks while an operation's initial walk is still incomplete: the pacing
    /// of an initial import is its time box, not the channel interval — chunks run back-to-back.
    /// </summary>
    public int InitialChainDelaySeconds { get; set; } = 5;

    /// <summary>
    /// Safety overlap subtracted from the incremental watermark (clock skew between host and shop,
    /// changes landing mid-run). Re-pulling a few seen items is harmless — imports are idempotent.
    /// </summary>
    public int IncrementalOverlapMinutes { get; set; } = 60;

    public FailureBackoffOptions FailureBackoff { get; set; } = new();

    public StockSyncOptions Stock { get; set; } = new();

    public SyncOperationOptions ImportSaless { get; set; } = new()
    {
        MinIntervalSeconds = 60,
        MaxIntervalSeconds = 900,
    };

    public SyncOperationOptions ImportProducts { get; set; } = new()
    {
        MinIntervalSeconds = 300,
        MaxIntervalSeconds = 21_600,
        FullSweepDays = 7,
    };

    public SyncOperationOptions ImportCustomers { get; set; } = new()
    {
        MinIntervalSeconds = 900,
        MaxIntervalSeconds = 86_400,
        FullSweepDays = 7,
    };

    public SyncOperationOptions ImportStock { get; set; } = new()
    {
        MinIntervalSeconds = 3_600,
        MaxIntervalSeconds = 86_400,
    };

    public SyncOperationOptions ImportCategories { get; set; } = new()
    {
        MinIntervalSeconds = 86_400,
        MaxIntervalSeconds = 86_400,
    };

    public SyncOperationOptions For(ChannelSyncOperation operation) => operation switch
    {
        ChannelSyncOperation.ImportSaless => ImportSaless,
        ChannelSyncOperation.ImportProducts => ImportProducts,
        ChannelSyncOperation.ImportCustomers => ImportCustomers,
        ChannelSyncOperation.ImportStock => ImportStock,
        ChannelSyncOperation.ImportCategories => ImportCategories,
        // Exports are outbox-driven and never scheduled through operation state; a sensible fallback
        // keeps a misrouted call harmless instead of throwing inside the scheduler.
        _ => ImportSaless,
    };
}

public sealed class StockSyncOptions
{
    /// <summary>
    /// Book sale decrements for orders imported from the stock-master channel too, as a near-real-time
    /// mirror substitute between the rare absolute sweeps. The sweep-start baseline prevents double
    /// counting (sales already reflected in the last sweep never book), the exactly-once index prevents
    /// re-booking, and every absolute sweep re-pins the true level regardless.
    /// </summary>
    public bool MirrorSaleDecrementsOnStockMaster { get; set; } = true;
}

public sealed class FailureBackoffOptions
{
    /// <summary>First retry delay after a failed run; doubles per consecutive failure.</summary>
    public int BaseSeconds { get; set; } = 60;

    /// <summary>Backoff ceiling — a persistently failing channel retries at most this often.</summary>
    public int MaxSeconds { get; set; } = 3_600;
}

public sealed class SyncOperationOptions
{
    /// <summary>
    /// Floor of the adaptive interval. The effective minimum is
    /// <c>max(MinIntervalSeconds, channel.SyncIntervalSeconds)</c> — the channel value stays the
    /// per-channel base knob.
    /// </summary>
    public int MinIntervalSeconds { get; set; } = 60;

    /// <summary>Ceiling the interval stretches to while runs keep coming back empty.</summary>
    public int MaxIntervalSeconds { get; set; } = 3_600;

    /// <summary>Stretch factor applied per idle run (no items); activity snaps back to the minimum.</summary>
    public double IdleStretchFactor { get; set; } = 1.5;

    /// <summary>
    /// Interval of the rare full-reconciliation sweep for delta operations (null = never forced).
    /// Consumed once the operation runs incrementally.
    /// </summary>
    public int? FullSweepDays { get; set; }
}
