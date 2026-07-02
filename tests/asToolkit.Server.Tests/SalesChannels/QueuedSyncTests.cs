using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Abstractions;
using asToolkit.SalesChannels.Logging;
using asToolkit.SalesChannels.Orchestration;
using asToolkit.SalesChannels.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asToolkit.Server.Tests.SalesChannels;

/// <summary>
/// Covers the async manual-sync rework: manual triggers enqueue a durable
/// <see cref="ChannelSyncRunStatus.Queued"/> run that the orchestrator adopts on its next tick, and a
/// channel's operations (sales ∥ customers) run concurrently now that the shared
/// <see cref="ImportIdAllocator"/> makes their id sequences race-free.
/// </summary>
public class QueuedSyncTests
{
    // --- Queued runs are picked up and executed by the orchestrator --------------------------------

    [Fact]
    public async Task Orchestrator_DispatchesQueuedRun_AndClosesIt()
    {
        var dbName = Guid.NewGuid().ToString();
        var connector = new CountingConnector();
        await using var provider = BuildProvider(dbName, connector);

        Guid runId;
        using (var scope = provider.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            // ImportSaless=false → the scheduled poll launches nothing; only the queued run may execute.
            var channel = NewChannel(importSaless: false);
            ctx.SalesChannel.Add(channel);

            var run = new ChannelSyncRun
            {
                Id = Guid.NewGuid(),
                SalesChannelId = channel.Id,
                Operation = ChannelSyncOperation.ImportSaless,
                TriggerSource = ChannelSyncTriggerSource.Manual,
                Status = ChannelSyncRunStatus.Queued,
                StartedAt = DateTime.UtcNow,
                CorrelationId = Guid.NewGuid(),
            };
            ctx.ChannelSyncRun.Add(run);
            await ctx.SaveChangesAsync();
            runId = run.Id;
        }

        var orchestrator = new SalesChannelOrchestrator(
            provider.GetRequiredService<IServiceScopeFactory>(),
            NullLogger<SalesChannelOrchestrator>.Instance,
            TimeSpan.FromMilliseconds(50));

        await orchestrator.StartAsync(CancellationToken.None);
        try
        {
            await WaitForAsync(async () =>
            {
                await using var ctx = new ApplicationDbContext(NewOptions(dbName), new TestTenantContext());
                var run = await ctx.ChannelSyncRun.IgnoreQueryFilters().FirstAsync(r => r.Id == runId);
                return run.Status == ChannelSyncRunStatus.Success;
            }, TimeSpan.FromSeconds(10), "queued run was not dispatched and closed");
        }
        finally
        {
            await orchestrator.StopAsync(CancellationToken.None);
        }

        Assert.Equal(1, connector.SalesImportCalls);

        await using var verify = new ApplicationDbContext(NewOptions(dbName), new TestTenantContext());
        var closed = await verify.ChannelSyncRun.IgnoreQueryFilters().FirstAsync(r => r.Id == runId);
        Assert.Equal(ChannelSyncRunStatus.Success, closed.Status);
        Assert.NotNull(closed.FinishedAt);
        Assert.Equal(1, closed.ItemsProcessed);
    }

    [Fact]
    public async Task Orchestrator_FailsQueuedRun_WhenChannelIsDisabled()
    {
        var dbName = Guid.NewGuid().ToString();
        var connector = new CountingConnector();
        await using var provider = BuildProvider(dbName, connector);

        Guid runId;
        using (var scope = provider.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var channel = NewChannel(importSaless: false);
            channel.IsEnabled = false;
            ctx.SalesChannel.Add(channel);

            var run = new ChannelSyncRun
            {
                Id = Guid.NewGuid(),
                SalesChannelId = channel.Id,
                Operation = ChannelSyncOperation.ImportSaless,
                TriggerSource = ChannelSyncTriggerSource.Manual,
                Status = ChannelSyncRunStatus.Queued,
                StartedAt = DateTime.UtcNow,
                CorrelationId = Guid.NewGuid(),
            };
            ctx.ChannelSyncRun.Add(run);
            await ctx.SaveChangesAsync();
            runId = run.Id;
        }

        var orchestrator = new SalesChannelOrchestrator(
            provider.GetRequiredService<IServiceScopeFactory>(),
            NullLogger<SalesChannelOrchestrator>.Instance,
            TimeSpan.FromMilliseconds(50));

        await orchestrator.StartAsync(CancellationToken.None);
        try
        {
            await WaitForAsync(async () =>
            {
                await using var ctx = new ApplicationDbContext(NewOptions(dbName), new TestTenantContext());
                var run = await ctx.ChannelSyncRun.IgnoreQueryFilters().FirstAsync(r => r.Id == runId);
                return run.Status == ChannelSyncRunStatus.Failed;
            }, TimeSpan.FromSeconds(10), "queued run for a disabled channel was not failed");
        }
        finally
        {
            await orchestrator.StopAsync(CancellationToken.None);
        }

        Assert.Equal(0, connector.SalesImportCalls);
    }

    // --- Two operations of one channel run concurrently --------------------------------------------

    [Fact]
    public async Task Orchestrator_RunsSalesAndCustomersOfOneChannel_Concurrently()
    {
        var dbName = Guid.NewGuid().ToString();
        var salesStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var customersStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var connector = new TwoOpBlockingConnector(salesStarted, customersStarted, release);

        await using var provider = BuildProvider(dbName, connector);

        using (var scope = provider.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            // Sales (incremental) + customers (initial pull pending) are both due on the first tick.
            ctx.SalesChannel.Add(NewChannel(importSaless: true, importCustomers: true, initialSalesDone: true));
            await ctx.SaveChangesAsync();
        }

        var orchestrator = new SalesChannelOrchestrator(
            provider.GetRequiredService<IServiceScopeFactory>(),
            NullLogger<SalesChannelOrchestrator>.Instance,
            TimeSpan.FromMilliseconds(50));

        await orchestrator.StartAsync(CancellationToken.None);
        try
        {
            // Both imports must be in flight AT THE SAME TIME — with the old channel-wide lock the
            // customer import could not start while the (blocked) sales import held the channel.
            await Task.WhenAll(salesStarted.Task, customersStarted.Task).WaitAsync(TimeSpan.FromSeconds(10));
        }
        finally
        {
            release.TrySetResult();
            await orchestrator.StopAsync(CancellationToken.None);
        }
    }

    // --- ImportIdAllocator --------------------------------------------------------------------------

    [Fact]
    public async Task ImportIdAllocator_HandsOutUniqueIds_UnderParallelLoad()
    {
        var allocator = new ImportIdAllocator();
        var seedCalls = 0;

        var ids = new int[500];
        await Parallel.ForAsync(0, ids.Length, async (i, _) =>
        {
            ids[i] = await allocator.NextAsync(null, ImportIdAllocator.CustomerKind, () =>
            {
                Interlocked.Increment(ref seedCalls);
                return Task.FromResult(100);
            });
        });

        Assert.Equal(ids.Length, ids.Distinct().Count());
        Assert.Equal(101, ids.Min());
        Assert.Equal(100 + ids.Length, ids.Max());
        Assert.Equal(1, seedCalls);
    }

    [Fact]
    public async Task ImportIdAllocator_RetriesSeed_AfterFailure()
    {
        var allocator = new ImportIdAllocator();
        var attempts = 0;

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            allocator.NextAsync(null, ImportIdAllocator.SalesKind, () =>
            {
                attempts++;
                throw new InvalidOperationException("db down");
            }));

        // The failed seed must not poison the key — the next call re-seeds.
        var id = await allocator.NextAsync(null, ImportIdAllocator.SalesKind, () =>
        {
            attempts++;
            return Task.FromResult(7);
        });

        Assert.Equal(8, id);
        Assert.Equal(2, attempts);
    }

    // --- helpers -----------------------------------------------------------------------------------

    private static DbContextOptions<ApplicationDbContext> NewOptions(string dbName) =>
        new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(dbName).Options;

    private static async Task WaitForAsync(Func<Task<bool>> condition, TimeSpan timeout, string failureMessage)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            if (await condition())
            {
                return;
            }
            await Task.Delay(25);
        }

        Assert.Fail(failureMessage);
    }

    private static SalesChannel NewChannel(
        bool importSaless = true,
        bool importCustomers = false,
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
            ImportProducts = false,
            ImportCustomers = importCustomers,
            ImportSaless = importSaless,
            InitialSalesImportCompleted = initialSalesDone,
            SyncIntervalSeconds = 0,
        };

    private static ServiceProvider BuildProvider(string dbName, ISalesChannelConnector connector)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<ITenantContext, TestTenantContext>();
        services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase(dbName));
        services.AddHttpClient();
        services.AddSingleton<ICredentialEncryptor, PassthroughEncryptor>();
        services.AddSingleton<ISalesChannelSyncLogBuffer, SalesChannelSyncLogBuffer>();
        services.AddSingleton<ImportIdAllocator>();
        services.AddSingleton<ISalesChannelConnectorRegistry>(_ => new SalesChannelConnectorRegistry(new[] { connector }));
        services.AddScoped<SalesChannelContextFactory>();
        services.AddScoped<SyncDispatcher>();
        services.AddScoped<OutboxDrainer>();
        services.AddScoped<SyncLogDrainer>();
        return services.BuildServiceProvider();
    }

    private sealed class TestTenantContext : ITenantContext
    {
        private Guid? _tenantId;
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

    private abstract class TestConnectorBase : ISalesChannelConnector
    {
        public SalesChannelType Type => SalesChannelType.WooCommerce;
        public SalesChannelCapabilities Capabilities =>
            SalesChannelCapabilities.ImportProducts | SalesChannelCapabilities.ImportSaless | SalesChannelCapabilities.ImportCustomers;

        public Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context) => Task.FromResult(new ConnectionTestResult(true));
        public virtual Task<SyncResult> ImportProductsAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportSalessAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportCustomersAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public virtual Task<SyncResult> ImportStockAsync(SalesChannelContext context) => Task.FromResult(SyncResult.Empty);
        public Task<ExportResult> ExportProductAsync(SalesChannelContext context, ProductExportPayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> UpdateSalesAsync(SalesChannelContext context, SalesUpdatePayload payload) => Task.FromResult(ExportResult.Ok());
        public Task<ExportResult> DelistProductAsync(SalesChannelContext context, DelistPayload payload) => Task.FromResult(ExportResult.Ok());
    }

    private sealed class CountingConnector : TestConnectorBase
    {
        private int _salesImportCalls;
        public int SalesImportCalls => _salesImportCalls;

        public override Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
        {
            Interlocked.Increment(ref _salesImportCalls);
            return Task.FromResult(new SyncResult(1, 0));
        }
    }

    /// <summary>Signals when each operation starts, then parks both until released.</summary>
    private sealed class TwoOpBlockingConnector : TestConnectorBase
    {
        private readonly TaskCompletionSource _salesStarted;
        private readonly TaskCompletionSource _customersStarted;
        private readonly TaskCompletionSource _release;

        public TwoOpBlockingConnector(TaskCompletionSource salesStarted, TaskCompletionSource customersStarted, TaskCompletionSource release)
        {
            _salesStarted = salesStarted;
            _customersStarted = customersStarted;
            _release = release;
        }

        public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
        {
            _salesStarted.TrySetResult();
            await _release.Task;
            return new SyncResult(1, 0);
        }

        public override async Task<SyncResult> ImportCustomersAsync(SalesChannelContext context)
        {
            _customersStarted.TrySetResult();
            await _release.Task;
            return new SyncResult(1, 0);
        }
    }
}
