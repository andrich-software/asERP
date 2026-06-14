using maERP.Domain.Constants;
using maERP.Domain.Enums;
using maERP.Persistence.Repositories;
using maERP.SalesChannels.Models;
using maERP.SalesChannels.Repositories;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace maERP.Server.Tests.Services;

/// <summary>
/// Direct-repository tests for variant import behaviour in <see cref="ProductImportRepository"/>.
/// Unlike the HTTP integration tests these construct the SalesChannels repository manually with the
/// test DbContext / TenantContext, since the Server test host does not register the SalesChannels layer.
/// </summary>
public class ProductImportRepositoryVariantTests : TenantIsolatedTestBase
{
    // Seeded by TestDataSeeder: WooCommerce channel and 19% tax class, both Tenant 1.
    private static readonly Guid SalesChannel1Id = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1");
    private const double TaxRate19 = 19.0;

    private ProductImportRepository CreateImportRepository()
    {
        // The import code resolves entities relative to the current tenant.
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var productRepository = new ProductRepository(DbContext, TenantContext);
        var salesChannelRepository = new SalesChannelRepository(DbContext, TenantContext);
        var taxClassRepository = new TaxClassRepository(DbContext, TenantContext);
        var productAttributeRepository = new ProductAttributeRepository(DbContext, TenantContext);
        var productSalesChannelRepository = new ProductSalesChannelRepository(DbContext, TenantContext);

        return new ProductImportRepository(
            NullLogger<ProductImportRepository>.Instance,
            productRepository,
            salesChannelRepository,
            taxClassRepository,
            productAttributeRepository,
            productSalesChannelRepository);
    }

    private async Task SeedBaseDataAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            if (!await DbContext.TaxClass.AnyAsync())
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private static SalesChannelImportProduct BuildImportProduct(
        string parentSku = "P-1",
        string remoteProductId = "100",
        decimal parentPrice = 10.00m,
        IEnumerable<SalesChannelImportVariant>? variants = null)
    {
        return new SalesChannelImportProduct
        {
            RemoteProductId = remoteProductId,
            Name = "Variable Product",
            Sku = parentSku,
            Description = "<p>desc</p>",
            TaxRate = TaxRate19,
            Price = parentPrice,
            IsVariantParent = true,
            VariantAxes = new List<string> { "Länge" },
            Variants = (variants ?? new List<SalesChannelImportVariant>
            {
                new()
                {
                    RemoteVariantId = "201",
                    Sku = null,
                    Price = 3.05m,
                    Options = new List<SalesChannelImportVariantOption>
                    {
                        new() { AttributeName = "Länge", Value = "22" }
                    }
                },
                new()
                {
                    RemoteVariantId = "202",
                    Sku = null,
                    Price = 4.10m,
                    Options = new List<SalesChannelImportVariantOption>
                    {
                        new() { AttributeName = "Länge", Value = "44" }
                    }
                }
            }).ToList()
        };
    }

    [Fact]
    public async Task Import_CreatesParentAsVariantParent_AndSynthesizesSkuForSkuLessVariant()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();
        var importProduct = BuildImportProduct();

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, importProduct);

        DbContext.ChangeTracker.Clear();
        var parent = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Sku == "P-1");
        TestAssertions.AssertNotNull(parent);
        TestAssertions.AssertEqual(ProductType.VariantParent, parent!.ProductType);

        // SKU-less variant gets a stable synthesized SKU "{parentSku}-V{RemoteVariantId}".
        var synthesized = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Sku == "P-1-V201");
        TestAssertions.AssertNotNull(synthesized);
        TestAssertions.AssertEqual(ProductType.Variant, synthesized!.ProductType);
        TestAssertions.AssertEqual(parent.Id, synthesized.ParentProductId);
    }

    [Fact]
    public async Task Import_UpsertsAttributeAndValue_TenantScoped()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();
        var importProduct = BuildImportProduct();

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, importProduct);

        DbContext.ChangeTracker.Clear();
        var attribute = await DbContext.ProductAttribute.IgnoreQueryFilters()
            .Include(a => a.Values)
            .FirstOrDefaultAsync(a => a.Name == "Länge");
        TestAssertions.AssertNotNull(attribute);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, attribute!.TenantId);
        TestAssertions.AssertTrue(attribute.Values.Any(v => v.Value == "22"));
        TestAssertions.AssertTrue(attribute.Values.Any(v => v.Value == "44"));
    }

    [Fact]
    public async Task Import_RunTwice_IsIdempotent_DoesNotDuplicateVariants()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildImportProduct());

        DbContext.ChangeTracker.Clear();
        var countAfterFirst = await DbContext.Product.IgnoreQueryFilters()
            .CountAsync(p => p.ProductType == ProductType.Variant && p.Sku.StartsWith("P-1-V"));

        // Second import with a freshly-constructed repository (fresh tracking) and equal payload.
        var repo2 = CreateImportRepository();
        await repo2.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildImportProduct());

        DbContext.ChangeTracker.Clear();
        var countAfterSecond = await DbContext.Product.IgnoreQueryFilters()
            .CountAsync(p => p.ProductType == ProductType.Variant && p.Sku.StartsWith("P-1-V"));

        TestAssertions.AssertEqual(2, countAfterFirst);
        TestAssertions.AssertEqual(countAfterFirst, countAfterSecond);
    }

    [Fact]
    public async Task Import_VariantWithNullPrice_InheritsParentPrice()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();

        var importProduct = BuildImportProduct(parentPrice: 12.50m, variants: new List<SalesChannelImportVariant>
        {
            new()
            {
                RemoteVariantId = "301",
                Sku = null,
                Price = null, // inherits parent price
                Options = new List<SalesChannelImportVariantOption>
                {
                    new() { AttributeName = "Länge", Value = "22" }
                }
            }
        });

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, importProduct);

        DbContext.ChangeTracker.Clear();
        var variant = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Sku == "P-1-V301");
        TestAssertions.AssertNotNull(variant);
        TestAssertions.AssertEqual(12.50m, variant!.Price);
    }

    [Fact]
    public async Task Import_RemoteIdFirstMatching_UpdatesSameVariantWhenSkuChanges()
    {
        await SeedBaseDataAsync();

        // First import: SKU-less variant -> synthesized SKU "P-1-V201".
        var firstProduct = BuildImportProduct(variants: new List<SalesChannelImportVariant>
        {
            new()
            {
                RemoteVariantId = "201",
                Sku = null,
                Price = 3.05m,
                Options = new List<SalesChannelImportVariantOption>
                {
                    new() { AttributeName = "Länge", Value = "22" }
                }
            }
        });
        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, firstProduct);

        DbContext.ChangeTracker.Clear();
        var original = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Sku == "P-1-V201");
        TestAssertions.AssertNotNull(original);
        var originalId = original!.Id;

        var variantCountBefore = await DbContext.Product.IgnoreQueryFilters()
            .CountAsync(p => p.ProductType == ProductType.Variant);

        // Second import: same RemoteVariantId, but now a real SKU. RemoteId-first matching must
        // update the SAME row (its SKU changes) rather than create a new variant.
        var secondProduct = BuildImportProduct(variants: new List<SalesChannelImportVariant>
        {
            new()
            {
                RemoteVariantId = "201",
                Sku = "REAL-SKU-201",
                Price = 3.05m,
                Options = new List<SalesChannelImportVariantOption>
                {
                    new() { AttributeName = "Länge", Value = "22" }
                }
            }
        });
        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, secondProduct);

        DbContext.ChangeTracker.Clear();
        var variantCountAfter = await DbContext.Product.IgnoreQueryFilters()
            .CountAsync(p => p.ProductType == ProductType.Variant);
        TestAssertions.AssertEqual(variantCountBefore, variantCountAfter);

        var updated = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == originalId);
        TestAssertions.AssertNotNull(updated);
        TestAssertions.AssertEqual("REAL-SKU-201", updated!.Sku);
    }
}
