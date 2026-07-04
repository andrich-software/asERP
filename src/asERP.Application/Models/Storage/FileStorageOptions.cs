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
    /// Accepted upload content types. Everything is re-encoded to PNG on save, so this
    /// list only gates what callers may upload, not what is stored.
    /// </summary>
    public string[] AllowedContentTypes { get; set; } =
        ["image/jpeg", "image/png", "image/webp", "image/gif", "image/bmp"];
}
