using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Tests;

public class ApplicationDbContextTests
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationDbContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        var mockTenantContext = new TestTenantContext();
        // A tenant-scoped entity is never persisted without an active tenant context in the real app
        // (middleware always sets one); SaveChangesAsync now enforces that, so the test mirrors it.
        mockTenantContext.SetCurrentTenantId(Guid.NewGuid());

        _applicationDbContext = new ApplicationDbContext(dbOptions, mockTenantContext);
    }

    private class TestTenantContext : ITenantContext
    {
        private Guid? _tenantId = null;
        private HashSet<Guid> _assignedTenantIds = new HashSet<Guid>();

        public Guid? GetCurrentTenantId() => _tenantId;
        public void SetCurrentTenantId(Guid? tenantId) => _tenantId = tenantId;
        public bool HasTenant() => _tenantId.HasValue;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => _assignedTenantIds;
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) => _assignedTenantIds = new HashSet<Guid>(tenantIds ?? new List<Guid>());
        public bool IsAssignedToTenant(Guid tenantId) => _assignedTenantIds.Contains(tenantId);
    }

    [Fact]
    public async Task Save_SetDateCreatedValue()
    {
        // Arrange
        var warehouse = new Warehouse
        {
            Id = Guid.NewGuid(),
            Name = "Test Warehouse 1"
        };

        // Act
        await _applicationDbContext.Warehouse.AddAsync(warehouse);
        await _applicationDbContext.SaveChangesAsync();

        // Assert
        Assert.True(warehouse.DateCreated > DateTime.MinValue);
    }

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        // Arrange
        var warehouse = new Warehouse
        {
            Id = Guid.NewGuid(),
            Name = "Test Warehouse 1"
        };

        // Act
        await _applicationDbContext.Warehouse.AddAsync(warehouse);
        await _applicationDbContext.SaveChangesAsync();

        // Assert
        Assert.True(warehouse.DateModified > DateTime.MinValue);
    }
}
