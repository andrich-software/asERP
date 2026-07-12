using System.Collections.Concurrent;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Single hosted service that drives all sales-channel work: schedules import polling per
/// channel (using <c>SyncIntervalSeconds</c> + <c>LastSyncStartedAt</c>) and drains the
/// export outbox. Replaces every per-channel <c>IHostedService</c> in <c>Tasks/</c>.
/// </summary>
public sealed class SalesChannelOrchestrator : BackgroundService
{
    private static readonly TimeSpan DefaultTickInterval = TimeSpan.FromSeconds(10);

    // Purge expired sync logs roughly once a minute (every 6th 10s tick) — the flush itself runs each tick.
    private const int PurgeEveryTicks = 6;

    // Re-link sales items whose product was missing at import time roughly every 30 minutes. Covers the
    // "order imported before its product" race without any coupling between the two imports.
    private const int ReconcileEveryTicks = 180;

    // Batch size per reconcile SaveChanges, and a per-pass ceiling that bounds one tick's DB work when a
    // huge backlog (e.g. a fresh install's historical order pull) becomes linkable at once; the next pass
    // 30 minutes later continues where this one stopped.
    private const int ReconcileBatchSize = 500;
    private const int ReconcileMaxBatchesPerPass = 400;

    // Configurable so tests can drive the loop fast; production uses the 10s default.
    private readonly TimeSpan _tickInterval;

    // How long shutdown waits for in-flight background imports to observe cancellation and close their runs
    // cleanly before giving up (the startup orphan-sweep is the backstop for anything that overruns).
    private static readonly TimeSpan ShutdownDrainTimeout = TimeSpan.FromSeconds(20);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<SalesChannelOrchestrator> _logger;
    private int _tick;

    // Imports run as detached background tasks so a long run (e.g. a multi-hour order backfill) never
    // blocks the tick loop — which must keep draining sync logs and the outbox while the import walks.
    // Keyed by (channel, operation): a channel's product, sales and customer imports run concurrently
    // (each on its own DI scope; the shared ImportIdAllocator keeps id sequences unique), while the same
    // operation is never launched twice. Entries self-remove on completion.
    private readonly ConcurrentDictionary<(Guid ChannelId, ChannelSyncOperation Operation), Task> _inFlight = new();

    public SalesChannelOrchestrator(IServiceScopeFactory scopeFactory, ILogger<SalesChannelOrchestrator> logger)
        : this(scopeFactory, logger, DefaultTickInterval)
    {
    }

    // Test seam: lets the loop tick faster so the decoupling behaviour can be exercised without 10s waits.
    internal SalesChannelOrchestrator(IServiceScopeFactory scopeFactory, ILogger<SalesChannelOrchestrator> logger, TimeSpan tickInterval)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _tickInterval = tickInterval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("SalesChannelOrchestrator starting");

        await CleanupOrphanedRunsAsync(stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DrainOutboxAsync(stoppingToken);
                await DispatchQueuedRunsAsync(stoppingToken);
                await PollImportsAsync(stoppingToken);
                await DrainSyncLogsAsync(stoppingToken);

                if (++_tick % PurgeEveryTicks == 0)
                {
                    await PurgeSyncLogsAsync(stoppingToken);
                }

                if (_tick % ReconcileEveryTicks == 1)
                {
                    await ReconcileMissingProductsAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Orchestrator tick failed");
            }

            try
            {
                await Task.Delay(_tickInterval, stoppingToken);
            }
            catch (TaskCanceledException) { break; }
        }

        await DrainInFlightImportsAsync();

        _logger.LogInformation("SalesChannelOrchestrator stopping");
    }

    /// <summary>
    /// On shutdown, give the detached per-channel import tasks a bounded window to observe cancellation and
    /// close their <see cref="ChannelSyncRun"/> rows cleanly (the dispatcher closes a canceled run rather
    /// than leaving it Running). Best-effort: anything still running past the timeout is swept by the
    /// startup orphan cleanup on the next boot.
    /// </summary>
    private async Task DrainInFlightImportsAsync()
    {
        var pending = _inFlight.Values.ToArray();
        if (pending.Length == 0)
        {
            return;
        }

        try
        {
            await Task.WhenAll(pending).WaitAsync(ShutdownDrainTimeout);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Some in-flight channel imports did not finish within the shutdown drain window");
        }
    }

    /// <summary>
    /// On startup, mark any run still flagged <see cref="ChannelSyncRunStatus.Running"/> as failed. A run
    /// only stays "Running" if the process died mid-sync (crash, force-kill, or shutdown timeout), so any
    /// such row found at boot is by definition orphaned — nothing is actively writing to it. Runs across
    /// all tenants are swept (this is host-level housekeeping), hence <c>IgnoreQueryFilters</c>.
    /// </summary>
    private async Task CleanupOrphanedRunsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var cleaned = await context.ChannelSyncRun
                .IgnoreQueryFilters()
                .Where(r => r.Status == ChannelSyncRunStatus.Running)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(r => r.Status, ChannelSyncRunStatus.Failed)
                    .SetProperty(r => r.FinishedAt, DateTime.UtcNow)
                    .SetProperty(r => r.ErrorSummary, "Orphaned run: server restarted while the sync was in progress; marked failed on startup.")
                    .SetProperty(r => r.DateModified, DateTime.UtcNow),
                    cancellationToken);

            if (cleaned > 0)
            {
                _logger.LogWarning("Marked {Count} orphaned sync run(s) as failed on startup", cleaned);
            }

            // Any export outbox row still flagged InFlight at boot is orphaned by the same reasoning: nothing
            // was actively dispatching it when the process died. Reset to Pending so it re-dispatches instead
            // of being wedged forever (the enqueuer's stable idempotency key would otherwise route every
            // future change for that aggregate into the InFlight no-op branch). Age-independent here — at
            // startup no drain is running — complementing the drainer's staleness sweep during normal ops.
            var reclaimed = await context.ChannelExportOutbox
                .IgnoreQueryFilters()
                .Where(o => o.Status == ChannelOutboxStatus.InFlight)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.Status, ChannelOutboxStatus.Pending)
                    .SetProperty(o => o.NextAttemptAt, DateTime.UtcNow)
                    .SetProperty(o => o.LastError, "Recovered: server restarted while the export was in flight; reset to pending on startup.")
                    .SetProperty(o => o.DateModified, DateTime.UtcNow),
                    cancellationToken);

            if (reclaimed > 0)
            {
                _logger.LogWarning("Reset {Count} in-flight export outbox row(s) to pending on startup", reclaimed);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to clean up orphaned sync runs on startup");
        }
    }

    private async Task DrainOutboxAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var drainer = scope.ServiceProvider.GetRequiredService<OutboxDrainer>();
        var processed = await drainer.DrainOnceAsync(cancellationToken);
        if (processed > 0)
        {
            _logger.LogDebug("Drainer processed {Count} outbox rows", processed);
        }
    }

    /// <summary>
    /// Drains the outbox immediately after an import that may have enqueued stock pushes, instead of
    /// waiting up to a full tick — shaving ~10s off the order→stock-push latency. Racing the tick's own
    /// drain is tolerated: the drainer marks rows InFlight before dispatching and the pushes themselves
    /// are idempotent (absolute stock values), so a rare double dispatch is harmless.
    /// </summary>
    private async Task DrainOutboxAfterImportAsync(IServiceProvider scopedProvider, ChannelSyncOperation operation, CancellationToken cancellationToken)
    {
        if (operation is not (ChannelSyncOperation.ImportSaless or ChannelSyncOperation.ImportStock))
        {
            return;
        }

        try
        {
            var drainer = scopedProvider.GetRequiredService<OutboxDrainer>();
            await drainer.DrainOnceAsync(cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Post-import outbox drain failed");
        }
    }

    private async Task DrainSyncLogsAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var drainer = scope.ServiceProvider.GetRequiredService<SyncLogDrainer>();
        var persisted = await drainer.DrainOnceAsync(cancellationToken);
        if (persisted > 0)
        {
            _logger.LogDebug("Persisted {Count} sync log entries", persisted);
        }
    }

    private async Task PurgeSyncLogsAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var drainer = scope.ServiceProvider.GetRequiredService<SyncLogDrainer>();
        var purged = await drainer.PurgeExpiredAsync(cancellationToken);
        if (purged > 0)
        {
            _logger.LogDebug("Purged {Count} expired sync log entries", purged);
        }
    }

    /// <summary>
    /// Links sales items that were imported before their product existed (the importer keeps the raw SKU
    /// on <c>MissingProductSku</c>) to the now-imported product. Link only — no retroactive stock
    /// movements, since the mirrored level already reflects historical sales. Batched so a large backlog
    /// resolves over a few passes without one long-running sweep. Internal for tests.
    /// </summary>
    internal async Task ReconcileMissingProductsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Only rows whose product exists NOW are selected. Rows with a SKU that was never imported
            // (e.g. a product meanwhile deleted in the shop) are permanently unresolvable — a plain
            // "oldest 500 missing" scan re-reads exactly those rows every pass once they accumulate at
            // the head of the queue and never reaches the linkable rows behind them (observed in prod:
            // 1 of the oldest 500 resolvable while 160k+ linkable rows waited).
            var totalLinked = 0;
            for (var batch = 0; batch < ReconcileMaxBatchesPerPass; batch++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var linkable = await context.SalesItem
                    .IgnoreQueryFilters()
                    .Where(i => i.ProductId == Guid.Empty && i.MissingProductSku != null && i.MissingProductSku != "")
                    .Select(i => new
                    {
                        Item = i,
                        ProductId = context.Product
                            .Where(p => p.TenantId == i.TenantId && p.Sku == i.MissingProductSku)
                            .Select(p => (Guid?)p.Id)
                            .FirstOrDefault()
                    })
                    .Where(x => x.ProductId != null)
                    .OrderBy(x => x.Item.DateCreated)
                    .Take(ReconcileBatchSize)
                    .ToListAsync(cancellationToken);

                if (linkable.Count == 0)
                {
                    break;
                }

                foreach (var entry in linkable)
                {
                    entry.Item.ProductId = entry.ProductId!.Value;
                    entry.Item.MissingProductSku = string.Empty;
                    entry.Item.MissingProductEan = string.Empty;
                }

                await context.SaveChangesAsync(cancellationToken);
                totalLinked += linkable.Count;

                // Linked rows are Unchanged ballast for the next batch — drop them so DetectChanges
                // stays cheap while a large backlog drains.
                context.ChangeTracker.Clear();

                if (linkable.Count < ReconcileBatchSize)
                {
                    break;
                }
            }

            if (totalLinked > 0)
            {
                _logger.LogInformation("Reconciled {Count} sales items to their now-imported products", totalLinked);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Missing-product reconciliation failed");
        }
    }

    private async Task PollImportsAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var now = DateTime.UtcNow;
        // Provider-portable filter: pull enabled channels and gate in-memory by elapsed seconds
        // (EF.Functions.DateDiffSecond is SQL-Server-only and EF Core cannot translate
        // (now - LastSyncStartedAt).TotalSeconds across providers).
        var enabledChannels = await context.SalesChannel
            .IgnoreQueryFilters()
            .Include(s => s.SyncState)
            .Where(s => s.IsEnabled)
            .ToListAsync(cancellationToken);

        var dueChannels = enabledChannels
            .Where(s => s.SyncState.LastSyncStartedAt is null
                        || (now - s.SyncState.LastSyncStartedAt.Value).TotalSeconds >= s.SyncIntervalSeconds)
            .ToList();

        if (dueChannels.Count == 0)
        {
            return;
        }

        foreach (var channel in dueChannels)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var dueOperations = ComputeDueOperations(channel);

            // Skip operations still running in the background — a long run must not be re-launched every
            // tick. The dispatcher's per-(channel, op) lock is a second guard, but gating here also avoids
            // needlessly bumping LastSyncStartedAt.
            dueOperations.RemoveAll(op => _inFlight.ContainsKey((channel.Id, op)));
            if (dueOperations.Count == 0)
            {
                continue;
            }

            // Stamp the real start time now (this also gates re-triggering before the interval elapses) and
            // persist it before detaching the work.
            channel.SyncState.LastSyncStartedAt = now;
            await context.SaveChangesAsync(cancellationToken);

            // Launch each due operation on its own DI scope and do NOT await — the tick loop has to stay
            // free so DrainSyncLogsAsync / DrainOutboxAsync keep running while the imports walk their pages,
            // and a 15-minute order backfill must not block the channel's customer import.
            foreach (var operation in dueOperations)
            {
                LaunchDetached((channel.Id, operation), RunChannelOperationAsync(channel.Id, operation, cancellationToken));
            }
        }
    }

    /// <summary>
    /// Which scheduled operations are due for a channel. Products and customers are full pulls gated to
    /// run until their initial import completes once (the connectors flip the flags; clearing a flag
    /// re-enables the scheduled run). Sales and stock match products by SKU, so on a channel that also
    /// imports products they wait for the initial catalogue during a fresh setup: importing the order
    /// history against a half-imported catalogue floods the DB with missing-product lines ("Unknown
    /// Product") and silently skips stock rows — the missing-product reconciler is the safety net for
    /// the incremental race, not a substitute for the initial product import. A channel whose initial
    /// sales import already completed keeps importing orders (the reconciler heals the residual lines);
    /// only the historical backfill is held back. Manual (queued) runs stay ungated as the escape hatch.
    /// Internal for tests.
    /// </summary>
    internal static List<ChannelSyncOperation> ComputeDueOperations(SalesChannel channel)
    {
        var initialCatalogueReady = !channel.ImportProducts || channel.SyncState.InitialProductImportCompleted;

        var dueOperations = new List<ChannelSyncOperation>();
        if (channel.ImportProducts && !channel.SyncState.InitialProductImportCompleted)
        {
            dueOperations.Add(ChannelSyncOperation.ImportProducts);
        }
        if (channel.ImportSaless && (initialCatalogueReady || channel.SyncState.InitialSalesImportCompleted))
        {
            dueOperations.Add(ChannelSyncOperation.ImportSaless);
        }
        if (channel.ImportCustomers && !channel.SyncState.InitialCustomerImportCompleted)
        {
            dueOperations.Add(ChannelSyncOperation.ImportCustomers);
        }
        // The stock-master channel's levels are mirrored every interval (incremental via
        // modified_after — cheap on a steady shop; the first run is the full seed). The seed must not
        // run against a partial catalogue: unknown SKUs are skipped silently and the incremental pass
        // never re-visits them, so the mirror waits for the catalogue unconditionally.
        if (channel.ImportStock && initialCatalogueReady)
        {
            dueOperations.Add(ChannelSyncOperation.ImportStock);
        }

        return dueOperations;
    }

    /// <summary>Registers a detached import task under its in-flight key; the entry self-removes on completion.</summary>
    private void LaunchDetached((Guid ChannelId, ChannelSyncOperation Operation) key, Task task)
    {
        _inFlight[key] = task;
        _ = task.ContinueWith(_ => _inFlight.TryRemove(key, out var _removed), TaskScheduler.Default);
    }

    /// <summary>
    /// Dispatches manually enqueued runs (<see cref="ChannelSyncRunStatus.Queued"/>), oldest first. The
    /// queue is the ChannelSyncRun table itself, so pending triggers survive restarts. A run whose
    /// (channel, operation) is already in flight stays Queued and is retried next tick.
    /// </summary>
    private async Task DispatchQueuedRunsAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var queued = await context.ChannelSyncRun
            .IgnoreQueryFilters()
            .Where(r => r.Status == ChannelSyncRunStatus.Queued)
            .OrderBy(r => r.DateCreated)
            .Select(r => new { r.Id, r.SalesChannelId, r.Operation })
            .ToListAsync(cancellationToken);

        foreach (var queuedRun in queued)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var key = (queuedRun.SalesChannelId, queuedRun.Operation);
            if (_inFlight.ContainsKey(key))
            {
                continue;
            }

            LaunchDetached(key, RunQueuedRunAsync(queuedRun.Id, cancellationToken));
        }
    }

    /// <summary>
    /// Executes one queued manual run on a dedicated DI scope: loads the run + channel, hands the run row
    /// to the dispatcher for adoption, and persists any cursor progress the connector left on the channel.
    /// </summary>
    private async Task RunQueuedRunAsync(Guid runId, CancellationToken cancellationToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var dispatcher = scope.ServiceProvider.GetRequiredService<SyncDispatcher>();

            var run = await context.ChannelSyncRun
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == runId && r.Status == ChannelSyncRunStatus.Queued, cancellationToken);

            if (run is null)
            {
                return;
            }

            var channel = await context.SalesChannel
                .IgnoreQueryFilters()
                .Include(s => s.SyncState)
                .FirstOrDefaultAsync(s => s.Id == run.SalesChannelId, cancellationToken);

            if (channel is null || !channel.IsEnabled)
            {
                run.Status = ChannelSyncRunStatus.Failed;
                run.FinishedAt = DateTime.UtcNow;
                run.ErrorSummary = channel is null
                    ? "Sales channel no longer exists."
                    : "Sales channel is disabled.";
                await context.SaveChangesAsync(CancellationToken.None);
                return;
            }

            await dispatcher.RunImportAsync(channel, run.Operation, run.TriggerSource, cancellationToken, existingRun: run);

            // Persist cursor/flag progress the connector left on the tracked channel entity (backfill
            // cursor, initial-import flags) — same post-run save the scheduled path does.
            await context.SaveChangesAsync(CancellationToken.None);

            await DrainOutboxAfterImportAsync(scope.ServiceProvider, run.Operation, cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Expected on shutdown — the dispatcher already closed an adopted run as canceled; a still-
            // Queued row simply gets picked up again after the restart.
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Queued sync run {RunId} failed to dispatch", runId);
        }
    }

    /// <summary>
    /// Runs one scheduled import operation for a channel on a dedicated DI scope. Detached from the tick
    /// loop, so it owns its own <see cref="ApplicationDbContext"/> (the tick scope is disposed each tick
    /// and DbContext is not thread-safe). Each operation loads its own channel instance and mutates only
    /// its own cursor/flag columns, so concurrent operations of one channel never clobber each other.
    /// </summary>
    private async Task RunChannelOperationAsync(Guid channelId, ChannelSyncOperation operation, CancellationToken cancellationToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var dispatcher = scope.ServiceProvider.GetRequiredService<SyncDispatcher>();

            var channel = await context.SalesChannel
                .IgnoreQueryFilters()
                .Include(s => s.SyncState)
                .FirstOrDefaultAsync(s => s.Id == channelId, cancellationToken);

            if (channel is null)
            {
                return;
            }

            var run = await dispatcher.RunImportAsync(channel, operation, ChannelSyncTriggerSource.Scheduler, cancellationToken);

            // The product import is a full, non-incremental catalogue pull: once it has completed, flip the
            // gate so the scheduler stops re-importing the whole catalogue every interval. Sales/customer
            // imports maintain their own flags/cursors on the channel entity inside the connector.
            if (operation == ChannelSyncOperation.ImportProducts
                && run.Status is ChannelSyncRunStatus.Success or ChannelSyncRunStatus.PartialFailure)
            {
                channel.SyncState.InitialProductImportCompleted = true;
            }

            // Persist cursor/flag progress — even after a partial or shutdown-canceled run — so the next
            // run resumes instead of restarting. CancellationToken.None: this must still save when the
            // import's own token was canceled by a shutdown.
            await context.SaveChangesAsync(CancellationToken.None);

            await DrainOutboxAfterImportAsync(scope.ServiceProvider, operation, cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Expected on shutdown — the dispatcher already closed the in-progress run as canceled.
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Background {Operation} import failed for channel {ChannelId}", operation, channelId);
        }
    }
}
