using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

public class Product : BaseEntity, IBaseEntity
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? NameOptimized { get; set; }
    public string? Ean { get; set; }
    public string? Asin { get; set; }
    public string? Gtin { get; set; }
    public string? Mpn { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }
    public string? DescriptionOptimized { get; set; }

    public bool UseOptimized { get; set; }
    public decimal Price { get; set; }
    public decimal Msrp { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }

    public Guid TaxClassId { get; set; }
    public Guid? ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public TaxClass? TaxClass { get; set; }

    public ProductType ProductType { get; set; } = ProductType.Standard;
    public Guid? ParentProductId { get; set; }
    public Product? ParentProduct { get; set; }
    public int VariantSortOrder { get; set; }

    public ICollection<Product> Variants { get; set; } = [];
    public ICollection<ProductVariantAxis> VariantAxes { get; set; } = [];
    public ICollection<ProductVariantOption> VariantOptions { get; set; } = [];

    public ICollection<ProductSalesChannel>? ProductSalesChannels { get; set; } = [];

    public ICollection<ProductStock> ProductStocks { get; set; } = [];

    public ICollection<ProductImage> Images { get; set; } = [];
}