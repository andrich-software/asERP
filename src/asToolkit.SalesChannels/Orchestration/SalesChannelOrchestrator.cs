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
    private static readonly TimeSpan TickInterval = TimeSpan.FromSeconds(10);

    // Purge expired sync logs roughly once a minute (every 6th 10s tick) — the flush itself runs each tick.
    private const int PurgeEveryTicks = 6;

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<SalesChannelOrchestrator> _logger;
    private int _tick;

    public SalesChannelOrchestrator(IServiceScopeFactory scopeFactory, ILogger<SalesChannelOrchestrator> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
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
                await Task.Delay(TickInterval, stoppingToken);
            }
            catch (TaskCanceledException) { break; }
        }

        _logger.LogInformation("SalesChannelOrchestrator stopping");
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
        var dispatcher = scope.ServiceProvider.GetRequiredService<SyncDispatcher>();

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

            channel.LastSyncStartedAt = now;
            await context.SaveChangesAsync(cancellationToken);

            try
            {
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
                    // every tick — even after a partial or shutdown-canceled run — so the next run resumes from
                    // the cursor instead of restarting. CancellationToken.None: this must still save when the
                    // poll's own token was canceled by a shutdown.
                    await context.SaveChangesAsync(CancellationToken.None);
                }
                // Like the product import, the customer import is a full, non-incremental pull. Gate the
                // scheduled run to once-until-complete so it does not re-pull the entire customer base every
                // interval and hammer the remote shop. Manual "Sync customers" bypasses this gate; clearing
                // InitialCustomerImportCompleted re-enables a scheduled full import.
                if (channel.ImportCustomers && !channel.InitialCustomerImportCompleted)
                {
                    var run = await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportCustomers, ChannelSyncTriggerSource.Scheduler, cancellationToken);
                    if (run.Status is ChannelSyncRunStatus.Success or ChannelSyncRunStatus.PartialFailure)
                    {
                        channel.InitialCustomerImportCompleted = true;
                        await context.SaveChangesAsync(cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Import-poll failed for channel {ChannelId} ({Name})", channel.Id, channel.Name);
            }
        }
    }
}
