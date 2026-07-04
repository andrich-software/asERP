namespace asERP.Domain.Dtos.Product;

/// <summary>
/// Metadata for a single product image. The binary is fetched separately from the authed
/// content endpoint, so no file path or URL is exposed here.
/// </summary>
public class ProductImageDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int SortOrder { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public long FileSizeBytes { get; set; }
    public string? AltText { get; set; }
    public string? OriginalFileName { get; set; }

    /// <summary>True for the first image in the order (the product's primary image).</summary>
    public bool IsPrimary => SortOrder == 0;
}
