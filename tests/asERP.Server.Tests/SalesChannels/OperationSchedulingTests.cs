using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Logging;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the durable per-(channel, operation) scheduling introduced with
/// <see cref="SalesChannelOperationState"/>: row self-healing, the due-query dispatch (flag +
/// completion gating in the query, ordering gating via recheck pushes), the dispatcher's durable
/// watermark semantics, and the hard run timeout.
/// </summary>
public class OperationSchedulingTests
{
    private static DbContextOptions<ApplicationDbContext> NewInMemoryOptions(string dbName) =>
        new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(dbName).Options;

    // --- row self-healing --------------------------------------------------------------------------

    [Fact]
    public async Task EnsureRows_CreatesOneRowPerImportOperation()
    {
        var dbName = Guid.NewGuid().ToString();
        var connector = new RecordingConnector();
        await using var provider = BuildProvider(dbName, connector);
        var channel = await SeedChannelAsync(provider, importSaless: true);

        var orchestrator = NewOrchestrator(provider);
        using (var scope = provider.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await orchestrator.EnsureOperationStateRowsAsync(ctx, CancellationToken.None);
        }

        await using var verify = NewContext(provider);
        var rows = await verify.SalesChannelOperationState.IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == channel.Id)
            .ToListAsync();
        Assert.Equal(SalesChannelOrchestrator.ScheduledImportOperations.Length, rows.Count);
        Assert.All(rows, r => Assert.Equal(ChannelSyncPhase.Unknown, r.Phase));
    }

    // --- due-query dispatch ------------------------------------------------------------------------

    [Fact]
    public async Task DueDispatch_LaunchesEligibleOperation_AndStampsProvisionalNextDue()
    {
        var dbName = Guid.NewGuid().ToString();
        var connector = new RecordingConnector();
        await using var provider = BuildProvider(dbName, connector);
        var channel = await SeedChannelAsync(provider, importSaless: true, initialSalesDone: true);

        var orchestrator = NewOrchestrator(provider);
        await orchestrator.DispatchDueOperationsAsync(CancellationToken.None);
        await WaitForFinishedRunAsync(provider, channel.Id, ChannelSyncOperation.ImportSaless);

        Assert.Contains(ChannelSyncOperation.ImportSaless, connector.InvokedOperations);

        await using var verify = NewContext(provider);
        var state = await verify.SalesChannelOperationState.IgnoreQueryFilters()
            .SingleAsync(o => o.SalesChannelId == channel.Id && o.Operation == ChannelSyncOperation.ImportSaless);
        Assert.NotNull(state.LastStartedAt);
        Assert.True(state.NextDueAt > state.LastStartedAt, "a launched operation must not be due again immediately");
    }

    [Fact]
    public async Task DueDispatch_KeepsSchedulingCompletedCatalogueOps_Incrementally()
    {
        // The one-shot era is over: a completed product import keeps running as incremental delta
        // pulls — the cadence comes from the operation state, not from the Initial*Completed flag.
        var dbName = Guid.NewGuid().ToString();
        var connector = new RecordingConnector();
        await using var provider = BuildProvider(dbName, connector);
        var channel = await SeedChannelAsync(provider, importProducts: true, initialProductsDone: true);

        var orchestrator = NewOrchestrator(provider);
        await orchestrator.DispatchDueOperationsAsync(CancellationToken.None);
        await WaitForFinishedRunAsync(provider, channel.Id, ChannelSyncOperation.ImportProducts);

        Assert.Contains(ChannelSyncOperation.ImportProducts, connector.InvokedOperations);

        // The very first incremental run bootstraps with a full sweep (null watermark, heals drift
        // from the one-shot era) and stamps the full-sweep timestamp.
        Assert.Null(connector.LastIncrementalSince);
        await using var verify = NewContext(provider);
        var state = await verify.SalesChannelOperationState.IgnoreQueryFilters()
            .SingleAsync(o => o.SalesChannelId == channel.Id && o.Operation == ChannelSyncOperation.ImportProducts);
        Assert.Equal(ChannelSyncPhase.Incremental, state.Phase);
        Assert.NotNull(state.Watermark);
        Assert.NotNull(state.LastFullSweepAt);
    }

    [Fact]
    public async Task DueDispatch_HoldsSalesByGating_AndPushesRecheck_WhileCatalogueIncomplete()
    {
        var dbName = Guid.NewGuid().ToString();
        var connector = new RecordingConnector();
        await using var provider = BuildProvider(dbName, connector);
        var channel = await SeedChannelAsync(provider, importProducts: true, importSaless: true);

        var orchestrator = NewOrchestrator(provider);
        var before = DateTime.UtcNow;
        await orchestrator.DispatchDueOperationsAsync(CancellationToken.None);
        await WaitForFinishedRunAsync(provider, channel.Id, ChannelSyncOperation.ImportProducts);

        // The initial product import launches; the sales import is held back by gating and its row is
        // pushed to a short recheck instead of spinning in the due-query every tick.
        Assert.Contains(ChannelSyncOperation.ImportProducts, connector.InvokedOperations);
        Assert.DoesNotContain(ChannelSyncOperation.ImportSaless, connector.InvokedOperations);

        await using var verify = NewContext(provider);
        var salesState = await verify.SalesChannelOperationState.IgnoreQueryFilters()
            .SingleAsync(o => o.SalesChannelId == channel.Id && o.Operation == ChannelSyncOperation.ImportSaless);
        Assert.True(salesState.NextDueAt > before, "gated row must be pushed to a recheck");
        Assert.Null(salesState.LastStartedAt);
    }

    // --- dispatcher: durable watermark -------------------------------------------------------------

    [Fact]
    public async Task Watermark_AdvancesOnSuccess_NotOnFailure()
    {
        var options = NewInMemoryOptions(Guid.NewGuid().ToString());
        await using var context = new ApplicationDbContext(options, new TestTenantContext());
        var channel = NewChannel(importSaless: true, initialSalesDone: true);

        var connector = new RecordingConnector();
        var dispatcher = NewDispatcher(context, connector);

        var successRun = await dispatcher.RunImportAsync(
            channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, CancellationToken.None);
        var state = await context.SalesChannelOperationState.IgnoreQueryFilters()
            .SingleAsync(o => o.SalesChannelId == channel.Id && o.Operation == ChannelSyncOperation.ImportSaless);
        Assert.Equal(successRun.StartedAt, state.Watermark);

        connector.FailNext = true;
        await dispatcher.RunImportAsync(
            channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, CancellationToken.None);
        Assert.Equal(successRun.StartedAt, state.Watermark);   // unchanged — failures never advance it
        Assert.Equal(1, state.ConsecutiveFailures);
    }

    [Fact]
    public async Task ManualTrigger_ForcesFullSweep_DespiteWatermark()
    {
        var options = NewInMemoryOptions(Guid.NewGuid().ToString());
        await using var context = new ApplicationDbContext(options, new TestTenantContext());
        var channel = NewChannel(importSaless: true, initialSalesDone: true);

        var connector = new RecordingConnector();
        var dispatcher = NewDispatcher(context, connector);

        // First scheduled run establishes a watermark; the second (scheduled) must carry it.
        await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, CancellationToken.None);
        await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, CancellationToken.None);
        Assert.NotNull(connector.LastIncrementalSince);

        await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Manual, CancellationToken.None);
        Assert.Null(connector.LastIncrementalSince);   // manual = the recovery lever, always full
    }

    // --- dispatcher: hard timeout ------------------------------------------------------------------

    [Fact]
    public async Task HardTimeout_FailsRun_AndAppliesFailureBackoff()
    {
        var options = NewInMemoryOptions(Guid.NewGuid().ToString());
        await using var context = new ApplicationDbContext(options, new TestTenantContext());
        var channel = NewChannel(importSaless: true, initialSalesDone: true);

        var connector = new HangingConnector();
        var dispatcher = NewDispatcher(context, connector, new SalesChannelSyncOptions { RunHardTimeoutMinutes = 0 });

        var run = await dispatcher.RunImportAsync(
            channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, CancellationToken.None);

        Assert.Equal(ChannelSyncRunStatus.Failed, run.Status);
        Assert.Contains("hard timeout", run.ErrorSummary, StringComparison.OrdinalIgnoreCase);

        var state = await context.SalesChannelOperationState.IgnoreQueryFilters()
            .SingleAsync(o => o.SalesChannelId == channel.Id && o.Operation == ChannelSyncOperation.ImportSaless);
        Assert.Equal(1, state.ConsecutiveFailures);
        Assert.True(state.NextDueAt > DateTime.UtcNow.AddSeconds(30), "failure backoff must delay the retry");
    }

    // --- helpers -----------------------------------------------------------------------------------

    private static SalesChannel NewChannel(
        bool importProducts = false,
        bool importSaless = false,
        bool initialProductsDone = false,
        bool initialSalesDone = false) => new()
        {
            Id = Guid.NewGuid(),
            TenantId = null,
            Type = SalesChannelType.WooCommerce,
            Name = "test-shop",
            Url = "https://shop.example/wp-json/wc/v3",
            Username = "key",
            Password = "secret",
            IsEnabled = true,
            ImportProducts = importProducts,
            ImportSaless = importSaless,
            SyncIntervalSeconds = 60,
            SyncState = new SalesChannelSyncState
            {
                InitialProductImportCompleted = initialProductsDone,
                InitialSalesImportCompleted = initialSalesDone,
            },
        };

    private static async Task<SalesChannel> SeedChannelAsync(
        ServiceProvider provider,
        bool importProducts = false,
        bool importSaless = false,
        bool initialProductsDone = false,
        bool initialSalesDone = false)
    {
        using var scope = provider.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var channel = NewChannel(importProducts, importSaless, initialProductsDone, initialSalesDone);
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();
        return channel;
    }

    private static async Task WaitForFinishedRunAsync(ServiceProvider provider, Guid channelId, ChannelSyncOperation operation)
    {
        var deadline = DateTime.UtcNow + TimeSpan.FromSeconds(10);
        while (DateTime.UtcNow < deadline)
        {
            await using var ctx = NewContext(provider);
            if (await ctx.ChannelSyncRun.IgnoreQueryFilters().AnyAsync(r =>
                    r.SalesChannelId == channelId && r.Operation == operation && r.Status != ChannelSyncRunStatus.Running))
            {
                return;
            }
            await Task.Delay(25);
        }

        Assert.Fail($"No finished {operation} run for channel {channelId} within 10s — the due dispatch did not launch it.");
    }

    private static SalesChannelOrchestrator NewOrchestrator(ServiceProvider provider) => new(
        provider.GetRequiredService<IServiceScopeFactory>(),
        NullLogger<SalesChannelOrchestrator>.Instance,
        TimeSpan.FromMilliseconds(50));

    private static ApplicationDbContext NewContext(ServiceProvider provider) => new(
        provider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(),
        new TestTenantContext());

    private static SyncDispatcher NewDispatcher(ApplicationDbContext context, ISalesChannelConnector connector, SalesChannelSyncOptions? options = null)
    {
        var registry = new SalesChannelConnectorRegistry(new[] { connector });
        var factory = new SalesChannelContextFactory(new StubHttpClientFactory(), new PassthroughEncryptor());
        return new SyncDispatcher(context, registry, factory, new TestTenantContext(),
            Microsoft.Extensions.Options.Options.Create(options ?? new SalesChannelSyncOptions()), NullLogger<SyncDispatcher>.Instance);
    }

    private static ServiceProvider BuildProvider(string dbName, ISalesChannelConnector connector)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddOptions();
        services.AddSingleton<ITenantContext, TestTenantContext>();
        services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase(dbName));
        services.AddHttpClient();
        services.AddSingleton<ICredentialEncryptor, PassthroughEncryptor>();
        services.AddSingleton<ISalesChannelSyncLogBuffer, SalesChannelSyncLogBuffer>();
        services.AddSingleton<ISalesChannelConnectorRegistry>(_ => new SalesChannelConnectorRegistry(new[] { connector }));
        services.AddScoped<SalesChannelContextFactory>();
        services.AddScoped<SyncDispatcher>();
        services.AddScoped<OutboxDrainer>();
        services.AddScoped<SyncLogDrainer>();
        return services.BuildServiceProvider();
    }

    private sealed class TestTenantContext : ITenantContext
    {
        private Guid? _tenantId = new Guid("11111111-1111-1111-1111-111111111111");
        private HashSet<Guid> _assigned = new();
        public Guid? GetCurrentTenantId() => _tenantId;
        public void SetCurrentTenantId(Guid? tenantId) => _tenantId = tenantId;
        public bool HasTenant() => _tenantId.HasValue;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => _assigned;
        public void SetAssignedTenantIds(IEnumerable<Guid> ids) => _assigned = new HashSet<Guid>(ids ?? Enumerable.Empty<Guid>());
        public bool IsAssignedToTenant(Guid tenantId) => _assigned.Contains(tenantId);
    }

    private sealed class PassthroughEncryptor : ICredentialEncryptor
    {
        public string Encrypt(string plaintext) => plaintext;
        public string Decrypt(string ciphertext) => ciphertext;
    }

    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }

    private abstract class TestConnectorBase : ISalesChannelConnector
    {
        public abstract SalesChannelType Type { get; }
        public virtual SalesChannelCapabilities Capabilities =>
            SalesChannelCapabilities.ImportProducts | SalesChannelCapabilities.ImportSaless
            | SalesChannelCapabilities.ImportCustomers | SalesChannelCapabilities.ImportStock
            | SalesChannelCapabilities.ImportCategories;

        public Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context) => Task.FromResult(new ConnectionTestResult(true));
        public virtual Task<SyncResult> ImportProductsAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportSalessAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportCustomersAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportStockAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportCategoriesAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportShipmentsAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public Task<ExportResult> ExportProductAsync(SalesChannelContext context, ProductExportPayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdateSalesAsync(SalesChannelContext context, SalesUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> DelistProductAsync(SalesChannelContext context, DelistPayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> CancelSalesAsync(SalesChannelContext context, CancelSalesPayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> ExportCategoryAsync(SalesChannelContext context, CategoryExportPayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> DeleteCategoryAsync(SalesChannelContext context, CategoryDeletePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdateProductCategoriesAsync(SalesChannelContext context, ProductCategoriesUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> PushShipmentAsync(SalesChannelContext context, ShipmentPushPayload payload) => Task.FromResult(ExportResult.Ok());
    }

    /// <summary>Records which import operations ran and the watermark each received; can fail on demand.</summary>
    private sealed class RecordingConnector : TestConnectorBase
    {
        public List<ChannelSyncOperation> InvokedOperations { get; } = new();
        public DateTime? LastIncrementalSince { get; private set; }
        public bool FailNext { get; set; }

        public override SalesChannelType Type => SalesChannelType.WooCommerce;

        private Task<SyncResult> Record(ChannelSyncOperation operation, SalesChannelContext context)
        {
            lock (InvokedOperations)
            {
                InvokedOperations.Add(operation);
            }
            LastIncrementalSince = context.IncrementalSince;

            if (FailNext)
            {
                FailNext = false;
                return Task.FromResult(SyncResult.Failed("simulated failure"));
            }

            return Task.FromResult(new SyncResult(1, 0));
        }

        public override Task<SyncResult> ImportProductsAsync(SalesChannelContext context) => Record(ChannelSyncOperation.ImportProducts, context);
        public override Task<SyncResult> ImportSalessAsync(SalesChannelContext context) => Record(ChannelSyncOperation.ImportSaless, context);
        public override Task<SyncResult> ImportCustomersAsync(SalesChannelContext context) => Record(ChannelSyncOperation.ImportCustomers, context);
        public override Task<SyncResult> ImportStockAsync(SalesChannelContext context) => Record(ChannelSyncOperation.ImportStock, context);
        public override Task<SyncResult> ImportCategoriesAsync(SalesChannelContext context) => Record(ChannelSyncOperation.ImportCategories, context);
    }

    /// <summary>Parks until the context token fires — exercises the dispatcher's hard timeout.</summary>
    private sealed class HangingConnector : TestConnectorBase
    {
        public override SalesChannelType Type => SalesChannelType.WooCommerce;

        public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
        {
            await Task.Delay(TimeSpan.FromSeconds(30), context.CancellationToken);
            return new SyncResult(1, 0);
        }
    }
}
