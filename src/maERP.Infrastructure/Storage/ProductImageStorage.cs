using maERP.Application.Contracts.Infrastructure;
using maERP.Application.Models.Storage;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace maERP.Infrastructure.Storage;

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

        using var image = await Image.LoadAsync(content, cancellationToken);
        var width = image.Width;
        var height = image.Height;

        // Original: re-encode whatever was uploaded to PNG.
        await image.SaveAsPngAsync(originalFullPath, cancellationToken);

        // Thumbnail: fit within a square box without upscaling, then PNG.
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Mode = ResizeMode.Max,
            Size = new Size(_options.ThumbnailSize, _options.ThumbnailSize),
            Sampler = KnownResamplers.Lanczos3
        }));
        await image.SaveAsPngAsync(thumbnailFullPath, cancellationToken);

        var fileSize = new FileInfo(originalFullPath).Length;

        return new StoredImage(fileName, relativePath, thumbnailPath, width, height, fileSize);
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
