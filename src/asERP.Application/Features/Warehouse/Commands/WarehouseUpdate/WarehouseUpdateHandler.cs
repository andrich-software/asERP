using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseUpdate;

public class WarehouseUpdateHandler : IRequestHandler<WarehouseUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<WarehouseUpdateHandler> _logger;
    private readonly IWarehouseRepository _warehouseRepository;


    public WarehouseUpdateHandler(
        IAppLogger<WarehouseUpdateHandler> logger,
        IWarehouseRepository warehouseRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<Result<Guid>> Handle(WarehouseUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating warehouse with ID: {Id}, Name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Load the tracked entity and mutate it, so the persistence layer keeps
        // TenantId/DateCreated intact instead of nulling them on a detached update.
        var warehouseToUpdate = await _warehouseRepository.GetByIdAsync(request.Id);
        if (warehouseToUpdate == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Warehouse.NotFound, "Warehouse not found.");
            _logger.LogWarning("Warehouse with ID {Id} not found for update", request.Id);
            return result;
        }

        warehouseToUpdate.Name = request.Name;

        // Save changes (entity is already tracked, so just save)
        await _warehouseRepository.SaveChangesAsync();

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = warehouseToUpdate.Id;

        _logger.LogInformation("Successfully updated warehouse with ID: {Id}", warehouseToUpdate.Id);

        return result;
    }
}
