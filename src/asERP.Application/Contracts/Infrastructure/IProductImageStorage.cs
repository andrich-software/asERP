namespace asERP.Application.Contracts.Infrastructure;

/// <summary>
/// Result of persisting an uploaded image to the storage backend. All paths are
/// relative to the configured storage root so the root can move between environments.
/// </summary>
public record StoredImage(
    string FileName,        // "{guid}.png"
    string RelativePath,    // "products/ab/{guid}.png"
    string ThumbnailPath,   // "products/ab/{guid}_thumb.png"
    int Width,
    int Height,
    long FileSizeBytes);

/// <summary>
/// Filesystem-backed storage for product images. Every upload is re-encoded to PNG
/// and stored sharded by the first two hex characters of a freshly minted GUID, with
/// a resized thumbnail written beside the original.
/// </summary>
public interface IProductImageStorage
{
    /// <summary>
    /// Decodes the incoming image (any accepted format), re-encodes it to PNG, writes the
    /// original plus a thumbnail and returns their relative paths and metadata.
    /// </summary>
    Task<StoredImage> SaveAsync(Stream content, CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a stored file for reading. Returns null if the file does not exist.
    /// </summary>
    Task<Stream?> OpenReadAsync(string relativePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the original and (optional) thumbnail. Tolerant of already-missing files.
    /// </summary>
    Task DeleteAsync(string relativePath, string? thumbnailPath, CancellationToken cancellationToken = default);
}
