using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Persistence.Repositories;
using asToolkit.SalesChannels.Models;
using asToolkit.SalesChannels.Repositories;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asToolkit.Server.Tests.Services;

/// <summary>
/// Direct tests for <see cref="ProductImageImportService"/>: photos are downloaded from the channel's
/// URLs and synced incrementally onto the product (add new, drop removed), while manual uploads and
/// other channels' images stay untouched. HTTP is stubbed so no real network access happens.
/// </summary>
public class ProductImageImportServiceTests : TenantIsolatedTestBase
{
    private static readonly Guid ChannelA = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    private static readonly Guid ChannelB = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

    private const string Url1 = "https://shop.example/media/front.png";
    private const string Url2 = "https://shop.example/media/back.png";
    private const string Url3 = "https://shop.example/media/side.png";
    private const string BrokenUrl = "https://shop.example/media/missing.png";

    private async Task<Guid> SeedProductAsync()
    {
        var previous = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var taxClass = new asToolkit.Domain.Entities.TaxClass
            {
                Id = Guid.NewGuid(),
                TaxRate = 19.0,
                TenantId = TenantConstants.TestTenant1Id
            };
            var product = new asToolkit.Domain.Entities.Product
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

    // A storage shared across runs in one test so deletions can be asserted against it.
    private FakeProductImageStorage CreateStorage() => new();

    private ProductImageImportService CreateService(FakeProductImageStorage storage)
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        var imageRepository = new ProductImageRepository(DbContext, TenantContext);
        var factory = new StubHttpClientFactory(new StubHttpMessageHandler());
        return new ProductImageImportService(imageRepository, storage, factory, NullLogger<ProductImageImportService>.Instance);
    }

    private static List<SalesChannelImportImage> Images(params (string id, string url, int sort)[] specs) =>
        specs.Select(s => new SalesChannelImportImage { RemoteImageId = s.id, Url = s.url, SortOrder = s.sort }).ToList();

    private async Task<List<asToolkit.Domain.Entities.ProductImage>> LoadImagesAsync(Guid productId)
    {
        DbContext.ChangeTracker.Clear();
        return await DbContext.ProductImage.IgnoreQueryFilters()
            .Where(i => i.ProductId == productId)
            .OrderBy(i => i.SortOrder)
            .ToListAsync();
    }

    [Fact]
    public async Task Import_Fresh_DownloadsOrdered_AndStampsChannelAndRemoteId()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        var imported = await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("2", Url2, 1), ("1", Url1, 0)), CancellationToken.None);

        TestAssertions.AssertEqual(2, imported);

        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(2, images.Count);
        TestAssertions.AssertEqual(0, images[0].SortOrder);
        TestAssertions.AssertEqual("1", images[0].RemoteImageId);
        TestAssertions.AssertEqual(ChannelA, images[0].SalesChannelId);
        TestAssertions.AssertEqual("front.png", images[0].OriginalFileName);
        TestAssertions.AssertEqual("2", images[1].RemoteImageId);
    }

    [Fact]
    public async Task Import_RunTwice_SameSet_IsIdempotent()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();
        var payload = Images(("1", Url1, 0), ("2", Url2, 1));

        await CreateService(storage).ImportImagesAsync(productId, ChannelA, payload, CancellationToken.None);
        var secondRun = await CreateService(storage).ImportImagesAsync(productId, ChannelA, payload, CancellationToken.None);

        TestAssertions.AssertEqual(0, secondRun);
        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(2, images.Count);
    }

    [Fact]
    public async Task Import_Incremental_AddsNewImage()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", Url1, 0), ("2", Url2, 1)), CancellationToken.None);

        var added = await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", Url1, 0), ("2", Url2, 1), ("3", Url3, 2)), CancellationToken.None);

        TestAssertions.AssertEqual(1, added);
        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(3, images.Count);
        TestAssertions.AssertTrue(images.Any(i => i.RemoteImageId == "3"));
        // Contiguous re-index preserved.
        TestAssertions.AssertEqual(new[] { 0, 1, 2 }, images.Select(i => i.SortOrder).ToArray());
    }

    [Fact]
    public async Task Import_Incremental_RemovesDroppedImage_AndDeletesFiles()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", Url1, 0), ("2", Url2, 1), ("3", Url3, 2)), CancellationToken.None);
        var filesAfterFirst = storage.FileCount; // 3 originals + 3 thumbs = 6

        // Channel no longer lists image "3".
        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", Url1, 0), ("2", Url2, 1)), CancellationToken.None);

        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(2, images.Count);
        TestAssertions.AssertFalse(images.Any(i => i.RemoteImageId == "3"));
        TestAssertions.AssertEqual(new[] { 0, 1 }, images.Select(i => i.SortOrder).ToArray());
        // The dropped image's original + thumbnail were removed from storage.
        TestAssertions.AssertEqual(6, filesAfterFirst);
        TestAssertions.AssertEqual(4, storage.FileCount);
    }

    [Fact]
    public async Task Import_EmptySet_IsNoOp_DoesNotWipeExisting()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", Url1, 0), ("2", Url2, 1)), CancellationToken.None);

        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            new List<SalesChannelImportImage>(), CancellationToken.None);

        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(2, images.Count);
    }

    [Fact]
    public async Task Import_LeavesManualAndOtherChannelImagesUntouched()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        // A manual upload (no channel) and another channel's image already exist.
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        DbContext.ProductImage.Add(new asToolkit.Domain.Entities.ProductImage
        {
            ProductId = productId, RelativePath = "p/manual.png", ThumbnailPath = "p/manual_thumb.png",
            SortOrder = 0, TenantId = TenantConstants.TestTenant1Id
        });
        DbContext.ProductImage.Add(new asToolkit.Domain.Entities.ProductImage
        {
            ProductId = productId, SalesChannelId = ChannelB, RemoteImageId = "b1",
            RelativePath = "p/b1.png", ThumbnailPath = "p/b1_thumb.png",
            SortOrder = 1, TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();

        // Import channel A with one image, then sync channel A to an empty-but... use a removal too.
        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("a1", Url1, 0)), CancellationToken.None);

        // Re-sync channel A dropping a1 — must remove only a1, never the manual or channel-B image.
        await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("a2", Url2, 0)), CancellationToken.None);

        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertTrue(images.Any(i => i.SalesChannelId == null));          // manual kept
        TestAssertions.AssertTrue(images.Any(i => i.SalesChannelId == ChannelB && i.RemoteImageId == "b1")); // other channel kept
        TestAssertions.AssertTrue(images.Any(i => i.SalesChannelId == ChannelA && i.RemoteImageId == "a2")); // new A image
        TestAssertions.AssertFalse(images.Any(i => i.RemoteImageId == "a1"));          // dropped A image gone
    }

    [Fact]
    public async Task Import_BrokenUrl_IsSkipped_OthersStillImported()
    {
        var productId = await SeedProductAsync();
        var storage = CreateStorage();

        var imported = await CreateService(storage).ImportImagesAsync(productId, ChannelA,
            Images(("1", BrokenUrl, 0), ("2", Url1, 1)), CancellationToken.None);

        TestAssertions.AssertEqual(1, imported);
        var images = await LoadImagesAsync(productId);
        TestAssertions.AssertEqual(1, images.Count);
        TestAssertions.AssertEqual("2", images[0].RemoteImageId);
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri?.ToString() == BrokenUrl)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

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
