using asERP.Domain.Dtos.Product;

namespace asERP.Application.Features.ProductImage.Shared;

/// <summary>Manual mapping from the ProductImage entity to its DTO (no AutoMapper, per project rule).</summary>
public static class ProductImageMapping
{
    public static ProductImageDto ToDto(Domain.Entities.ProductImage image) => new()
    {
        Id = image.Id,
        ProductId = image.ProductId,
        SortOrder = image.SortOrder,
        Width = image.Width,
        Height = image.Height,
        FileSizeBytes = image.FileSizeBytes,
        AltText = image.AltText,
        OriginalFileName = image.OriginalFileName
    };
}
