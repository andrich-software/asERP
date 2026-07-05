using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Returns;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Returns.Services;

/// <summary>
/// Implementation of the return service using the shared HTTP client.
/// </summary>
public class ReturnService : IReturnService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ReturnService> _logger;

    public ReturnService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ReturnService> logger)
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

    public async Task<List<ReturnableSalesItemDto>> GetReturnableItemsAsync(Guid salesId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Saless.ReturnableItems(salesId)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListReturnableSalesItemDto, ct);
        return apiResponse?.Data ?? new List<ReturnableSalesItemDto>();
    }

    public async Task<Guid> CreateReturnAsync(ReturnShipmentInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.Base}";
        var response = await _httpClient.PostAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ReturnShipmentInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task<ReturnShipmentDetailDto?> GetReturnAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseReturnShipmentDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task ReceiveReturnAsync(Guid id, ReturnReceiveInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.Receive(id)}";
        var response = await _httpClient.PostAsJsonAsync(
            url, input, AppJsonSerializerContext.Default.ReturnReceiveInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task CancelReturnAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.Cancel(id)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task CompleteReturnAsync(Guid id, bool reject = false, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.Complete(id, reject)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task RetryLabelAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Returns.LabelRetry(id)}";
        var response = await _httpClient.PostAsync(url, content: null, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
