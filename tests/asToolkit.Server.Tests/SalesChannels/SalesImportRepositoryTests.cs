using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.Persistence.Repositories;
using asToolkit.SalesChannels.Models;
using asToolkit.SalesChannels.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asToolkit.Server.Tests.SalesChannels;

/// <summary>
/// End-to-end tests for the throughput refactor of <see cref="SalesImportRepository"/> (Phase 2/3):
/// the order graph is built and committed in one SaveChanges, per-run caches/counters are used, and the
/// import stays idempotent. Runs the real repositories over an EF Core InMemory database.
/// </summary>
public class SalesImportRepositoryTests
{
    private static DbContextOptions<ApplicationDbContext> NewOptions() =>
        new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

    private static SalesImportRepository BuildRepository(ApplicationDbContext ctx, ITenantContext tenant) =>
        new(
            NullLogger<ProductImportRepository>.Instance,
            new SalesRepository(ctx, tenant),
            new CustomerRepository(ctx, tenant),
            new CountryRepository(ctx, tenant),
            new ProductRepository(ctx, tenant),
            ctx,
            new ImportIdAllocator());

    private static SalesChannelImportSales NewImport(string remoteSalesId, string remoteCustomerId, string email, string sku) => new()
    {
        RemoteSalesId = remoteSalesId,
        RemoteCustomerId = remoteCustomerId,
        Status = SalesStatus.Processing,
        PaymentStatus = PaymentStatus.CompletelyPaid,
        DateSalesed = DateTime.UtcNow.AddMonths(-6),
        Customer = new SalesChannelImportCustomer
        {
            RemoteCustomerId = remoteCustomerId,
            Email = email,
            Firstname = "Test",
            Lastname = "Customer",
            DateEnrollment = DateTime.UtcNow.AddYears(-1),
        },
        SalesItems = new List<SalesChannelImportSalesItem>
        {
            new() { Sku = sku, Name = "Line item", Quantity = 2, Price = 10m, TaxRate = 19 },
        },
        // Empty country → no structured address created; keeps the test focused on the order graph.
    };

    [Fact]
    public async Task Import_CreatesFullOrderGraph_AndMatchesProductBySku()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var product = new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" };
        var channel = NewChannel();
        ctx.Product.Add(product);
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("1001", "C-1", "buyer@example.de", "SKU-1"));

        var sales = await ctx.Sales.IgnoreQueryFilters().Include(s => s.SalesItems).ToListAsync();
        Assert.Single(sales);
        Assert.Equal("1001", sales[0].RemoteSalesId);
        Assert.True(sales[0].SalesId >= 1);
        Assert.Single(sales[0].SalesItems);
        Assert.Equal(product.Id, sales[0].SalesItems.First().ProductId);

        var customers = await ctx.Customer.IgnoreQueryFilters().ToListAsync();
        Assert.Single(customers);
        Assert.Equal("buyer@example.de", customers[0].Email);
        Assert.Equal(sales[0].CustomerId, customers[0].CustomerId);

        var links = await ctx.CustomerSalesChannel.IgnoreQueryFilters().ToListAsync();
        Assert.Single(links);
        Assert.Equal("C-1", links[0].RemoteCustomerId);
    }

    [Fact]
    public async Task Reimport_IsIdempotent_NoDuplicateSalesOrCustomer()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.Product.Add(new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" });
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("1001", "C-1", "buyer@example.de", "SKU-1"));
        // Same order again — must update in place, not duplicate.
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("1001", "C-1", "buyer@example.de", "SKU-1"));

        Assert.Equal(1, await ctx.Sales.IgnoreQueryFilters().CountAsync());
        Assert.Equal(1, await ctx.Customer.IgnoreQueryFilters().CountAsync());
    }

    [Fact]
    public async Task Import_TwoOrdersSameCustomerAndSku_ShareOneCustomer_AndAssignSequentialSalesIds()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.Product.Add(new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" });
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("1001", "C-1", "buyer@example.de", "SKU-1"));
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("1002", "C-1", "buyer@example.de", "SKU-1"));

        // One customer shared across both orders (resolved via the sales-channel link / email).
        Assert.Equal(1, await ctx.Customer.IgnoreQueryFilters().CountAsync());

        var salesIds = await ctx.Sales.IgnoreQueryFilters().Select(s => s.SalesId).OrderBy(x => x).ToListAsync();
        Assert.Equal(2, salesIds.Count);
        // In-memory SalesId counter hands out distinct, consecutive ids.
        Assert.Equal(salesIds[0] + 1, salesIds[1]);
    }

    [Fact]
    public async Task Import_ManyOrders_ChangeTrackerStaysBounded_AndChannelStaysTracked()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.Product.Add(new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" });
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        for (var i = 0; i < 30; i++)
        {
            await repo.ImportOrUpdateFromSalesChannel(channel, NewImport($"2{i:000}", $"C-{i}", $"buyer{i}@example.de", "SKU-1"));

            // The per-order trim must keep the tracker flat: without it, 30 orders × ~6 entities
            // would accumulate ~180 tracked entries and DetectChanges cost would grow per order.
            Assert.True(ctx.ChangeTracker.Entries().Count() < 25,
                $"Change tracker holds {ctx.ChangeTracker.Entries().Count()} entries after order {i} — trim is not working");
        }

        // The channel entity carries mid-run cursor state and must survive every trim.
        Assert.NotEqual(EntityState.Detached, ctx.Entry(channel).State);
        Assert.Equal(30, await ctx.Sales.IgnoreQueryFilters().CountAsync());
        Assert.Equal(30, await ctx.Customer.IgnoreQueryFilters().CountAsync());
    }

    [Fact]
    public async Task Import_TwoOrdersSameCountry_AfterTrim_DoesNotDuplicateCountry()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        var country = new Country { Id = Guid.NewGuid(), Name = "Deutschland", CountryCode = "DE" };
        ctx.Country.Add(country);
        ctx.Product.Add(new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" });
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        SalesChannelImportSales WithAddress(string remoteSalesId, string remoteCustomerId, string email)
        {
            var import = NewImport(remoteSalesId, remoteCustomerId, email, "SKU-1");
            import.BillingAddress = new SalesChannelImportCustomerAddress
            {
                Firstname = "Test",
                Lastname = "Customer",
                Street = $"Street {remoteSalesId}",
                City = "Dresden",
                Zip = "01067",
                Country = "DE",
            };
            import.ShippingAddress = import.BillingAddress;
            return import;
        }

        var repo = BuildRepository(ctx, tenant);
        // Regression: the second order resolves the country from the per-run cache AFTER the first
        // order's trim detached the Country entity. If the address graph re-attached the detached
        // entity (instead of setting only CountryId), EF would insert a duplicate Country row.
        await repo.ImportOrUpdateFromSalesChannel(channel, WithAddress("3001", "C-A", "a@example.de"));
        await repo.ImportOrUpdateFromSalesChannel(channel, WithAddress("3002", "C-B", "b@example.de"));

        Assert.Equal(1, await ctx.Country.IgnoreQueryFilters().CountAsync());

        var addresses = await ctx.CustomerAddress.IgnoreQueryFilters().ToListAsync();
        Assert.Equal(2, addresses.Count);
        Assert.All(addresses, a => Assert.Equal(country.Id, a.CountryId));
    }

    [Fact]
    [Trait("Category", "Benchmark")]
    public async Task Import_LargeRun_TrackerStaysBounded_SoPerOrderCostStaysFlat()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.Product.Add(new Product { Id = Guid.NewGuid(), Sku = "SKU-1", Name = "Test Product" });
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);

        // The flat-cost property is asserted via its mechanical cause — a bounded change tracker —
        // rather than wall-clock timing, which is unreliably noisy when the whole suite runs in
        // parallel. Bucket timings are still printed for humans watching a local run.
        const int total = 600;
        const int bucketSize = 200;
        var bucketMillis = new List<double>();
        var stopwatch = new System.Diagnostics.Stopwatch();
        var maxTracked = 0;

        for (var bucket = 0; bucket < total / bucketSize; bucket++)
        {
            stopwatch.Restart();
            for (var i = 0; i < bucketSize; i++)
            {
                var n = bucket * bucketSize + i;
                await repo.ImportOrUpdateFromSalesChannel(channel, NewImport($"5{n:0000}", $"C-{n}", $"buyer{n}@example.de", "SKU-1"));
                maxTracked = Math.Max(maxTracked, ctx.ChangeTracker.Entries().Count());
            }
            stopwatch.Stop();
            bucketMillis.Add(stopwatch.Elapsed.TotalMilliseconds);
        }

        Console.WriteLine($"Import buckets ({bucketSize} orders each): [{string.Join(", ", bucketMillis.Select(m => m.ToString("F0")))}] ms; max tracked entries: {maxTracked}");

        Assert.Equal(total, await ctx.Sales.IgnoreQueryFilters().CountAsync());

        // Without the per-order trim, 600 orders × ~6 entities would leave ~3600 tracked entries and
        // DetectChanges cost would grow quadratically across the run. The bound proves it stays flat.
        Assert.True(maxTracked < 25,
            $"Change tracker grew to {maxTracked} entries during the run — per-order trim is not working");
    }

    private static SalesChannel NewChannel() => new()
    {
        Id = Guid.NewGuid(),
        TenantId = null,
        Type = SalesChannelType.WooCommerce,
        Name = "test-shop",
        Url = "https://shop.example/wp-json/wc/v3",
        Username = "key",
        Password = "secret",
    };

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
}
