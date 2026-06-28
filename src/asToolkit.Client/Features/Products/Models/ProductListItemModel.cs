using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Enums;

namespace asToolkit.Client.Features.Products.Models;

/// <summary>
/// List-row wrapper around <see cref="ProductListDto"/> that adds the primary image's
/// thumbnail bytes. It re-exposes the DTO's display fields under the same names so the
/// existing row bindings (Sku, Name, …) keep working unchanged.
/// </summary>
public class ProductListItemModel
{
    public ProductListItemModel(ProductListDto dto)
    {
        Dto = dto;
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

    /// <summary>Thumbnail bytes of the primary image, materialized in XAML by BytesToImageSourceConverter.</summary>
    public byte[]? ThumbnailBytes { get; set; }
}
