using asToolkit.Client.Core.Constants;
using asToolkit.Client.Core.Extensions;
using asToolkit.Client.Features.Auth.Services;

namespace asToolkit.Client.Features.Shippings.Services;

/// <summary>
/// Shared part of the label service: fetches the label bytes from the API and dispatches
/// remembered actions. The platform-specific members (Capabilities, Save/Print/Open) live
/// in the per-platform partial files (LabelService.desktop.cs / .wasm.cs / .default.cs).
/// </summary>
public partial class LabelService : ILabelService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;

    public LabelService(IHttpClientFactory httpClientFactory, ITokenStorageService tokenStorage)
    {
        _httpClient = httpClientFactory.CreateClient("MaErpApi");
        _tokenStorage = tokenStorage;
    }

    public Task<LabelFile> FetchLabelAsync(Guid shippingId, CancellationToken ct = default) =>
        FetchAsync(ApiEndpoints.Shippings.Label(shippingId), "label", shippingId, ct);

    public Task<LabelFile> FetchPackingSlipAsync(Guid shippingId, CancellationToken ct = default) =>
        FetchAsync(ApiEndpoints.Shippings.PackingSlip(shippingId), "packliste", shippingId, ct);

    private async Task<LabelFile> FetchAsync(string relativeUrl, string fallbackPrefix, Guid shippingId, CancellationToken ct)
    {
        var serverUrl = await _tokenStorage.GetServerUrlAsync();
        if (string.IsNullOrEmpty(serverUrl))
        {
            throw new InvalidOperationException("Server URL is not configured. Please login first.");
        }

        var url = $"{serverUrl.TrimEnd('/')}{relativeUrl}";
        var response = await _httpClient.GetAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        var bytes = await response.Content.ReadAsByteArrayAsync(ct);
        var contentType = response.Content.Headers.ContentType?.MediaType ?? "application/pdf";
        var fileName = ResolveFileName(response, fallbackPrefix, shippingId, contentType);

        return new LabelFile(bytes, contentType, fileName);
    }

    /// <summary>Content-Disposition filename (RFC 5987 star form preferred), with a
    /// deterministic fallback name derived from the shipment id.</summary>
    private static string ResolveFileName(HttpResponseMessage response, string fallbackPrefix, Guid shippingId, string contentType)
    {
        var disposition = response.Content.Headers.ContentDisposition;
        var name = disposition?.FileNameStar ?? disposition?.FileName;
        name = name?.Trim().Trim('"');

        return string.IsNullOrWhiteSpace(name)
            ? $"{fallbackPrefix}-{shippingId:N}{LabelContentTypes.GetExtension(contentType)}"
            : name;
    }

    public async Task ExecuteAsync(LabelFile label, LabelActionPreference pref)
    {
        switch (pref.Action)
        {
            case LabelAction.Save when Capabilities.HasFlag(LabelCapabilities.Save):
                await SaveAsync(label);
                break;
            case LabelAction.Download when Capabilities.HasFlag(LabelCapabilities.Download):
                // On the platforms that support it, "download" is the save path.
                await SaveAsync(label);
                break;
            case LabelAction.Print when Capabilities.HasFlag(LabelCapabilities.Print):
                await PrintAsync(label, pref.PrinterName);
                break;
            default:
                await OpenWithSystemDefaultAsync(label);
                break;
        }
    }
}
