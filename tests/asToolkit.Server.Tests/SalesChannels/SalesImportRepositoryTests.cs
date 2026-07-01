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
            ctx);

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
