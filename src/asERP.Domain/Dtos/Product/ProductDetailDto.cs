using System.ComponentModel.DataAnnotations;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Product;

public class ProductDetailDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Sku { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [StringLength(255)]
    public string? NameOptimized { get; set; }

    [StringLength(32)]
    public string? Ean { get; set; }

    [StringLength(32)]
    public string? Asin { get; set; }

    [StringLength(64000)]
    public string? Description { get; set; }

    [StringLength(64000)]
    public string? DescriptionOptimized { get; set; }

    public bool UseOptimized { get; set; }

    [Required]
    public decimal Price { get; set; }

    public decimal Msrp { get; set; }

    public decimal Weight { get; set; }

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    public decimal Depth { get; set; }

    public Guid TaxClassId { get; set; } = new();

    public ManufacturerDetailDto? Manufacturer { get; set; }

    public ProductType ProductType { get; set; }

    public Guid? ParentProductId { get; set; }

    public int VariantSortOrder { get; set; }

    /// <summary>Axes the product varies by; only filled for variant parents.</summary>
    public List<ProductVariantAxisDto> VariantAxes { get; set; } = new();

    /// <summary>Child variants; only filled for variant parents.</summary>
    public List<ProductVariantListDto> Variants { get; set; } = new();

    /// <summary>Own attribute values; only filled when the product itself is a variant.</summary>
    public List<ProductVariantOptionDto> Options { get; set; } = new();

    public List<Guid> ProductSalesChannel { get; set; } = new();

    public List<Guid> ProductStocks { get; set; } = new();

    /// <summary>Images attached to the product, ordered by SortOrder (first = primary).</summary>
    public List<ProductImageDto> Images { get; set; } = new();
}