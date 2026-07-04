using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Models.Storage;
using Microsoft.Extensions.Options;
using SkiaSharp;

namespace asERP.Infrastructure.Storage;

/// <summary>
/// Filesystem implementation of <see cref="IProductImageStorage"/>. Stores originals and
/// thumbnails as PNG, sharded by the first two hex characters of a freshly minted GUID:
/// <c>{root}/products/{ab}/{guid}.png</c> and <c>{root}/products/{ab}/{guid}_thumb.png</c>.
/// </summary>
public class ProductImageStorage : IProductImageStorage
{
    private const string ProductsFolder = "products";

    private readonly FileStorageOptions _options;

    public ProductImageStorage(IOptions<FileStorageOptions> options)
    {
        _options = options.Value;
    }

    private string RootPath => Path.IsPathRooted(_options.RootPath)
        ? _options.RootPath
        : Path.Combine(Directory.GetCurrentDirectory(), _options.RootPath);

    public async Task<StoredImage> SaveAsync(Stream content, CancellationToken cancellationToken = default)
    {
        var id = Guid.CreateVersion7();
        var name = id.ToString("N");
        var shard = name[..2];

        var fileName = $"{name}.png";
        var thumbName = $"{name}_thumb.png";
        var relativePath = $"{ProductsFolder}/{shard}/{fileName}";
        var thumbnailPath = $"{ProductsFolder}/{shard}/{thumbName}";

        var directory = Path.Combine(RootPath, ProductsFolder, shard);
        Directory.CreateDirectory(directory);

        var originalFullPath = Path.Combine(directory, fileName);
        var thumbnailFullPath = Path.Combine(directory, thumbName);

        // Skia decodes synchronously and needs a seekable source, so buffer the upload first.
        using var buffer = new MemoryStream();
        await content.CopyToAsync(buffer, cancellationToken);
        buffer.Position = 0;

        using var image = SKBitmap.Decode(buffer)
            ?? throw new InvalidOperationException("The uploaded content is not a supported image.");
        var width = image.Width;
        var height = image.Height;

        // Original: re-encode whatever was uploaded to PNG.
        await WritePngAsync(image, originalFullPath, cancellationToken);

        // Thumbnail: fit within a square box without upscaling, then PNG.
        using var thumbnail = CreateThumbnail(image, _options.ThumbnailSize);
        await WritePngAsync(thumbnail, thumbnailFullPath, cancellationToken);

        var fileSize = new FileInfo(originalFullPath).Length;

        return new StoredImage(fileName, relativePath, thumbnailPath, width, height, fileSize);
    }

    /// <summary>
    /// Scales <paramref name="source"/> to fit within a square box of <paramref name="maxSize"/>,
    /// preserving aspect ratio and never upscaling — the equivalent of ImageSharp's <c>ResizeMode.Max</c>.
    /// </summary>
    private static SKBitmap CreateThumbnail(SKBitmap source, int maxSize)
    {
        var scale = Math.Min(1.0, Math.Min((double)maxSize / source.Width, (double)maxSize / source.Height));
        var targetWidth = Math.Max(1, (int)Math.Round(source.Width * scale));
        var targetHeight = Math.Max(1, (int)Math.Round(source.Height * scale));

        if (targetWidth == source.Width && targetHeight == source.Height)
        {
            return source.Copy();
        }

        var info = new SKImageInfo(targetWidth, targetHeight);
        return source.Resize(info, new SKSamplingOptions(SKCubicResampler.Mitchell))
            ?? throw new InvalidOperationException("Failed to generate the image thumbnail.");
    }

    private static async Task WritePngAsync(SKBitmap bitmap, string path, CancellationToken cancellationToken)
    {
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await data.AsStream().CopyToAsync(fileStream, cancellationToken);
    }

    public Task<Stream?> OpenReadAsync(string relativePath, CancellationToken cancellationToken = default)
    {
        var fullPath = ResolveFullPath(relativePath);
        if (!File.Exists(fullPath))
        {
            return Task.FromResult<Stream?>(null);
        }

        Stream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        return Task.FromResult<Stream?>(stream);
    }

    public Task DeleteAsync(string relativePath, string? thumbnailPath, CancellationToken cancellationToken = default)
    {
        DeleteIfExists(relativePath);
        if (!string.IsNullOrEmpty(thumbnailPath))
        {
            DeleteIfExists(thumbnailPath);
        }

        return Task.CompletedTask;
    }

    private void DeleteIfExists(string relativePath)
    {
        var fullPath = ResolveFullPath(relativePath);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }

    private string ResolveFullPath(string relativePath)
        => Path.Combine(RootPath, relativePath.Replace('/', Path.DirectorySeparatorChar));
}
