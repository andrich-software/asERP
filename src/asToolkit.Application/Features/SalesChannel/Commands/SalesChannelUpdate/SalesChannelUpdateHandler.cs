using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Exceptions;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.SalesChannel.Commands.SalesChannelUpdate;

public class SalesChannelUpdateHandler : IRequestHandler<SalesChannelUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesChannelUpdateHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public SalesChannelUpdateHandler(
        IAppLogger<SalesChannelUpdateHandler> logger,
        ISalesChannelRepository salesChannelRepository,
        IWarehouseRepository warehouseRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<Result<Guid>> Handle(SalesChannelUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating sales channel with ID: {Id} and name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SalesChannelUpdateValidator(_salesChannelRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(SalesChannelUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Get existing sales channel with warehouses
            Domain.Entities.SalesChannel existingSalesChannel;
            try
            {
                existingSalesChannel = await _salesChannelRepository.GetDetails(request.Id);
            }
            catch (NotFoundException)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Sales channel with ID {request.Id} not found");
                return result;
            }

            // Update properties from request
            existingSalesChannel.Type = request.SalesChannelType;
            existingSalesChannel.Name = request.Name;
            existingSalesChannel.Url = request.Url;
            existingSalesChannel.Username = request.Username;
            // The password/secret is write-only: it is never returned to the client, so the edit
            // form submits it empty unless the user deliberately enters a new value. Treat an empty
            // password as "keep the stored secret" instead of wiping it.
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                existingSalesChannel.Password = request.Password;
            }
            // Null means "keep the stored connector config" (older clients don't send the field);
            // an empty string deliberately clears it.
            if (request.AdditionalConfigJson is not null)
            {
                existingSalesChannel.AdditionalConfigJson =
                    string.IsNullOrWhiteSpace(request.AdditionalConfigJson) ? null : request.AdditionalConfigJson;
            }
            existingSalesChannel.ImportProducts = request.ImportProducts;
            existingSalesChannel.ImportCustomers = request.ImportCustomers;
            existingSalesChannel.ImportSaless = request.ImportSaless;
            existingSalesChannel.ExportProducts = request.ExportProducts;
            existingSalesChannel.ExportCustomers = request.ExportCustomers;
            existingSalesChannel.ExportSaless = request.ExportSaless;
            existingSalesChannel.ExportStock = request.ExportStock;
            existingSalesChannel.ImportStock = request.ImportStock;

            // Update warehouse relationships
            var warehouses = new List<Domain.Entities.Warehouse>();
            if (request.WarehouseIds != null && request.WarehouseIds.Any())
            {
                var invalidWarehouseIds = new List<Guid>();

                foreach (var warehouseId in request.WarehouseIds)
                {
                    var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
                    if (warehouse != null)
                    {
                        warehouses.Add(warehouse);
                    }
                    else
                    {
                        invalidWarehouseIds.Add(warehouseId);
                    }
                }

                // Return error if any warehouse IDs are invalid
                if (invalidWarehouseIds.Any())
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"The following warehouse IDs do not exist: {string.Join(", ", invalidWarehouseIds)}");
                    return result;
                }
            }
            existingSalesChannel.Warehouses = warehouses;

            // Update in database
            await _salesChannelRepository.UpdateAsync(existingSalesChannel);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = existingSalesChannel.Id;

            _logger.LogInformation("Successfully updated sales channel with ID: {Id}", existingSalesChannel.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while updating the sales channel: {ex.Message}");

            _logger.LogError("Error updating sales channel: {Message}", ex.Message);
        }

        return result;
    }
}
