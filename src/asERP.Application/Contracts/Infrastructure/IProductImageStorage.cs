namespace asERP.Application.Contracts.Infrastructure;

/// <summary>
/// Result of persisting an uploaded image to the storage backend. All paths are
/// relative to the configured storage root so the root can move between environments.
/// </summary>
public record StoredImage(
    string FileName,        // "{guid}.{ext}"
    string RelativePath,    // "products/ab/{guid}.{ext}"
    string ThumbnailPath,   // "products/ab/{guid}_thumb.{ext}"
    int Width,
    int Height,
    long FileSizeBytes);

/// <summary>
/// Filesystem-backed storage for product images. Every upload is re-encoded to the configured
/// storage format (WebP by default) and stored sharded by the first two hex characters of a
/// freshly minted GUID, with a resized thumbnail written beside the original.
/// </summary>
public interface IProductImageStorage
{
    /// <summary>
    /// Decodes the incoming image (any accepted format), re-encodes it to the configured storage
    /// format, writes the original plus a thumbnail and returns their relative paths and metadata.
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

    /// <summary>
    /// Re-encodes a single already-stored file into the currently configured storage format,
    /// writing a new file (same GUID, new extension). The original is intentionally left in place —
    /// the caller deletes it (via <see cref="DeleteAsync"/>) only after persisting the new path, so a
    /// crash mid-migration never leaves a DB row pointing at a deleted file. Returns the new
    /// path/metadata, or <c>null</c> when there is nothing to do — the file is missing, already in
    /// the target format, or undecodable.
    /// </summary>
    Task<ReencodedFile?> ReencodeAsync(string relativePath, CancellationToken cancellationToken = default);
}

/// <summary>Result of re-encoding one stored file to the configured format (see <see cref="IProductImageStorage.ReencodeAsync"/>).</summary>
public record ReencodedFile(string RelativePath, string FileName, long FileSizeBytes, int Width, int Height);
