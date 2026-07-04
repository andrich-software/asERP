using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Search;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Search.Services;

/// <summary>
/// Implementation of the global search service using the shared HTTP client.
/// </summary>
public class SearchService : ISearchService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<SearchService> _logger;

    public SearchService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<SearchService> logger)
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

    public async Task<GlobalSearchResultDto> SearchAsync(string query, int limit, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Search.Base}?searchString={Uri.EscapeDataString(query)}&limit={limit}";

        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseGlobalSearchResultDto, ct);

        if (response?.Succeeded != true)
        {
            _logger.LogWarning("Search returned unsuccessful response: {Messages}",
                string.Join(", ", response?.Messages ?? new List<string>()));
            return new GlobalSearchResultDto();
        }

        return response.Data ?? new GlobalSearchResultDto();
    }
}
