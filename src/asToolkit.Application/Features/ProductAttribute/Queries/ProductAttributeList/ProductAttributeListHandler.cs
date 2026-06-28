using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Queries.ProductAttributeList;

public class ProductAttributeListHandler : IRequestHandler<ProductAttributeListQuery, PaginatedResult<ProductAttributeListDto>>
{
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
            var salesing = string.Join(",", request.SalesBy);
            query = query.OrderBy(salesing);
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
