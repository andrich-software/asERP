using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Mediator;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Product.Queries.ProductList;

public class ProductListHandler : IRequestHandler<ProductListQuery, PaginatedResult<ProductListDto>>
{
    private readonly IAppLogger<ProductListHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ProductListHandler(
        IAppLogger<ProductListHandler> logger,
        IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<PaginatedResult<ProductListDto>> Handle(ProductListQuery request, CancellationToken cancellationToken)
    {
        var salesFilterSpec = new ProductFilterSpecification(request.SearchString, request.IncludeVariants);

        _logger.LogInformation("Handle ProductListQuery: {0}", request);

        if (request.SalesBy.Any() != true)
        {
            var products = await _productRepository.Entities
               .Include(p => p.Manufacturer)
               .Include(p => p.TaxClass)
               .Include(p => p.Variants)
               .Specify(salesFilterSpec)
               .Select(p => MapToProductListDto(p))
               .AsNoTracking() // Ensure no EF caching
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return products;
        }

        var salesing = string.Join(",", request.SalesBy);

        var salesedProducts = await _productRepository.Entities
            .Include(p => p.Manufacturer)
            .Include(p => p.TaxClass)
            .Include(p => p.Variants)
            .Specify(salesFilterSpec)
            .OrderBy(salesing)
            .Select(p => MapToProductListDto(p))
            .AsNoTracking() // Ensure no EF caching
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);

        return salesedProducts;
    }

    private static ProductListDto MapToProductListDto(Domain.Entities.Product product)
    {
        return new ProductListDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Name = product.Name,
            Description = product.Description,
            Ean = product.Ean,
            Price = product.Price,
            Msrp = product.Msrp,
            TaxRate = product.TaxClass?.TaxRate ?? 0,
            ProductType = product.ProductType,
            VariantCount = product.Variants.Count,
            PrimaryImageId = product.Images
                .OrderBy(i => i.SortOrder)
                .Select(i => (Guid?)i.Id)
                .FirstOrDefault(),
            Manufacturer = product.Manufacturer != null ? new ManufacturerListDto
            {
                Id = product.Manufacturer.Id,
                Name = product.Manufacturer.Name,
                City = product.Manufacturer.City,
                Country = product.Manufacturer.Country
            } : null
        };
    }
}
