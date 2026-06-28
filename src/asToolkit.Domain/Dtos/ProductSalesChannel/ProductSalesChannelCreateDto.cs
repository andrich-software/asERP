using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.ProductSalesChannel;

public class ProductSalesChannelCreateDto : IProductSalesChannelInputModel
{
    public Guid ProductId { get; set; }
    public Guid SalesChannelId { get; set; }

    public string? RemoteProductId { get; set; }

    public decimal Price { get; set; }

    public bool ProductImport { get; set; }

    public bool ProductExport { get; set; }
}