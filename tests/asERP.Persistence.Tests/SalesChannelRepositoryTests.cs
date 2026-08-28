using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Tests;

public class SalesChannelRepositoryTests
{
    private static (ApplicationDbContext db, SalesChannelRepository repo) CreateRepository(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(dbName).Options;
        var db = new ApplicationDbContext(options, new FixedTenantContext());
        var repo = new SalesChannelRepository(db, new FixedTenantContext());
        return (db, repo);
    }

    // A fixed, shared tenant so every context over the same store agrees on ownership. Tenant-scoped
    // entities can no longer be persisted without an active tenant context (SaveChangesAsync enforces
    // it), so the test uses a real tenant id — the realistic case — instead of a null context.
    private static readonly Guid TestTenantId = new("11111111-1111-1111-1111-111111111111");

    private sealed class FixedTenantContext : ITenantContext
    {
        public Guid? GetCurrentTenantId() => TestTenantId;
        public void SetCurrentTenantId(Guid? tenantId) { }
        public bool HasTenant() => true;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => new[] { TestTenantId };
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => tenantId == TestTenantId;
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

    /// <summary>
    /// Pins the delete path against a REAL relational provider: InMemory enforces no foreign keys and
    /// supports no ExecuteDelete, so it can prove neither of the two things that matter here — that the
    /// RESTRICT foreign key of the category links no longer blocks the delete (it made deleting any
    /// channel with categories fail outright), and that the set-based cleanup actually translates.
    /// </summary>
    [Fact]
    public async Task DeleteWithDependentsAsync_OnRelationalProvider_RemovesDependentsAndDetachesFeed()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;
        await using var db = new ApplicationDbContext(options, new FixedTenantContext());
        await db.Database.EnsureCreatedAsync();

        var repo = new SalesChannelRepository(db, new FixedTenantContext());
        var now = DateTime.UtcNow;

        var channel = NewSalesChannel("DIY-Stoffe.de");
        channel.TenantId = TestTenantId;
        var category = new Category { Id = Guid.NewGuid(), TenantId = TestTenantId, Name = "Stoffe", Slug = "stoffe" };
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            TenantId = TestTenantId,
            CustomerId = 424242,
            Firstname = "Erika",
            Lastname = "Mustermann",
            Email = "erika@example.com"
        };
        await db.SalesChannel.AddAsync(channel);
        await db.Category.AddAsync(category);
        await db.Customer.AddAsync(customer);
        await db.SaveChangesAsync();

        // One row per dependent table, all addressed by the channel.
        await db.CategorySalesChannel.AddAsync(new CategorySalesChannel
        {
            TenantId = TestTenantId,
            CategoryId = category.Id,
            SalesChannelId = channel.Id,
            IsActive = true
        });
        await db.CustomerSalesChannel.AddAsync(new CustomerSalesChannel
        {
            TenantId = TestTenantId,
            CustomerId = customer.Id,
            SalesChannelId = channel.Id,
            RemoteCustomerId = "1001"
        });
        await db.ShopDomain.AddAsync(new ShopDomain
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Host = "shop.example.com",
            IsPrimary = true
        });
        await db.OAuthState.AddAsync(new OAuthState
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Provider = SalesChannelType.WooCommerce,
            StateToken = "state",
            Nonce = "nonce",
            ExpiresAt = now.AddMinutes(10)
        });
        await db.ChannelExportOutbox.AddAsync(new ChannelExportOutbox
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ExportProduct,
            AggregateType = ChannelOutboxAggregateType.Product,
            AggregateId = Guid.NewGuid(),
            IdempotencyKey = "key",
            Status = ChannelOutboxStatus.Pending,
            NextAttemptAt = now
        });
        await db.ChannelSyncRun.AddAsync(new ChannelSyncRun
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            Status = ChannelSyncRunStatus.Success,
            StartedAt = now,
            CorrelationId = Guid.NewGuid()
        });
        await db.ChannelSyncLog.AddAsync(new ChannelSyncLog
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            Level = ChannelSyncLogLevel.Information,
            Message = "imported",
            Timestamp = now,
            CorrelationId = Guid.NewGuid()
        });
        await db.SalesChannelSyncState.AddAsync(new SalesChannelSyncState
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id
        });
        await db.SalesChannelOperationState.AddAsync(new SalesChannelOperationState
        {
            TenantId = TestTenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            Phase = ChannelSyncPhase.Incremental,
            NextDueAt = now
        });
        var feed = new Feed
        {
            TenantId = TestTenantId,
            Name = "Google feed",
            Template = FeedTemplate.GoogleProducts,
            Currency = "EUR",
            SalesChannelId = channel.Id
        };
        await db.Feed.AddAsync(feed);
        await db.SaveChangesAsync();

        var summary = await repo.DeleteWithDependentsAsync(channel.Id);

        Assert.Equal(1, summary.CategoryLinks);
        Assert.Equal(1, summary.CustomerLinks);
        Assert.Equal(1, summary.ShopDomains);
        Assert.Equal(1, summary.OAuthStates);
        Assert.Equal(5, summary.SyncRows);
        Assert.Equal(1, summary.DetachedFeeds);

        db.ChangeTracker.Clear();

        Assert.Null(await db.SalesChannel.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == channel.Id));
        Assert.Empty(await db.CategorySalesChannel.IgnoreQueryFilters().Where(l => l.SalesChannelId == channel.Id).ToListAsync());
        Assert.Empty(await db.CustomerSalesChannel.IgnoreQueryFilters().Where(l => l.SalesChannelId == channel.Id).ToListAsync());
        Assert.Empty(await db.ShopDomain.IgnoreQueryFilters().Where(d => d.SalesChannelId == channel.Id).ToListAsync());
        Assert.Empty(await db.OAuthState.Where(s => s.SalesChannelId == channel.Id).ToListAsync());

        // The category itself is a survivor — only its channel activation went away.
        Assert.NotNull(await db.Category.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == category.Id));

        var persistedFeed = await db.Feed.IgnoreQueryFilters().FirstAsync(f => f.Id == feed.Id);
        Assert.Null(persistedFeed.SalesChannelId);
    }

    private static SalesChannelCarrierMappingInputDto Mapping(string code, Guid providerId)
        => new() { RemoteCarrierCode = code, ShippingProviderId = providerId };

    private static async Task<Guid> AddProviderAsync(ApplicationDbContext db, string name)
    {
        var provider = new ShippingProvider
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = ShippingProviderType.Dhl,
        };
        await db.ShippingProvider.AddAsync(provider);
        await db.SaveChangesAsync();
        return provider.Id;
    }

    [Fact]
    public async Task ReplaceCarrierMappingsAsync_NormalizesCodes_AndDropsIncompleteRows()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var channel = NewSalesChannel("DIY-Stoffe.de");
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();
        var providerId = await AddProviderAsync(db, "DHL");

        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[]
        {
            Mapping("  DHL_Home_Delivery  ", providerId),
            // Dropped: a code without a provider can never resolve a shipment.
            Mapping("flat_rate", Guid.Empty),
            Mapping("   ", providerId),
        });

        var (verifyDb, _) = CreateRepository(dbName);
        var persisted = await verifyDb.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == channel.Id)
            .ToListAsync();

        var mapping = Assert.Single(persisted);
        Assert.Equal("dhl_home_delivery", mapping.RemoteCarrierCode);
        Assert.Equal(providerId, mapping.ShippingProviderId);
    }

    [Fact]
    public async Task ReplaceCarrierMappingsAsync_KeepsRowIdentity_ForUnchangedMappings()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var channel = NewSalesChannel("DIY-Stoffe.de");
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();
        var dhlId = await AddProviderAsync(db, "DHL");
        var dpdId = await AddProviderAsync(db, "DPD");

        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[] { Mapping("dhl_home_delivery", dhlId) });
        var originalId = (await db.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == channel.Id).SingleAsync()).Id;

        // Same code, different provider, plus one added and the whole set re-submitted — the existing
        // row must be updated in place instead of being replaced by a fresh id.
        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[]
        {
            Mapping("dhl_home_delivery", dpdId),
            Mapping("flat_rate", dhlId),
        });

        var (verifyDb, _) = CreateRepository(dbName);
        var persisted = await verifyDb.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == channel.Id)
            .ToListAsync();

        Assert.Equal(2, persisted.Count);
        var updated = persisted.Single(m => m.RemoteCarrierCode == "dhl_home_delivery");
        Assert.Equal(originalId, updated.Id);
        Assert.Equal(dpdId, updated.ShippingProviderId);
    }

    [Fact]
    public async Task ReplaceCarrierMappingsAsync_RemovesMappingsNoLongerSubmitted()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var channel = NewSalesChannel("DIY-Stoffe.de");
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();
        var providerId = await AddProviderAsync(db, "DHL");

        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[]
        {
            Mapping("dhl_home_delivery", providerId),
            Mapping("flat_rate", providerId),
        });

        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[] { Mapping("flat_rate", providerId) });

        var (verifyDb, _) = CreateRepository(dbName);
        var persisted = await verifyDb.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == channel.Id)
            .ToListAsync();

        Assert.Equal("flat_rate", Assert.Single(persisted).RemoteCarrierCode);
    }

    [Fact]
    public async Task ReplaceCarrierMappingsAsync_EmptySet_ClearsAllMappings()
    {
        var dbName = Guid.NewGuid().ToString();
        var (db, repo) = CreateRepository(dbName);

        var channel = NewSalesChannel("DIY-Stoffe.de");
        await db.SalesChannel.AddAsync(channel);
        await db.SaveChangesAsync();
        var providerId = await AddProviderAsync(db, "DHL");

        await repo.ReplaceCarrierMappingsAsync(channel.Id, new[] { Mapping("dhl_home_delivery", providerId) });
        await repo.ReplaceCarrierMappingsAsync(channel.Id, Array.Empty<SalesChannelCarrierMappingInputDto>());

        var (verifyDb, _) = CreateRepository(dbName);
        Assert.Empty(await verifyDb.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == channel.Id).ToListAsync());
    }
}
