using System.ComponentModel.DataAnnotations;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.Product;

public class ProductInputDto : IProductInputModel
{
    public Guid Id { get; set; }

    [StringLength(255)]
    public string Sku { get; set; } = string.Empty;

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

    public decimal Price { get; set; }

    public decimal Msrp { get; set; }

    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }

    public Guid TaxClassId { get; set; } = new();

    public Guid? ManufacturerId { get; set; }

    public ProductType ProductType { get; set; } = ProductType.Standard;

    public Guid? ParentProductId { get; set; }

    public int VariantSortOrder { get; set; }

    /// <summary>For variant parents: attribute ids the product varies by.</summary>
    public List<Guid> VariantAxisAttributeIds { get; set; } = new();

    /// <summary>For variants: one attribute value id per parent axis.</summary>
    public List<Guid> VariantOptionValueIds { get; set; } = new();

    public List<Guid> ProductSalesChannel { get; set; } = new();
}