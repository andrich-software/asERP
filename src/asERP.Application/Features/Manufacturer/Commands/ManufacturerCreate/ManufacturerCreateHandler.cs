using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerCreate;

/// <summary>
/// Handler for processing manufacturer creation commands.
/// Implements IRequestHandler from the custom mediator to handle ManufacturerCreateCommand requests
/// and return the ID of the newly created manufacturer wrapped in a Result.
/// </summary>
public class ManufacturerCreateHandler : IRequestHandler<ManufacturerCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ManufacturerCreateHandler> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerCreateHandler(
        IAppLogger<ManufacturerCreateHandler> logger,
        IManufacturerRepository manufacturerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
    }

    public async Task<Result<Guid>> Handle(ManufacturerCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new manufacturer with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Manual mapping to domain entity
        var manufacturerToCreate = new Domain.Entities.Manufacturer
        {
            Name = request.Name,
            Street = request.Street,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ZipCode = request.ZipCode,
            Phone = request.Phone,
            Email = request.Email,
            Website = request.Website,
            Logo = request.Logo
        };

        // Add the new manufacturer to the database
        await _manufacturerRepository.CreateAsync(manufacturerToCreate);

        // Set successful result with the new manufacturer ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = manufacturerToCreate.Id;

        _logger.LogInformation("Successfully created manufacturer with ID: {Id}", manufacturerToCreate.Id);

        return result;
    }
}
