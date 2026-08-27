using System.Collections.Concurrent;
using System.Text.Json;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Wraps a connector invocation with the <see cref="ChannelSyncRun"/> audit lifecycle:
/// open the row before dispatching, populate item counts + status from the connector's
/// <see cref="SyncResult"/>, persist on close. Connector exceptions land as Failed runs
/// instead of bubbling up to the orchestrator's tick loop.
/// </summary>
public sealed class SyncDispatcher
{
    // Process-wide per-(channel, operation) locks so concurrent dispatches (manual vs scheduled) of the
    // SAME operation for the same channel serialize. Different operations of one channel are allowed to
    // run concurrently — the shared ImportIdAllocator makes their CustomerId/SalesId allocation safe.
    // Static because SyncDispatcher is resolved per scope.
    private static readonly ConcurrentDictionary<(Guid ChannelId, ChannelSyncOperation Operation), SemaphoreSlim> ChannelLocks = new();

    private readonly ApplicationDbContext _context;
    private readonly ISalesChannelConnectorRegistry _registry;
    private readonly SalesChannelContextFactory _contextFactory;
    private readonly ITenantContext _tenantContext;
    private readonly SalesChannelSyncOptions _options;
    private readonly ILogger<SyncDispatcher> _logger;

    public SyncDispatcher(
        ApplicationDbContext context,
        ISalesChannelConnectorRegistry registry,
        SalesChannelContextFactory contextFactory,
        ITenantContext tenantContext,
        IOptions<SalesChannelSyncOptions> options,
        ILogger<SyncDispatcher> logger)
    {
        _context = context;
        _registry = registry;
        _contextFactory = contextFactory;
        _tenantContext = tenantContext;
        _options = options.Value;
        _logger = logger;
    }

    /// <summary>
    /// Aligns the scoped <see cref="ITenantContext"/> with the channel being synced. The orchestrator
    /// runs in a background scope with no HTTP request, so nothing else populates the tenant — without
    /// this, tenant-scoped reads (e.g. the tax-class lookup during product import) and writes silently
    /// fall back to the null tenant, dropping every imported row. Manual syncs already carry the tenant
    /// from the request; re-asserting the channel's own tenant here is consistent and harmless.
    /// </summary>
    private void AlignTenantContext(SalesChannel salesChannel)
    {
        if (salesChannel.TenantId.HasValue)
        {
            _tenantContext.SetAssignedTenantIds(new[] { salesChannel.TenantId.Value });
            _tenantContext.SetCurrentTenantId(salesChannel.TenantId.Value);
        }
    }

    /// <summary>
    /// Opens an <see cref="ILogger"/> scope carrying the channel/run/operation identifiers. Serilog
    /// surfaces these scope key/values as log-event properties, which the sync-log sink reads to
    /// attribute and persist each line. Pure MEL — no Serilog dependency in this layer.
    /// </summary>
    private IDisposable? BeginSyncLogScope(SalesChannel salesChannel, ChannelSyncOperation operation, ChannelSyncRun run)
    {
        var scope = new Dictionary<string, object>
        {
            ["SalesChannelId"] = salesChannel.Id,
            ["SyncRunCorrelationId"] = run.CorrelationId,
            ["SyncOperation"] = operation,
        };

        if (salesChannel.TenantId.HasValue)
        {
            scope["SyncTenantId"] = salesChannel.TenantId.Value;
        }

        return _logger.BeginScope(scope);
    }

    /// <param name="existingRun">
    /// A pre-created (Queued) run row to adopt instead of opening a new one — the orchestrator's queued-run
    /// dispatch passes the row the manual trigger inserted. Must be tracked by this scope's context.
    /// </param>
    public async Task<ChannelSyncRun> RunImportAsync(
        SalesChannel salesChannel,
        ChannelSyncOperation operation,
        ChannelSyncTriggerSource trigger,
        CancellationToken cancellationToken,
        ChannelSyncRun? existingRun = null)
    {
        // Serialize runs per (channel, operation): a manual sync and the scheduled poll of the same op must
        // not overlap (cursor state), while different operations of one channel run concurrently. try-acquire
        // (don't block): a scheduled run that loses the race simply retries on its next tick rather than
        // queueing behind a long manual sweep. An adopted Queued row stays Queued in that case — the caller
        // leaves it for the next tick instead of failing it.
        var gate = ChannelLocks.GetOrAdd((salesChannel.Id, operation), _ => new SemaphoreSlim(1, 1));
        if (!await gate.WaitAsync(0, cancellationToken))
        {
            if (existingRun is not null)
            {
                // Not dispatched — leave the Queued row untouched for the next tick.
                return existingRun;
            }

            _logger.LogInformation("Skipping {Op} for channel {Channel}: another sync run is already in progress", operation, salesChannel.Id);
            return new ChannelSyncRun
            {
                Id = Guid.NewGuid(),
                TenantId = salesChannel.TenantId,
                SalesChannelId = salesChannel.Id,
                Operation = operation,
                TriggerSource = trigger,
                Status = ChannelSyncRunStatus.Failed,
                StartedAt = DateTime.UtcNow,
                FinishedAt = DateTime.UtcNow,
                ErrorSummary = "Skipped: another sync run for this channel is already in progress.",
            };
        }

        try
        {
            AlignTenantContext(salesChannel);

            var connector = _registry.Resolve(salesChannel.Type);
            var operationState = await GetOrCreateOperationStateAsync(salesChannel, operation, cancellationToken);
            var run = existingRun is not null
                ? await AdoptRunAsync(existingRun, cancellationToken)
                : await OpenRunAsync(salesChannel, operation, trigger, cancellationToken);

            operationState.LastStartedAt = run.StartedAt;

            if (connector is null || !ConnectorSupports(connector, operation))
            {
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, $"No capable connector for {salesChannel.Type}/{operation}", cancellationToken);
                await ApplyPostRunSchedulingAsync(operationState, salesChannel, operation, run);
                return run;
            }

            // Tag every log line emitted while the connector runs so the sync-log sink can attribute and
            // persist it. The scope flows via AsyncLocal into the awaited connector/repository code.
            using var logScope = BeginSyncLogScope(salesChannel, operation, run);

            try
            {
                // Captured before the connector runs: a run that COMPLETES the initial walk must not
                // advance the watermark to its own start (changes made while earlier chunks walked
                // already-visited ranges would be skipped) — only runs that STARTED incremental do.
                var preRunInitialIncomplete = IsInitialWalkIncomplete(salesChannel, operation);
                var incrementalSince = ComputeIncrementalSince(operationState, operation, trigger, preRunInitialIncomplete);

                // Mid-run checkpoint: persist the audit row's item counts (and any cursor the connector
                // advanced on the tracked channel entity) while the import is still walking pages. Both
                // `run` and `salesChannel` are tracked by this scope's _context, so one SaveChanges flushes
                // counts + cursor together. The connector throttles how often it calls this. The heartbeat
                // is stamped unconditionally so the live orphan sweep can tell alive from hung.
                async Task ReportProgressAsync(int processed, int failed, CancellationToken ct)
                {
                    run.ItemsProcessed = processed;
                    run.ItemsFailed = failed;
                    run.HeartbeatAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync(ct);
                }

                // Hard ceiling per invocation: a connector call that never observes cancellation on its
                // own (hung socket, SDK ignoring the token) is aborted here, which frees the per-
                // (channel, operation) lock instead of blocking the operation until a process restart.
                using var invocationCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                invocationCts.CancelAfter(TimeSpan.FromMinutes(_options.RunHardTimeoutMinutes));

                var context = _contextFactory.Create(salesChannel, run, invocationCts.Token, incrementalSince, ReportProgressAsync, operationState);
                var result = operation switch
                {
                    ChannelSyncOperation.ImportProducts => await connector.ImportProductsAsync(context),
                    ChannelSyncOperation.ImportSaless => await connector.ImportSalessAsync(context),
                    ChannelSyncOperation.ImportCustomers => await connector.ImportCustomersAsync(context),
                    ChannelSyncOperation.ImportStock => await connector.ImportStockAsync(context),
                    ChannelSyncOperation.ImportCategories => await connector.ImportCategoriesAsync(context),
                    _ => SyncResult.Failed($"Operation {operation} is not an import"),
                };

                var status = result switch
                {
                    { ErrorSummary: not null } when result.ItemsProcessed == 0 => ChannelSyncRunStatus.Failed,
                    { ItemsFailed: > 0 } when result.ItemsProcessed > 0 => ChannelSyncRunStatus.PartialFailure,
                    { ItemsFailed: > 0 } => ChannelSyncRunStatus.Failed,
                    _ => ChannelSyncRunStatus.Success,
                };

                await CloseRunAsync(run, status, result.ItemsProcessed, result.ItemsFailed, result.ErrorSummary, cancellationToken);
                ApplyLegacyCompletionFlags(salesChannel, operation, run);
                ApplyWatermarkBookkeeping(operationState, operation, run, incrementalSince, preRunInitialIncomplete);
                await ApplyPostRunSchedulingAsync(operationState, salesChannel, operation, run);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                // Expected on server shutdown — the connector observed the token between pages. Close the run
                // cleanly (not an error) so it does not linger as an orphaned "Running" row. Deliberately no
                // scheduling update: NextDueAt stays in the past, so the operation resumes promptly after the
                // restart instead of serving a failure backoff for being shut down.
                _logger.LogInformation("Sync canceled for channel {Channel} op {Op} (server shutdown)", salesChannel.Id, operation);
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, "Sync canceled (server shutdown).", cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // The linked token fired without an external cancellation: the invocation exceeded the hard
                // ceiling. Close as failed and apply the failure backoff — a shop that hangs every run must
                // not be re-dialed every interval.
                _logger.LogError("Sync for channel {Channel} op {Op} exceeded the hard timeout of {Minutes} min and was aborted",
                    salesChannel.Id, operation, _options.RunHardTimeoutMinutes);
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0,
                    $"Aborted: run exceeded the hard timeout of {_options.RunHardTimeoutMinutes} minutes.", cancellationToken);
                await ApplyPostRunSchedulingAsync(operationState, salesChannel, operation, run);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sync dispatch failed for channel {Channel} op {Op}", salesChannel.Id, operation);
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, ex.Message, cancellationToken);
                await ApplyPostRunSchedulingAsync(operationState, salesChannel, operation, run);
            }

            return run;
        }
        finally
        {
            gate.Release();
        }
    }

    public async Task<ExportResult> RunExportAsync(
        SalesChannel salesChannel,
        ChannelExportOutbox outboxRow,
        CancellationToken cancellationToken)
    {
        AlignTenantContext(salesChannel);

        var connector = _registry.Resolve(salesChannel.Type);
        if (connector is null)
        {
            return ExportResult.Fail($"No connector for {salesChannel.Type}");
        }

        // The enqueuer filters capability-less channels, but a row can predate a channel-type
        // switch. There is nothing to push for a connector without the capability (internal
        // channels read the ERP data directly) — complete the row instead of retrying it into
        // DeadLetter.
        if (!connector.Supports(outboxRow.Operation))
        {
            _logger.LogInformation(
                "Outbox row {Outbox}: {ChannelType} does not support {Operation} — completed as no-op",
                outboxRow.Id, salesChannel.Type, outboxRow.Operation);
            return ExportResult.Ok();
        }

        // Exports do NOT create ChannelSyncRun rows: with per-sale stock pushes an audit row per outbox
        // row would flood the runs table and the dashboard. The outbox row itself is the audit
        // (Status/AttemptCount/LastError/CompletedAt); this transient run only carries the correlation id
        // for the log scope and the context contract — it is never persisted.
        var run = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            TenantId = salesChannel.TenantId,
            SalesChannelId = salesChannel.Id,
            Operation = outboxRow.Operation,
            TriggerSource = ChannelSyncTriggerSource.Event,
            Status = ChannelSyncRunStatus.Running,
            StartedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        };

        using var logScope = BeginSyncLogScope(salesChannel, outboxRow.Operation, run);

        try
        {
            var context = _contextFactory.Create(salesChannel, run, cancellationToken);
            return await DispatchExportAsync(connector, context, outboxRow, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Export dispatch failed for channel {Channel} outbox {Outbox}", salesChannel.Id, outboxRow.Id);
            return ExportResult.Fail(ex.Message);
        }
    }

    /// <summary>
    /// Which operations run incrementally off a modified-since watermark: orders (modified_after and
    /// friends), products (modified_after / post_modified_gmt / updatedAt) and customers (last_update
    /// on the direct-DB path; registered-since for new customers on REST). Stock deliberately not —
    /// its modified-filter mode is lossy (order-driven stock changes do not bump the product's
    /// modified timestamp), so stock always runs as a rare absolute sweep. Categories are a cheap
    /// single-save full reconcile and need no watermark either.
    /// </summary>
    private static bool IsWatermarkOperation(ChannelSyncOperation operation) =>
        operation is ChannelSyncOperation.ImportSaless
            or ChannelSyncOperation.ImportProducts
            or ChannelSyncOperation.ImportCustomers;

    /// <summary>
    /// Reads the incremental watermark from the durable operation state, minus a safety overlap
    /// (clock skew, changes landing mid-run — re-pulling seen items is harmless, imports are
    /// idempotent). Null → full sweep: for operations without an incremental mode, for the very
    /// first incremental run (bootstrap: one healing full sweep, then delta), for manual triggers
    /// (the user's recovery lever backfills anything an earlier run missed), for chunks of a still
    /// incomplete initial walk (the walk's cursor governs those, not a modified filter), and when
    /// the periodic full-reconciliation sweep is due.
    /// </summary>
    /// <remarks>
    /// For the sales import the watermark is also consulted while the history backfill is still
    /// running — the connector uses it for the per-run "recent orders" pass that keeps current
    /// orders live before the oldest-first walk reaches the present (null → the connector falls
    /// back to a fixed seed window on the first run). It never governs which historical orders the
    /// backfill fetches (that is the date cursor), so reading it during backfill is safe.
    /// </remarks>
    private DateTime? ComputeIncrementalSince(
        SalesChannelOperationState operationState,
        ChannelSyncOperation operation,
        ChannelSyncTriggerSource trigger,
        bool initialWalkIncomplete)
    {
        if (!IsWatermarkOperation(operation) || trigger == ChannelSyncTriggerSource.Manual)
        {
            return null;
        }

        // Sales excepted (recent-pass, see remarks): initial-walk chunks never filter by modified —
        // the resume cursor drives them.
        if (operation != ChannelSyncOperation.ImportSaless && initialWalkIncomplete)
        {
            return null;
        }

        if (IsFullSweepDue(operationState))
        {
            return null;
        }

        return operationState.Watermark is null
            ? null
            : operationState.Watermark.Value - TimeSpan.FromMinutes(_options.IncrementalOverlapMinutes);
    }

    /// <summary>
    /// True when the operation's rare full-reconciliation sweep is due: deletions and drift that a
    /// modified-since delta can never see are healed by periodically re-walking everything.
    /// </summary>
    private bool IsFullSweepDue(SalesChannelOperationState operationState)
    {
        var fullSweepDays = _options.For(operationState.Operation).FullSweepDays;
        if (fullSweepDays is null)
        {
            return false;
        }

        var last = operationState.LastFullSweepAt ?? operationState.LastSuccessAt;
        return last is null || DateTime.UtcNow - last.Value >= TimeSpan.FromDays(fullSweepDays.Value);
    }

    /// <summary>
    /// Post-run watermark bookkeeping. Advancement rules:
    /// only fully successful runs advance (a failed/partial run keeps the previous baseline so the
    /// next run re-pulls the same window — idempotent upserts make that safe); for products and
    /// customers only runs that STARTED in the incremental phase advance (a chunked initial walk
    /// keeps the watermark stamped at its beginning, so the first delta re-covers everything that
    /// changed while the walk ran); sales advance on any success (its recent-pass semantics predate
    /// the phase model and are cursor-protected). A successful sweep that ran without a watermark in
    /// the incremental phase was a full reconciliation — stamp <c>LastFullSweepAt</c>.
    /// </summary>
    private static void ApplyWatermarkBookkeeping(
        SalesChannelOperationState operationState,
        ChannelSyncOperation operation,
        ChannelSyncRun run,
        DateTime? usedIncrementalSince,
        bool preRunInitialIncomplete)
    {
        if (run.Status != ChannelSyncRunStatus.Success)
        {
            return;
        }

        // Stock is not a watermark operation (its sweeps are always absolute), but the sweep-START
        // instant is still recorded here: the sales import uses it as the baseline for stock-master
        // mirroring — orders placed before it are already reflected in the mirrored level and must
        // not decrement again.
        if (operation == ChannelSyncOperation.ImportStock)
        {
            operationState.Watermark = run.StartedAt;
            return;
        }

        if (!IsWatermarkOperation(operation))
        {
            return;
        }

        if (operation == ChannelSyncOperation.ImportSaless || !preRunInitialIncomplete)
        {
            operationState.Watermark = run.StartedAt;

            if (usedIncrementalSince is null && !preRunInitialIncomplete)
            {
                operationState.LastFullSweepAt = run.StartedAt;
            }
        }
    }

    /// <summary>
    /// Loads the durable per-(channel, operation) scheduling state, creating and seeding it on first
    /// use. Seeding pulls everything the legacy bookkeeping knows: the phase from the one-shot
    /// Initial*Completed flags, the resume cursors from <see cref="SalesChannelSyncState"/>, and the
    /// incremental watermark from the historical run table (the old per-dispatch MAX() derivation,
    /// executed exactly once here and then owned by the state row). Callers run inside the
    /// per-(channel, operation) gate, so create/seed is race-free per row; the row is persisted with
    /// the caller's next SaveChanges.
    /// </summary>
    internal async Task<SalesChannelOperationState> GetOrCreateOperationStateAsync(
        SalesChannel salesChannel,
        ChannelSyncOperation operation,
        CancellationToken cancellationToken)
    {
        var state = await _context.SalesChannelOperationState
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(o => o.SalesChannelId == salesChannel.Id && o.Operation == operation, cancellationToken);

        if (state is null)
        {
            state = new SalesChannelOperationState
            {
                SalesChannelId = salesChannel.Id,
                // Explicit: background scopes have no ambient tenant until AlignTenantContext ran, and
                // the save hook must never guess for host-level rows.
                TenantId = salesChannel.TenantId,
                Operation = operation,
                NextDueAt = DateTime.UtcNow,
            };
            _context.SalesChannelOperationState.Add(state);
        }

        if (state.Phase == ChannelSyncPhase.Unknown)
        {
            state.Phase = IsInitialWalkIncomplete(salesChannel, operation)
                ? ChannelSyncPhase.Initial
                : ChannelSyncPhase.Incremental;

            state.CursorDateTime = operation == ChannelSyncOperation.ImportSaless
                ? salesChannel.SyncState.SalesImportBackfillCursor
                : null;
            state.CursorPage = operation == ChannelSyncOperation.ImportCustomers
                ? salesChannel.SyncState.CustomerImportPageCursor
                : 0;

            if (operation == ChannelSyncOperation.ImportSaless && state.Watermark is null)
            {
                // Advance-on-Success semantics carried over: only fully successful runs ever advanced
                // the legacy sales watermark, so seeding from the last Success run is loss-free.
                state.Watermark = await _context.ChannelSyncRun
                    .IgnoreQueryFilters()
                    .Where(r => r.SalesChannelId == salesChannel.Id
                                && r.Operation == operation
                                && r.Status == ChannelSyncRunStatus.Success)
                    .MaxAsync(r => (DateTime?)r.StartedAt, cancellationToken);
            }
            else if (state.Phase == ChannelSyncPhase.Initial && IsWatermarkOperation(operation))
            {
                // Baseline for the first delta after the (chunked, possibly multi-day) initial walk:
                // everything modified since the walk BEGAN is re-pulled once, so changes landing in
                // already-walked ranges are not lost. Products/customers only — legacy never ran them
                // incrementally, so there is no historical watermark to inherit.
                state.Watermark = DateTime.UtcNow;
            }
            // Products/customers whose one-shot sweep completed under the legacy scheduler start with
            // a null watermark on purpose: their first incremental run becomes one healing full sweep
            // (catching everything the one-shot era silently missed), then delta takes over.
        }

        return state;
    }

    /// <summary>
    /// True when a one-shot sweep walked off the end of the remote data set: a clean run, or a run whose
    /// only failures are per-item (no run-level <see cref="ChannelSyncRun.ErrorSummary"/>). An aborted
    /// walk carries the abort exception as ErrorSummary and must keep its initial flag unset.
    /// </summary>
    internal static bool IsStructurallyComplete(ChannelSyncRun run) =>
        run.Status == ChannelSyncRunStatus.Success
        || (run.Status == ChannelSyncRunStatus.PartialFailure && string.IsNullOrEmpty(run.ErrorSummary));

    /// <summary>
    /// Flips the one-shot completion flag for categories — the only sweep whose connector does not
    /// maintain its own flag: the category import is a single whole-tree reconcile per run (never
    /// chunked), so its run outcome IS its structural completion. Products, customers and the sales
    /// backfill flip their flags inside the connector, which alone knows whether a time-boxed chunk
    /// walked off the end or merely ran out of time. Runs before the scheduling update so the phase
    /// mirror sees the fresh flags — isolated item failures still count as completed (a poison item
    /// must not pin a full sweep to repeat forever), an aborted walk never does.
    /// </summary>
    private static void ApplyLegacyCompletionFlags(SalesChannel salesChannel, ChannelSyncOperation operation, ChannelSyncRun run)
    {
        if (operation == ChannelSyncOperation.ImportCategories && IsStructurallyComplete(run))
        {
            salesChannel.SyncState.InitialCategoryImportCompleted = true;
        }
    }

    /// <summary>
    /// True while the operation's initial full walk has not completed yet. Derived from the legacy
    /// one-shot flags for now — the connectors still maintain those; once they move onto the
    /// operation state (phase 2 of the sync redesign), this reads <see cref="ChannelSyncPhase"/>.
    /// </summary>
    private static bool IsInitialWalkIncomplete(SalesChannel salesChannel, ChannelSyncOperation operation) => operation switch
    {
        ChannelSyncOperation.ImportProducts => salesChannel.ImportProducts && !salesChannel.SyncState.InitialProductImportCompleted,
        ChannelSyncOperation.ImportCustomers => salesChannel.ImportCustomers && !salesChannel.SyncState.InitialCustomerImportCompleted,
        ChannelSyncOperation.ImportCategories => salesChannel.ImportCategories && !salesChannel.SyncState.InitialCategoryImportCompleted,
        ChannelSyncOperation.ImportSaless => salesChannel.ImportSaless && !salesChannel.SyncState.InitialSalesImportCompleted,
        _ => false,
    };

    /// <summary>
    /// Post-run scheduling on the durable operation state: mirror the phase from the legacy flags and
    /// let the scheduling policy compute the next due time (chunk-chaining while the initial walk is
    /// incomplete, adaptive interval otherwise, exponential backoff after failures). Persisted
    /// immediately with a non-cancellable token — like the run close, this must land even during
    /// shutdown. Watermark bookkeeping happens separately in <see cref="ApplyWatermarkBookkeeping"/>.
    /// </summary>
    private async Task ApplyPostRunSchedulingAsync(
        SalesChannelOperationState operationState,
        SalesChannel salesChannel,
        ChannelSyncOperation operation,
        ChannelSyncRun run)
    {
        var initialWalkIncomplete = IsInitialWalkIncomplete(salesChannel, operation);
        operationState.Phase = initialWalkIncomplete ? ChannelSyncPhase.Initial : ChannelSyncPhase.Incremental;

        operationState.NextDueAt = SyncScheduler.ComputeNextDue(
            operationState,
            run,
            _options,
            salesChannel.SyncIntervalSeconds,
            initialWalkIncomplete,
            DateTime.UtcNow);

        await _context.SaveChangesAsync(CancellationToken.None);
    }

    /// <summary>
    /// Adopts a pre-created (Queued) run row: stamps the actual start time, flips it to Running and gives
    /// it a fresh correlation id so its log lines group under this execution, not the enqueue moment.
    /// </summary>
    private async Task<ChannelSyncRun> AdoptRunAsync(ChannelSyncRun run, CancellationToken cancellationToken)
    {
        run.Status = ChannelSyncRunStatus.Running;
        run.StartedAt = DateTime.UtcNow;
        run.CorrelationId = Guid.NewGuid();
        await _context.SaveChangesAsync(cancellationToken);
        return run;
    }

    private async Task<ChannelSyncRun> OpenRunAsync(
        SalesChannel salesChannel,
        ChannelSyncOperation operation,
        ChannelSyncTriggerSource trigger,
        CancellationToken cancellationToken)
    {
        var run = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            TenantId = salesChannel.TenantId,
            SalesChannelId = salesChannel.Id,
            Operation = operation,
            TriggerSource = trigger,
            Status = ChannelSyncRunStatus.Running,
            StartedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        };

        _context.ChannelSyncRun.Add(run);
        await _context.SaveChangesAsync(cancellationToken);
        return run;
    }

    private async Task CloseRunAsync(
        ChannelSyncRun run,
        ChannelSyncRunStatus status,
        int itemsProcessed,
        int itemsFailed,
        string? errorSummary,
        CancellationToken cancellationToken)
    {
        run.FinishedAt = DateTime.UtcNow;
        run.Status = status;
        run.ItemsProcessed = itemsProcessed;
        run.ItemsFailed = itemsFailed;
        run.ErrorSummary = Truncate(errorSummary, 2000);

        // Persist the terminal status with a non-cancellable token: this write runs in the catch path of
        // a canceled/shutting-down sync, and passing the already-canceled token would abort the close and
        // leave the run stuck at "Running" (orphaned). The startup cleanup is the backstop, not this.
        _ = cancellationToken;
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    private static bool ConnectorSupports(ISalesChannelConnector connector, ChannelSyncOperation operation)
        => connector.Supports(operation);

    private async Task<ExportResult> DispatchExportAsync(
        ISalesChannelConnector connector,
        SalesChannelContext context,
        ChannelExportOutbox outbox,
        CancellationToken cancellationToken)
    {
        // Hydrate payload from current DB state — outbox rows store only the aggregate id, so a
        // coalesced row always carries the latest data when the drainer picks it up.
        return outbox.Operation switch
        {
            ChannelSyncOperation.ExportProduct => await ExportProductAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.UpdateStock => await UpdateStockAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.UpdatePrice => await UpdatePriceAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.UpdateSales => await UpdateSalesAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.DelistProduct => await DelistProductAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.CancelSales => await CancelSalesAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.ExportCategory => await ExportCategoryAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.DeleteCategory => await DeleteCategoryAsync(connector, context, outbox, cancellationToken),
            ChannelSyncOperation.UpdateProductCategories => await UpdateProductCategoriesAsync(connector, context, outbox, cancellationToken),
            _ => ExportResult.Fail($"Unsupported export operation {outbox.Operation}"),
        };
    }

    private async Task<ExportResult> ExportProductAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var psc = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == outbox.AggregateId && p.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (psc?.Product is null)
        {
            return ExportResult.Fail("ProductSalesChannel row not found at dispatch time");
        }

        var stock = await ComputeChannelStockAsync(outbox.SalesChannelId, psc.ProductId, psc.StockBuffer, cancellationToken);

        var payload = new ProductExportPayload(
            psc.ProductId,
            psc.Id,
            psc.Product.Sku,
            psc.Product.Name,
            psc.Product.Description,
            psc.Price,
            psc.MinPrice,
            psc.MaxPrice,
            psc.Currency,
            stock,
            psc.Product.Ean,
            psc.Product.Gtin,
            psc.Product.Mpn,
            psc.Product.Brand,
            psc.RemoteProductId,
            psc.ExternalListingId,
            psc.MetadataJson);

        return await connector.ExportProductAsync(context, payload);
    }

    private async Task<ExportResult> UpdateStockAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var psc = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == outbox.AggregateId && p.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (psc?.Product is null)
        {
            return ExportResult.Fail("ProductSalesChannel row not found at dispatch time");
        }

        var stock = await ComputeChannelStockAsync(outbox.SalesChannelId, psc.ProductId, psc.StockBuffer, cancellationToken);
        var parentRemoteProductId = await GetParentRemoteProductIdAsync(psc.Product, outbox.SalesChannelId, cancellationToken);

        return await connector.UpdateStockAsync(context, new StockUpdatePayload(
            psc.ProductId, psc.Id, psc.Product.Sku, stock, psc.RemoteProductId, parentRemoteProductId));
    }

    private async Task<ExportResult> UpdatePriceAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var psc = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == outbox.AggregateId && p.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (psc?.Product is null)
        {
            return ExportResult.Fail("ProductSalesChannel row not found at dispatch time");
        }

        var parentRemoteProductId = await GetParentRemoteProductIdAsync(psc.Product, outbox.SalesChannelId, cancellationToken);

        return await connector.UpdatePriceAsync(context, new PriceUpdatePayload(
            psc.ProductId, psc.Id, psc.Product.Sku, psc.Price, psc.Currency, psc.RemoteProductId, psc.ExternalListingId, parentRemoteProductId));
    }

    /// <summary>
    /// For variant products some channels (WooCommerce) address the variation under its parent
    /// (PUT products/{parent}/variations/{variation}), so the parent's RemoteProductId on the
    /// same channel is hydrated into the payload. Null for non-variants or unlinked parents.
    /// </summary>
    private async Task<string?> GetParentRemoteProductIdAsync(Domain.Entities.Product product, Guid salesChannelId, CancellationToken cancellationToken)
    {
        if (product.ProductType != Domain.Enums.ProductType.Variant || product.ParentProductId is null)
        {
            return null;
        }

        return await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Where(p => p.ProductId == product.ParentProductId && p.SalesChannelId == salesChannelId)
            .Select(p => p.RemoteProductId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    private async Task<ExportResult> UpdateSalesAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var sales = await _context.Sales
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(o => o.Id == outbox.AggregateId, cancellationToken);

        if (sales is null)
        {
            return ExportResult.Fail("Sales not found at dispatch time");
        }

        return await connector.UpdateSalesAsync(context, new SalesUpdatePayload(
            sales.Id, sales.RemoteSalesId, sales.Status.ToString(), null, null));
    }

    private async Task<ExportResult> CancelSalesAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var sales = await _context.Sales
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(o => o.Id == outbox.AggregateId, cancellationToken);

        if (sales is null)
        {
            return ExportResult.Fail("Sales not found at dispatch time");
        }

        return await connector.CancelSalesAsync(context, new CancelSalesPayload(
            sales.Id, sales.RemoteSalesId));
    }

    private async Task<ExportResult> DelistProductAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        // Delist is typically enqueued because the product (and its channel links) was deleted, so
        // the live rows are gone. Prefer the payload snapshot captured before deletion; only fall
        // back to DB hydration for a delist of a still-existing-but-unlisted product.
        if (!string.IsNullOrEmpty(outbox.PayloadJson))
        {
            var snapshot = JsonSerializer.Deserialize<DelistPayload>(outbox.PayloadJson);
            if (snapshot is not null)
            {
                return await connector.DelistProductAsync(context, snapshot);
            }
        }

        var psc = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == outbox.AggregateId && p.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (psc?.Product is null)
        {
            return ExportResult.Fail("ProductSalesChannel row not found at dispatch time");
        }

        return await connector.DelistProductAsync(context, new DelistPayload(
            psc.Id, psc.Product.Sku, psc.RemoteProductId, psc.ExternalListingId));
    }

    private async Task<ExportResult> ExportCategoryAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var link = await _context.CategorySalesChannel
            .IgnoreQueryFilters()
            .Include(l => l.Category)
            .FirstOrDefaultAsync(l => l.CategoryId == outbox.AggregateId && l.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (link?.Category is null)
        {
            return ExportResult.Fail("CategorySalesChannel row not found at dispatch time");
        }

        if (!link.IsActive)
        {
            // Deactivated between enqueue and drain — the DeleteCategory row handles the remote removal.
            return ExportResult.Ok();
        }

        string? parentRemoteCategoryId = null;
        if (link.Category.ParentCategoryId is not null)
        {
            var parentLink = await _context.CategorySalesChannel
                .IgnoreQueryFilters()
                .Where(l => l.CategoryId == link.Category.ParentCategoryId && l.SalesChannelId == outbox.SalesChannelId)
                .Select(l => new { l.IsActive, l.RemoteCategoryId })
                .FirstOrDefaultAsync(cancellationToken);

            if (parentLink is null || !parentLink.IsActive)
            {
                return ExportResult.Fail("Parent category is not active on this channel");
            }

            if (string.IsNullOrEmpty(parentLink.RemoteCategoryId))
            {
                // Parent enqueued but not exported yet — fail so the outbox backoff retries this row
                // after the parent's own row completed. This is what orders parents before children.
                return ExportResult.Fail("Parent category has no remote id yet");
            }

            parentRemoteCategoryId = parentLink.RemoteCategoryId;
        }

        var payload = new CategoryExportPayload(
            link.CategoryId,
            link.Id,
            link.Category.Name,
            link.Category.Slug,
            link.Category.Description,
            link.Category.SortOrder,
            link.RemoteCategoryId,
            parentRemoteCategoryId);

        var result = await connector.ExportCategoryAsync(context, payload);

        if (result.Success)
        {
            link.RemoteCategoryId = result.RemoteId ?? link.RemoteCategoryId;
            link.LastSyncedAt = DateTime.UtcNow;
            link.LastErrorMessage = null;
        }
        else
        {
            link.LastErrorMessage = Truncate(result.ErrorMessage, 1000);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }

    private async Task<ExportResult> DeleteCategoryAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        // Deletes are typically enqueued because the category (and its channel links) was removed;
        // prefer the payload snapshot captured before deletion. Fall back to DB hydration for the
        // deactivation of a still-existing link.
        if (!string.IsNullOrEmpty(outbox.PayloadJson))
        {
            var snapshot = JsonSerializer.Deserialize<CategoryDeletePayload>(outbox.PayloadJson);
            if (snapshot is not null)
            {
                // Never exported to the channel → nothing to remove remotely.
                return string.IsNullOrEmpty(snapshot.RemoteCategoryId)
                    ? ExportResult.Ok()
                    : await connector.DeleteCategoryAsync(context, snapshot);
            }
        }

        var link = await _context.CategorySalesChannel
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(l => l.CategoryId == outbox.AggregateId && l.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (link is null || string.IsNullOrEmpty(link.RemoteCategoryId))
        {
            return ExportResult.Ok();
        }

        if (link.IsActive)
        {
            // Re-activated between enqueue and drain — the ExportCategory row takes over.
            return ExportResult.Ok();
        }

        var result = await connector.DeleteCategoryAsync(
            context, new CategoryDeletePayload(link.CategoryId, link.SalesChannelId, link.RemoteCategoryId));

        if (result.Success)
        {
            link.RemoteCategoryId = null;
            link.LastSyncedAt = DateTime.UtcNow;
            link.LastErrorMessage = null;
        }
        else
        {
            link.LastErrorMessage = Truncate(result.ErrorMessage, 1000);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }

    private async Task<ExportResult> UpdateProductCategoriesAsync(ISalesChannelConnector connector, SalesChannelContext context, ChannelExportOutbox outbox, CancellationToken cancellationToken)
    {
        var psc = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == outbox.AggregateId && p.SalesChannelId == outbox.SalesChannelId, cancellationToken);

        if (psc?.Product is null)
        {
            return ExportResult.Fail("ProductSalesChannel row not found at dispatch time");
        }

        if (string.IsNullOrEmpty(psc.RemoteProductId))
        {
            return ExportResult.Fail("Product has no remote id on this channel yet");
        }

        // Map the product's assignments to this channel's remote category ids. Categories not (yet)
        // exported to the channel are skipped; the next assignment change re-syncs them.
        var remoteCategoryIds = await _context.ProductCategory
            .IgnoreQueryFilters()
            .Where(pc => pc.ProductId == psc.ProductId)
            .Join(
                _context.CategorySalesChannel.IgnoreQueryFilters()
                    .Where(l => l.SalesChannelId == outbox.SalesChannelId && l.IsActive && l.RemoteCategoryId != null),
                pc => pc.CategoryId,
                l => l.CategoryId,
                (pc, l) => l.RemoteCategoryId!)
            .ToListAsync(cancellationToken);

        var parentRemoteProductId = await GetParentRemoteProductIdAsync(psc.Product, outbox.SalesChannelId, cancellationToken);

        return await connector.UpdateProductCategoriesAsync(context, new ProductCategoriesUpdatePayload(
            psc.ProductId, psc.RemoteProductId, parentRemoteProductId, remoteCategoryIds));
    }


    private async Task<int> ComputeChannelStockAsync(Guid salesChannelId, Guid productId, int stockBuffer, CancellationToken cancellationToken)
    {
        // Sum stock from the warehouses attached to this channel; subtract the per-channel buffer.
        var stock = await _context.ProductStock
            .IgnoreQueryFilters()
            .Where(ps => ps.ProductId == productId &&
                         _context.SalesChannel
                             .IgnoreQueryFilters()
                             .Where(sc => sc.Id == salesChannelId)
                             .SelectMany(sc => sc.Warehouses)
                             .Any(w => w.Id == ps.WarehouseId))
            .SumAsync(ps => (double?)ps.Stock, cancellationToken) ?? 0;

        var available = (int)Math.Floor(stock) - stockBuffer;
        return Math.Max(0, available);
    }

    private static string? Truncate(string? value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= max ? value : value[..max];
    }
}
