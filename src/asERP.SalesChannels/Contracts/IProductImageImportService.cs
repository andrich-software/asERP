using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

/// <summary>
/// Downloads the product photos a connector collected from a channel and attaches them to the
/// imported product. Kept channel-agnostic: connectors only fill <see cref="SalesChannelImportImage"/>s,
/// the actual HTTP download + storage happens here so every channel behaves identically.
/// </summary>
public interface IProductImageImportService
{
    /// <summary>
    /// Incrementally syncs a channel's photo set onto a product: downloads images new to this channel,
    /// removes ones the channel no longer lists (files included), and leaves manually uploaded and
    /// other-channel images untouched. Idempotent — an unchanged set is a no-op. Resilient — a single
    /// broken image URL is logged and skipped, never failing the product import. As a safety guard an
    /// empty incoming set makes no changes, so a transient load failure never wipes existing photos.
    /// </summary>
    /// <returns>Number of images newly stored.</returns>
    Task<int> ImportImagesAsync(Guid productId, Guid salesChannelId, IReadOnlyList<SalesChannelImportImage> images, CancellationToken cancellationToken);
}
