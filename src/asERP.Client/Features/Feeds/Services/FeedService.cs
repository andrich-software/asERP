using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Feed;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Feeds.Services;

/// <summary>
/// Implementation of the feed service using the shared "MaErpApi" HTTP client.
/// </summary>
public class FeedService : IFeedService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<FeedService> _logger;

    public FeedService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<FeedService> logger)
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

    public async Task<PaginatedResponse<FeedListDto>> GetFeedsAsync(
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.Base}?{parameters.ToQueryString()}";

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseFeedListDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful feed list response: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<FeedListDto>();
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching feeds from {Url}", url);
            throw;
        }
    }

    public async Task<FeedDetailDto?> GetFeedAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseFeedDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task<Guid> CreateFeedAsync(FeedInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.Base}";
        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.FeedInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task UpdateFeedAsync(Guid id, FeedInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.ById(id)}";
        var response = await _httpClient.PutAsJsonAsync(url, input, AppJsonSerializerContext.Default.FeedInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteFeedAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task<PaginatedResponse<FeedLogDto>> GetFeedLogsAsync(
        Guid id,
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.Logs(id)}?{parameters.ToQueryString()}";
        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.PaginatedResponseFeedLogDto, ct);
        return response ?? new PaginatedResponse<FeedLogDto>();
    }

    public async Task<PaginatedResponse<FeedProductSelectionDto>> GetFeedProductsAsync(
        Guid id,
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.Products(id)}?{parameters.ToQueryString()}";
        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.PaginatedResponseFeedProductSelectionDto, ct);
        return response ?? new PaginatedResponse<FeedProductSelectionDto>();
    }

    public async Task UpdateFeedProductsAsync(Guid id, FeedProductSelectionUpdateDto changes, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Feeds.Products(id)}";
        var response = await _httpClient.PutAsJsonAsync(
            url, changes, AppJsonSerializerContext.Default.FeedProductSelectionUpdateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
