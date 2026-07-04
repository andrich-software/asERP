using System.Net.Http.Json;
using asToolkit.Client.Core.Constants;
using asToolkit.Client.Core.Extensions;
using asToolkit.Client.Core.Json;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Domain.Dtos.GlobalSettings;
using Microsoft.Extensions.Logging;

namespace asToolkit.Client.Features.GlobalSettings.Services;

public class GlobalSettingsService : IGlobalSettingsService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<GlobalSettingsService> _logger;

    public GlobalSettingsService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<GlobalSettingsService> logger)
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

    public async Task<List<GlobalSettingDto>?> GetAllAsync(CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.GlobalSettings.Base}";
        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListGlobalSettingDto, ct);
        return response?.Data;
    }

    public async Task UpdateAsync(GlobalSettingsUpdateInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.GlobalSettings.Base}";
        var response = await _httpClient.PutAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.GlobalSettingsUpdateInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
