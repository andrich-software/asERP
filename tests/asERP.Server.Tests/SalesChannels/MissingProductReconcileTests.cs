using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the two fixes that keep imported order lines from staying "Unknown Product" forever:
/// (1) the missing-product reconciler selects only rows whose product exists now, so permanently
/// unresolvable rows (SKU never imported, e.g. deleted in the shop) cannot clog the head of the
/// queue and starve the linkable rows behind them, and it drains multiple batches per pass;
/// (2) the scheduler withholds the sales/stock imports of a product-importing channel until the
/// initial product catalogue has landed, so a fresh install matches line items at import time
/// instead of creating hundreds of thousands of missing-product rows.
/// </summary>
public class MissingProductReconcileTests
{
    private static readonly Guid Tenant = new("11111111-1111-1111-1111-111111111111");

    // --- Fix 1: reconciler is not blocked by unresolvable rows at the head of the queue ------------

    [Fact]
    public async Task Reconcile_LinksResolvableRows_BehindAnUnresolvableHead()
    {
        var dbName = Guid.NewGuid().ToString();
        await using var provider = BuildProvider(dbName);

        await using (var seed = NewContext(provider))
        {
            // 550 old rows whose SKU has no product (> one 500-row batch): the previous
            // oldest-first scan re-read exactly these every pass and never linked anything.
            for (var i = 0; i < 550; i++)
            {
                seed.SalesItem.Add(NewMissingItem($"GONE-{i}", DateTime.UtcNow.AddDays(-30)));
            }

            // 5 newer rows whose product exists — these must be linked despite the head.
            for (var i = 0; i < 5; i++)
            {
                seed.Product.Add(NewProduct($"HAVE-{i}"));
                seed.SalesItem.Add(NewMissingItem($"HAVE-{i}", DateTime.UtcNow.AddDays(-1)));
            }

            await seed.SaveChangesAsync();
        }

        await NewOrchestrator(provider).ReconcileMissingProductsAsync(CancellationToken.None);

        await using var verify = NewContext(provider);
        var linked = await verify.SalesItem.IgnoreQueryFilters()
            .Where(i => i.ProductId != Guid.Empty)
            .ToListAsync();
        Assert.Equal(5, linked.Count);
        Assert.All(linked, i => Assert.Equal(string.Empty, i.MissingProductSku));

        // Unresolvable rows keep their SKU so a later product import can still pick them up.
        var stillMissing = await verify.SalesItem.IgnoreQueryFilters()
            .CountAsync(i => i.ProductId == Guid.Empty && i.MissingProductSku.StartsWith("GONE-"));
        Assert.Equal(550, stillMissing);
    }

    [Fact]
    public async Task Reconcile_DrainsMultipleBatches_InOnePass()
    {
        var dbName = Guid.NewGuid().ToString();
        await using var provider = BuildProvider(dbName);

        const int rows = 1200;   // > 2 batches of 500
        await using (var seed = NewContext(provider))
        {
            seed.Product.Add(NewProduct("BULK"));
            for (var i = 0; i < rows; i++)
            {
                seed.SalesItem.Add(NewMissingItem("BULK", DateTime.UtcNow.AddDays(-2)));
            }
            await seed.SaveChangesAsync();
        }

        await NewOrchestrator(provider).ReconcileMissingProductsAsync(CancellationToken.None);

        await using var verify = NewContext(provider);
        Assert.Equal(rows, await verify.SalesItem.IgnoreQueryFilters().CountAsync(i => i.ProductId != Guid.Empty));
        Assert.Equal(0, await verify.SalesItem.IgnoreQueryFilters().CountAsync(i => i.MissingProductSku != ""));
    }

    [Fact]
    public async Task Reconcile_MatchesWithinTenantOnly()
    {
        var dbName = Guid.NewGuid().ToString();
        await using var provider = BuildProvider(dbName);
        var otherTenant = Guid.NewGuid();

        await using (var seed = NewContext(provider))
        {
            var foreignProduct = NewProduct("SHARED-SKU");
            foreignProduct.TenantId = otherTenant;
            seed.Product.Add(foreignProduct);
            seed.SalesItem.Add(NewMissingItem("SHARED-SKU", DateTime.UtcNow.AddDays(-1)));
            await seed.SaveChangesAsync();
        }

        await NewOrchestrator(provider).ReconcileMissingProductsAsync(CancellationToken.None);

        await using var verify = NewContext(provider);
        var item = await verify.SalesItem.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(Guid.Empty, item.ProductId);   // another tenant's product must never be linked
        Assert.Equal("SHARED-SKU", item.MissingProductSku);
    }

    // --- Fix 2: sales/stock imports wait for the initial product catalogue -------------------------

    [Fact]
    public void DueOperations_WithholdSalesAndStock_UntilInitialProductImportCompletes()
    {
        var channel = NewChannel(importProducts: true, importSaless: true, importStock: true, initialProductsDone: false);

        var due = SalesChannelOrchestrator.ComputeDueOperations(channel);

        Assert.Contains(ChannelSyncOperation.ImportProducts, due);
        Assert.DoesNotContain(ChannelSyncOperation.ImportSaless, due);
        Assert.DoesNotContain(ChannelSyncOperation.ImportStock, due);
    }

    [Fact]
    public void DueOperations_ReleaseSalesAndStock_OnceInitialProductImportCompleted()
    {
        var channel = NewChannel(importProducts: true, importSaless: true, importStock: true, initialProductsDone: true);

        var due = SalesChannelOrchestrator.ComputeDueOperations(channel);

        Assert.DoesNotContain(ChannelSyncOperation.ImportProducts, due);   // initial pull done → no re-import
        Assert.Contains(ChannelSyncOperation.ImportSaless, due);
        Assert.Contains(ChannelSyncOperation.ImportStock, due);
    }

    [Fact]
    public void DueOperations_DoNotGateSales_WhenChannelImportsNoProducts()
    {
        var channel = NewChannel(importProducts: false, importSaless: true, importStock: false, initialProductsDone: false);

        var due = SalesChannelOrchestrator.ComputeDueOperations(channel);

        Assert.Contains(ChannelSyncOperation.ImportSaless, due);
    }

    [Fact]
    public void DueOperations_KeepImportingSales_OnEstablishedChannels_EvenWhileCatalogueIncomplete()
    {
        // A channel whose initial sales import already completed must not stop syncing new orders just
        // because the product catalogue is (still or again) incomplete — the reconciler heals those
        // lines. Only the fresh-setup backfill waits for the catalogue. Stock stays gated: its seed
        // silently drops unknown SKUs and the incremental pass never returns to them.
        var channel = NewChannel(importProducts: true, importSaless: true, importStock: true, initialProductsDone: false);
        channel.SyncState.InitialSalesImportCompleted = true;

        var due = SalesChannelOrchestrator.ComputeDueOperations(channel);

        Assert.Contains(ChannelSyncOperation.ImportSaless, due);
        Assert.DoesNotContain(ChannelSyncOperation.ImportStock, due);
    }

    // --- helpers -----------------------------------------------------------------------------------

    private static SalesItem NewMissingItem(string sku, DateTime dateCreated) => new()
    {
        Id = Guid.NewGuid(),
        SalesId = Guid.NewGuid(),
        ProductId = Guid.Empty,
        MissingProductSku = sku,
        MissingProductEan = string.Empty,
        Name = $"Line {sku}",
        Quantity = 1,
        Price = 9.99m,
        TenantId = Tenant,
        DateCreated = dateCreated,
        DateModified = dateCreated,
    };

    private static Product NewProduct(string sku) => new()
    {
        Id = Guid.NewGuid(),
        Sku = sku,
        Name = $"Product {sku}",
        TenantId = Tenant,
    };

    private static SalesChannel NewChannel(bool importProducts, bool importSaless, bool importStock, bool initialProductsDone) => new()
    {
        Id = Guid.NewGuid(),
        Type = SalesChannelType.WooCommerce,
        Name = "test-shop",
        IsEnabled = true,
        ImportProducts = importProducts,
        ImportSaless = importSaless,
        ImportStock = importStock,
        SyncState = new SalesChannelSyncState { InitialProductImportCompleted = initialProductsDone },
    };

    private static SalesChannelOrchestrator NewOrchestrator(ServiceProvider provider) => new(
        provider.GetRequiredService<IServiceScopeFactory>(),
        NullLogger<SalesChannelOrchestrator>.Instance);

    private static ApplicationDbContext NewContext(ServiceProvider provider) => new(
        provider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(),
        new TestTenantContext());

    private static ServiceProvider BuildProvider(string dbName)
    {
        var services = new ServiceCollection();
        services.AddSingleton<ITenantContext, TestTenantContext>();
        services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase(dbName));
        return services.BuildServiceProvider();
    }

    private sealed class TestTenantContext : ITenantContext
    {
        private Guid? _tenantId = Tenant;
        private HashSet<Guid> _assigned = new() { Tenant };
        public Guid? GetCurrentTenantId() => _tenantId;
        public void SetCurrentTenantId(Guid? tenantId) => _tenantId = tenantId;
        public bool HasTenant() => _tenantId.HasValue;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => _assigned;
        public void SetAssignedTenantIds(IEnumerable<Guid> ids) => _assigned = new HashSet<Guid>(ids ?? Enumerable.Empty<Guid>());
        public bool IsAssignedToTenant(Guid tenantId) => _assigned.Contains(tenantId);
    }
}
