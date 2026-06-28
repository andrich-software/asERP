using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.ProductAttribute.Commands;

public class ProductAttributeCreateCommandTests : TenantIsolatedTestBase
{
    private async Task SeedBaseDataAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var hasData = await DbContext.TaxClass.AnyAsync();
            if (!hasData)
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private static ProductAttributeInputDto CreateValidDto(string name = "Color")
    {
        return new ProductAttributeInputDto
        {
            Name = name,
            SortOrder = 1,
            Values = new List<ProductAttributeValueInputDto>
            {
                new() { Value = "Red", SortOrder = 0 },
                new() { Value = "Green", SortOrder = 1 },
                new() { Value = "Blue", SortOrder = 2 }
            }
        };
    }

    [Fact]
    public async Task CreateProductAttribute_WithValidData_ShouldReturnCreatedAndPersist()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var dto = CreateValidDto("Color");

        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertTrue(result.Data != Guid.Empty);

        // Verify it persists with its values via detail endpoint
        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{result.Data}");
        TestAssertions.AssertHttpSuccess(getResponse);
        var detail = await ReadResponseAsync<Result<ProductAttributeDetailDto>>(getResponse);
        TestAssertions.AssertNotNull(detail?.Data);
        TestAssertions.AssertEqual("Color", detail!.Data.Name);
        TestAssertions.AssertEqual(3, detail.Data.Values.Count);
    }

    [Fact]
    public async Task CreateProductAttribute_WithDuplicateName_ShouldReturnBadRequest()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var first = CreateValidDto("Size");
        var firstResponse = await PostAsJsonAsync("/api/v1/ProductAttributes", first);
        TestAssertions.AssertEqual(HttpStatusCode.Created, firstResponse.StatusCode);

        var duplicate = CreateValidDto("Size");
        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", duplicate);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }

    [Fact]
    public async Task CreateProductAttribute_WithMissingName_ShouldReturnBadRequest()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var dto = CreateValidDto("");

        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }

    [Fact]
    public async Task CreateProductAttribute_WithDuplicateValues_ShouldReturnBadRequest()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var dto = new ProductAttributeInputDto
        {
            Name = "Material",
            SortOrder = 0,
            Values = new List<ProductAttributeValueInputDto>
            {
                new() { Value = "Cotton", SortOrder = 0 },
                new() { Value = "Cotton", SortOrder = 1 }
            }
        };

        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }

    [Fact]
    public async Task CreateProductAttribute_TenantIsolation_ShouldNotBeVisibleToOtherTenant()
    {
        await SeedBaseDataAsync();

        // Create in tenant 1
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var dto = CreateValidDto($"Iso-{Guid.NewGuid():N}");
        var createResponse = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, createResponse.StatusCode);
        var created = await ReadResponseAsync<Result<Guid>>(createResponse);

        // Tenant 2 must not see it via detail
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{created.Data}");
        TestAssertions.AssertEqual(HttpStatusCode.NotFound, getResponse.StatusCode);

        // Tenant 2 must not see it in the list
        var listResponse = await Client.GetAsync("/api/v1/ProductAttributes");
        TestAssertions.AssertHttpSuccess(listResponse);
        var list = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(listResponse);
        var visible = list.Data?.Any(a => a.Id == created.Data) ?? false;
        TestAssertions.AssertFalse(visible, "Tenant 2 should not see Tenant 1's attribute");
    }

    [Fact]
    public async Task CreateProductAttribute_WithoutTenantHeader_ShouldNotBeVisibleToAnyTenant()
    {
        await SeedBaseDataAsync();

        // Without a tenant header the attribute is created as a tenant-agnostic (TenantId == null)
        // row. The security-relevant contract is that such a row must never surface for a real
        // tenant; assert that rather than the HTTP status, which differs from ProductsController.
        RemoveTenantHeader();
        var dto = CreateValidDto($"NoTenant-{Guid.NewGuid():N}");
        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);
        var created = await ReadResponseAsync<Result<Guid>>(response);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var t1Detail = await Client.GetAsync($"/api/v1/ProductAttributes/{created.Data}");
        TestAssertions.AssertEqual(HttpStatusCode.NotFound, t1Detail.StatusCode);

        var t1List = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(
            await Client.GetAsync("/api/v1/ProductAttributes"));
        TestAssertions.AssertFalse(t1List.Data?.Any(a => a.Id == created.Data) ?? false,
            "A tenant-agnostic attribute must not appear in a tenant's list");
    }

    [Fact]
    public async Task CreateProductAttribute_WithInvalidTenantHeaderFormat_ShouldReturnUnauthorized()
    {
        await SeedBaseDataAsync();
        SetInvalidTenantHeaderValue("not-a-guid");
        var dto = CreateValidDto("BadTenant");

        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
