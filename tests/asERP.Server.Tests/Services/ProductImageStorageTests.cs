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
    // A valid 4x3 JPEG, generated via SkiaSharp, to prove the re-encode-to-PNG path.
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

    private ProductImageStorage CreateStorage(int thumbnailSize = 300)
    {
        var options = Options.Create(new FileStorageOptions { RootPath = _root, ThumbnailSize = thumbnailSize });
        return new ProductImageStorage(options);
    }

    [Fact]
    public async Task SaveAsync_ShardsByGuidPrefix_AndStoresPng()
    {
        var storage = CreateStorage();

        using var input = new MemoryStream(CreateJpeg());
        var stored = await storage.SaveAsync(input);

        // Original + thumbnail are PNG with the expected sharded layout.
        TestAssertions.AssertTrue(stored.FileName.EndsWith(".png"));
        TestAssertions.AssertTrue(stored.RelativePath.StartsWith("products/"));
        TestAssertions.AssertTrue(stored.ThumbnailPath.EndsWith("_thumb.png"));

        var segments = stored.RelativePath.Split('/');
        TestAssertions.AssertEqual(3, segments.Length);
        TestAssertions.AssertEqual(2, segments[1].Length); // first two hex chars of the guid

        var originalPath = Path.Combine(_root, "products", segments[1], stored.FileName);
        TestAssertions.AssertTrue(File.Exists(originalPath));
        // The JPEG input must have been re-encoded to a real PNG on disk.
        using var codec = SKCodec.Create(originalPath);
        TestAssertions.AssertEqual(SKEncodedImageFormat.Png, codec.EncodedFormat);
        TestAssertions.AssertEqual(4, stored.Width);
        TestAssertions.AssertEqual(3, stored.Height);
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
