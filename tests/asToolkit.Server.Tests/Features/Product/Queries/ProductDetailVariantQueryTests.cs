using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.Product.Queries;

/// <summary>
/// Variant-specific product detail behaviour. Dedicated class with an isolated database so the
/// exact-shape assertions in <see cref="ProductDetailQueryTests"/> are not affected by extra seed rows.
/// </summary>
public class ProductDetailVariantQueryTests : TenantIsolatedTestBase
{
    private static readonly Guid TaxClass1Id = Guid.NewGuid();
    private static readonly Guid AttributeId = Guid.NewGuid();
    private static readonly Guid Value22Id = Guid.NewGuid();
    private static readonly Guid Value44Id = Guid.NewGuid();
    private static readonly Guid ParentId = Guid.NewGuid();
    private static readonly Guid VariantId = Guid.NewGuid();

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

                DbContext.ProductAttribute.Add(new asToolkit.Domain.Entities.ProductAttribute
                {
                    Id = AttributeId,
                    Name = "Länge",
                    SortOrder = 0,
                    TenantId = TenantConstants.TestTenant1Id,
                    Values = new List<asToolkit.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Id = Value22Id, Value = "22", SortOrder = 0, TenantId = TenantConstants.TestTenant1Id },
                        new() { Id = Value44Id, Value = "44", SortOrder = 1, TenantId = TenantConstants.TestTenant1Id }
                    }
                });

                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = ParentId,
                    Sku = "VD-PARENT",
                    Name = "Variant Parent",
                    Price = 0m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.VariantParent,
                    TenantId = TenantConstants.TestTenant1Id,
                    VariantAxes = new List<asToolkit.Domain.Entities.ProductVariantAxis>
                    {
                        new() { ProductAttributeId = AttributeId, SortOrder = 0, TenantId = TenantConstants.TestTenant1Id }
                    }
                });

                DbContext.Product.Add(new asToolkit.Domain.Entities.Product
                {
                    Id = VariantId,
                    Sku = "VD-VAR-22",
                    Name = "Variant 22",
                    Price = 5m,
                    TaxClassId = TaxClass1Id,
                    ProductType = ProductType.Variant,
                    ParentProductId = ParentId,
                    TenantId = TenantConstants.TestTenant1Id,
                    VariantOptions = new List<asToolkit.Domain.Entities.ProductVariantOption>
                    {
                        new() { ProductAttributeValueId = Value22Id, TenantId = TenantConstants.TestTenant1Id }
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
    public async Task GetProductDetail_Parent_ShouldExposeVariantAxesAndVariants()
    {
        await SeedVariantTreeAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Products/{ParentId}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ProductDetailDto>>(response);
        TestAssertions.AssertNotNull(result?.Data);
        TestAssertions.AssertEqual(ProductType.VariantParent, result!.Data.ProductType);

        TestAssertions.AssertEqual(1, result.Data.VariantAxes.Count);
        TestAssertions.AssertEqual(AttributeId, result.Data.VariantAxes.First().ProductAttributeId);
        TestAssertions.AssertEqual("Länge", result.Data.VariantAxes.First().AttributeName);

        TestAssertions.AssertEqual(1, result.Data.Variants.Count);
        TestAssertions.AssertEqual(VariantId, result.Data.Variants.First().Id);
    }

    [Fact]
    public async Task GetProductDetail_Variant_ShouldExposeOptionsAndParentProductId()
    {
        await SeedVariantTreeAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Products/{VariantId}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ProductDetailDto>>(response);
        TestAssertions.AssertNotNull(result?.Data);
        TestAssertions.AssertEqual(ProductType.Variant, result!.Data.ProductType);
        TestAssertions.AssertEqual(ParentId, result.Data.ParentProductId);

        TestAssertions.AssertEqual(1, result.Data.Options.Count);
        var option = result.Data.Options.First();
        TestAssertions.AssertEqual(Value22Id, option.ProductAttributeValueId);
        TestAssertions.AssertEqual("22", option.Value);
        TestAssertions.AssertEqual("Länge", option.AttributeName);
    }
}
