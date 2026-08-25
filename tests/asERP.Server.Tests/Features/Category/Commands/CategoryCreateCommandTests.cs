using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Commands;

/// <summary>
/// Category creation: field validation, sibling-uniqueness per parent, slug generation and
/// tenant isolation of the uniqueness check.
/// </summary>
public class CategoryCreateCommandTests : TenantIsolatedTestBase
{
    private static readonly Guid RootCategory1Id = Guid.NewGuid();
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

                DbContext.Category.Add(new asERP.Domain.Entities.Category
                {
                    Id = RootCategory1Id,
                    Name = "Existing Category",
                    Slug = "existing-category",
                    TenantId = TenantConstants.TestTenant1Id
                });
                DbContext.Category.Add(new asERP.Domain.Entities.Category
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

    private static CategoryInputDto CreateValidCategoryInput() => new()
    {
        Name = "New Test Category",
        Slug = "new-test-category",
        Description = "A test category",
        SortOrder = 5
    };

    [Fact]
    public async Task CreateCategory_WithValidData_ShouldReturnCreated()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Categories", CreateValidCategoryInput());

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertTrue(result.Data != Guid.Empty);

        var created = await DbContext.Category.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == result.Data);
        TestAssertions.AssertNotNull(created);
        TestAssertions.AssertEqual("New Test Category", created!.Name);
        TestAssertions.AssertEqual("new-test-category", created.Slug);
        TestAssertions.AssertEqual(5, created.SortOrder);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, created.TenantId);
    }

    [Fact]
    public async Task CreateCategory_WithEmptySlug_GeneratesSlugFromName()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = "Größen & Schuhe";
        input.Slug = string.Empty;

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        var created = await DbContext.Category.IgnoreQueryFilters().FirstAsync(c => c.Id == result!.Data);
        TestAssertions.AssertEqual("groessen-schuhe", created.Slug);
    }

    [Fact]
    public async Task CreateCategory_WithEmptyName_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = "";

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<object>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }

    [Fact]
    public async Task CreateCategory_WithTooLongName_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = new string('x', 256);

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateCategory_WithDuplicateNameUnderSameParent_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = "Existing Category";

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateCategory_WithSameNameUnderDifferentParent_ShouldReturnCreated()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = "Existing Category";
        input.Slug = "existing-category-child";
        input.ParentCategoryId = RootCategory1Id;

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        var created = await DbContext.Category.IgnoreQueryFilters().FirstAsync(c => c.Id == result!.Data);
        TestAssertions.AssertEqual(RootCategory1Id, created.ParentCategoryId);
    }

    [Fact]
    public async Task CreateCategory_WithSameNameAsOtherTenant_ShouldReturnCreated()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.Name = "Tenant2 Category";

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task CreateCategory_WithNonExistentParent_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.ParentCategoryId = Guid.NewGuid();

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateCategory_WithParentFromOtherTenant_ShouldReturnBadRequest()
    {
        await SeedTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = CreateValidCategoryInput();
        input.ParentCategoryId = Tenant2CategoryId;

        var response = await PostAsJsonAsync("/api/v1/Categories", input);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateCategory_WithMalformedTenantHeader_ShouldReturnUnauthorized()
    {
        await SeedTestDataAsync();
        SetInvalidTenantHeaderValue("not-a-guid");

        var response = await PostAsJsonAsync("/api/v1/Categories", CreateValidCategoryInput());

        TestAssertions.AssertEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
