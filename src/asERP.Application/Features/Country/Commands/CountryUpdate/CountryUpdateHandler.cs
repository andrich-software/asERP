using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Country.Commands.CountryUpdate;

public class CountryUpdateHandler : IRequestHandler<CountryUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<CountryUpdateHandler> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountryUpdateHandler(
        IAppLogger<CountryUpdateHandler> logger,
        ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<Result<Guid>> Handle(CountryUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating country with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Get the country for tracking (required for update)
        var countryToUpdate = await _countryRepository.GetByIdAsync(request.Id, true);
        if (countryToUpdate == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Country.NotFound, "Country not found or access denied due to tenant isolation.");

            _logger.LogWarning("Country with ID {Id} not found or access denied due to tenant isolation", request.Id);
            return result;
        }

        // Update the existing entity properties
        countryToUpdate.Name = request.Name;
        countryToUpdate.CountryCode = request.CountryCode;

        // Update in database
        await _countryRepository.UpdateAsync(countryToUpdate);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = countryToUpdate.Id;

        _logger.LogInformation("Successfully updated country with ID: {Id}", countryToUpdate.Id);

        return result;
    }
}
