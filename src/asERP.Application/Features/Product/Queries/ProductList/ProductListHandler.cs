using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Features.Product.Shared;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Product.Queries.ProductList;

public class ProductListHandler : IRequestHandler<ProductListQuery, PaginatedResult<ProductListDto>>
{
    // Ordering runs on the Product entity (before Select). Only DTO columns backed by a direct entity
    // property are sortable; navigation/computed columns (TaxRate, VariantCount, Manufacturer, PrimaryImageId)
    // are omitted.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Product.Id),
        nameof(Domain.Entities.Product.Sku),
        nameof(Domain.Entities.Product.Name),
        nameof(Domain.Entities.Product.Description),
        nameof(Domain.Entities.Product.Ean),
        nameof(Domain.Entities.Product.Price),
        nameof(Domain.Entities.Product.Msrp),
        nameof(Domain.Entities.Product.ProductType)
    };

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

        var query = _productRepository.Entities
            .Include(p => p.Manufacturer)
            .Include(p => p.TaxClass)
            .Include(p => p.Variants)
            // MapToProductListDto is a method call, so EF evaluates the projection on the client
            // against the materialized entity: every navigation it reads has to be included here or
            // it silently maps to null/empty — which is why PrimaryImageId was always null.
            // Only the primary image is needed, so the filtered include pulls a single row.
            .Include(p => p.Images.OrderBy(i => i.SortOrder).Take(1))
            .Specify(salesFilterSpec);

        if (request.LowStockOnly)
        {
            query = query.Where(ProductStockFilters.LowStock);
        }

        return await query
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .AsSingleQuery() // Projection reads two collections (Variants, Images); keep one query and silence the multi-collection warning
            .Select(p => MapToProductListDto(p))
            .AsNoTracking() // Ensure no EF caching
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
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
