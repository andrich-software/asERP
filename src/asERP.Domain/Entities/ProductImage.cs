using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// An image attached to a product. Files live on the filesystem (filename = GUID, stored in the
/// configured FileStorage format — WebP by default, historically PNG); only metadata is persisted
/// here. The image with the lowest <see cref="SortOrder"/> is the product's primary image.
/// </summary>
public class ProductImage : BaseEntity, IBaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    /// <summary>On-disk original file name, "{guid}.{ext}".</summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>Path of the original, relative to the storage root: "products/ab/{guid}.{ext}".</summary>
    public string RelativePath { get; set; } = string.Empty;

    /// <summary>Path of the thumbnail, relative to the storage root: "products/ab/{guid}_thumb.{ext}".</summary>
    public string ThumbnailPath { get; set; } = string.Empty;

    /// <summary>Original file name as uploaded, kept for download/alt fallback.</summary>
    public string? OriginalFileName { get; set; }

    /// <summary>
    /// Sales channel this image was imported from, or null for a manual upload. Together with
    /// <see cref="RemoteImageId"/> it lets the importer sync a channel's photo set incrementally
    /// (add new, drop removed) without ever touching manually uploaded or other-channel images.
    /// </summary>
    public Guid? SalesChannelId { get; set; }

    /// <summary>
    /// Stable channel-side key of the source photo (the media/image id, or its URL as a fallback).
    /// Null for manual uploads. Scoped by <see cref="SalesChannelId"/>.
    /// </summary>
    public string? RemoteImageId { get; set; }

    public string? AltText { get; set; }

    public long FileSizeBytes { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    /// <summary>0-based display order; the lowest value is the primary image.</summary>
    public int SortOrder { get; set; }
}
