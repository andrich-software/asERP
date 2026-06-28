using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Entities;
using asToolkit.SalesChannels.Contracts;
using asToolkit.SalesChannels.Models;
using Microsoft.Extensions.Logging;

namespace asToolkit.SalesChannels.Repositories;

public class ProductImageImportService : IProductImageImportService
{
    /// <summary>Named HttpClient (Polly-backed) used to download images from the shop's public URLs.</summary>
    public const string HttpClientName = "product-images";

    private readonly IProductImageRepository _imageRepository;
    private readonly IProductImageStorage _imageStorage;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ProductImageImportService> _logger;

    public ProductImageImportService(
        IProductImageRepository imageRepository,
        IProductImageStorage imageStorage,
        IHttpClientFactory httpClientFactory,
        ILogger<ProductImageImportService> logger)
    {
        _imageRepository = imageRepository;
        _imageStorage = imageStorage;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<int> ImportImagesAsync(Guid productId, Guid salesChannelId, IReadOnlyList<SalesChannelImportImage> images, CancellationToken cancellationToken)
    {
        // Safety guard: an empty set never mutates existing photos. A connector returning no images for
        // a product that genuinely has none, and one that failed to load its media association, look the
        // same here — so we refuse to delete on an empty set rather than risk wiping a live gallery.
        if (images is null || images.Count == 0)
        {
            return 0;
        }

        // Deduplicate the incoming set by its stable remote key, keeping channel order.
        var incoming = images
            .Where(i => !string.IsNullOrWhiteSpace(i.Url) && !string.IsNullOrWhiteSpace(RemoteKey(i)))
            .GroupBy(RemoteKey)
            .Select(g => g.OrderBy(i => i.SortOrder).First())
            .OrderBy(i => i.SortOrder)
            .ToList();

        if (incoming.Count == 0)
        {
            return 0;
        }

        var existingAll = await _imageRepository.GetByProductIdAsync(productId);

        // Only this channel's images participate in the sync; manual uploads (no channel) and other
        // channels' images are never added to, reordered, or removed by this run.
        var existingForChannel = existingAll
            .Where(i => i.SalesChannelId == salesChannelId && !string.IsNullOrEmpty(i.RemoteImageId))
            .ToList();
        var existingByKey = existingForChannel
            .GroupBy(i => i.RemoteImageId!)
            .ToDictionary(g => g.Key, g => g.First());

        var incomingKeys = incoming.Select(RemoteKey).ToHashSet();

        var changed = false;

        // 1. Update alt text on images that still exist on the channel (cheap, no re-download).
        //    Persisted right away — an alt-only run has no add/remove/reindex to flush it otherwise.
        var metadataDirty = false;
        foreach (var incomingImage in incoming)
        {
            if (existingByKey.TryGetValue(RemoteKey(incomingImage), out var current))
            {
                var altText = string.IsNullOrWhiteSpace(incomingImage.AltText) ? null : incomingImage.AltText;
                if (current.AltText != altText)
                {
                    current.AltText = altText;
                    metadataDirty = true;
                    changed = true;
                }
            }
        }

        if (metadataDirty)
        {
            await _imageRepository.SaveChangesAsync(cancellationToken);
        }

        // 2. Remove this channel's images the shop no longer lists — DB row plus stored files.
        foreach (var removed in existingForChannel.Where(i => !incomingKeys.Contains(i.RemoteImageId!)))
        {
            await _imageRepository.DeleteAsync(removed);
            await _imageStorage.DeleteAsync(removed.RelativePath, removed.ThumbnailPath, cancellationToken);
            _logger.LogDebug("Removed image {RemoteImageId} from product {ProductId} (no longer on channel)",
                removed.RemoteImageId, productId);
        }

        // 3. Download + attach images new to this channel. New rows are appended after the current
        //    highest sort order so an existing (possibly manually reordered) gallery is preserved;
        //    a contiguous re-index at the end keeps the order gap-free.
        var toAdd = incoming.Where(i => !existingByKey.ContainsKey(RemoteKey(i))).ToList();
        var nextSortOrder = existingAll.Count == 0 ? 0 : existingAll.Max(i => i.SortOrder) + 1;

        var client = _httpClientFactory.CreateClient(HttpClientName);
        var imported = 0;

        foreach (var image in toAdd)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                using var response = await client.GetAsync(image.Url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Skipping image {Url} for product {ProductId}: HTTP {Status}",
                        image.Url, productId, (int)response.StatusCode);
                    continue;
                }

                StoredImage stored;
                await using (var stream = await response.Content.ReadAsStreamAsync(cancellationToken))
                {
                    stored = await _imageStorage.SaveAsync(stream, cancellationToken);
                }

                await _imageRepository.CreateAsync(new ProductImage
                {
                    ProductId = productId,
                    SalesChannelId = salesChannelId,
                    RemoteImageId = RemoteKey(image),
                    FileName = stored.FileName,
                    RelativePath = stored.RelativePath,
                    ThumbnailPath = stored.ThumbnailPath,
                    OriginalFileName = DeriveFileName(image.Url),
                    AltText = string.IsNullOrWhiteSpace(image.AltText) ? null : image.AltText,
                    Width = stored.Width,
                    Height = stored.Height,
                    FileSizeBytes = stored.FileSizeBytes,
                    SortOrder = nextSortOrder++,
                });
                imported++;
                changed = true;
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                // One unreachable/corrupt image must not abort the whole product import.
                _logger.LogWarning(ex, "Failed to import image {Url} for product {ProductId}", image.Url, productId);
            }
        }

        // 4. Re-normalize remaining images to a contiguous 0..n-1 order (closing gaps from removals),
        //    preserving the relative order. Mirrors the manual delete handler's re-index.
        await ReindexAsync(productId, cancellationToken);

        if (changed)
        {
            _logger.LogDebug("Synced images for product {ProductId} on channel {ChannelId}: +{Added} new",
                productId, salesChannelId, imported);
        }

        return imported;
    }

    private async Task ReindexAsync(Guid productId, CancellationToken cancellationToken)
    {
        var remaining = await _imageRepository.GetByProductIdAsync(productId);
        var reindexed = false;
        for (var i = 0; i < remaining.Count; i++)
        {
            if (remaining[i].SortOrder != i)
            {
                remaining[i].SortOrder = i;
                reindexed = true;
            }
        }

        if (reindexed)
        {
            await _imageRepository.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>Stable per-channel key: the remote image id, or the URL when the channel gives no id.</summary>
    private static string RemoteKey(SalesChannelImportImage image) =>
        string.IsNullOrWhiteSpace(image.RemoteImageId) ? image.Url : image.RemoteImageId;

    /// <summary>Last path segment of the URL (query stripped) for the download/alt fallback name.</summary>
    private static string? DeriveFileName(string url)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            var name = uri.Segments.LastOrDefault()?.Trim('/');
            return string.IsNullOrWhiteSpace(name) ? null : Uri.UnescapeDataString(name);
        }

        return null;
    }
}
