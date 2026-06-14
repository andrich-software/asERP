using System.Net;
using maERP.Domain.Constants;
using maERP.Domain.Dtos.Product;
using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Enums;
using maERP.Domain.Wrapper;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace maERP.Server.Tests.Features.ProductAttribute.Commands;

public class ProductAttributeDeleteCommandTests : TenantIsolatedTestBase
{
    // Tenant 1, 19% tax class seeded by TestDataSeeder.
    private static readonly Guid TaxClass1Id = Guid.Parse("00000001-0001-0001-0001-000000000001");

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

    private async Task<Guid> CreateAttributeAsync(string name)
    {
        var dto = new ProductAttributeInputDto
        {
            Name = name,
            SortOrder = 0,
            Values = new List<ProductAttributeValueInputDto>
            {
                new() { Value = "S", SortOrder = 0 },
                new() { Value = "M", SortOrder = 1 }
            }
        };
        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    private async Task<Guid> CreateVariantParentUsingAttributeAsync(Guid attributeId, string sku)
    {
        var dto = new ProductInputDto
        {
            Sku = sku,
            Name = "Variant Parent " + sku,
            Price = 0m,
            TaxClassId = TaxClass1Id,
            ProductType = ProductType.VariantParent,
            VariantAxisAttributeIds = new List<Guid> { attributeId }
        };
        var response = await PostAsJsonAsync("/api/v1/Products", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    [Fact]
    public async Task DeleteProductAttribute_Unused_ShouldReturnOkAndThenNotFound()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync($"DelUnused-{Guid.NewGuid():N}");

        var response = await Client.DeleteAsync($"/api/v1/ProductAttributes/{id}");
        TestAssertions.AssertTrue(response.IsSuccessStatusCode,
            $"Expected success deleting unused attribute, got {response.StatusCode}");

        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{id}");
        TestAssertions.AssertEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task DeleteProductAttribute_InUseByVariantAxis_ShouldReturnBadRequest()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var attributeId = await CreateAttributeAsync($"DelInUse-{Guid.NewGuid():N}");
        await CreateVariantParentUsingAttributeAsync(attributeId, $"VP-DEL-{Guid.NewGuid():N}");

        var response = await Client.DeleteAsync($"/api/v1/ProductAttributes/{attributeId}");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);

        // Still retrievable
        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{attributeId}");
        TestAssertions.AssertHttpSuccess(getResponse);
    }

    [Fact]
    public async Task DeleteProductAttribute_NotFound_ShouldReturnNotFound()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/ProductAttributes/{Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteProductAttribute_CrossTenant_ShouldReturnNotFound()
    {
        await SeedBaseDataAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync($"DelCross-{Guid.NewGuid():N}");

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.DeleteAsync($"/api/v1/ProductAttributes/{id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);

        // Confirm it still exists for tenant 1
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{id}");
        TestAssertions.AssertHttpSuccess(getResponse);
    }
}
