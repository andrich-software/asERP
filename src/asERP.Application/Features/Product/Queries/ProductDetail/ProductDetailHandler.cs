using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Features.ProductImage.Shared;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Product.Queries.ProductDetail;

/// <summary>
/// Handler for processing product detail queries.
/// Implements IRequestHandler from the custom mediator to handle ProductDetailQuery requests
/// and return detailed product information wrapped in a Result.
/// </summary>
public class ProductDetailHandler : IRequestHandler<ProductDetailQuery, Result<ProductDetailDto>>
{
    private readonly IAppLogger<ProductDetailHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public ProductDetailHandler(
        IAppLogger<ProductDetailHandler> logger,
        IProductRepository productRepository,
        IWarehouseRepository warehouseRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<Result<ProductDetailDto>> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving product details for ID: {Id}", request.Id);

        // Retrieve product with all related details from the repository
        var product = await _productRepository.GetWithDetailsAsync(request.Id);

        // If product not found, return a not found result
        if (product == null)
        {
            _logger.LogWarning("Product with ID {Id} not found", request.Id);
            return Result<ProductDetailDto>.NotFound(ErrorCodes.Product.NotFound,
                $"Product with ID {request.Id} not found");
        }

        // Manual mapping instead of using AutoMapper
        var data = new ProductDetailDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Name = product.Name,
            NameOptimized = product.NameOptimized,
            Ean = product.Ean,
            Asin = product.Asin,
            Description = product.Description,
            DescriptionOptimized = product.DescriptionOptimized,
            UseOptimized = product.UseOptimized,
            Price = product.Price,
            Msrp = product.Msrp,
            Weight = product.Weight,
            Width = product.Width,
            Height = product.Height,
            Depth = product.Depth,
            TaxClassId = product.TaxClassId,
            Manufacturer = product.Manufacturer != null ? new ManufacturerDetailDto
            {
                Id = product.Manufacturer.Id,
                Name = product.Manufacturer.Name,
                Street = product.Manufacturer.Street,
                City = product.Manufacturer.City,
                State = product.Manufacturer.State,
                Country = product.Manufacturer.Country,
                ZipCode = product.Manufacturer.ZipCode,
                Phone = product.Manufacturer.Phone,
                Email = product.Manufacturer.Email,
                Website = product.Manufacturer.Website,
                Logo = product.Manufacturer.Logo
            } : null,
            ProductType = product.ProductType,
            ParentProductId = product.ParentProductId,
            VariantSortOrder = product.VariantSortOrder,
            VariantAxes = product.VariantAxes
                .OrderBy(a => a.SortOrder)
                .Select(a => new ProductVariantAxisDto
                {
                    ProductAttributeId = a.ProductAttributeId,
                    AttributeName = a.ProductAttribute?.Name ?? string.Empty,
                    SortOrder = a.SortOrder,
                    AvailableValues = (a.ProductAttribute?.Values ?? [])
                        .OrderBy(v => v.SortOrder).ThenBy(v => v.Value)
                        .Select(v => new Domain.Dtos.ProductAttribute.ProductAttributeValueDto
                        {
                            Id = v.Id,
                            Value = v.Value,
                            SortOrder = v.SortOrder
                        }).ToList()
                }).ToList(),
            Variants = product.Variants
                .OrderBy(v => v.VariantSortOrder).ThenBy(v => v.Sku)
                .Select(v => new ProductVariantListDto
                {
                    Id = v.Id,
                    Sku = v.Sku,
                    Name = v.Name,
                    Ean = v.Ean,
                    Price = v.Price,
                    VariantSortOrder = v.VariantSortOrder,
                    Options = MapOptions(v.VariantOptions)
                }).ToList(),
            Options = MapOptions(product.VariantOptions),
            // Map related sales channels and stocks
            ProductSalesChannel = product.ProductSalesChannels?.Select(psc => psc.Id).ToList() ?? new List<Guid>(),
            ProductStocks = product.ProductStocks.Select(ps => ps.Id).ToList(),
            Images = product.Images
                .OrderBy(i => i.SortOrder)
                .Select(ProductImageMapping.ToDto)
                .ToList()
        };

        data.CategoryIds = (await _productRepository.GetCategoryLinksAsync(product.Id))
            .Select(l => l.CategoryId)
            .ToList();

        data.Stocks = await BuildStocksAsync(product, cancellationToken);

        _logger.LogInformation("Product with ID {Id} retrieved successfully", request.Id);

        return Result<ProductDetailDto>.Success(data);
    }

    /// <summary>
    /// Lists every warehouse of the current tenant with the product's stock in it.
    /// Warehouses the product has no stock row for are reported with zero stock.
    /// </summary>
    private async Task<List<ProductStockDto>> BuildStocksAsync(
        Domain.Entities.Product product,
        CancellationToken cancellationToken)
    {
        var warehouses = await _warehouseRepository.Entities
            .AsNoTracking()
            .OrderBy(w => w.Name)
            .Select(w => new { w.Id, w.Name })
            .ToListAsync(cancellationToken);

        var stocksByWarehouse = product.ProductStocks
            .GroupBy(ps => ps.WarehouseId)
            .ToDictionary(g => g.Key, g => g.First());

        return warehouses
            .Select(w =>
            {
                stocksByWarehouse.TryGetValue(w.Id, out var stock);

                return new ProductStockDto
                {
                    WarehouseId = w.Id,
                    WarehouseName = w.Name,
                    Stock = stock?.Stock ?? 0,
                    StockMin = stock?.StockMin ?? 0,
                    StockMax = stock?.StockMax ?? 0
                };
            })
            .ToList();
    }

    private static List<ProductVariantOptionDto> MapOptions(IEnumerable<Domain.Entities.ProductVariantOption> options)
    {
        return options
            .Select(o => new ProductVariantOptionDto
            {
                ProductAttributeId = o.ProductAttributeValue?.ProductAttributeId ?? Guid.Empty,
                AttributeName = o.ProductAttributeValue?.ProductAttribute?.Name ?? string.Empty,
                ProductAttributeValueId = o.ProductAttributeValueId,
                Value = o.ProductAttributeValue?.Value ?? string.Empty
            })
            .OrderBy(o => o.AttributeName)
            .ToList();
    }
}
