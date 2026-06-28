using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.Product.Queries;

/// <summary>
/// Variant-specific list behaviour. Kept in a dedicated class with its own isolated database so the
/// exact-count assertions in <see cref="ProductListQueryTests"/> remain valid (a shared seed would
/// change the default product count those tests assert).
/// </summary>
public class ProductListVariantQueryTests : TenantIsolatedTestBase
{
    private static readonly Guid TaxClass1Id = Guid.NewGuid();
    private static readonly Guid ParentId = Guid.NewGuid();
    private static readonly Guid Variant1Id = Guid.NewGuid();
    private static readonly Guid Variant2Id = Guid.NewGuid();
    private static readonly Guid StandaloneId = Guid.NewGuid();

    private async Task SeedVariantTreeAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            if (!await DbContext.Product.AnyAsync())
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

                DbContext.TaxClass.Add(new asToolkit.Domain.Entities.TaxClass
                {
                    Id = TaxClass1Id,
                    TaxRate = 19.0,
                    TenantId = TenantConstants.TestTenant1Id
                });

                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = ParentId,
                    Sku = "VL-PARENT",
                    Name = "Variant Parent",
                    Price = 0m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.VariantParent,
                    TenantId = TenantConstants.TestTenant1Id
                });
                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = Variant1Id,
                    Sku = "VL-VAR-1",
                    Name = "Variant 1",
                    Price = 5m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.Variant,
                    ParentProductId = ParentId,
                    TenantId = TenantConstants.TestTenant1Id
                });
                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = Variant2Id,
                    Sku = "VL-VAR-2",
                    Name = "Variant 2",
                    Price = 6m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.Variant,
                    ParentProductId = ParentId,
                    TenantId = TenantConstants.TestTenant1Id
                });
                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = StandaloneId,
                    Sku = "VL-STD",
                    Name = "Standalone Standard",
                    Price = 7m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.Standard,
                    TenantId = TenantConstants.TestTenant1Id
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
    public async Task GetProducts_DefaultListing_ShouldExcludeVariants()
    {
        await SeedVariantTreeAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Products");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);

        // Parent + standalone, but no variant rows
        TestAssertions.AssertFalse(result.Data!.Any(p => p.ProductType == ProductType.Variant),
            "Variants must be excluded by default");
        TestAssertions.AssertTrue(result.Data!.Any(p => p.Id == ParentId));
        TestAssertions.AssertTrue(result.Data!.Any(p => p.Id == StandaloneId));
        TestAssertions.AssertFalse(result.Data!.Any(p => p.Id == Variant1Id));
        TestAssertions.AssertFalse(result.Data!.Any(p => p.Id == Variant2Id));
    }

    [Fact]
    public async Task GetProducts_IncludeVariantsTrue_ShouldIncludeVariants()
    {
        await SeedVariantTreeAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Products?includeVariants=true");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);

        TestAssertions.AssertTrue(result.Data!.Any(p => p.Id == Variant1Id), "Variant 1 should be listed");
        TestAssertions.AssertTrue(result.Data!.Any(p => p.Id == Variant2Id), "Variant 2 should be listed");
    }

    [Fact]
    public async Task GetProducts_ParentRow_ShouldReportVariantCountAndProductType()
    {
        await SeedVariantTreeAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Products");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductListDto>>(response);

        var parent = result.Data!.FirstOrDefault(p => p.Id == ParentId);
        TestAssertions.AssertNotNull(parent);
        TestAssertions.AssertEqual(ProductType.VariantParent, parent!.ProductType);
        TestAssertions.AssertEqual(2, parent.VariantCount);

        var standalone = result.Data!.FirstOrDefault(p => p.Id == StandaloneId);
        TestAssertions.AssertNotNull(standalone);
        TestAssertions.AssertEqual(ProductType.Standard, standalone!.ProductType);
        TestAssertions.AssertEqual(0, standalone.VariantCount);
    }
}
