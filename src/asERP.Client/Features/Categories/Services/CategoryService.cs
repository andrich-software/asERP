using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Category;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Categories.Services;

/// <summary>
/// Implementation of category service using HTTP client.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<CategoryService> logger)
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

    public async Task<List<CategoryListDto>> GetCategoriesAsync(CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.Base}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListCategoryListDto, ct);

        if (apiResponse?.Succeeded != true)
        {
            _logger.LogWarning("API returned unsuccessful category list response: {Messages}",
                string.Join(", ", apiResponse?.Messages ?? new List<string>()));
        }

        return apiResponse?.Data ?? new List<CategoryListDto>();
    }

    public async Task<CategoryDetailDto?> GetCategoryAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseCategoryDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task<Guid> CreateCategoryAsync(CategoryInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.Base}";
        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.CategoryInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var apiResponse = await response.Content.ReadFromJsonAsync(
            AppJsonSerializerContext.Default.ApiResponseGuid, ct);
        return apiResponse?.Data ?? Guid.Empty;
    }

    public async Task UpdateCategoryAsync(Guid id, CategoryInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.ById(id)}";
        var response = await _httpClient.PutAsJsonAsync(url, input, AppJsonSerializerContext.Default.CategoryInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task UpdateChannelActivationsAsync(CategoryChannelActivationUpdateDto update, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Categories.Channels}";
        var response = await _httpClient.PutAsJsonAsync(
            url, update, AppJsonSerializerContext.Default.CategoryChannelActivationUpdateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
