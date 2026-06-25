using maERP.Domain.Constants;
using maERP.Domain.Enums;
using maERP.Persistence.Repositories;
using maERP.SalesChannels.Contracts;
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
            DbContext,
            productRepository,
            salesChannelRepository,
            taxClassRepository,
            productAttributeRepository,
            productSalesChannelRepository,
            new NoOpProductImageImportService());
    }

    /// <summary>
    /// These variant tests carry no image payloads; a no-op importer keeps them focused on variant
    /// behaviour without wiring up image storage / HttpClient. Image import has its own coverage.
    /// </summary>
    private sealed class NoOpProductImageImportService : IProductImageImportService
    {
        public Task<int> ImportImagesAsync(Guid productId, Guid salesChannelId, IReadOnlyList<SalesChannelImportImage> images, CancellationToken cancellationToken)
            => Task.FromResult(0);
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
    public async Task Import_VariantChannelLink_DoesNotCreatePhantomSalesChannelOrProduct()
    {
        await SeedBaseDataAsync();

        var channelsBefore = await DbContext.SalesChannel.IgnoreQueryFilters().CountAsync();

        // Import twice: the first run links variants as graph children; the second hits the
        // "channel link missing" path that adds a ProductSalesChannel standalone — the case where an
        // auto-initialized navigation would otherwise insert a phantom SalesChannel/Product.
        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildImportProduct());
        DbContext.ChangeTracker.Clear();
        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildImportProduct());
        DbContext.ChangeTracker.Clear();

        // No empty phantom SalesChannel rows were inserted; every channel link points at the real channel.
        var channelsAfter = await DbContext.SalesChannel.IgnoreQueryFilters().CountAsync();
        TestAssertions.AssertEqual(channelsBefore, channelsAfter);

        var links = await DbContext.ProductSalesChannel.IgnoreQueryFilters().ToListAsync();
        TestAssertions.AssertTrue(links.Count > 0);
        TestAssertions.AssertTrue(links.All(psc => psc.SalesChannelId == SalesChannel1Id));

        // No phantom default Product (a new Product() carries TaxClassId == Guid.Empty, which is what the
        // standalone link insert used to drag in and fail the foreign key on).
        var products = await DbContext.Product.IgnoreQueryFilters().ToListAsync();
        TestAssertions.AssertTrue(products.All(p => p.TaxClassId != Guid.Empty));
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

    [Fact]
    public async Task Import_TaxRateWithoutMatchingClass_CreatesTaxClass_TenantScoped()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();

        // 5.5% has no seeded tax class. The import must create one for the current tenant on the fly
        // rather than failing the product.
        const double unseededRate = 5.5;
        var importProduct = new SalesChannelImportProduct
        {
            RemoteProductId = "900",
            Name = "Foreign-rate product",
            Sku = "TAX-900",
            Description = "<p>desc</p>",
            TaxRate = unseededRate,
            Price = 9.99m,
        };

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, importProduct);

        DbContext.ChangeTracker.Clear();
        var createdClass = await DbContext.TaxClass.IgnoreQueryFilters()
            .FirstOrDefaultAsync(t => t.TaxRate == unseededRate);
        TestAssertions.AssertNotNull(createdClass);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, createdClass!.TenantId);

        var product = await DbContext.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Sku == "TAX-900");
        TestAssertions.AssertNotNull(product);
        TestAssertions.AssertEqual(createdClass.Id, product!.TaxClassId);
    }

    [Fact]
    public async Task Import_TwoProductsSameUnseededRate_ReusesSingleTaxClass()
    {
        await SeedBaseDataAsync();
        const double unseededRate = 5.5;

        SalesChannelImportProduct Build(string sku, string remoteId) => new()
        {
            RemoteProductId = remoteId,
            Name = $"Product {sku}",
            Sku = sku,
            Description = "<p>desc</p>",
            TaxRate = unseededRate,
            Price = 1.00m,
        };

        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, Build("TAX-A", "910"));
        await CreateImportRepository().ImportOrUpdateFromSalesChannel(SalesChannel1Id, Build("TAX-B", "911"));

        DbContext.ChangeTracker.Clear();
        var classCount = await DbContext.TaxClass.IgnoreQueryFilters()
            .CountAsync(t => t.TaxRate == unseededRate && t.TenantId == TenantConstants.TestTenant1Id);
        TestAssertions.AssertEqual(1, classCount);
    }
}
