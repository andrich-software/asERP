using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using asToolkit.Domain.Enums;
using asToolkit.Shipping.Abstractions;
using asToolkit.Shipping.Connectors.Common;
using asToolkit.Shipping.Models.Gls;
using Microsoft.Extensions.Logging;

namespace asToolkit.Shipping.Connectors.Gls;

/// <summary>
/// GLS Web API for Parcel Processing (ShipIT). Auth: HTTP Basic.
/// [verify] Cancel path and tracking endpoint availability under the shipping subscription.
/// </summary>
public sealed class GlsConnector : ShippingConnectorBase, IShippingCarrierConnector
{
    internal const string HttpClientName = "gls";

    private const string ProductionBaseUrl = "https://api.gls-group.eu/public/v1";
    private const string SandboxBaseUrl = "https://api-qs.gls-group.eu/public/v1";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<GlsConnector> _logger;

    public GlsConnector(IHttpClientFactory httpClientFactory, ILogger<GlsConnector> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public ShippingProviderType Type => ShippingProviderType.Gls;

    private static string BaseUrlFor(ShippingCarrierContext context)
        => context.UseSandbox ? SandboxBaseUrl : ProductionBaseUrl;

    private HttpClient CreateClient(ShippingCarrierContext context)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        http.Timeout = TimeSpan.FromSeconds(60);
        http.DefaultRequestHeaders.Authorization = BasicAuth(context.Username, context.Password);
        http.DefaultRequestHeaders.Accept.ParseAdd("application/glsVersion1+json");
        return http;
    }

    public async Task<CarrierConnectionTestResult> TestConnectionAsync(ShippingCarrierContext context)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = CreateClient(context);
            var response = await http.GetAsync($"{BaseUrlFor(context)}/allowedservices", context.CancellationToken);
            return response.IsSuccessStatusCode
                ? CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>())
                : CarrierLabelResult.Permanent($"GLS responded with {(int)response.StatusCode}.");
        }, "GLS");

        return new CarrierConnectionTestResult(result.Success, result.ErrorMessage);
    }

    public Task<CarrierLabelResult> CreateLabelAsync(ShippingCarrierContext context, ShipmentLabelRequest request)
        => ExecuteLabelCallAsync(async () =>
        {
            var config = ParseConfig<GlsCarrierConfig>(context);
            config.Sender.EnsureComplete(context.Provider.Name);

            if (string.IsNullOrWhiteSpace(config.ContactId))
            {
                return CarrierLabelResult.Permanent(
                    $"Shipping provider '{context.Provider.Name}' has no GLS ContactId in AdditionalConfigJson.");
            }

            var body = new
            {
                Shipment = new
                {
                    Product = config.Product,
                    ShipmentReference = new[] { request.Reference },
                    Shipper = new
                    {
                        ContactID = config.ContactId,
                        AlternativeShipperAddress = new
                        {
                            Name1 = config.Sender.Name,
                            Street = config.Sender.Street,
                            ZIPCode = config.Sender.Zip,
                            City = config.Sender.City,
                            CountryCode = config.Sender.CountryCode
                        }
                    },
                    Consignee = new
                    {
                        Address = new
                        {
                            Name1 = request.RecipientName,
                            Name2 = request.RecipientCompany,
                            Street = request.Street,
                            ZIPCode = request.Zip,
                            City = request.City,
                            CountryCode = request.CountryIsoCode,
                            FixedLinePhonenumber = request.RecipientPhone
                        }
                    },
                    ShipmentUnit = new[]
                    {
                        new { Weight = request.WeightKg }
                    }
                },
                PrintingOptions = new
                {
                    ReturnLabels = new { TemplateSet = "NONE", LabelFormat = "PDF" }
                }
            };

            var http = CreateClient(context);
            var response = await http.PostAsJsonAsync($"{BaseUrlFor(context)}/shipments", body, JsonOptions, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = $"GLS label creation failed ({(int)response.StatusCode}): {Truncate(payload, 500)}";
                return IsPermanentStatusCode(response.StatusCode)
                    ? CarrierLabelResult.Permanent(error)
                    : CarrierLabelResult.Transient(error);
            }

            using var doc = JsonDocument.Parse(payload);
            if (!doc.RootElement.TryGetProperty("CreatedShipment", out var created))
            {
                return CarrierLabelResult.Permanent("GLS response contained no CreatedShipment.");
            }

            var trackId = created.TryGetProperty("ParcelData", out var parcels) && parcels.GetArrayLength() > 0
                && parcels[0].TryGetProperty("TrackID", out var t)
                ? t.GetString()
                : null;
            var labelB64 = created.TryGetProperty("PrintData", out var prints) && prints.GetArrayLength() > 0
                && prints[0].TryGetProperty("Data", out var d)
                ? d.GetString()
                : null;

            if (string.IsNullOrEmpty(trackId) || string.IsNullOrEmpty(labelB64))
            {
                return CarrierLabelResult.Permanent($"GLS response missing TrackID or label data: {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(
                trackId,
                trackId,
                Convert.FromBase64String(labelB64),
                trackingUrl: $"https://gls-group.eu/DE/de/paketverfolgung?match={trackId}");
        }, "GLS");

    public Task<CarrierTrackingResult> GetTrackingStatusAsync(ShippingCarrierContext context, string trackingNumber)
        => ExecuteTrackingCallAsync(async () =>
        {
            var http = CreateClient(context);

            // [verify] Track & Trace endpoint/subscription — falls back to Unknown on 404.
            var response = await http.GetAsync(
                $"{BaseUrlFor(context)}/tracking/references/{Uri.EscapeDataString(trackingNumber)}",
                context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return CarrierTrackingResult.Failed(
                    $"GLS tracking failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            using var doc = JsonDocument.Parse(payload);
            if (!doc.RootElement.TryGetProperty("parcels", out var parcels) || parcels.GetArrayLength() == 0)
            {
                return CarrierTrackingResult.Ok(CarrierTrackingStatus.Unknown, "No tracking data available yet.");
            }

            var parcel = parcels[0];
            var status = parcel.TryGetProperty("status", out var s) ? s.GetString() : null;
            DateTime? timestamp = parcel.TryGetProperty("timestamp", out var ts) && ts.ValueKind == JsonValueKind.String
                && DateTime.TryParse(ts.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var parsed)
                ? parsed
                : null;

            var mapped = status?.ToUpperInvariant() switch
            {
                "PREADVICE" => CarrierTrackingStatus.PreTransit,
                "INTRANSIT" => CarrierTrackingStatus.InTransit,
                "INWAREHOUSE" => CarrierTrackingStatus.InTransit,
                "INDELIVERY" => CarrierTrackingStatus.OutForDelivery,
                "DELIVEREDPS" or "DELIVERED" => CarrierTrackingStatus.Delivered,
                "NOTDELIVERED" => CarrierTrackingStatus.DeliveryFailed,
                _ => CarrierTrackingStatus.Unknown
            };

            return CarrierTrackingResult.Ok(mapped, status, timestamp);
        }, "GLS");

    public async Task<CarrierCancelResult> CancelShipmentAsync(ShippingCarrierContext context, string carrierShipmentId)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = CreateClient(context);
            // [verify] cancel path.
            var response = await http.PostAsync(
                $"{BaseUrlFor(context)}/shipments/cancel/{Uri.EscapeDataString(carrierShipmentId)}",
                content: null,
                context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);
                return CarrierLabelResult.Permanent(
                    $"GLS cancellation failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>());
        }, "GLS");

        return result.Success ? CarrierCancelResult.Ok() : CarrierCancelResult.Failed(result.ErrorMessage ?? "unknown");
    }
}
