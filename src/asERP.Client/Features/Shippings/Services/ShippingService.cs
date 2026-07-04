using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// Implementation of the shipping service using the shared HTTP client.
/// </summary>
public class ShippingService : IShippingService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ShippingService> _logger;

    public ShippingService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ShippingService> logger)
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

    public async Task<PaginatedResponse<ShipmentListItemDto>> GetShippingsAsync(
        QueryParameters parameters,
        ShippingStatus? status = null,
        bool problemsOnly = false,
        Guid? salesId = null,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var query = parameters.ToQueryString();

        if (status.HasValue)
        {
            query += $"&status={(int)status.Value}";
        }

        if (problemsOnly)
        {
            query += "&problemsOnly=true";
        }

        if (salesId.HasValue)
        {
            query += $"&salesId={salesId.Value}";
        }

        var url = $"{baseUrl}{ApiEndpoints.Shippings.Base}?{query}";

        _logger.LogInformation("Fetching shippings from URL: {Url}", url);

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseShipmentListItemDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<ShipmentListItemDto>();
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching shippings from {Url}", url);
            throw;
        }
    }

    public async Task<ShippingDetailDto?> GetShippingAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Shippings.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseShippingDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task CancelShippingAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Shippings.Cancel(id)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task RetryLabelAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Shippings.LabelRetry(id)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task<List<ShippableSalesItemDto>> GetShippableItemsAsync(Guid salesId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Saless.ShippableItems(salesId)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListShippableSalesItemDto, ct);
        return apiResponse?.Data ?? new List<ShippableSalesItemDto>();
    }

    public async Task<ApiResponse<List<ApplicableShippingRateDto>>> GetShippingOptionsAsync(
        Guid salesId,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Saless.ShippingOptions(salesId)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListApplicableShippingRateDto, ct);
        return apiResponse ?? new ApiResponse<List<ApplicableShippingRateDto>>();
    }

    public async Task<Guid> CreateShippingAsync(ShippingInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Shippings.Base}";
        var response = await _httpClient.PostAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ShippingInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task CancelSalesAsync(Guid salesId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Saless.Cancel(salesId)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
