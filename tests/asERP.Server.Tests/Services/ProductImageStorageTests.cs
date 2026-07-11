using System.IO;
using asERP.Application.Models.Storage;
using asERP.Infrastructure.Storage;
using asERP.Server.Tests.Infrastructure;
using Microsoft.Extensions.Options;
using SkiaSharp;
using Xunit;

namespace asERP.Server.Tests.Services;

public class ProductImageStorageTests : IDisposable
{
    // A valid 4x3 JPEG, generated via SkiaSharp, to prove the re-encode path.
    private static byte[] CreateJpeg(int width = 4, int height = 3)
    {
        using var bitmap = new SKBitmap(width, height);
        using (var canvas = new SKCanvas(bitmap))
        {
            canvas.Clear(new SKColor(100, 149, 237)); // CornflowerBlue
        }
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);
        return data.ToArray();
    }

    private readonly string _root = Path.Combine(Path.GetTempPath(), "aserp_img_test_" + Guid.NewGuid().ToString("N"));

    private ProductImageStorage CreateStorage(int thumbnailSize = 300, string format = "webp")
    {
        var options = Options.Create(new FileStorageOptions
        {
            RootPath = _root,
            ThumbnailSize = thumbnailSize,
            StoredImageFormat = format,
        });
        return new ProductImageStorage(options);
    }

    [Fact]
    public async Task SaveAsync_ShardsByGuidPrefix_AndStoresWebpByDefault()
    {
        var storage = CreateStorage();

        using var input = new MemoryStream(CreateJpeg());
        var stored = await storage.SaveAsync(input);

        // Original + thumbnail are WebP (the default) with the expected sharded layout.
        TestAssertions.AssertTrue(stored.FileName.EndsWith(".webp"));
        TestAssertions.AssertTrue(stored.RelativePath.StartsWith("products/"));
        TestAssertions.AssertTrue(stored.ThumbnailPath.EndsWith("_thumb.webp"));

        var segments = stored.RelativePath.Split('/');
        TestAssertions.AssertEqual(3, segments.Length);
        TestAssertions.AssertEqual(2, segments[1].Length); // first two hex chars of the guid

        var originalPath = Path.Combine(_root, "products", segments[1], stored.FileName);
        TestAssertions.AssertTrue(File.Exists(originalPath));
        // The JPEG input must have been re-encoded to a real WebP on disk.
        using var codec = SKCodec.Create(originalPath);
        TestAssertions.AssertEqual(SKEncodedImageFormat.Webp, codec.EncodedFormat);
        TestAssertions.AssertEqual(4, stored.Width);
        TestAssertions.AssertEqual(3, stored.Height);
    }

    [Fact]
    public async Task SaveAsync_HonoursConfiguredPngFormat()
    {
        var storage = CreateStorage(format: "png");

        using var input = new MemoryStream(CreateJpeg());
        var stored = await storage.SaveAsync(input);

        TestAssertions.AssertTrue(stored.FileName.EndsWith(".png"));
        TestAssertions.AssertTrue(stored.ThumbnailPath.EndsWith("_thumb.png"));

        var segments = stored.RelativePath.Split('/');
        var originalPath = Path.Combine(_root, "products", segments[1], stored.FileName);
        using var codec = SKCodec.Create(originalPath);
        TestAssertions.AssertEqual(SKEncodedImageFormat.Png, codec.EncodedFormat);
    }

    [Fact]
    public async Task ReencodeAsync_ConvertsPngToWebp_LeavesOriginal_AndIsIdempotent()
    {
        // Arrange: store an original as PNG.
        var pngStorage = CreateStorage(format: "png");
        using var input = new MemoryStream(CreateJpeg());
        var stored = await pngStorage.SaveAsync(input);
        TestAssertions.AssertTrue(stored.RelativePath.EndsWith(".png"));

        // Act: re-encode it with a WebP-configured storage (same root).
        var webpStorage = CreateStorage(format: "webp");
        var result = await webpStorage.ReencodeAsync(stored.RelativePath);

        // Assert: a real WebP was written under the new extension.
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertTrue(result!.RelativePath.EndsWith(".webp"));
        var segments = result.RelativePath.Split('/');
        var newPath = Path.Combine(_root, "products", segments[1], result.FileName);
        using (var codec = SKCodec.Create(newPath))
        {
            TestAssertions.AssertEqual(SKEncodedImageFormat.Webp, codec.EncodedFormat);
        }

        // The original PNG is intentionally left in place (the caller deletes it after the DB save).
        var oldSegments = stored.RelativePath.Split('/');
        TestAssertions.AssertTrue(File.Exists(Path.Combine(_root, "products", oldSegments[1], stored.FileName)));

        // Idempotent: re-encoding a file already in the target format is a no-op.
        var again = await webpStorage.ReencodeAsync(result.RelativePath);
        TestAssertions.AssertNull(again);

        // Missing file → null, never throws.
        var missing = await webpStorage.ReencodeAsync("products/zz/does-not-exist.png");
        TestAssertions.AssertNull(missing);
    }

    [Fact]
    public async Task OpenReadAsync_ReturnsStoredFile_AndNullForMissing()
    {
        var storage = CreateStorage();

        using var input = new MemoryStream(CreateJpeg());
        var stored = await storage.SaveAsync(input);

        await using var read = await storage.OpenReadAsync(stored.RelativePath);
        TestAssertions.AssertNotNull(read);

        var missing = await storage.OpenReadAsync("products/zz/does-not-exist.png");
        TestAssertions.AssertNull(missing);
    }

    [Fact]
    public async Task DeleteAsync_RemovesOriginalAndThumbnail()
    {
        var storage = CreateStorage();

        using var input = new MemoryStream(CreateJpeg());
        var stored = await storage.SaveAsync(input);

        await storage.DeleteAsync(stored.RelativePath, stored.ThumbnailPath);

        var segments = stored.RelativePath.Split('/');
        TestAssertions.AssertFalse(File.Exists(Path.Combine(_root, "products", segments[1], stored.FileName)));
    }

    public void Dispose()
    {
        if (Directory.Exists(_root))
        {
            Directory.Delete(_root, recursive: true);
        }
    }
}
