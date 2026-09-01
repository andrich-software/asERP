using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerUpdate;

public class ManufacturerUpdateHandler : IRequestHandler<ManufacturerUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ManufacturerUpdateHandler> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerUpdateHandler(
        IAppLogger<ManufacturerUpdateHandler> logger,
        IManufacturerRepository manufacturerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
    }

    public async Task<Result<Guid>> Handle(ManufacturerUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating manufacturer with ID: {Id}, Name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Load existing manufacturer from database
        var existingManufacturer = await _manufacturerRepository.GetByIdAsync(request.Id);

        if (existingManufacturer == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Manufacturer.NotFound, $"Manufacturer with ID {request.Id} not found");
            return result;
        }

        // Update only the provided fields, preserving system fields like TenantId, DateCreated, etc.
        existingManufacturer.Name = request.Name;
        existingManufacturer.Street = request.Street;
        existingManufacturer.City = request.City;
        existingManufacturer.State = request.State;
        existingManufacturer.Country = request.Country;
        existingManufacturer.ZipCode = request.ZipCode;
        existingManufacturer.Phone = request.Phone;
        existingManufacturer.Email = request.Email;
        existingManufacturer.Website = request.Website;
        existingManufacturer.Logo = request.Logo;

        // Update in database
        await _manufacturerRepository.UpdateAsync(existingManufacturer);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = existingManufacturer.Id;

        _logger.LogInformation("Successfully updated manufacturer with ID: {Id}", existingManufacturer.Id);

        return result;
    }
}
