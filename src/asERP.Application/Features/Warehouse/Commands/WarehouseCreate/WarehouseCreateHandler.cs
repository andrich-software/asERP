using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseCreate;

/// <summary>
/// Handler for processing warehouse creation commands.
/// Implements IRequestHandler from the custom mediator to handle WarehouseCreateCommand requests
/// and return the ID of the newly created warehouse wrapped in a Result.
/// </summary>
public class WarehouseCreateHandler : IRequestHandler<WarehouseCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<WarehouseCreateHandler> _logger;
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseCreateHandler(
        IAppLogger<WarehouseCreateHandler> logger,
        IWarehouseRepository warehouseRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<Result<Guid>> Handle(WarehouseCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new warehouse with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Manual mapping to domain entity
        var warehouseToCreate = new Domain.Entities.Warehouse
        {
            Name = request.Name
        };

        // Add the new warehouse to the database
        await _warehouseRepository.CreateAsync(warehouseToCreate);

        // Set successful result with the new warehouse ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = warehouseToCreate.Id;

        _logger.LogInformation("Successfully created warehouse with ID: {Id}", warehouseToCreate.Id);

        return result;
    }
}
