namespace asERP.Client.Core.Media;

/// <summary>
/// Bounded in-memory cache in front of the product image endpoint so scrolling back
/// through a virtualized list does not re-download thumbnails.
/// </summary>
public interface IThumbnailCache
{
    /// <summary>Returns the thumbnail bytes from cache or loads (and caches) them.</summary>
    ValueTask<byte[]?> GetOrLoadAsync(ThumbnailRequest request, CancellationToken ct = default);
}
