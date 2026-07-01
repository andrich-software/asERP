using System.Collections.Concurrent;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asToolkit.SalesChannels.Orchestration;

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

    // Configurable so tests can drive the loop fast; production uses the 10s default.
    private readonly TimeSpan _tickInterval;

    // How long shutdown waits for in-flight background imports to observe cancellation and close their runs
    // cleanly before giving up (the startup orphan-sweep is the backstop for anything that overruns).
    private static readonly TimeSpan ShutdownDrainTimeout = TimeSpan.FromSeconds(20);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<SalesChannelOrchestrator> _logger;
    private int _tick;

    // Per-channel imports run as detached background tasks so a long run (e.g. a multi-hour order backfill)
    // never blocks the tick loop — which must keep draining sync logs and the outbox while the import walks.
    // Keyed by channel id; an entry's presence means "an import for this channel is in flight", which gates
    // re-launching the same channel each tick. Entries self-remove on completion.
    private readonly ConcurrentDictionary<Guid, Task> _inFlight = new();

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
                await PollImportsAsync(stoppingToken);
                await DrainSyncLogsAsync(stoppingToken);

                if (++_tick % PurgeEveryTicks == 0)
                {
                    await PurgeSyncLogsAsync(stoppingToken);
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

            // Skip channels whose previous import is still running in the background — a long run must not
            // be re-launched (and re-stamped) every tick. The dispatcher's per-channel lock is a second
            // guard, but gating here also avoids needlessly bumping LastSyncStartedAt.
            if (_inFlight.ContainsKey(channel.Id))
            {
                continue;
            }

            // Stamp the real start time now (this also gates re-triggering before the interval elapses) and
            // persist it before detaching the work.
            channel.LastSyncStartedAt = now;
            await context.SaveChangesAsync(cancellationToken);

            // Launch the channel's imports on their own DI scope and do NOT await — the tick loop has to stay
            // free so DrainSyncLogsAsync / DrainOutboxAsync keep running while this import walks its pages.
            var channelId = channel.Id;
            var task = RunChannelImportsAsync(channelId, cancellationToken);
            _inFlight[channelId] = task;
            _ = task.ContinueWith(_ => _inFlight.TryRemove(channelId, out var _removed), TaskScheduler.Default);
        }
    }

    /// <summary>
    /// Runs a single channel's due imports (products → sales → customers) on a dedicated DI scope. Detached
    /// from the tick loop, so it owns its own <see cref="ApplicationDbContext"/> (the tick scope is disposed
    /// each tick and DbContext is not thread-safe). Within a channel the operations stay sequential — the
    /// dispatcher's per-channel lock and the per-run SalesId allocation both require that — but different
    /// channels now run concurrently.
    /// </summary>
    private async Task RunChannelImportsAsync(Guid channelId, CancellationToken cancellationToken)
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

            // The product import is a full, non-incremental catalogue pull. Run it on a schedule
            // only until it has completed once; otherwise it would re-import the entire catalogue
            // every interval and hammer the remote shop (observed: back-to-back full imports +
            // timeouts). Manual "Sync products" still works any time and bypasses this gate;
            // clearing InitialProductImportCompleted re-enables a scheduled full import.
            if (channel.ImportProducts && !channel.InitialProductImportCompleted)
            {
                var run = await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportProducts, ChannelSyncTriggerSource.Scheduler, cancellationToken);
                if (run.Status is ChannelSyncRunStatus.Success or ChannelSyncRunStatus.PartialFailure)
                {
                    channel.InitialProductImportCompleted = true;
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
            if (channel.ImportSaless)
            {
                await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, cancellationToken);

                // The sales import advances its resumable backfill cursor on the channel entity as it pages
                // (and flips InitialSalesImportCompleted once the whole history is in). Persist that progress
                // — even after a partial or shutdown-canceled run — so the next run resumes from the cursor
                // instead of restarting. CancellationToken.None: this must still save when the import's own
                // token was canceled by a shutdown.
                await context.SaveChangesAsync(CancellationToken.None);
            }
            // The customer import is a full pull, walked in time-boxed, resumable chunks (like the sales
            // backfill). The connector advances CustomerImportPageCursor per page and flips
            // InitialCustomerImportCompleted once the whole base is in — so run it while that flag is unset
            // and just persist the progress it made, even after a partial or shutdown-canceled chunk.
            // CancellationToken.None: this must still save when the poll's own token was canceled by shutdown.
            if (channel.ImportCustomers && !channel.InitialCustomerImportCompleted)
            {
                await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportCustomers, ChannelSyncTriggerSource.Scheduler, cancellationToken);
                await context.SaveChangesAsync(CancellationToken.None);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Expected on shutdown — the dispatcher already closed the in-progress run as canceled.
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Background import failed for channel {ChannelId}", channelId);
        }
    }
}
