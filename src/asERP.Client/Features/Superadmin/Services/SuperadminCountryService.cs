using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Country;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Superadmin.Services;

/// <summary>
/// Implementation of the superadmin country service using HTTP client.
/// </summary>
public class SuperadminCountryService : ISuperadminCountryService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<SuperadminCountryService> _logger;

    public SuperadminCountryService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<SuperadminCountryService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("MaErpApi");
        _tokenStorage = tokenStorage;
        _logger = logger;
    }

    private async Task<string> GetBaseUrlAsync()
    {
        var serverUrl = await _tokenStorage.GetServerUrlAsync();
        if (string.IsNullOrEmpty(serverUrl))
        {
            throw new InvalidOperationException("Server URL is not configured. Please login first.");
        }
        return serverUrl.TrimEnd('/');
    }

    public async Task<PaginatedResponse<CountryListDto>> GetCountriesAsync(
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Countries.Base}?{parameters.ToQueryString()}";

        _logger.LogInformation("Fetching countries from URL: {Url}", url);

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseCountryListDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<CountryListDto>();
            }

            _logger.LogInformation(
                "Fetched {Count} countries (Page {Page}/{TotalPages}, Total: {Total})",
                response.Data?.Count ?? 0,
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching countries from {Url}", url);
            throw;
        }
    }

    public async Task<CountryDetailDto?> GetCountryAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Countries.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(url, AppJsonSerializerContext.Default.ApiResponseCountryDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task CreateCountryAsync(CountryInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Countries.Base}";
        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.CountryInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task UpdateCountryAsync(Guid id, CountryInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Countries.ById(id)}";
        var response = await _httpClient.PutAsJsonAsync(url, input, AppJsonSerializerContext.Default.CountryInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteCountryAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Countries.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
