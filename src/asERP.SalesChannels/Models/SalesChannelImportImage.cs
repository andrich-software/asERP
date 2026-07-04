namespace asERP.SalesChannels.Models;

/// <summary>
/// A product photo referenced on the sales channel. The import downloads the file from
/// <see cref="Url"/>, re-encodes it to PNG via the image storage and attaches it to the product.
/// </summary>
public class SalesChannelImportImage
{
    /// <summary>Channel-side image/media id (Woo image id, Sw6 media id). Stable across re-imports.</summary>
    public string RemoteImageId { get; set; } = string.Empty;

    /// <summary>Public URL of the original image to download.</summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>Optional alt text carried over from the channel.</summary>
    public string? AltText { get; set; }

    /// <summary>Channel-provided display order; the lowest becomes the product's primary image.</summary>
    public int SortOrder { get; set; }
}
