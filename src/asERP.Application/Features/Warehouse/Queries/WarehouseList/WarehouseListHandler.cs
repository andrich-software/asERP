using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Warehouse.Queries.WarehouseList;

// ReSharper disable once UnusedType.Global
public class WarehouseListHandler : IRequestHandler<WarehouseListQuery, PaginatedResult<WarehouseListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Warehouse.Id),
        nameof(Domain.Entities.Warehouse.Name)
    };

    private readonly IAppLogger<WarehouseListHandler> _logger;
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseListHandler(
        IAppLogger<WarehouseListHandler> logger,
        IWarehouseRepository warehouseRepository)
    {
        _logger = logger;
        _warehouseRepository = warehouseRepository;
    }
    public async Task<PaginatedResult<WarehouseListDto>> Handle(WarehouseListQuery request, CancellationToken cancellationToken)
    {
        var warehouseFilterSpec = new WarehouseFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle WarehouseListQuery: {0}", request);

        return await _warehouseRepository.Entities
            .AsNoTracking()
            .Specify(warehouseFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(w => new WarehouseListDto
            {
                Id = w.Id,
                Name = w.Name
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
