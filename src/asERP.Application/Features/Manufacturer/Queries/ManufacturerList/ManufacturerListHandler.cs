using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Manufacturer.Queries.ManufacturerList;

public class ManufacturerListHandler : IRequestHandler<ManufacturerListQuery, PaginatedResult<ManufacturerListDto>>
{
    private readonly IAppLogger<ManufacturerListHandler> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerListHandler(
        IAppLogger<ManufacturerListHandler> logger,
        IManufacturerRepository manufacturerRepository)
    {
        _logger = logger;
        _manufacturerRepository = manufacturerRepository;
    }

    public async Task<PaginatedResult<ManufacturerListDto>> Handle(ManufacturerListQuery request, CancellationToken cancellationToken)
    {
        var manufacturerFilterSpec = new ManufacturerFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle ManufacturerListQuery: {0}", request);

        if (request.SalesBy.Any() != true)
        {
            return await _manufacturerRepository.Entities
               .Specify(manufacturerFilterSpec)
               .Select(m => new ManufacturerListDto
               {
                   Id = m.Id,
                   Name = m.Name,
                   City = m.City,
                   Country = m.Country
               })
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }

        var salesing = string.Join(",", request.SalesBy);

        return await _manufacturerRepository.Entities
            .Specify(manufacturerFilterSpec)
            .OrderBy(salesing)
            .Select(m => new ManufacturerListDto
            {
                Id = m.Id,
                Name = m.Name,
                City = m.City,
                Country = m.Country
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}