using maERP.Domain.Dtos.Manufacturer;
using maERP.Domain.Enums;

namespace maERP.Domain.Dtos.Product;

public class ProductListDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Ean { get; set; }
    public decimal Price { get; set; }
    public decimal Msrp { get; set; }
    public double TaxRate { get; set; }
    public ProductType ProductType { get; set; }
    public int VariantCount { get; set; }
    public ManufacturerListDto? Manufacturer { get; set; }
}