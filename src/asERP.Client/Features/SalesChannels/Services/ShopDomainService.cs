using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.ShopDomain;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.SalesChannels.Services;

/// <summary>
/// HTTP implementation of the shop domain service (asShop host bindings).
/// </summary>
public class ShopDomainService : IShopDomainService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ShopDomainService> _logger;

    public ShopDomainService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ShopDomainService> logger)
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

    public async Task<List<ShopDomainListDto>> GetShopDomainsAsync(Guid salesChannelId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShopDomains.ByChannel(salesChannelId)}";

        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListShopDomainListDto, ct);

        return response?.Data ?? new List<ShopDomainListDto>();
    }

    public async Task<Guid> CreateShopDomainAsync(ShopDomainInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShopDomains.Base}";
        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.ShopDomainInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task DeleteShopDomainAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ShopDomains.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
