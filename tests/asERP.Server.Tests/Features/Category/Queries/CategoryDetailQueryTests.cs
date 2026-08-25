using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Queries;

/// <summary>Category detail: full field round-trip, NotFound behavior and cross-tenant blindness.</summary>
public class CategoryDetailQueryTests : TenantIsolatedTestBase
{
    private Guid _categoryId;

    private async Task SeedAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        _categoryId = Guid.NewGuid();

        try
        {
            await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

            DbContext.Category.Add(new asERP.Domain.Entities.Category
            {
                Id = _categoryId,
                Name = "Detail Category ÖÄÜ",
                Slug = "detail-category",
                Description = "Eine Beschreibung",
                SortOrder = 7,
                TenantId = TenantConstants.TestTenant1Id
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    [Fact]
    public async Task GetCategoryDetail_ReturnsAllFields()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Categories/{_categoryId}");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<CategoryDetailDto>>(response);
        TestAssertions.AssertNotNull(result?.Data);
        TestAssertions.AssertEqual("Detail Category ÖÄÜ", result!.Data!.Name);
        TestAssertions.AssertEqual("detail-category", result.Data.Slug);
        TestAssertions.AssertEqual("Eine Beschreibung", result.Data.Description);
        TestAssertions.AssertEqual(7, result.Data.SortOrder);
        TestAssertions.AssertNull(result.Data.ParentCategoryId);
    }

    [Fact]
    public async Task GetCategoryDetail_NonExistentId_ReturnsNotFound()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Categories/{Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetCategoryDetail_FromOtherTenant_ReturnsNotFound()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Categories/{_categoryId}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
