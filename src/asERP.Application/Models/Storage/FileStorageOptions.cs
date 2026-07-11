namespace asERP.Application.Models.Storage;

/// <summary>
/// Configuration for filesystem-backed file storage (product images, …).
/// Bound from the "FileStorage" configuration section in the Server.
/// </summary>
public class FileStorageOptions
{
    public const string Section = "FileStorage";

    /// <summary>
    /// Storage root. A relative path is resolved against the process working directory
    /// (the ASP.NET Core content root) at runtime.
    /// </summary>
    public string RootPath { get; set; } = "App_Data/files";

    /// <summary>Longest edge of a generated thumbnail, in pixels.</summary>
    public int ThumbnailSize { get; set; } = 300;

    /// <summary>
    /// On-disk format for stored originals and thumbnails: <c>webp</c> (default), <c>jpeg</c> or
    /// <c>png</c>. WebP/JPEG are lossy and dramatically smaller than PNG for photographic product
    /// images (the previous PNG-@-quality-100 default produced multi-MB files); PNG stays lossless.
    /// Existing files keep whatever format they were written with — this only affects new saves.
    /// </summary>
    public string StoredImageFormat { get; set; } = "webp";

    /// <summary>
    /// Encoder quality (1–100) for the lossy formats (<c>webp</c>/<c>jpeg</c>); ignored for
    /// <c>png</c>. 80 is a good size/quality trade-off for e-commerce product photos.
    /// </summary>
    public int ImageQuality { get; set; } = 80;

    /// <summary>
    /// Accepted upload content types. Uploads are re-encoded to <see cref="StoredImageFormat"/> on
    /// save, so this list only gates what callers may upload, not what is stored.
    /// </summary>
    public string[] AllowedContentTypes { get; set; } =
        ["image/jpeg", "image/png", "image/webp", "image/gif", "image/bmp"];
}
