using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Queries.ProductAttributeList;

public class ProductAttributeListHandler : IRequestHandler<ProductAttributeListQuery, PaginatedResult<ProductAttributeListDto>>
{
    // Restrict client-supplied ordering to columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.ProductAttribute.Id),
        nameof(Domain.Entities.ProductAttribute.Name),
        nameof(Domain.Entities.ProductAttribute.SortOrder)
    };

    private readonly IAppLogger<ProductAttributeListHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeListHandler(
        IAppLogger<ProductAttributeListHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger;
        _productAttributeRepository = productAttributeRepository;
    }

    public async Task<PaginatedResult<ProductAttributeListDto>> Handle(ProductAttributeListQuery request, CancellationToken cancellationToken)
    {
        var filterSpec = new ProductAttributeFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle ProductAttributeListQuery: {0}", request);

        var query = _productAttributeRepository.Entities.Specify(filterSpec);

        if (request.SalesBy.Any())
        {
            query = query.ApplySafeOrdering(request.SalesBy, AllowedSortFields);
        }
        else
        {
            query = query.OrderBy(a => a.SortOrder).ThenBy(a => a.Name);
        }

        return await query
            .Select(a => new ProductAttributeListDto
            {
                Id = a.Id,
                Name = a.Name,
                SortOrder = a.SortOrder,
                ValueCount = a.Values.Count
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
