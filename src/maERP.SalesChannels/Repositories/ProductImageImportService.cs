using maERP.Application.Contracts.Infrastructure;
using maERP.Application.Contracts.Persistence;
using maERP.Domain.Entities;
using maERP.SalesChannels.Contracts;
using maERP.SalesChannels.Models;
using Microsoft.Extensions.Logging;

namespace maERP.SalesChannels.Repositories;

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

    public async Task<int> ImportImagesAsync(Guid productId, IReadOnlyList<SalesChannelImportImage> images, CancellationToken cancellationToken)
    {
        if (images is null || images.Count == 0)
        {
            return 0;
        }

        // First-import-only: once a product carries images we never touch them again, so re-syncs are
        // idempotent and a shop-side photo set we cannot map back by id is not duplicated every run.
        // (Incrementally syncing a changed photo set would need a remote-id column on ProductImage.)
        var existing = await _imageRepository.GetByProductIdAsync(productId);
        if (existing.Count > 0)
        {
            return 0;
        }

        var ordered = images
            .Where(i => !string.IsNullOrWhiteSpace(i.Url))
            .OrderBy(i => i.SortOrder)
            .ToList();

        if (ordered.Count == 0)
        {
            return 0;
        }

        var client = _httpClientFactory.CreateClient(HttpClientName);
        var sortOrder = 0;
        var imported = 0;

        foreach (var image in ordered)
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
                    FileName = stored.FileName,
                    RelativePath = stored.RelativePath,
                    ThumbnailPath = stored.ThumbnailPath,
                    OriginalFileName = DeriveFileName(image.Url),
                    AltText = string.IsNullOrWhiteSpace(image.AltText) ? null : image.AltText,
                    Width = stored.Width,
                    Height = stored.Height,
                    FileSizeBytes = stored.FileSizeBytes,
                    // Re-number 0..n from the channel's order so the first image is the primary one,
                    // independent of any gaps/negative cover markers the channel mapping produced.
                    SortOrder = sortOrder++,
                });
                imported++;
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                // One unreachable/corrupt image must not abort the whole product import.
                _logger.LogWarning(ex, "Failed to import image {Url} for product {ProductId}", image.Url, productId);
            }
        }

        if (imported > 0)
        {
            _logger.LogDebug("Imported {Count} image(s) for product {ProductId}", imported, productId);
        }

        return imported;
    }

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
