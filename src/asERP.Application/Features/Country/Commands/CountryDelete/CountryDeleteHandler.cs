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

        var result = new Result<Guid>();

        try
        {
            // Get entity from database first
            var countryToDelete = await _countryRepository.GetByIdAsync(request.Id);

            if (countryToDelete == null)
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.Country.NotFound, "Country not found");

                _logger.LogWarning("Country with ID: {Id} not found for deletion", request.Id);
                return result;
            }

            // Delete from database
            await _countryRepository.DeleteAsync(countryToDelete);

            result.Succeeded = true;
            result.Status = ResultStatus.Ok;
            result.Data = countryToDelete.Id;

            _logger.LogInformation("Successfully deleted country with ID: {Id}", countryToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - country was already deleted by another request
            result.Fail(ErrorType.NotFound, ErrorCodes.Country.NotFound, "Country not found");

            _logger.LogWarning("Country with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
        }

        return result;
    }
}
