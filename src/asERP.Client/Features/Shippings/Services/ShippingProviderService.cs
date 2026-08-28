using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.ShippingProvider;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Shippings.Services;

public class ShippingProviderService : IShippingProviderService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ShippingProviderService> _logger;

    public ShippingProviderService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ShippingProviderService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("MaErpApi");
        _tokenStorage = tokenStorage;
        _logger = logger;
    }

    public async Task<PaginatedResponse<ShippingProviderListDto>> GetProvidersAsync(
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var serverUrl = await _tokenStorage.GetServerUrlAsync();
        if (string.IsNullOrEmpty(serverUrl))
        {
            throw new InvalidOperationException("Server URL is not configured. Please login first.");
        }

        var url = $"{serverUrl.TrimEnd('/')}{ApiEndpoints.ShippingProviders.Base}?{parameters.ToQueryString()}";

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseShippingProviderListDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("Shipping provider list request was unsuccessful: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<ShippingProviderListDto>();
            }

            return response;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch shipping providers from {Url}", url);
            return new PaginatedResponse<ShippingProviderListDto>();
        }
    }
}
