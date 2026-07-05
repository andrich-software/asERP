using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using asERP.Domain.Enums;
using asERP.Shipping.Abstractions;
using asERP.Shipping.Connectors.Common;
using asERP.Shipping.Models.Dhl;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Connectors.Dhl;

/// <summary>
/// DHL Parcel DE Shipping API v2 (label creation/cancel) + DHL Unified Tracking API.
/// Auth: HTTP Basic with the business-portal user plus the <c>dhl-api-key</c> header.
/// [verify] Sandbox host and test billing numbers against the official docs during the smoke run.
/// </summary>
public sealed class DhlConnector : ShippingConnectorBase, IShippingCarrierConnector
{
    internal const string HttpClientName = "dhl";
    internal const string TrackingHttpClientName = "dhl-track";

    private const string ProductionBaseUrl = "https://api-eu.dhl.com/parcel/de/shipping/v2";
    private const string SandboxBaseUrl = "https://api-sandbox.dhl.com/parcel/de/shipping/v2";
    private const string TrackingBaseUrl = "https://api-eu.dhl.com/track/shipments";
    private const string Profile = "STANDARD_GRUPPENPROFIL";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<DhlConnector> _logger;

    public DhlConnector(IHttpClientFactory httpClientFactory, ILogger<DhlConnector> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public ShippingProviderType Type => ShippingProviderType.Dhl;

    private static string BaseUrlFor(ShippingCarrierContext context)
        => context.UseSandbox ? SandboxBaseUrl : ProductionBaseUrl;

    private HttpClient CreateShippingClient(ShippingCarrierContext context)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        http.Timeout = TimeSpan.FromSeconds(60);
        http.DefaultRequestHeaders.Authorization = BasicAuth(context.Username, context.Password);
        http.DefaultRequestHeaders.Add("dhl-api-key", context.ApiKey);
        return http;
    }

    public async Task<CarrierConnectionTestResult> TestConnectionAsync(ShippingCarrierContext context)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = CreateShippingClient(context);
            // The root endpoint answers with API metadata when credentials are accepted.
            var response = await http.GetAsync(BaseUrlFor(context), context.CancellationToken);
            return response.IsSuccessStatusCode
                ? CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>())
                : CarrierLabelResult.Permanent($"DHL responded with {(int)response.StatusCode}.");
        }, "DHL");

        return new CarrierConnectionTestResult(result.Success, result.ErrorMessage);
    }

    public Task<CarrierLabelResult> CreateLabelAsync(ShippingCarrierContext context, ShipmentLabelRequest request)
        => ExecuteLabelCallAsync(async () =>
        {
            var config = ParseConfig<DhlCarrierConfig>(context);
            config.Sender.EnsureComplete(context.Provider.Name);

            if (string.IsNullOrWhiteSpace(context.AccountNumber))
            {
                return CarrierLabelResult.Permanent(
                    $"Shipping provider '{context.Provider.Name}' has no EKP (AccountNumber) configured.");
            }

            var isDomestic = request.CountryIsoCode.Equals(config.Sender.CountryCode, StringComparison.OrdinalIgnoreCase);
            var product = config.Product ?? (isDomestic ? "V01PAK" : "V53WPAK");
            var billingNumber = $"{context.AccountNumber}{config.Procedure}{config.Participation}";

            var body = new
            {
                profile = Profile,
                shipments = new[]
                {
                    new
                    {
                        product,
                        billingNumber,
                        refNo = request.Reference,
                        shipper = new
                        {
                            name1 = config.Sender.Name,
                            addressStreet = config.Sender.Street,
                            postalCode = config.Sender.Zip,
                            city = config.Sender.City,
                            country = ToIso3(config.Sender.CountryCode),
                            email = config.Sender.Email,
                            phone = config.Sender.Phone
                        },
                        consignee = new
                        {
                            name1 = request.RecipientName,
                            name2 = request.RecipientCompany,
                            addressStreet = request.Street,
                            postalCode = request.Zip,
                            city = request.City,
                            country = ToIso3(request.CountryIsoCode),
                            phone = request.RecipientPhone
                        },
                        details = new
                        {
                            dim = request.LengthCm.HasValue && request.WidthCm.HasValue && request.HeightCm.HasValue
                                ? new { uom = "cm", length = request.LengthCm, width = request.WidthCm, height = request.HeightCm }
                                : null,
                            weight = new { uom = "kg", value = request.WeightKg }
                        }
                    }
                }
            };

            var http = CreateShippingClient(context);
            var url = $"{BaseUrlFor(context)}/orders?docFormat=PDF&includeDocs=include";
            var response = await http.PostAsJsonAsync(url, body, JsonOptions, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = $"DHL label creation failed ({(int)response.StatusCode}): {Truncate(payload, 500)}";
                return IsPermanentStatusCode(response.StatusCode)
                    ? CarrierLabelResult.Permanent(error)
                    : CarrierLabelResult.Transient(error);
            }

            using var doc = JsonDocument.Parse(payload);
            if (!doc.RootElement.TryGetProperty("items", out var items) || items.GetArrayLength() == 0)
            {
                return CarrierLabelResult.Permanent("DHL response contained no shipment items.");
            }

            var item = items[0];
            var shipmentNo = item.TryGetProperty("shipmentNo", out var no) ? no.GetString() : null;
            var labelB64 = item.TryGetProperty("label", out var label) && label.TryGetProperty("b64", out var b64)
                ? b64.GetString()
                : null;

            if (string.IsNullOrEmpty(shipmentNo) || string.IsNullOrEmpty(labelB64))
            {
                // Item-level validation errors surface here (HTTP 207 with per-item status).
                var itemStatus = item.TryGetProperty("sstatus", out var s) ? s.ToString() : payload;
                return CarrierLabelResult.Permanent($"DHL rejected the shipment: {Truncate(itemStatus, 500)}");
            }

            return CarrierLabelResult.Ok(
                shipmentNo,
                shipmentNo,
                Convert.FromBase64String(labelB64),
                trackingUrl: $"https://www.dhl.de/de/privatkunden/pakete-empfangen/verfolgen.html?piececode={shipmentNo}");
        }, "DHL");

    public Task<CarrierTrackingResult> GetTrackingStatusAsync(ShippingCarrierContext context, string trackingNumber)
        => ExecuteTrackingCallAsync(async () =>
        {
            var config = ParseConfig<DhlCarrierConfig>(context);

            var http = _httpClientFactory.CreateClient(TrackingHttpClientName);
            http.Timeout = TimeSpan.FromSeconds(30);
            http.DefaultRequestHeaders.Add("DHL-API-Key", config.TrackingApiKey ?? context.ApiKey);

            var response = await http.GetAsync(
                $"{TrackingBaseUrl}?trackingNumber={Uri.EscapeDataString(trackingNumber)}",
                context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return CarrierTrackingResult.Failed(
                    $"DHL tracking failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            using var doc = JsonDocument.Parse(payload);
            if (!doc.RootElement.TryGetProperty("shipments", out var shipments) || shipments.GetArrayLength() == 0)
            {
                return CarrierTrackingResult.Ok(CarrierTrackingStatus.Unknown, "No tracking data available yet.");
            }

            var status = shipments[0].GetProperty("status");
            var statusCode = status.TryGetProperty("statusCode", out var sc) ? sc.GetString() : null;
            var description = status.TryGetProperty("description", out var d) ? d.GetString()
                : status.TryGetProperty("status", out var st) ? st.GetString() : null;
            DateTime? timestamp = status.TryGetProperty("timestamp", out var ts) && ts.ValueKind == JsonValueKind.String
                && DateTime.TryParse(ts.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var parsed)
                ? parsed
                : null;

            // [verify] granular codes (out-for-delivery, return detection) against real responses.
            var mapped = statusCode?.ToLowerInvariant() switch
            {
                "pre-transit" => CarrierTrackingStatus.PreTransit,
                "transit" when description != null && description.Contains("Zustellung", StringComparison.OrdinalIgnoreCase) => CarrierTrackingStatus.OutForDelivery,
                "transit" => CarrierTrackingStatus.InTransit,
                "delivered" => CarrierTrackingStatus.Delivered,
                "failure" when description != null && description.Contains("zurück", StringComparison.OrdinalIgnoreCase) => CarrierTrackingStatus.ReturnedToSender,
                "failure" => CarrierTrackingStatus.DeliveryFailed,
                _ => CarrierTrackingStatus.Unknown
            };

            return CarrierTrackingResult.Ok(mapped, description ?? statusCode, timestamp);
        }, "DHL");

    public async Task<CarrierCancelResult> CancelShipmentAsync(ShippingCarrierContext context, string carrierShipmentId)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = CreateShippingClient(context);
            var url = $"{BaseUrlFor(context)}/orders?profile={Profile}&shipment={Uri.EscapeDataString(carrierShipmentId)}";
            var response = await http.DeleteAsync(url, context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);
                return CarrierLabelResult.Permanent(
                    $"DHL cancellation failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>());
        }, "DHL");

        return result.Success ? CarrierCancelResult.Ok() : CarrierCancelResult.Failed(result.ErrorMessage ?? "unknown");
    }

    public override bool SupportsReturnLabels => true;

    /// <summary>
    /// DHL Parcel DE Returns API v1 — a separate API product next to the shipping API; the
    /// business-portal credentials and dhl-api-key are shared. The return destination is the
    /// configured "Retourenempfänger" (<see cref="DhlCarrierConfig.ReturnReceiverId"/>).
    /// [verify] Returns-API subscription, receiverId values and sandbox behavior during the smoke run.
    /// </summary>
    public override Task<CarrierLabelResult> CreateReturnLabelAsync(ShippingCarrierContext context, ReturnLabelRequest request)
        => ExecuteLabelCallAsync(async () =>
        {
            var config = ParseConfig<DhlCarrierConfig>(context);

            if (string.IsNullOrWhiteSpace(config.ReturnReceiverId))
            {
                return CarrierLabelResult.Permanent(
                    $"Shipping provider '{context.Provider.Name}' has no ReturnReceiverId in AdditionalConfigJson — required for DHL return labels.");
            }

            if (string.IsNullOrWhiteSpace(context.AccountNumber))
            {
                return CarrierLabelResult.Permanent(
                    $"Shipping provider '{context.Provider.Name}' has no EKP (AccountNumber) configured.");
            }

            var body = new
            {
                receiverId = config.ReturnReceiverId,
                customerReference = request.Reference,
                shipper = new
                {
                    name1 = request.CustomerName,
                    name2 = request.CustomerCompany,
                    addressStreet = request.Street,
                    postalCode = request.Zip,
                    city = request.City,
                    country = ToIso3(request.CountryIsoCode),
                    phone = request.CustomerPhone
                },
                itemWeight = new { uom = "kg", value = request.WeightKg }
            };

            var http = CreateShippingClient(context);
            var url = $"{ReturnsBaseUrlFor(context)}/orders?labelType=BOTH";
            var response = await http.PostAsJsonAsync(url, body, JsonOptions, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = $"DHL return-label creation failed ({(int)response.StatusCode}): {Truncate(payload, 500)}";
                return IsPermanentStatusCode(response.StatusCode)
                    ? CarrierLabelResult.Permanent(error)
                    : CarrierLabelResult.Transient(error);
            }

            using var doc = JsonDocument.Parse(payload);
            var root = doc.RootElement;
            var shipmentNo = root.TryGetProperty("shipmentNo", out var no) ? no.GetString() : null;
            var labelB64 = root.TryGetProperty("label", out var label) && label.TryGetProperty("b64", out var b64)
                ? b64.GetString()
                : null;

            if (string.IsNullOrEmpty(shipmentNo) || string.IsNullOrEmpty(labelB64))
            {
                return CarrierLabelResult.Permanent($"DHL return response missing shipment number or label: {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(
                shipmentNo,
                shipmentNo,
                Convert.FromBase64String(labelB64),
                trackingUrl: $"https://www.dhl.de/de/privatkunden/pakete-empfangen/verfolgen.html?piececode={shipmentNo}");
        }, "DHL");

    private static string ReturnsBaseUrlFor(ShippingCarrierContext context)
        => context.UseSandbox
            ? "https://api-sandbox.dhl.com/parcel/de/shipping/returns/v1"
            : "https://api-eu.dhl.com/parcel/de/shipping/returns/v1";

    /// <summary>DHL Parcel DE expects ISO 3166-1 alpha-3 country codes.</summary>
    private static string ToIso3(string iso2)
    {
        try
        {
            return new RegionInfo(iso2).ThreeLetterISORegionName;
        }
        catch (ArgumentException)
        {
            throw new InvalidOperationException($"Unknown ISO country code '{iso2}'.");
        }
    }
}
