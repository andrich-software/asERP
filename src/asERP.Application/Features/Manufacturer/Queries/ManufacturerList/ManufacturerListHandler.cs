using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Queries.ManufacturerList;

public class ManufacturerListHandler : IRequestHandler<ManufacturerListQuery, PaginatedResult<ManufacturerListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Manufacturer.Id),
        nameof(Domain.Entities.Manufacturer.Name),
        nameof(Domain.Entities.Manufacturer.City),
        nameof(Domain.Entities.Manufacturer.Country)
    };

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

        return await _manufacturerRepository.Entities
            .Specify(manufacturerFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
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
