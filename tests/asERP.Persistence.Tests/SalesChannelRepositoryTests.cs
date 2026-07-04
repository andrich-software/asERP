using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Tests;

public class SalesChannelRepositoryTests
{
    private static (ApplicationDbContext db, SalesChannelRepository repo) CreateRepository(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(dbName).Options;
        var db = new ApplicationDbContext(options, new NullTenantContext());
        var repo = new SalesChannelRepository(db, new NullTenantContext());
        return (db, repo);
    }

    private sealed class NullTenantContext : ITenantContext
    {
        public Guid? GetCurrentTenantId() => null;
        public void SetCurrentTenantId(Guid? tenantId) { }
        public bool HasTenant() => false;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => Array.Empty<Guid>();
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => false;
    }

    private static Warehouse NewWarehouse(string name)
        => new() { Id = Guid.NewGuid(), Name = name };

    private static SalesChannel NewSalesChannel(string name)
        => new() { Id = Guid.NewGuid(), Name = name, Warehouses = new List<Warehouse>() };

    /// <summary>
    /// Reproduces the bug where assigning a warehouse to a sales channel silently dropped the
    /// assignment: the handler loads the channel tracked (GetDetails), and UpdateAsync re-queried
    /// the same tracked instance, so clearing existing.Warehouses also cleared the incoming list.
    /// </summary>
    [Fact]
    public async Task UpdateAsync_AssignsWarehouse_WhenChannelWasLoadedTracked()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var warehouse = NewWarehouse("Hauptlager");
        var channel = NewSalesChannel("DIY-Stoffe.de");
        await db.Warehouse.AddAsync(warehouse);
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();

        // Mirror the handler: load tracked via GetDetails, then assign the warehouse.
        var loaded = await repo.GetDetails(channel.Id);
        loaded.Warehouses = new List<Warehouse> { warehouse };

        await repo.UpdateAsync(loaded);

        // Read back through a separate context over the same store so the tracking cache can't
        // mask a missing persisted assignment.
        var (verifyDb, _) = CreateRepository(dbName);
        var persisted = await verifyDb.SalesChannel
            .Include(s => s.Warehouses)
            .AsNoTracking()
            .FirstAsync(s => s.Id == channel.Id);

        Assert.Single(persisted.Warehouses);
        Assert.Equal(warehouse.Id, persisted.Warehouses.First().Id);
    }

    [Fact]
    public async Task UpdateAsync_RemovesWarehouse_WhenAssignmentCleared()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var warehouse = NewWarehouse("Hauptlager");
        var channel = NewSalesChannel("DIY-Stoffe.de");
        channel.Warehouses = new List<Warehouse> { warehouse };
        await db.Warehouse.AddAsync(warehouse);
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();

        var loaded = await repo.GetDetails(channel.Id);
        loaded.Warehouses = new List<Warehouse>();

        await repo.UpdateAsync(loaded);

        var (verifyDb, _) = CreateRepository(dbName);
        var persisted = await verifyDb.SalesChannel
            .Include(s => s.Warehouses)
            .AsNoTracking()
            .FirstAsync(s => s.Id == channel.Id);

        Assert.Empty(persisted.Warehouses);
    }
}
