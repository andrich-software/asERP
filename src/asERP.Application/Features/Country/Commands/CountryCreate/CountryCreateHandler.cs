using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Country.Commands.CountryCreate;

/// <summary>
/// Handler for processing country creation commands.
/// Implements IRequestHandler from custom mediator to handle CountryCreateCommand requests
/// and return the ID of the newly created country wrapped in a Result.
/// </summary>
public class CountryCreateHandler : IRequestHandler<CountryCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<CountryCreateHandler> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountryCreateHandler(
        IAppLogger<CountryCreateHandler> logger,
        ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<Result<Guid>> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new country with name: {Name}, code: {CountryCode}",
            request.Name, request.CountryCode);

        // Manual mapping to domain entity
        var countryToCreate = new Domain.Entities.Country
        {
            Name = request.Name,
            CountryCode = request.CountryCode
        };

        // Add the new country to the database
        await _countryRepository.CreateAsync(countryToCreate);

        _logger.LogInformation("Successfully created country with ID: {Id}", countryToCreate.Id);

        return Result<Guid>.Created(countryToCreate.Id);
    }
}
