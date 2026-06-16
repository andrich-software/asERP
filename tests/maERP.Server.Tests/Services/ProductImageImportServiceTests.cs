using System.Net;
using maERP.Domain.Constants;
using maERP.Persistence.Repositories;
using maERP.SalesChannels.Models;
using maERP.SalesChannels.Repositories;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace maERP.Server.Tests.Services;

/// <summary>
/// Direct tests for <see cref="ProductImageImportService"/>: photos are downloaded from the channel's
/// URLs and attached to the product, the import is idempotent on re-run, and a single broken URL is
/// skipped rather than failing the whole product. HTTP is stubbed so no real network access happens.
/// </summary>
public class ProductImageImportServiceTests : TenantIsolatedTestBase
{
    private const string GoodUrl = "https://shop.example/media/front.png";
    private const string SecondUrl = "https://shop.example/media/back.png";
    private const string BrokenUrl = "https://shop.example/media/missing.png";

    private async Task<Guid> SeedProductAsync()
    {
        var previous = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var taxClass = new maERP.Domain.Entities.TaxClass
            {
                Id = Guid.NewGuid(),
                TaxRate = 19.0,
                TenantId = TenantConstants.TestTenant1Id
            };
            var product = new maERP.Domain.Entities.Product
            {
                Id = Guid.NewGuid(),
                Sku = "IMG-IMPORT-1",
                Name = "Imported Product",
                Price = 9.99m,
                TaxClassId = taxClass.Id,
                TenantId = TenantConstants.TestTenant1Id
            };
            DbContext.TaxClass.Add(taxClass);
            DbContext.Product.Add(product);
            await DbContext.SaveChangesAsync();
            return product.Id;
        }
        finally
        {
            TenantContext.SetCurrentTenantId(previous);
        }
    }

    private ProductImageImportService CreateService()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        var imageRepository = new ProductImageRepository(DbContext, TenantContext);
        var storage = new FakeProductImageStorage();
        var handler = new StubHttpMessageHandler();
        var factory = new StubHttpClientFactory(handler);
        return new ProductImageImportService(imageRepository, storage, factory, NullLogger<ProductImageImportService>.Instance);
    }

    [Fact]
    public async Task ImportImages_DownloadsAndAttaches_OrderedBySortOrder()
    {
        var productId = await SeedProductAsync();
        var service = CreateService();

        var imported = await service.ImportImagesAsync(productId, new List<SalesChannelImportImage>
        {
            new() { RemoteImageId = "2", Url = SecondUrl, AltText = "Back", SortOrder = 1 },
            new() { RemoteImageId = "1", Url = GoodUrl, AltText = "Front", SortOrder = 0 },
        }, CancellationToken.None);

        TestAssertions.AssertEqual(2, imported);

        DbContext.ChangeTracker.Clear();
        var images = await DbContext.ProductImage.IgnoreQueryFilters()
            .Where(i => i.ProductId == productId)
            .OrderBy(i => i.SortOrder)
            .ToListAsync();

        TestAssertions.AssertEqual(2, images.Count);
        // Lowest SortOrder (the SortOrder=0 image) is renumbered to the primary slot.
        TestAssertions.AssertEqual(0, images[0].SortOrder);
        TestAssertions.AssertEqual("Front", images[0].AltText);
        TestAssertions.AssertEqual(1, images[1].SortOrder);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, images[0].TenantId);
        TestAssertions.AssertEqual("front.png", images[0].OriginalFileName);
    }

    [Fact]
    public async Task ImportImages_RunTwice_IsIdempotent()
    {
        var productId = await SeedProductAsync();
        var payload = new List<SalesChannelImportImage>
        {
            new() { RemoteImageId = "1", Url = GoodUrl, SortOrder = 0 },
        };

        await CreateService().ImportImagesAsync(productId, payload, CancellationToken.None);
        DbContext.ChangeTracker.Clear();

        var secondRunImported = await CreateService().ImportImagesAsync(productId, payload, CancellationToken.None);

        TestAssertions.AssertEqual(0, secondRunImported);
        DbContext.ChangeTracker.Clear();
        var count = await DbContext.ProductImage.IgnoreQueryFilters().CountAsync(i => i.ProductId == productId);
        TestAssertions.AssertEqual(1, count);
    }

    [Fact]
    public async Task ImportImages_BrokenUrl_IsSkipped_OthersStillImported()
    {
        var productId = await SeedProductAsync();
        var service = CreateService();

        var imported = await service.ImportImagesAsync(productId, new List<SalesChannelImportImage>
        {
            new() { RemoteImageId = "1", Url = BrokenUrl, SortOrder = 0 },
            new() { RemoteImageId = "2", Url = GoodUrl, SortOrder = 1 },
        }, CancellationToken.None);

        TestAssertions.AssertEqual(1, imported);
        DbContext.ChangeTracker.Clear();
        var count = await DbContext.ProductImage.IgnoreQueryFilters().CountAsync(i => i.ProductId == productId);
        TestAssertions.AssertEqual(1, count);
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri?.ToString() == BrokenUrl)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            // Any non-broken URL returns a tiny payload; FakeProductImageStorage accepts arbitrary bytes.
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(new byte[] { 1, 2, 3, 4 }),
            });
        }
    }

    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        private readonly HttpMessageHandler _handler;
        public StubHttpClientFactory(HttpMessageHandler handler) => _handler = handler;
        public HttpClient CreateClient(string name) => new(_handler, disposeHandler: false);
    }
}
