using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Commands;

/// <summary>
/// Category updates: field changes, reparenting, and — most importantly — cycle prevention
/// (a category must never become its own ancestor).
/// </summary>
public class CategoryUpdateCommandTests : TenantIsolatedTestBase
{
    // A ← B ← C chain (C is the deepest child) plus an unrelated sibling root.
    private static readonly Guid CategoryAId = Guid.NewGuid();
    private static readonly Guid CategoryBId = Guid.NewGuid();
    private static readonly Guid CategoryCId = Guid.NewGuid();
    private static readonly Guid OtherRootId = Guid.NewGuid();
    private static readonly Guid Tenant2CategoryId = Guid.NewGuid();

    private async Task SeedTestDataAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        try
        {
            var hasData = await DbContext.Category.IgnoreQueryFilters().AnyAsync();
            if (!hasData)
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

                DbContext.Category.AddRange(
                    new asERP.Domain.Entities.Category
                    {
                        Id = CategoryAId,
                        Name = "A",
                        Slug = "a",
                        TenantId = TenantConstants.TestTenant1Id
                    },
                    new asERP.Domain.Entities.Category
                    {
                        Id = CategoryBId,
                        Name = "B",
                        Slug = "b",
                        ParentCategoryId = CategoryAId,
                        TenantId = TenantConstants.TestTenant1Id
                    },
                    new asERP.Domain.Entities.Category
                    {
                        Id = CategoryCId,
                        Name = "C",
                        Slug = "c",
                        ParentCategoryId = CategoryBId,
                        TenantId = TenantConstants.TestTenant1Id
                    },
                    new asERP.Domain.Entities.Category
                    {
                        Id = OtherRootId,
                        Name = "Other Root",
                        Slug = "other-root",
                        TenantId = TenantConstants.TestTenant1Id
                    },
                    new asERP.Domain.Entities.Category
                    {
                        Id = Tenant2CategoryId,
                        Name = "Tenant2 Category",
                        Slug = "tenant2-category",
                        TenantId = TenantConstants.TestTenant2Id
                    });
                await DbContext.SaveChangesAsync();
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private static CategoryInputDto BuildInput(string name, Guid? parentId = null, int sortOrder = 0) => new()
    {
        Name = name,
        Slug = string.Empty,
        ParentCategoryId = parentId,
        SortOrder = sortOrder
    };

    [Fact]
    public async Task UpdateCategory_WithValidData_ShouldPersistChanges()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = BuildInput("Umbenannt Ä", parentId: null, sortOrder: 42);
        input.Description = "Neue Beschreibung";

        var response = await PutAsJsonAsync($"/api/v1/Categories/{OtherRootId}", input);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        // AsNoTracking: the request ran on its own scope — the test context's tracked seed
        // instance would otherwise shadow the updated store row.
        var updated = await DbContext.Category.IgnoreQueryFilters().AsNoTracking().FirstAsync(c => c.Id == OtherRootId);
        TestAssertions.AssertEqual("Umbenannt Ä", updated.Name);
        TestAssertions.AssertEqual("umbenannt-ae", updated.Slug);
        TestAssertions.AssertEqual("Neue Beschreibung", updated.Description);
        TestAssertions.AssertEqual(42, updated.SortOrder);
    }

    [Fact]
    public async Task UpdateCategory_Reparent_ShouldPersist()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Categories/{CategoryCId}", BuildInput("C", OtherRootId));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var updated = await DbContext.Category.IgnoreQueryFilters().AsNoTracking().FirstAsync(c => c.Id == CategoryCId);
        TestAssertions.AssertEqual(OtherRootId, updated.ParentCategoryId);
    }

    [Fact]
    public async Task UpdateCategory_SelfAsParent_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Categories/{CategoryAId}", BuildInput("A", CategoryAId));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<object>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Succeeded);
    }

    [Fact]
    public async Task UpdateCategory_DirectChildAsParent_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // B's parent is A; making A a child of B would be a direct cycle.
        var response = await PutAsJsonAsync($"/api/v1/Categories/{CategoryAId}", BuildInput("A", CategoryBId));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCategory_TransitiveDescendantAsParent_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // C is A's grandchild; A under C would create the cycle A → B → C → A.
        var response = await PutAsJsonAsync($"/api/v1/Categories/{CategoryAId}", BuildInput("A", CategoryCId));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCategory_NonExistentId_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Categories/{Guid.NewGuid()}", BuildInput("Ghost"));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCategory_FromOtherTenant_ShouldBeRejected()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // The tenant-filtered existence check must not see Tenant2's category.
        var response = await PutAsJsonAsync($"/api/v1/Categories/{Tenant2CategoryId}", BuildInput("Hijack"));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var untouched = await DbContext.Category.IgnoreQueryFilters().FirstAsync(c => c.Id == Tenant2CategoryId);
        TestAssertions.AssertEqual("Tenant2 Category", untouched.Name);
    }
}
