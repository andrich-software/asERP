using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using asERP.Domain.Enums;
using asERP.Shipping.Abstractions;
using asERP.Shipping.Connectors.Common;
using asERP.Shipping.Models.Dpd;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Connectors.Dpd;

/// <summary>
/// DPD Cloud Webservice (REST) for label creation and the public DPD tracking REST endpoint.
/// [verify] Cloud staging host, header names and setOrder payload against the official docs —
/// DPD grants sandbox access per integration partner.
/// </summary>
public sealed class DpdConnector : ShippingConnectorBase, IShippingCarrierConnector
{
    internal const string HttpClientName = "dpd";
    internal const string TrackingHttpClientName = "dpd-track";

    private const string ProductionBaseUrl = "https://cloud-ws.dpd.com/api/Cloud";
    // [verify] staging host.
    private const string SandboxBaseUrl = "https://cloud-stage-ws.dpd.com/api/Cloud";
    private const string TrackingBaseUrl = "https://tracking.dpd.de/rest/plc/de_DE";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<DpdConnector> _logger;

    public DpdConnector(IHttpClientFactory httpClientFactory, ILogger<DpdConnector> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public ShippingProviderType Type => ShippingProviderType.Dpd;

    private static string BaseUrlFor(ShippingCarrierContext context)
        => context.UseSandbox ? SandboxBaseUrl : ProductionBaseUrl;

    private HttpClient CreateClient(ShippingCarrierContext context)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        http.Timeout = TimeSpan.FromSeconds(60);
        http.DefaultRequestHeaders.Add("Version", "100");
        http.DefaultRequestHeaders.Add("Language", "de_DE");
        // [verify] header names for cloud user credentials.
        http.DefaultRequestHeaders.Add("UserCredentials-cloudUserID", context.Username);
        http.DefaultRequestHeaders.Add("UserCredentials-Token", context.ApiKey);
        return http;
    }

    public async Task<CarrierConnectionTestResult> TestConnectionAsync(ShippingCarrierContext context)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = CreateClient(context);
            var response = await http.GetAsync($"{BaseUrlFor(context)}/getZipCodeRules", context.CancellationToken);
            return response.IsSuccessStatusCode
                ? CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>())
                : CarrierLabelResult.Permanent($"DPD responded with {(int)response.StatusCode}.");
        }, "DPD");

        return new CarrierConnectionTestResult(result.Success, result.ErrorMessage);
    }

    public Task<CarrierLabelResult> CreateLabelAsync(ShippingCarrierContext context, ShipmentLabelRequest request)
        => ExecuteLabelCallAsync(async () =>
        {
            var config = ParseConfig<DpdCarrierConfig>(context);
            config.Sender.EnsureComplete(context.Provider.Name);

            var body = new
            {
                OrderAction = "startOrder",
                OrderSettings = new
                {
                    ShipDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd"),
                    LabelSize = config.LabelSize,
                    LabelStartPosition = "UpperLeft"
                },
                OrderDataList = new[]
                {
                    new
                    {
                        ShipAddress = new
                        {
                            Company = request.RecipientCompany,
                            Name = request.RecipientName,
                            Street = request.Street,
                            ZipCode = request.Zip,
                            City = request.City,
                            Country = request.CountryIsoCode,
                            Phone = request.RecipientPhone
                        },
                        ParcelData = new
                        {
                            ShipService = config.Product,
                            Weight = request.WeightKg.ToString(CultureInfo.InvariantCulture),
                            Content = request.Reference,
                            YourInternalID = request.Reference,
                            Reference1 = request.Reference
                        }
                    }
                }
            };

            var http = CreateClient(context);
            var response = await http.PostAsJsonAsync($"{BaseUrlFor(context)}/setOrder", body, JsonOptions, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = $"DPD label creation failed ({(int)response.StatusCode}): {Truncate(payload, 500)}";
                return IsPermanentStatusCode(response.StatusCode)
                    ? CarrierLabelResult.Permanent(error)
                    : CarrierLabelResult.Transient(error);
            }

            using var doc = JsonDocument.Parse(payload);
            var root = doc.RootElement;

            // Cloud API reports errors inside a 200 response.
            if (root.TryGetProperty("ErrorDataList", out var errors) && errors.ValueKind == JsonValueKind.Array
                && errors.GetArrayLength() > 0)
            {
                return CarrierLabelResult.Permanent($"DPD rejected the order: {Truncate(errors.ToString(), 500)}");
            }

            var labelResponse = root.TryGetProperty("LabelResponse", out var lr) ? lr : root;
            var parcelNo = labelResponse.TryGetProperty("LabelDataList", out var labels) && labels.GetArrayLength() > 0
                && labels[0].TryGetProperty("ParcelNo", out var p)
                ? p.GetString()
                : null;
            var labelB64 = labelResponse.TryGetProperty("LabelPDF", out var pdf) ? pdf.GetString() : null;

            if (string.IsNullOrEmpty(parcelNo) || string.IsNullOrEmpty(labelB64))
            {
                return CarrierLabelResult.Permanent($"DPD response missing parcel number or label: {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(
                parcelNo,
                parcelNo,
                Convert.FromBase64String(labelB64),
                trackingUrl: $"https://tracking.dpd.de/status/de_DE/parcel/{parcelNo}");
        }, "DPD");

    public Task<CarrierTrackingResult> GetTrackingStatusAsync(ShippingCarrierContext context, string trackingNumber)
        => ExecuteTrackingCallAsync(async () =>
        {
            // Public tracking endpoint — no credentials required.
            var http = _httpClientFactory.CreateClient(TrackingHttpClientName);
            http.Timeout = TimeSpan.FromSeconds(30);

            var response = await http.GetAsync(
                $"{TrackingBaseUrl}/{Uri.EscapeDataString(trackingNumber)}",
                context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return CarrierTrackingResult.Failed(
                    $"DPD tracking failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            using var doc = JsonDocument.Parse(payload);
            if (!doc.RootElement.TryGetProperty("parcellifecycleResponse", out var lifecycle)
                || !lifecycle.TryGetProperty("parcelLifeCycleData", out var data)
                || !data.TryGetProperty("statusInfo", out var statusInfos)
                || statusInfos.GetArrayLength() == 0)
            {
                return CarrierTrackingResult.Ok(CarrierTrackingStatus.Unknown, "No tracking data available yet.");
            }

            // Find the current lifecycle step. [verify] status vocabulary against real responses.
            JsonElement? current = null;
            foreach (var info in statusInfos.EnumerateArray())
            {
                if (info.TryGetProperty("isCurrentStatus", out var isCurrent) && isCurrent.GetBoolean())
                {
                    current = info;
                }
            }

            if (current is null)
            {
                return CarrierTrackingResult.Ok(CarrierTrackingStatus.Unknown, "No current tracking status.");
            }

            var status = current.Value.TryGetProperty("status", out var s) ? s.GetString() : null;
            var description = current.Value.TryGetProperty("label", out var l) && l.TryGetProperty("content", out var c)
                ? c.ToString()
                : status;

            var mapped = status?.ToUpperInvariant() switch
            {
                "ACCEPTED" => CarrierTrackingStatus.PreTransit,
                "AT_SENDING_DEPOT" or "ON_THE_ROAD" or "AT_DELIVERY_DEPOT" => CarrierTrackingStatus.InTransit,
                "OUT_FOR_DELIVERY" or "DELIVERY" => CarrierTrackingStatus.OutForDelivery,
                "DELIVERED" => CarrierTrackingStatus.Delivered,
                "NOT_DELIVERED" or "DELIVERY_FAILED" => CarrierTrackingStatus.DeliveryFailed,
                "BACK_TO_SENDER" or "RETURNED" => CarrierTrackingStatus.ReturnedToSender,
                _ => CarrierTrackingStatus.Unknown
            };

            return CarrierTrackingResult.Ok(mapped, description);
        }, "DPD");

    public Task<CarrierCancelResult> CancelShipmentAsync(ShippingCarrierContext context, string carrierShipmentId)
    {
        // [verify] The DPD Cloud API offers no shipment void — unprinted orders simply expire.
        _logger.LogInformation("DPD cancel requested for {ParcelNo} — not supported by the Cloud API, skipping", carrierShipmentId);
        return Task.FromResult(CarrierCancelResult.Failed(
            "The DPD Cloud API does not support cancelling shipments — the label simply must not be used."));
    }
}
