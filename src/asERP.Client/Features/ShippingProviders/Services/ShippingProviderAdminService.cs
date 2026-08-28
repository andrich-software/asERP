using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Dtos.ShippingProviderRate;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.ShippingProviders.Services;

public class ShippingProviderAdminService : IShippingProviderAdminService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ShippingProviderAdminService> _logger;

    public ShippingProviderAdminService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ShippingProviderAdminService> logger)
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

    public async Task<List<ShippingProviderListDto>> GetProvidersAsync(CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        // A tenant has a handful of carriers at most — fetch them all in one page.
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.Base}?pageNumber=0&pageSize=200&salesBy=Name";

        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.PaginatedResponseShippingProviderListDto, ct);

        if (response?.Succeeded != true)
        {
            _logger.LogWarning("Shipping provider list request was unsuccessful: {Messages}",
                string.Join(", ", response?.Messages ?? new List<string>()));
        }

        return response?.Data ?? new List<ShippingProviderListDto>();
    }

    public async Task<ShippingProviderDetailDto?> GetProviderAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.ById(id)}";
        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseShippingProviderDetailDto, ct);
        return response?.Data;
    }

    public async Task<Guid> CreateProviderAsync(ShippingProviderCreateDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.Base}";
        var response = await _httpClient.PostAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ShippingProviderCreateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task UpdateProviderAsync(Guid id, ShippingProviderUpdateDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.ById(id)}";
        var response = await _httpClient.PutAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ShippingProviderUpdateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteProviderAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task<ShippingProviderRateDetailDto?> GetRateAsync(Guid providerId, Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.RateById(providerId, id)}";
        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseShippingProviderRateDetailDto, ct);
        return response?.Data;
    }

    public async Task<Guid> CreateRateAsync(Guid providerId, ShippingProviderRateCreateDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.Rates(providerId)}";
        var response = await _httpClient.PostAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ShippingProviderRateCreateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task UpdateRateAsync(Guid providerId, Guid id, ShippingProviderRateUpdateDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.RateById(providerId, id)}";
        var response = await _httpClient.PutAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ShippingProviderRateUpdateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteRateAsync(Guid providerId, Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShippingProviders.RateById(providerId, id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
