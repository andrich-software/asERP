using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Tests;

/// <summary>
/// Tenant-ownership rules of the generic repository write path. Globally shared reference data
/// (TenantId == null, e.g. the seeded Country rows) is readable by every tenant through the query
/// filter — a tenant-scoped context must therefore not be able to rewrite it.
/// </summary>
public class GenericRepositoryTenantOwnershipTests
{
    private static readonly Guid TenantId = new("11111111-1111-1111-1111-111111111111");

    private sealed class TestTenantContext : ITenantContext
    {
        private Guid? _currentTenantId;

        public Guid? GetCurrentTenantId() => _currentTenantId;
        public void SetCurrentTenantId(Guid? tenantId) => _currentTenantId = tenantId;
        public bool HasTenant() => _currentTenantId.HasValue;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() =>
            _currentTenantId.HasValue ? new[] { _currentTenantId.Value } : Array.Empty<Guid>();
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => tenantId == _currentTenantId;
    }

    private static ApplicationDbContext CreateContext(string dbName, ITenantContext tenantContext)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(dbName).Options;
        return new ApplicationDbContext(options, tenantContext);
    }

    [Fact]
    public async Task UpdateAsync_TenantAgnosticRow_IsRejectedForTenantScopedContext()
    {
        var dbName = Guid.NewGuid().ToString();
        var tenantContext = new TestTenantContext();
        await using var db = CreateContext(dbName, tenantContext);
        var repo = new GenericRepository<Country>(db, tenantContext);

        // Globally shared reference row, as shipped by the Country seed: no owner, no tenant context.
        var globalCountry = new Country { Id = Guid.NewGuid(), Name = "Germany", CountryCode = "DE" };
        await db.Country.AddAsync(globalCountry);
        await db.SaveChangesAsync();

        // A tenant user reads the global row through the TenantId == null arm of the query filter...
        tenantContext.SetCurrentTenantId(TenantId);
        var loaded = await repo.GetByIdAsync(globalCountry.Id);
        Assert.NotNull(loaded);

        // ...but must not be able to write it back.
        loaded!.Name = "Hijacked";
        loaded.CountryCode = "XX";
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => repo.UpdateAsync(loaded));

        await using var verifyDb = CreateContext(dbName, new TestTenantContext());
        var stored = await verifyDb.Country.IgnoreQueryFilters().AsNoTracking()
            .SingleAsync(c => c.Id == globalCountry.Id);
        Assert.Equal("Germany", stored.Name);
        Assert.Equal("DE", stored.CountryCode);
        Assert.Null(stored.TenantId);
    }

    [Fact]
    public async Task UpdateAsync_OwnedRow_IsAppliedForOwningTenant()
    {
        var dbName = Guid.NewGuid().ToString();
        var tenantContext = new TestTenantContext();
        tenantContext.SetCurrentTenantId(TenantId);
        await using var db = CreateContext(dbName, tenantContext);
        var repo = new GenericRepository<Country>(db, tenantContext);

        var ownCountry = new Country { Id = Guid.NewGuid(), Name = "Austria", CountryCode = "AT" };
        await db.Country.AddAsync(ownCountry);
        await db.SaveChangesAsync();

        ownCountry.Name = "Oesterreich";
        await repo.UpdateAsync(ownCountry);

        await using var verifyDb = CreateContext(dbName, new TestTenantContext());
        var stored = await verifyDb.Country.IgnoreQueryFilters().AsNoTracking()
            .SingleAsync(c => c.Id == ownCountry.Id);
        Assert.Equal("Oesterreich", stored.Name);
        Assert.Equal(TenantId, stored.TenantId);
    }
}
