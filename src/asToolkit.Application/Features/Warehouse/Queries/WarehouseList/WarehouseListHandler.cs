using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Warehouse.Queries.WarehouseList;

// ReSharper disable once UnusedType.Global
public class WarehouseListHandler : IRequestHandler<WarehouseListQuery, PaginatedResult<WarehouseListDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await _warehouseRepository.Entities
               .AsNoTracking()
               .Specify(warehouseFilterSpec)
               .Select(w => new WarehouseListDto
               {
                   Id = w.Id,
                   Name = w.Name
               })
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }

        var salesing = string.Join(",", request.SalesBy);

        return await _warehouseRepository.Entities
            .AsNoTracking()
            .Specify(warehouseFilterSpec)
            .OrderBy(salesing)
            .Select(w => new WarehouseListDto
            {
                Id = w.Id,
                Name = w.Name
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}