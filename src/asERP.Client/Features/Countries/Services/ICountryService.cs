using asERP.Domain.Dtos.Country;

namespace asERP.Client.Features.Countries.Services;

/// <summary>
/// Service interface for country-related API operations.
/// </summary>
public interface ICountryService
{
    /// <summary>
    /// Gets all available countries.
    /// </summary>
    Task<List<CountryListDto>> GetCountriesAsync(CancellationToken ct = default);
}
