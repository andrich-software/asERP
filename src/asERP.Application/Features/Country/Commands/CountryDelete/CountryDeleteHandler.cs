using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Country.Commands.CountryDelete;

public class CountryDeleteHandler : IRequestHandler<CountryDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<CountryDeleteHandler> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountryDeleteHandler(
        IAppLogger<CountryDeleteHandler> logger,
        ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<Result<Guid>> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting country with ID: {Id}", request.Id);

        try
        {
            // Get entity from database first
            var countryToDelete = await _countryRepository.GetByIdAsync(request.Id);

            if (countryToDelete == null)
            {
                _logger.LogWarning("Country with ID: {Id} not found for deletion", request.Id);
                return Result<Guid>.NotFound(ErrorCodes.Country.NotFound, "Country not found");
            }

            // Delete from database
            await _countryRepository.DeleteAsync(countryToDelete);

            _logger.LogInformation("Successfully deleted country with ID: {Id}", countryToDelete.Id);
            return Result<Guid>.Ok(countryToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - country was already deleted by another request

            _logger.LogWarning("Country with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
            return Result<Guid>.NotFound(ErrorCodes.Country.NotFound, "Country not found");
        }

    }
}
