using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Dtos.WebAnalytics;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.SalesChannelDashboards.Services;

/// <summary>
/// Implementation of SalesChannel-filtered statistics service using HTTP client.
/// </summary>
public class SalesChannelStatisticsService : ISalesChannelStatisticsService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<SalesChannelStatisticsService> _logger;

    public SalesChannelStatisticsService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<SalesChannelStatisticsService> logger)
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

    public async Task<SalesTodayDto?> GetSalesTodayAsync(Guid salesChannelId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Statistics.SalesToday}?salesChannelId={salesChannelId}";

        _logger.LogInformation("Fetching sales today statistics for SalesChannel {SalesChannelId} from URL: {Url}", salesChannelId, url);

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseSalesTodayDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for SalesToday (SalesChannel {SalesChannelId})", salesChannelId);
                return null;
            }

            if (apiResponse.Data == null)
            {
                _logger.LogWarning("API returned success but SalesToday Data is null (SalesChannel {SalesChannelId})", salesChannelId);
                return new SalesTodayDto();
            }

            return apiResponse.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching sales today statistics for SalesChannel {SalesChannelId}", salesChannelId);
            throw;
        }
    }

    public async Task<SalessTodayDto?> GetSalessTodayAsync(Guid salesChannelId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Statistics.SalessToday}?salesChannelId={salesChannelId}";

        _logger.LogInformation("Fetching saless today statistics for SalesChannel {SalesChannelId} from URL: {Url}", salesChannelId, url);

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseSalessTodayDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for SalessToday (SalesChannel {SalesChannelId})", salesChannelId);
                return null;
            }

            if (apiResponse.Data == null)
            {
                _logger.LogWarning("API returned success but SalessToday Data is null (SalesChannel {SalesChannelId})", salesChannelId);
                return new SalessTodayDto();
            }

            return apiResponse.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching saless today statistics for SalesChannel {SalesChannelId}", salesChannelId);
            throw;
        }
    }

    public async Task<SalessLatestDto?> GetSalessLatestAsync(Guid salesChannelId, int count = 5, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Statistics.SalessLatest}?count={count}&salesChannelId={salesChannelId}";

        _logger.LogInformation("Fetching latest saless for SalesChannel {SalesChannelId} from URL: {Url}", salesChannelId, url);

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseSalessLatestDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for SalessLatest (SalesChannel {SalesChannelId})", salesChannelId);
                return null;
            }

            if (apiResponse.Data == null)
            {
                _logger.LogWarning("API returned success but SalessLatest Data is null (SalesChannel {SalesChannelId})", salesChannelId);
                return new SalessLatestDto();
            }

            return apiResponse.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching latest saless for SalesChannel {SalesChannelId}", salesChannelId);
            throw;
        }
    }

    public async Task<WebSessionsSummaryDto?> GetWebSessionsAsync(Guid salesChannelId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.WebStatistics.Sessions}?salesChannelId={salesChannelId}";

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseWebSessionsSummaryDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for WebSessions (SalesChannel {SalesChannelId})", salesChannelId);
                return null;
            }

            return apiResponse.Data ?? new WebSessionsSummaryDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching web sessions for SalesChannel {SalesChannelId}", salesChannelId);
            throw;
        }
    }

    public async Task<WebTopProductsDto?> GetWebTopProductsAsync(Guid salesChannelId, DateTime startDate, DateTime endDate, int count = 10, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.WebStatistics.TopProducts}" +
                  $"?salesChannelId={salesChannelId}&startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}&count={count}";

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseWebTopProductsDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for WebTopProducts (SalesChannel {SalesChannelId})", salesChannelId);
                return null;
            }

            return apiResponse.Data ?? new WebTopProductsDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching web top products for SalesChannel {SalesChannelId}", salesChannelId);
            throw;
        }
    }
}
