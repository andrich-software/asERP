using asERP.Client.Core.Models;
using asERP.Domain.Dtos.Country;

namespace asERP.Client.Features.Superadmin.Services;

/// <summary>
/// Service interface for superadmin country reference-data operations.
/// Uses the /api/v1/countries endpoint (country management is a cross-tenant,
/// superadmin-only concern in the client, even though the entity is global).
/// </summary>
public interface ISuperadminCountryService
{
    /// <summary>
    /// Gets a paginated list of countries with full pagination metadata.
    /// </summary>
    Task<PaginatedResponse<CountryListDto>> GetCountriesAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single country by ID.
    /// </summary>
    Task<CountryDetailDto?> GetCountryAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Creates a new country.
    /// </summary>
    Task CreateCountryAsync(CountryInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing country.
    /// </summary>
    Task UpdateCountryAsync(Guid id, CountryInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Deletes a country.
    /// </summary>
    Task DeleteCountryAsync(Guid id, CancellationToken ct = default);
}
