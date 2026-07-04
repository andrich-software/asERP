using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.ProductAttribute.Queries;

public class ProductAttributeListQueryTests : TenantIsolatedTestBase
{
    private static readonly Guid Attr1Id = Guid.NewGuid();
    private static readonly Guid Attr2Id = Guid.NewGuid();
    private static readonly Guid Attr3Id = Guid.NewGuid();

    private async Task SeedAttributesAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var hasData = await DbContext.ProductAttribute.AnyAsync();
            if (!hasData)
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

                // Tenant 1: "Color" (3 values), "Size" (2 values)
                DbContext.ProductAttribute.Add(new asERP.Domain.Entities.ProductAttribute
                {
                    Id = Attr1Id,
                    Name = "Color",
                    SortOrder = 0,
                    TenantId = TenantConstants.TestTenant1Id,
                    Values = new List<asERP.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Value = "Red", SortOrder = 0, TenantId = TenantConstants.TestTenant1Id },
                        new() { Value = "Green", SortOrder = 1, TenantId = TenantConstants.TestTenant1Id },
                        new() { Value = "Blue", SortOrder = 2, TenantId = TenantConstants.TestTenant1Id }
                    }
                });
                DbContext.ProductAttribute.Add(new asERP.Domain.Entities.ProductAttribute
                {
                    Id = Attr2Id,
                    Name = "Size",
                    SortOrder = 1,
                    TenantId = TenantConstants.TestTenant1Id,
                    Values = new List<asERP.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Value = "S", SortOrder = 0, TenantId = TenantConstants.TestTenant1Id },
                        new() { Value = "M", SortOrder = 1, TenantId = TenantConstants.TestTenant1Id }
                    }
                });

                // Tenant 2: "Material" (1 value)
                DbContext.ProductAttribute.Add(new asERP.Domain.Entities.ProductAttribute
                {
                    Id = Attr3Id,
                    Name = "Material",
                    SortOrder = 0,
                    TenantId = TenantConstants.TestTenant2Id,
                    Values = new List<asERP.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Value = "Cotton", SortOrder = 0, TenantId = TenantConstants.TestTenant2Id }
                    }
                });

                await DbContext.SaveChangesAsync();
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    [Fact]
    public async Task GetProductAttributes_Tenant1_ShouldReturnOnlyTenant1Attributes()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/ProductAttributes");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data!.Count);
        TestAssertions.AssertFalse(result.Data.Any(a => a.Name == "Material"));
    }

    [Fact]
    public async Task GetProductAttributes_Tenant2_ShouldReturnOnlyTenant2Attributes()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync("/api/v1/ProductAttributes");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual("Material", result.Data.First().Name);
    }

    [Fact]
    public async Task GetProductAttributes_ShouldReportCorrectValueCount()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/ProductAttributes");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);

        var color = result.Data!.FirstOrDefault(a => a.Name == "Color");
        var size = result.Data!.FirstOrDefault(a => a.Name == "Size");
        TestAssertions.AssertNotNull(color);
        TestAssertions.AssertNotNull(size);
        TestAssertions.AssertEqual(3, color!.ValueCount);
        TestAssertions.AssertEqual(2, size!.ValueCount);
    }

    [Fact]
    public async Task GetProductAttributes_WithSearchString_ShouldFilterByName()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/ProductAttributes?searchString=Color");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual("Color", result.Data.First().Name);
    }

    [Fact]
    public async Task GetProductAttributes_WithPagination_ShouldRespectPageSize()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/ProductAttributes?pageNumber=0&pageSize=1");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual(2, result.TotalCount);
        TestAssertions.AssertEqual(2, result.TotalPages);
    }

    [Fact]
    public async Task GetProductAttributes_WithoutTenantHeader_ShouldReturnEmptyResult()
    {
        await SeedAttributesAsync();
        RemoveTenantHeader();

        var response = await Client.GetAsync("/api/v1/ProductAttributes");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductAttributeListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEmpty(result.Data);
    }

    [Fact]
    public async Task GetProductAttributes_WithInvalidTenantHeaderFormat_ShouldReturnUnauthorized()
    {
        await SeedAttributesAsync();
        SetInvalidTenantHeaderValue("invalid-guid-format");

        var response = await Client.GetAsync("/api/v1/ProductAttributes");

        TestAssertions.AssertEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
