using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
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

        // Validate incoming data
        var validator = new WarehouseUpdateValidator(_warehouseRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(WarehouseUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Load the tracked entity and mutate it, so the persistence layer keeps
            // TenantId/DateCreated intact instead of nulling them on a detached update.
            var warehouseToUpdate = await _warehouseRepository.GetByIdAsync(request.Id);
            if (warehouseToUpdate == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add("Warehouse not found.");
                _logger.LogWarning("Warehouse with ID {Id} not found for update", request.Id);
                return result;
            }

            warehouseToUpdate.Name = request.Name;

            // Save changes (entity is already tracked, so just save)
            await _warehouseRepository.SaveChangesAsync();

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = warehouseToUpdate.Id;

            _logger.LogInformation("Successfully updated warehouse with ID: {Id}", warehouseToUpdate.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the warehouse.",
                "Error updating warehouse.");
        }

        return result;
    }
}
