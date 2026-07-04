using System.Net.Http.Headers;
using System.Net.Http.Json;
using asERP.Client.Core.Constants;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Product;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Products.Services;

/// <summary>
/// Implementation of product service using HTTP client.
/// </summary>
public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ILogger<ProductService> _logger;

    public ProductService(
        IHttpClientFactory httpClientFactory,
        ITokenStorageService tokenStorage,
        ILogger<ProductService> logger)
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

    public async Task<PaginatedResponse<ProductListDto>> GetProductsAsync(
        QueryParameters parameters,
        CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.Base}?{parameters.ToQueryString()}";

        _logger.LogInformation("Fetching products from URL: {Url}", url);

        try
        {
            var response = await _httpClient.GetFromJsonAsync(
                url, AppJsonSerializerContext.Default.PaginatedResponseProductListDto, ct);

            if (response?.Succeeded != true)
            {
                _logger.LogWarning("API returned unsuccessful response: {Messages}",
                    string.Join(", ", response?.Messages ?? new List<string>()));
                return new PaginatedResponse<ProductListDto>();
            }

            _logger.LogInformation(
                "Fetched {Count} products (Page {Page}/{TotalPages}, Total: {Total})",
                response.Data?.Count ?? 0,
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching products from {Url}", url);
            throw;
        }
    }

    public async Task<ProductDetailDto?> GetProductAsync(Guid id, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.ById(id)}";
        var apiResponse = await _httpClient.GetFromJsonAsync(url, AppJsonSerializerContext.Default.ApiResponseProductDetailDto, ct);
        return apiResponse?.Data;
    }

    public async Task CreateProductAsync(ProductInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.Base}";

        _logger.LogInformation("Creating product at URL: {Url}", url);

        var response = await _httpClient.PostAsJsonAsync(url, input, AppJsonSerializerContext.Default.ProductInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task UpdateProductAsync(Guid id, ProductInputDto input, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.ById(id)}";

        _logger.LogInformation("Updating product {Id} at URL: {Url}", id, url);

        var response = await _httpClient.PutAsJsonAsync(url, input, AppJsonSerializerContext.Default.ProductInputDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task<List<Guid>> GenerateVariantsAsync(Guid parentProductId, ProductVariantGenerateDto request, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.GenerateVariants(parentProductId)}";

        _logger.LogInformation("Generating variants for product {Id} at URL: {Url}", parentProductId, url);

        var response = await _httpClient.PostAsJsonAsync(url, request, AppJsonSerializerContext.Default.ProductVariantGenerateDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var result = await response.Content.ReadFromJsonAsync(AppJsonSerializerContext.Default.ApiResponseListGuid, ct);
        return result?.Data ?? new List<Guid>();
    }

    public async Task<List<ProductImageDto>> GetProductImagesAsync(Guid productId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.Images(productId)}";

        var response = await _httpClient.GetFromJsonAsync(
            url, AppJsonSerializerContext.Default.ApiResponseListProductImageDto, ct);
        return response?.Data ?? new List<ProductImageDto>();
    }

    public async Task<ProductImageDto?> UploadProductImageAsync(
        Guid productId, Stream content, string fileName, string contentType, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.Images(productId)}";

        _logger.LogInformation("Uploading image '{FileName}' for product {Id}", fileName, productId);

        using var form = new MultipartFormDataContent();
        var streamContent = new StreamContent(content);
        if (!string.IsNullOrEmpty(contentType))
        {
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        }
        // Field name "file" must match the controller's IFormFile parameter.
        form.Add(streamContent, "file", fileName);

        var response = await _httpClient.PostAsync(url, form, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var result = await response.Content.ReadFromJsonAsync(AppJsonSerializerContext.Default.ApiResponseProductImageDto, ct);
        return result?.Data;
    }

    public async Task DeleteProductImageAsync(Guid productId, Guid imageId, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.ImageById(productId, imageId)}";

        var response = await _httpClient.DeleteAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task ReorderProductImagesAsync(Guid productId, List<Guid> orderedImageIds, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.ImagesReorder(productId)}";

        var request = new ProductImageReorderDto { OrderedImageIds = orderedImageIds };
        var response = await _httpClient.PutAsJsonAsync(url, request, AppJsonSerializerContext.Default.ProductImageReorderDto, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
    }

    public async Task<byte[]> GetProductImageBytesAsync(Guid productId, Guid imageId, bool thumbnail, CancellationToken ct = default)
    {
        var baseUrl = await GetBaseUrlAsync();
        var url = $"{baseUrl}{ApiEndpoints.Products.ImageContent(productId, imageId, thumbnail)}";

        return await _httpClient.GetByteArrayAsync(url, ct);
    }
}
