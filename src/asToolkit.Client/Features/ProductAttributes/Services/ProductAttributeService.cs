using System.Net.Http.Json;
using asToolkit.Client.Core.Constants;
using asToolkit.Client.Core.Extensions;
using asToolkit.Client.Core.Json;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Domain.Dtos.ProductAttribute;
using Microsoft.Extensions.Logging;

namespace asToolkit.Client.Features.ProductAttributes.Services;

/// <summary>
/// Implementation of product attribute service using HTTP client.
/// </summary>
public class ProductAttributeService : IProductAttributeService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ProductAttributeService> _logger;

    public ProductAttributeService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ProductAttributeService> logger)
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

    public async Task<PaginatedResponse<ProductAttributeListDto>> GetProductAttributesAsync(
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ProductAttributes.Base}?{parameters.ToQueryString()}";

        _logger.LogInformation("Fetching product attributes from URL: {Url}", url);

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseProductAttributeListDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<ProductAttributeListDto>();
            }

            _logger.LogInformation(
                "Fetched {Count} product attributes (Page {Page}/{TotalPages}, Total: {Total})",
                response.Data?.Count ?? 0,
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product attributes from {Url}", url);
            throw;
        }
    }

    public async Task<ProductAttributeDetailDto?> GetProductAttributeAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ProductAttributes.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(url, AppJsonSerializerContext.Default.ApiResponseProductAttributeDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task CreateProductAttributeAsync(ProductAttributeInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ProductAttributes.Base}";
        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.ProductAttributeInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task UpdateProductAttributeAsync(Guid id, ProductAttributeInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ProductAttributes.ById(id)}";
        var response = await _httpClient.PutAsJsonAsync(url, input, AppJsonSerializerContext.Default.ProductAttributeInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task DeleteProductAttributeAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.ProductAttributes.ById(id)}";
        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }
}
