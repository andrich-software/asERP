using System.Net;
using maERP.Domain.Constants;
using maERP.Domain.Dtos.Product;
using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Enums;
using maERP.Domain.Wrapper;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace maERP.Server.Tests.Features.Product.Commands;

public class ProductVariantGenerateCommandTests : TenantIsolatedTestBase
{
    // Tenant 1, 19% tax class seeded by TestDataSeeder.
    private static readonly Guid TaxClass1Id = Guid.Parse("00000001-0001-0001-0001-000000000001");
    // Tenant 2, 20% tax class seeded by TestDataSeeder.
    private static readonly Guid TaxClass2Id = Guid.Parse("00000003-0003-0003-0003-000000000003");

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

    private async Task<(Guid attributeId, List<Guid> valueIds)> CreateAttributeAsync(string name, params string[] values)
    {
        var dto = new ProductAttributeInputDto
        {
            Name = name,
            SortOrder = 0,
            Values = values.Select((v, i) => new ProductAttributeValueInputDto { Value = v, SortOrder = i }).ToList()
        };
        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var created = await ReadResponseAsync<Result<Guid>>(response);

        var detailResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{created.Data}");
        TestAssertions.AssertHttpSuccess(detailResponse);
        var detail = await ReadResponseAsync<Result<ProductAttributeDetailDto>>(detailResponse);
        return (created.Data, detail!.Data.Values.Select(v => v.Id).ToList());
    }

    private async Task<Guid> CreateVariantParentAsync(Guid attributeId, string sku, Guid taxClassId)
    {
        var dto = new ProductInputDto
        {
            Sku = sku,
            Name = "Parent " + sku,
            Price = 0m,
            TaxClassId = taxClassId,
            ProductType = ProductType.VariantParent,
            VariantAxisAttributeIds = new List<Guid> { attributeId }
        };
        var response = await PostAsJsonAsync("/api/v1/Products", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    private async Task<Guid> CreateStandardProductAsync(string sku)
    {
        var dto = new ProductInputDto
        {
            Sku = sku,
            Name = "Standard " + sku,
            Price = 10m,
            TaxClassId = TaxClass1Id,
            ProductType = ProductType.Standard
        };
        var response = await PostAsJsonAsync("/api/v1/Products", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    [Fact]
    public async Task GenerateVariants_FullFlow_ShouldCreateAllCombinationsAndBeIdempotent()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var (attributeId, valueIds) = await CreateAttributeAsync($"Color-{Guid.NewGuid():N}", "Red", "Green", "Blue");
        var parentId = await CreateVariantParentAsync(attributeId, $"GEN-{Guid.NewGuid():N}", TaxClass1Id);

        var generateBody = new ProductVariantGenerateDto
        {
            ParentProductId = parentId,
            Axes = new List<ProductVariantGenerateAxisDto>
            {
                new() { ProductAttributeId = attributeId, ValueIds = valueIds }
            }
        };

        var response = await PostAsJsonAsync($"/api/v1/Products/{parentId}/variants/generate", generateBody);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<List<Guid>>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEqual(3, result.Data!.Count);

        // Parent detail exposes the 3 variants
        var detailResponse = await Client.GetAsync($"/api/v1/Products/{parentId}");
        TestAssertions.AssertHttpSuccess(detailResponse);
        var detail = await ReadResponseAsync<Result<ProductDetailDto>>(detailResponse);
        TestAssertions.AssertEqual(3, detail!.Data.Variants.Count);

        // Idempotent re-run: no new variants
        var rerunResponse = await PostAsJsonAsync($"/api/v1/Products/{parentId}/variants/generate", generateBody);
        TestAssertions.AssertEqual(HttpStatusCode.Created, rerunResponse.StatusCode);
        var rerun = await ReadResponseAsync<Result<List<Guid>>>(rerunResponse);
        TestAssertions.AssertEmpty(rerun.Data!);

        var detailAfter = await ReadResponseAsync<Result<ProductDetailDto>>(
            await Client.GetAsync($"/api/v1/Products/{parentId}"));
        TestAssertions.AssertEqual(3, detailAfter!.Data.Variants.Count);
    }

    [Fact]
    public async Task GenerateVariants_AgainstStandardProduct_ShouldReturnBadRequest()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var (attributeId, valueIds) = await CreateAttributeAsync($"Size-{Guid.NewGuid():N}", "S", "M");
        var standardId = await CreateStandardProductAsync($"STD-{Guid.NewGuid():N}");

        var generateBody = new ProductVariantGenerateDto
        {
            ParentProductId = standardId,
            Axes = new List<ProductVariantGenerateAxisDto>
            {
                new() { ProductAttributeId = attributeId, ValueIds = valueIds }
            }
        };

        var response = await PostAsJsonAsync($"/api/v1/Products/{standardId}/variants/generate", generateBody);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var result = await ReadResponseAsync<Result<List<Guid>>>(response);
        TestAssertions.AssertFalse(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }

    [Fact]
    public async Task GenerateVariants_CrossTenantParent_ShouldNotSucceed()
    {
        await SeedBaseDataAsync();

        // Build a variant parent in tenant 1
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var (attributeId, valueIds) = await CreateAttributeAsync($"CT-{Guid.NewGuid():N}", "S", "M");
        var parentId = await CreateVariantParentAsync(attributeId, $"CT-VP-{Guid.NewGuid():N}", TaxClass1Id);

        // Attempt generation from tenant 2
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var generateBody = new ProductVariantGenerateDto
        {
            ParentProductId = parentId,
            Axes = new List<ProductVariantGenerateAxisDto>
            {
                new() { ProductAttributeId = attributeId, ValueIds = valueIds }
            }
        };

        var response = await PostAsJsonAsync($"/api/v1/Products/{parentId}/variants/generate", generateBody);

        // Parent is invisible to tenant 2 -> NotFound (or BadRequest if rejected earlier)
        TestAssertions.AssertTrue(
            response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest,
            $"Expected NotFound/BadRequest for cross-tenant generate, got {response.StatusCode}");

        // Tenant 1 still has no variants
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var detail = await ReadResponseAsync<Result<ProductDetailDto>>(
            await Client.GetAsync($"/api/v1/Products/{parentId}"));
        TestAssertions.AssertEmpty(detail!.Data.Variants);
    }
}
