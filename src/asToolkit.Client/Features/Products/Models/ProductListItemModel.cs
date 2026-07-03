using asToolkit.Client.Core.Media;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Enums;

namespace asToolkit.Client.Features.Products.Models;

/// <summary>
/// List-row wrapper around <see cref="ProductListDto"/>. It re-exposes the DTO's display
/// fields under the same names so the existing row bindings (Sku, Name, …) keep working
/// unchanged, and exposes a <see cref="ThumbnailRequest"/> consumed lazily per realized
/// row by <see cref="ThumbnailLoader"/>.
/// </summary>
public class ProductListItemModel
{
    public ProductListItemModel(ProductListDto dto)
    {
        Dto = dto;
        ThumbnailRequest = dto.PrimaryImageId.HasValue
            ? new ThumbnailRequest(dto.Id, dto.PrimaryImageId.Value)
            : null;
    }

    public ProductListDto Dto { get; }

    public Guid Id => Dto.Id;
    public string Sku => Dto.Sku;
    public string Name => Dto.Name;
    public ProductType ProductType => Dto.ProductType;
    public int VariantCount => Dto.VariantCount;
    public ManufacturerListDto? Manufacturer => Dto.Manufacturer;
    public decimal Price => Dto.Price;
    public decimal Msrp => Dto.Msrp;
    public Guid? PrimaryImageId => Dto.PrimaryImageId;

    /// <summary>Lazy-load handle for the primary image thumbnail; null when the product has no image.</summary>
    public ThumbnailRequest? ThumbnailRequest { get; }
}
