using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Manufacturer.Queries.ManufacturerDetail;

public class ManufacturerDetailHandler : IRequestHandler<ManufacturerDetailQuery, Result<ManufacturerDetailDto>>
{
    private readonly IAppLogger<ManufacturerDetailHandler> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerDetailHandler(
        IAppLogger<ManufacturerDetailHandler> logger,
        IManufacturerRepository manufacturerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
    }

    public async Task<Result<ManufacturerDetailDto>> Handle(ManufacturerDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving manufacturer details for ID: {Id}", request.Id);

        var result = new Result<ManufacturerDetailDto>();

        try
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(request.Id, true);

            if (manufacturer == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Manufacturer with ID {request.Id} not found");

                _logger.LogWarning("Manufacturer with ID {Id} not found", request.Id);
                return result;
            }

            // Manual mapping to DTO entity
            var data = new ManufacturerDetailDto
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Street = manufacturer.Street,
                City = manufacturer.City,
                State = manufacturer.State,
                Country = manufacturer.Country,
                ZipCode = manufacturer.ZipCode,
                Phone = manufacturer.Phone,
                Email = manufacturer.Email,
                Website = manufacturer.Website,
                Logo = manufacturer.Logo
            };

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = data;

            _logger.LogInformation("Manufacturer with ID {Id} retrieved successfully", request.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while retrieving the manufacturer: {ex.Message}");

            _logger.LogError("Error retrieving manufacturer: {Message}", ex.Message);
        }

        return result;
    }
}