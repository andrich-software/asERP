using maERP.SalesChannels.Models;

namespace maERP.SalesChannels.Contracts;

/// <summary>
/// Downloads the product photos a connector collected from a channel and attaches them to the
/// imported product. Kept channel-agnostic: connectors only fill <see cref="SalesChannelImportImage"/>s,
/// the actual HTTP download + storage happens here so every channel behaves identically.
/// </summary>
public interface IProductImageImportService
{
    /// <summary>
    /// Imports the given images for a product. Idempotent: products that already have images are
    /// left untouched (first-import-only), so a re-sync never re-downloads or duplicates photos.
    /// Resilient: a single broken image URL is logged and skipped, never failing the product import.
    /// </summary>
    /// <returns>Number of images newly stored.</returns>
    Task<int> ImportImagesAsync(Guid productId, IReadOnlyList<SalesChannelImportImage> images, CancellationToken cancellationToken);
}
