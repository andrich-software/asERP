using asERP.Domain.Constants;
using asERP.Persistence.Repositories;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Repositories;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Direct-repository tests for the channel-link healing on product re-imports: the remote product id
/// is identity and always follows the shop, while the channel price only mirrors on import-only
/// channels (an export-enabled channel owns its price locally — no import/export ping-pong).
/// </summary>
public class ProductImportRepositoryHealTests : TenantIsolatedTestBase
{
    // Seeded by TestDataSeeder: WooCommerce channel and 19% tax class, both Tenant 1.
    private static readonly Guid SalesChannel1Id = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1");
    private const double TaxRate19 = 19.0;

    private ProductImportRepository CreateImportRepository()
    {
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

    private static SalesChannelImportProduct BuildSimpleProduct(
        string sku = "HEAL-1", string remoteProductId = "500", decimal price = 10.00m)
    {
        return new SalesChannelImportProduct
        {
            RemoteProductId = remoteProductId,
            Name = "Simple Product",
            Sku = sku,
            Description = "<p>desc</p>",
            TaxRate = TaxRate19,
            Price = price,
            IsVariantParent = false,
        };
    }

    private async Task SetChannelExportProductsAsync(bool exportProducts)
    {
        var channel = await DbContext.SalesChannel.IgnoreQueryFilters().SingleAsync(s => s.Id == SalesChannel1Id);
        channel.ExportProducts = exportProducts;
        await DbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task Reimport_HealsChangedRemoteProductId()
    {
        await SeedBaseDataAsync();
        var repo = CreateImportRepository();
        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(remoteProductId: "500"));

        // The shop re-created the product under a new id — the link must follow, or every later
        // stock/price push and remote lookup resolves against a dead id.
        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(remoteProductId: "600"));

        var link = await DbContext.ProductSalesChannel.IgnoreQueryFilters().AsNoTracking()
            .SingleAsync(l => l.SalesChannelId == SalesChannel1Id);
        Assert.Equal("600", link.RemoteProductId);
    }

    [Fact]
    public async Task Reimport_UpdatesChannelPrice_OnImportOnlyChannel()
    {
        await SeedBaseDataAsync();
        await SetChannelExportProductsAsync(false);
        var repo = CreateImportRepository();
        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(price: 10.00m));

        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(price: 12.50m));

        var link = await DbContext.ProductSalesChannel.IgnoreQueryFilters().AsNoTracking()
            .SingleAsync(l => l.SalesChannelId == SalesChannel1Id);
        Assert.Equal(12.50m, link.Price);
    }

    [Fact]
    public async Task Reimport_KeepsChannelPrice_OnExportingChannel()
    {
        await SeedBaseDataAsync();
        await SetChannelExportProductsAsync(true);
        var repo = CreateImportRepository();
        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(price: 10.00m, remoteProductId: "500"));

        // Price stays local (the ERP owns it on an exporting channel), but identity still heals.
        await repo.ImportOrUpdateFromSalesChannel(SalesChannel1Id, BuildSimpleProduct(price: 12.50m, remoteProductId: "600"));

        var link = await DbContext.ProductSalesChannel.IgnoreQueryFilters().AsNoTracking()
            .SingleAsync(l => l.SalesChannelId == SalesChannel1Id);
        Assert.Equal(10.00m, link.Price);
        Assert.Equal("600", link.RemoteProductId);
    }
}
