using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Models.Storage;
using Microsoft.Extensions.Options;
using SkiaSharp;

namespace asERP.Infrastructure.Storage;

/// <summary>
/// Filesystem implementation of <see cref="IProductImageStorage"/>. Stores originals and
/// thumbnails in the configured <see cref="FileStorageOptions.StoredImageFormat"/> (WebP by
/// default — far smaller than the former PNG default for photographic images), sharded by the
/// first two hex characters of a freshly minted GUID:
/// <c>{root}/products/{ab}/{guid}.{ext}</c> and <c>{root}/products/{ab}/{guid}_thumb.{ext}</c>.
/// </summary>
public class ProductImageStorage : IProductImageStorage
{
    private const string ProductsFolder = "products";

    // Cap the buffered upload before decoding to bound memory usage (a huge "image" would otherwise
    // be fully buffered into a MemoryStream ahead of the SkiaSharp decode → memory DoS).
    private const long MaxImageSizeBytes = 20L * 1024 * 1024;

    private readonly FileStorageOptions _options;
    private readonly SKEncodedImageFormat _format;
    private readonly string _extension;
    private readonly int _quality;

    public ProductImageStorage(IOptions<FileStorageOptions> options)
    {
        _options = options.Value;
        (_format, _extension) = ResolveFormat(_options.StoredImageFormat);
        // PNG is lossless (quality is ignored by the encoder); clamp lossy quality into 1..100.
        _quality = Math.Clamp(_options.ImageQuality, 1, 100);
    }

    /// <summary>Maps the configured format name to the SkiaSharp encoder + file extension. Unknown values fall back to WebP.</summary>
    private static (SKEncodedImageFormat Format, string Extension) ResolveFormat(string? name) =>
        (name?.Trim().ToLowerInvariant()) switch
        {
            "png" => (SKEncodedImageFormat.Png, "png"),
            "jpg" or "jpeg" => (SKEncodedImageFormat.Jpeg, "jpg"),
            _ => (SKEncodedImageFormat.Webp, "webp"),
        };

    private string RootPath => Path.IsPathRooted(_options.RootPath)
        ? _options.RootPath
        : Path.Combine(Directory.GetCurrentDirectory(), _options.RootPath);

    public async Task<StoredImage> SaveAsync(Stream content, CancellationToken cancellationToken = default)
    {
        var id = Guid.CreateVersion7();
        var name = id.ToString("N");
        var shard = name[..2];

        var fileName = $"{name}.{_extension}";
        var thumbName = $"{name}_thumb.{_extension}";
        var relativePath = $"{ProductsFolder}/{shard}/{fileName}";
        var thumbnailPath = $"{ProductsFolder}/{shard}/{thumbName}";

        var directory = Path.Combine(RootPath, ProductsFolder, shard);
        Directory.CreateDirectory(directory);

        var originalFullPath = Path.Combine(directory, fileName);
        var thumbnailFullPath = Path.Combine(directory, thumbName);

        // Skia decodes synchronously and needs a seekable source, so buffer the upload first.
        // Enforce the size cap while copying so we abort before buffering an oversized body.
        using var buffer = new MemoryStream();
        await CopyWithLimitAsync(content, buffer, MaxImageSizeBytes, cancellationToken);
        buffer.Position = 0;

        using var image = SKBitmap.Decode(buffer)
            ?? throw new InvalidOperationException("The uploaded content is not a supported image.");
        var width = image.Width;
        var height = image.Height;

        // Original: re-encode whatever was uploaded to the configured format.
        await WriteEncodedAsync(image, originalFullPath, cancellationToken);

        // Thumbnail: fit within a square box without upscaling, then encode.
        using var thumbnail = CreateThumbnail(image, _options.ThumbnailSize);
        await WriteEncodedAsync(thumbnail, thumbnailFullPath, cancellationToken);

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

    private async Task WriteEncodedAsync(SKBitmap bitmap, string path, CancellationToken cancellationToken)
    {
        using var image = SKImage.FromBitmap(bitmap);
        // Quality is honoured by the lossy encoders (WebP/JPEG) and ignored by PNG.
        using var data = image.Encode(_format, _quality)
            ?? throw new InvalidOperationException($"Failed to encode the image as {_format}.");

        await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await data.AsStream().CopyToAsync(fileStream, cancellationToken);
    }

    public async Task<ReencodedFile?> ReencodeAsync(string relativePath, CancellationToken cancellationToken = default)
    {
        var fullPath = ResolveFullPath(relativePath);
        if (!File.Exists(fullPath))
        {
            return null;
        }

        // Already in the target format → nothing to migrate.
        if (string.Equals(Path.GetExtension(fullPath).TrimStart('.'), _extension, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        using var bitmap = SKBitmap.Decode(fullPath);
        if (bitmap is null)
        {
            // Corrupt/undecodable file — leave it untouched rather than destroy it.
            return null;
        }

        var newRelativePath = Path.ChangeExtension(relativePath, _extension)!.Replace('\\', '/');
        var newFullPath = ResolveFullPath(newRelativePath);

        // Write the new file but deliberately leave the original in place. The caller deletes the
        // old file only after it has persisted the new path — so a crash mid-migration never leaves
        // a DB row pointing at a deleted file (at worst an orphaned new file, cleaned up separately).
        await WriteEncodedAsync(bitmap, newFullPath, cancellationToken);

        var size = new FileInfo(newFullPath).Length;
        return new ReencodedFile(newRelativePath, Path.GetFileName(newRelativePath), size, bitmap.Width, bitmap.Height);
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

    /// <summary>
    /// Copies <paramref name="source"/> into <paramref name="destination"/>, aborting as soon as
    /// more than <paramref name="maxBytes"/> have been read, so an oversized body is never fully buffered.
    /// </summary>
    private static async Task CopyWithLimitAsync(Stream source, Stream destination, long maxBytes, CancellationToken cancellationToken)
    {
        var bufferArray = new byte[81920];
        var buffer = bufferArray.AsMemory();
        long total = 0;

        int read;
        while ((read = await source.ReadAsync(buffer, cancellationToken)) > 0)
        {
            total += read;
            if (total > maxBytes)
            {
                throw new InvalidOperationException(
                    $"The uploaded image exceeds the maximum allowed size of {maxBytes} bytes.");
            }

            await destination.WriteAsync(buffer[..read], cancellationToken);
        }
    }

    private string ResolveFullPath(string relativePath)
    {
        var combined = Path.Combine(RootPath, relativePath.Replace('/', Path.DirectorySeparatorChar));
        var fullPath = Path.GetFullPath(combined);

        // Containment check: the resolved path must stay inside RootPath (defence against `..` traversal).
        var rootFull = Path.GetFullPath(RootPath);
        var rootPrefix = rootFull.EndsWith(Path.DirectorySeparatorChar)
            ? rootFull
            : rootFull + Path.DirectorySeparatorChar;

        if (!fullPath.StartsWith(rootPrefix, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("The resolved path escapes the storage root.");
        }

        return fullPath;
    }
}
