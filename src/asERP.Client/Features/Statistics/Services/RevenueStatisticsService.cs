using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Statistic;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Statistics.Services;

/// <summary>
/// Implementation of the revenue statistics service using the shared "MaErpApi" HTTP client.
/// </summary>
public class RevenueStatisticsService : IRevenueStatisticsService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<RevenueStatisticsService> _logger;

    public RevenueStatisticsService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<RevenueStatisticsService> logger)
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

    public async Task<RevenueChartDto?> GetRevenueChartAsync(DateTime startDate, DateTime endDate, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Statistics.RevenueChart}" +
                  $"?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

        _logger.LogInformation("Fetching revenue chart from URL: {Url}", url);

        try
        {
            var apiResponse = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.ApiResponseRevenueChartDto, ct);

            if (apiResponse?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response for RevenueChart: {Messages}",
                    string.Join(", ", apiResponse?.Messages ?? new List<string>()));
                return null;
            }

            return apiResponse.Data ?? new RevenueChartDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching revenue chart from {Url}", url);
            throw;
        }
    }
}
