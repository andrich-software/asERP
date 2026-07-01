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
/// Covers the batched-save refactor of <see cref="CustomerImportRepository"/>: a customer's graph
/// (customer + sales-channel link + addresses) is committed in one SaveChanges, and the import stays
/// idempotent (a re-import updates in place rather than duplicating the customer or its link).
/// </summary>
public class CustomerImportRepositoryTests
{
    private static DbContextOptions<ApplicationDbContext> NewOptions() =>
        new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

    private static CustomerImportRepository BuildRepository(ApplicationDbContext ctx, ITenantContext tenant) =>
        new(
            NullLogger<CustomerImportRepository>.Instance,
            ctx,
            new CustomerRepository(ctx, tenant),
            new CountryRepository(ctx, tenant));

    private static SalesChannelImportCustomer NewImport(string remoteId, string email) => new()
    {
        RemoteCustomerId = remoteId,
        Email = email,
        Firstname = "Test",
        Lastname = "Customer",
        CustomerStatus = CustomerStatus.Active,
        DateEnrollment = DateTime.UtcNow.AddYears(-1),
        // Null addresses → no structured address; keeps the test focused on the customer + link graph.
    };

    [Fact]
    public async Task Import_CreatesCustomerAndLink()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("WC-1", "buyer@example.de"));

        var customers = await ctx.Customer.IgnoreQueryFilters().ToListAsync();
        Assert.Single(customers);
        Assert.Equal("buyer@example.de", customers[0].Email);
        Assert.True(customers[0].CustomerId >= 1);

        var links = await ctx.CustomerSalesChannel.IgnoreQueryFilters().ToListAsync();
        Assert.Single(links);
        Assert.Equal("WC-1", links[0].RemoteCustomerId);
    }

    [Fact]
    public async Task Reimport_IsIdempotent_NoDuplicateCustomerOrLink()
    {
        var options = NewOptions();
        var tenant = new TestTenantContext();
        await using var ctx = new ApplicationDbContext(options, tenant);

        var channel = NewChannel();
        ctx.SalesChannel.Add(channel);
        await ctx.SaveChangesAsync();

        var repo = BuildRepository(ctx, tenant);
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("WC-1", "buyer@example.de"));
        // Same customer again — resolved via the sales-channel link, updated in place.
        await repo.ImportOrUpdateFromSalesChannel(channel, NewImport("WC-1", "buyer@example.de"));

        Assert.Equal(1, await ctx.Customer.IgnoreQueryFilters().CountAsync());
        Assert.Equal(1, await ctx.CustomerSalesChannel.IgnoreQueryFilters().CountAsync());
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
