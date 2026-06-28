using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Manufacturer.Queries.ManufacturerList;

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