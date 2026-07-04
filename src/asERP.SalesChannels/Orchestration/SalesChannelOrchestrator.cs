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
    /// resolves over a few passes without one long-running sweep.
    /// </summary>
    private async Task ReconcileMissingProductsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var items = await context.SalesItem
                .IgnoreQueryFilters()
                .Where(i => i.ProductId == Guid.Empty && i.MissingProductSku != null && i.MissingProductSku != "")
                .OrderBy(i => i.DateCreated)
                .Take(500)
                .ToListAsync(cancellationToken);

            if (items.Count == 0)
            {
                return;
            }

            var skus = items.Select(i => i.MissingProductSku!).Distinct().ToList();
            var products = await context.Product
                .IgnoreQueryFilters()
                .Where(p => skus.Contains(p.Sku))
                .Select(p => new { p.Id, p.Sku, p.TenantId })
                .ToListAsync(cancellationToken);

            var bySku = products
                .GroupBy(p => (p.TenantId, p.Sku))
                .ToDictionary(g => g.Key, g => g.First().Id);

            var linked = 0;
            foreach (var item in items)
            {
                if (bySku.TryGetValue((item.TenantId, item.MissingProductSku!), out var productId))
                {
                    item.ProductId = productId;
                    item.MissingProductSku = string.Empty;
                    item.MissingProductEan = string.Empty;
                    linked++;
                }
            }

            if (linked > 0)
            {
                await context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Reconciled {Count} sales items to their now-imported products", linked);
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
            .Where(s => s.IsEnabled)
            .ToListAsync(cancellationToken);

        var dueChannels = enabledChannels
            .Where(s => s.LastSyncStartedAt is null
                        || (now - s.LastSyncStartedAt.Value).TotalSeconds >= s.SyncIntervalSeconds)
            .ToList();

        if (dueChannels.Count == 0)
        {
            return;
        }

        foreach (var channel in dueChannels)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Which operations are due for this channel. Products and customers are full pulls gated to
            // run until their initial import completes once (the connectors flip the flags; clearing a
            // flag re-enables the scheduled run). Sales runs every interval (incremental or backfill chunk).
            var dueOperations = new List<ChannelSyncOperation>();
            if (channel.ImportProducts && !channel.InitialProductImportCompleted)
            {
                dueOperations.Add(ChannelSyncOperation.ImportProducts);
            }
            if (channel.ImportSaless)
            {
                dueOperations.Add(ChannelSyncOperation.ImportSaless);
            }
            if (channel.ImportCustomers && !channel.InitialCustomerImportCompleted)
            {
                dueOperations.Add(ChannelSyncOperation.ImportCustomers);
            }
            // The stock-master channel's levels are mirrored every interval (incremental via
            // modified_after — cheap on a steady shop; the first run is the full seed).
            if (channel.ImportStock)
            {
                dueOperations.Add(ChannelSyncOperation.ImportStock);
            }

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
            channel.LastSyncStartedAt = now;
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
                channel.InitialProductImportCompleted = true;
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
