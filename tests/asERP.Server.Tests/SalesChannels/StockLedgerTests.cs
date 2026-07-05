using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Repositories;
using asERP.Persistence.Services;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the stock ledger of the shop-mirror model: exactly-once booking per order line, absolute
/// mirror sets, and the import-side gating — the stock-master channel and the historical backfill must
/// never book movements, cancellations compensate only what was actually booked.
/// </summary>
public class StockLedgerTests
{
    // --- StockLedgerService --------------------------------------------------------------------------

    [Fact]
    public async Task ApplyMovement_SameSalesItemTwice_BooksOnlyOnce()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var (productId, warehouseId) = await SeedProductWithStockAsync(ctx, initialStock: 10);

        var salesItemId = Guid.NewGuid();
        var request = new StockMovementRequest(productId, warehouseId, -3, StockMovementType.SaleImport, SalesItemId: salesItemId);

        Assert.True(await ledger.ApplyMovementAsync(request, CancellationToken.None));
        Assert.False(await ledger.ApplyMovementAsync(request, CancellationToken.None));

        Assert.Equal(1, await ctx.StockMovement.IgnoreQueryFilters().CountAsync());
        var stock = await ctx.ProductStock.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(7, stock.Stock);
    }

    [Fact]
    public async Task ApplyMovement_WithoutStockRow_CreatesNegativeBalance()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;

        var productId = Guid.NewGuid();
        var warehouseId = Guid.NewGuid();
        await ledger.ApplyMovementAsync(
            new StockMovementRequest(productId, warehouseId, -2, StockMovementType.SaleImport, SalesItemId: Guid.NewGuid()),
            CancellationToken.None);

        // Negative starting balance is the deliberate data-quality signal for "sold without a mirror".
        var stock = await ctx.ProductStock.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(-2, stock.Stock);
    }

    [Fact]
    public async Task SetAbsoluteStock_BooksDelta_AndIsIdempotentOnSameValue()
    {
        var (ctx, ledger, published) = Build();
        await using var _ctx = ctx;
        var (productId, warehouseId) = await SeedProductWithStockAsync(ctx, initialStock: 5);

        Assert.True(await ledger.SetAbsoluteStockAsync(productId, warehouseId, 12, StockMovementType.MirrorCorrection, null, CancellationToken.None));
        Assert.False(await ledger.SetAbsoluteStockAsync(productId, warehouseId, 12, StockMovementType.MirrorCorrection, null, CancellationToken.None));

        var stock = await ctx.ProductStock.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(12, stock.Stock);

        var movement = await ctx.StockMovement.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(7, movement.QuantityDelta);
        Assert.Equal(StockMovementType.MirrorCorrection, movement.Type);

        // Exactly one StockChangedNotification — the unchanged second set must not push exports.
        Assert.Single(published.OfType<StockChangedNotification>());
    }

    // --- SalesImportRepository booking gates ----------------------------------------------------------

    [Fact]
    public async Task Import_IncrementalNonMasterChannel_BooksSaleMovement()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var repo = BuildSalesImportRepository(ctx, ledger);

        var (channel, productId, warehouseId) = await SeedChannelWithWarehouseAsync(ctx, importStock: false, initialSalesDone: true);
        await SeedStockAsync(ctx, productId, warehouseId, 10);

        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2));

        var stock = await ctx.ProductStock.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(8, stock.Stock);
        var movement = await ctx.StockMovement.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(StockMovementType.SaleImport, movement.Type);
        Assert.Equal(-2, movement.QuantityDelta);
    }

    [Fact]
    public async Task Import_DuringBackfill_BooksNothing()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var repo = BuildSalesImportRepository(ctx, ledger);

        var (channel, productId, warehouseId) = await SeedChannelWithWarehouseAsync(ctx, importStock: false, initialSalesDone: false);
        await SeedStockAsync(ctx, productId, warehouseId, 10);

        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2));

        Assert.Equal(0, await ctx.StockMovement.IgnoreQueryFilters().CountAsync());
        var stock = await ctx.ProductStock.IgnoreQueryFilters().SingleAsync();
        Assert.Equal(10, stock.Stock);
    }

    [Fact]
    public async Task Import_FromStockMasterChannel_BooksNothing()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var repo = BuildSalesImportRepository(ctx, ledger);

        var (channel, productId, warehouseId) = await SeedChannelWithWarehouseAsync(ctx, importStock: true, initialSalesDone: true);
        await SeedStockAsync(ctx, productId, warehouseId, 10);

        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2));

        // The master already decremented itself; the mirror sync carries its numbers.
        Assert.Equal(0, await ctx.StockMovement.IgnoreQueryFilters().CountAsync());
    }

    [Fact]
    public async Task Cancellation_CompensatesOnlyBookedLines_Once()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var repo = BuildSalesImportRepository(ctx, ledger);

        var (channel, productId, warehouseId) = await SeedChannelWithWarehouseAsync(ctx, importStock: false, initialSalesDone: true);
        await SeedStockAsync(ctx, productId, warehouseId, 10);

        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2));
        Assert.Equal(8, (await ctx.ProductStock.IgnoreQueryFilters().SingleAsync()).Stock);

        // Order flips to cancelled → compensation.
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2, status: SalesStatus.Cancelled));
        Assert.Equal(10, (await ctx.ProductStock.IgnoreQueryFilters().SingleAsync()).Stock);

        // Replayed cancellation must not double-compensate.
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2, status: SalesStatus.Cancelled));
        Assert.Equal(10, (await ctx.ProductStock.IgnoreQueryFilters().SingleAsync()).Stock);

        Assert.Equal(2, await ctx.StockMovement.IgnoreQueryFilters().CountAsync());
    }

    [Fact]
    public async Task Cancellation_OfBackfilledOrder_DoesNotCreatePhantomStock()
    {
        var (ctx, ledger, _) = Build();
        await using var _ctx = ctx;
        var repo = BuildSalesImportRepository(ctx, ledger);

        // Imported during backfill → no decrement was booked.
        var (channel, productId, warehouseId) = await SeedChannelWithWarehouseAsync(ctx, importStock: false, initialSalesDone: false);
        await SeedStockAsync(ctx, productId, warehouseId, 10);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2));

        // Later (still or again) cancelled — the compensation must be skipped.
        channel.InitialSalesImportCompleted = true;
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("O-1", quantity: 2, status: SalesStatus.Cancelled));

        Assert.Equal(0, await ctx.StockMovement.IgnoreQueryFilters().CountAsync());
        Assert.Equal(10, (await ctx.ProductStock.IgnoreQueryFilters().SingleAsync()).Stock);
    }

    // --- helpers -------------------------------------------------------------------------------------

    private static (ApplicationDbContext Context, StockLedgerService Ledger, List<INotification> Published) Build()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var ctx = new ApplicationDbContext(options, new TestTenantContext());
        var published = new List<INotification>();
        var ledger = new StockLedgerService(ctx, new CapturingMediator(published), NullLogger<StockLedgerService>.Instance);
        return (ctx, ledger, published);
    }

    private static SalesImportRepository BuildSalesImportRepository(ApplicationDbContext ctx, IStockLedgerService ledger)
    {
        var tenant = new TestTenantContext();
        return new SalesImportRepository(
            NullLogger<SalesImportRepository>.Instance,
            new SalesRepository(ctx, tenant),
            new CustomerRepository(ctx, tenant),
            new CountryRepository(ctx, tenant),
            new ProductRepository(ctx, tenant),
            ctx,
            new ImportIdAllocator(),
            ledger);
    }

    private static async Task<(Guid ProductId, Guid WarehouseId)> SeedProductWithStockAsync(ApplicationDbContext ctx, double initialStock)
    {
        var productId = Guid.NewGuid();
        var warehouseId = Guid.NewGuid();
        await SeedStockAsync(ctx, productId, warehouseId, initialStock);
        return (productId, warehouseId);
    }

    private static async Task SeedStockAsync(ApplicationDbContext ctx, Guid productId, Guid warehouseId, double stock)
    {
        ctx.ProductStock.Add(new ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            WarehouseId = warehouseId,
            Stock = stock,
        });
        await ctx.SaveChangesAsync();
        ctx.ChangeTracker.Clear();
    }

    private static async Task<(SalesChannel Channel, Guid ProductId, Guid WarehouseId)> SeedChannelWithWarehouseAsync(
        ApplicationDbContext ctx, bool importStock, bool initialSalesDone)
    {
        var warehouse = new Warehouse { Id = Guid.NewGuid(), Name = "Main" };
        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.Shopware6,
            Name = "second-shop",
            Url = "https://shop2.example",
            Username = "key",
            Password = "secret",
            IsEnabled = true,
            ImportSaless = true,
            ImportStock = importStock,
            InitialSalesImportCompleted = initialSalesDone,
            Warehouses = new List<Warehouse> { warehouse },
        };

        var product = new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" };
        ctx.Warehouse.Add(warehouse);
        ctx.SalesChannel.Add(channel);
        ctx.Product.Add(product);
        await ctx.SaveChangesAsync();

        return (channel, product.Id, warehouse.Id);
    }

    private static SalesChannelImportSales NewImport(string remoteSalesId, double quantity, SalesStatus status = SalesStatus.Processing) => new()
    {
        RemoteSalesId = remoteSalesId,
        RemoteCustomerId = "C-1",
        Status = status,
        PaymentStatus = PaymentStatus.CompletelyPaid,
        DateSalesed = DateTime.UtcNow.AddDays(-1),
        Customer = new SalesChannelImportCustomer
        {
            RemoteCustomerId = "C-1",
            Email = "buyer@example.de",
            Firstname = "Test",
            Lastname = "Customer",
            DateEnrollment = DateTime.UtcNow.AddYears(-1),
        },
        SalesItems = new List<SalesChannelImportSalesItem>
        {
            new() { Sku = "SKU-1", Name = "Line item", Quantity = quantity, Price = 10m, TaxRate = 19 },
        },
    };

    private sealed class CapturingMediator : IMediator
    {
        private readonly List<INotification> _published;
        public CapturingMediator(List<INotification> published) => _published = published;

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Send is not used by the ledger");

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            _published.Add(notification);
            return Task.CompletedTask;
        }
    }

    private sealed class TestTenantContext : asERP.Application.Contracts.Services.ITenantContext
    {
        // Production sync always runs under an active tenant (SyncDispatcher sets it); mirror that
        // with a fixed default so directly-exercised repositories/ledger persist under one owner.
        private Guid? _tenantId = new Guid("11111111-1111-1111-1111-111111111111");
        private HashSet<Guid> _assigned = new();
        public Guid? GetCurrentTenantId() => _tenantId;
        public void SetCurrentTenantId(Guid? tenantId) => _tenantId = tenantId;
        public bool HasTenant() => _tenantId.HasValue;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => _assigned;
        public void SetAssignedTenantIds(IEnumerable<Guid> ids) => _assigned = new HashSet<Guid>(ids ?? Enumerable.Empty<Guid>());
        public bool IsAssignedToTenant(Guid tenantId) => _assigned.Contains(tenantId);
    }
}
