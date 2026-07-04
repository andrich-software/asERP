using System.Collections.Concurrent;
using System.Text.Json;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<SyncDispatcher> _logger;

    public SyncDispatcher(
        ApplicationDbContext context,
        ISalesChannelConnectorRegistry registry,
        SalesChannelContextFactory contextFactory,
        ITenantContext tenantContext,
        ILogger<SyncDispatcher> logger)
    {
        _context = context;
        _registry = registry;
        _contextFactory = contextFactory;
        _tenantContext = tenantContext;
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
            var run = existingRun is not null
                ? await AdoptRunAsync(existingRun, cancellationToken)
                : await OpenRunAsync(salesChannel, operation, trigger, cancellationToken);

            if (connector is null || !ConnectorSupports(connector, operation))
            {
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, $"No capable connector for {salesChannel.Type}/{operation}", cancellationToken);
                return run;
            }

            // Tag every log line emitted while the connector runs so the sync-log sink can attribute and
            // persist it. The scope flows via AsyncLocal into the awaited connector/repository code.
            using var logScope = BeginSyncLogScope(salesChannel, operation, run);

            try
            {
                var incrementalSince = await ComputeIncrementalSinceAsync(salesChannel, operation, trigger, run, cancellationToken);

                // Mid-run checkpoint: persist the audit row's item counts (and any cursor the connector
                // advanced on the tracked channel entity) while the import is still walking pages. Both
                // `run` and `salesChannel` are tracked by this scope's _context, so one SaveChanges flushes
                // counts + cursor together. The connector throttles how often it calls this.
                async Task ReportProgressAsync(int processed, int failed, CancellationToken ct)
                {
                    run.ItemsProcessed = processed;
                    run.ItemsFailed = failed;
                    await _context.SaveChangesAsync(ct);
                }

                var context = _contextFactory.Create(salesChannel, run, cancellationToken, incrementalSince, ReportProgressAsync);
                var result = operation switch
                {
                    ChannelSyncOperation.ImportProducts => await connector.ImportProductsAsync(context),
                    ChannelSyncOperation.ImportSaless => await connector.ImportSalessAsync(context),
                    ChannelSyncOperation.ImportCustomers => await connector.ImportCustomersAsync(context),
                    ChannelSyncOperation.ImportStock => await connector.ImportStockAsync(context),
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
            }
            catch (OperationCanceledException)
            {
                // Expected on server shutdown — the connector observed the token between pages. Close the run
                // cleanly (not an error) so it does not linger as an orphaned "Running" row.
                _logger.LogInformation("Sync canceled for channel {Channel} op {Op} (server shutdown)", salesChannel.Id, operation);
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, "Sync canceled (server shutdown).", cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sync dispatch failed for channel {Channel} op {Op}", salesChannel.Id, operation);
                await CloseRunAsync(run, ChannelSyncRunStatus.Failed, 0, 0, ex.Message, cancellationToken);
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

    // Small safety overlap subtracted from the watermark so orders modified during the previous run (or
    // under minor clock skew between this host and the shop) are not missed. Re-pulling a few already-seen
    // orders is harmless because the import upsert is idempotent.
    private static readonly TimeSpan IncrementalOverlap = TimeSpan.FromHours(1);

    /// <summary>
    /// Computes the incremental watermark for the sales import: the start of the most recent run that
    /// finished as Success or PartialFailure, minus a safety overlap. Returns null (→ full import) when no
    /// such run exists yet (first import) or for operations that have no incremental mode. Failed runs are
    /// excluded so a failure never advances the watermark — the next run safely re-pulls from the last good
    /// point. The just-opened "Running" row is excluded by the status filter.
    /// </summary>
    private async Task<DateTime?> ComputeIncrementalSinceAsync(
        SalesChannel salesChannel,
        ChannelSyncOperation operation,
        ChannelSyncTriggerSource trigger,
        ChannelSyncRun currentRun,
        CancellationToken cancellationToken)
    {
        // Sales and stock imports both run incrementally off a modified_after watermark; the other
        // operations have their own cursors/flags.
        if (operation is not (ChannelSyncOperation.ImportSaless or ChannelSyncOperation.ImportStock))
        {
            return null;
        }

        // A manual sync is the user's recovery lever: do a full sweep (no watermark) so it backfills
        // anything an earlier run missed. Only the scheduled poll stays incremental for efficiency.
        if (trigger == ChannelSyncTriggerSource.Manual)
        {
            return null;
        }

        // NOTE: this watermark is also consulted while the history backfill is still running — the connector
        // uses it for the per-run "recent orders" pass that keeps current orders live before the oldest-first
        // walk reaches the present (null → the connector falls back to a fixed seed window on the first run).
        // It never governs which historical orders the backfill fetches (that is the date_created cursor), so
        // computing it during backfill is safe.

        // Advance the watermark ONLY past fully successful runs. A PartialFailure means the run aborted
        // mid-walk (e.g. a page fetch failed), so the orders it never reached were not imported. If we
        // treated its StartedAt as the new baseline, the next incremental run's 'modified_after' would skip
        // straight past those never-fetched orders and they would be lost forever — exactly the gap that
        // left this shop at ~17% coverage. By keying off the last *Success* only, a failed/partial run makes
        // the next scheduled run re-pull the same window (idempotent upserts), so the import self-heals once
        // connectivity is restored instead of cementing the hole.
        var lastSuccessfulStart = await _context.ChannelSyncRun
            .IgnoreQueryFilters()
            .Where(r => r.SalesChannelId == salesChannel.Id
                        && r.Operation == operation
                        && r.Id != currentRun.Id
                        && r.Status == ChannelSyncRunStatus.Success)
            .MaxAsync(r => (DateTime?)r.StartedAt, cancellationToken);

        return lastSuccessfulStart is null ? null : lastSuccessfulStart.Value - IncrementalOverlap;
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

    private static bool ConnectorSupports(ISalesChannelConnector connector, ChannelSyncOperation operation) => operation switch
    {
        ChannelSyncOperation.ImportProducts => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportProducts),
        ChannelSyncOperation.ImportSaless => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportSaless),
        ChannelSyncOperation.ImportCustomers => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportCustomers),
        ChannelSyncOperation.ImportStock => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportStock),
        ChannelSyncOperation.ExportProduct => connector.Capabilities.HasFlag(SalesChannelCapabilities.ExportProducts),
        ChannelSyncOperation.UpdateStock => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdateStock),
        ChannelSyncOperation.UpdatePrice => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdatePrice),
        ChannelSyncOperation.UpdateSales => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdateSaless),
        ChannelSyncOperation.DelistProduct => connector.Capabilities.HasFlag(SalesChannelCapabilities.DelistProducts),
        _ => false,
    };

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
