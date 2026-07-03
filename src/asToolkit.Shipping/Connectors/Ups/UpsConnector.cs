using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using asToolkit.Domain.Enums;
using asToolkit.Shipping.Abstractions;
using asToolkit.Shipping.Connectors.Common;
using asToolkit.Shipping.Models.Ups;
using Microsoft.Extensions.Logging;

namespace asToolkit.Shipping.Connectors.Ups;

/// <summary>
/// UPS Ship + Track APIs with OAuth2 client-credentials auth (<see cref="UpsAuthHelper"/>).
/// The Ship API returns GIF labels — stored as image/gif; the label endpoint serves the correct
/// content type. [verify] Ship API version segment and exact tracking status code set.
/// </summary>
public sealed class UpsConnector : ShippingConnectorBase, IShippingCarrierConnector
{
    internal const string HttpClientName = "ups";

    // [verify] current Ship API version segment.
    private const string ShipApiVersion = "v2409";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UpsAuthHelper _authHelper;
    private readonly ILogger<UpsConnector> _logger;

    public UpsConnector(IHttpClientFactory httpClientFactory, UpsAuthHelper authHelper, ILogger<UpsConnector> logger)
    {
        _httpClientFactory = httpClientFactory;
        _authHelper = authHelper;
        _logger = logger;
    }

    public ShippingProviderType Type => ShippingProviderType.Ups;

    private static string BaseUrlFor(ShippingCarrierContext context)
        => context.UseSandbox ? "https://wwwcie.ups.com" : "https://onlinetools.ups.com";

    private async Task<HttpClient> CreateClientAsync(ShippingCarrierContext context)
    {
        var token = await _authHelper.GetAccessTokenAsync(context);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        http.Timeout = TimeSpan.FromSeconds(60);
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        http.DefaultRequestHeaders.Add("transId", Guid.NewGuid().ToString("N"));
        http.DefaultRequestHeaders.Add("transactionSrc", "asToolkit");
        return http;
    }

    public async Task<CarrierConnectionTestResult> TestConnectionAsync(ShippingCarrierContext context)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            // A successful OAuth exchange proves credentials and connectivity.
            await _authHelper.GetAccessTokenAsync(context);
            return CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>());
        }, "UPS");

        return new CarrierConnectionTestResult(result.Success, result.ErrorMessage);
    }

    public Task<CarrierLabelResult> CreateLabelAsync(ShippingCarrierContext context, ShipmentLabelRequest request)
        => ExecuteLabelCallAsync(async () =>
        {
            var config = ParseConfig<UpsCarrierConfig>(context);
            config.Sender.EnsureComplete(context.Provider.Name);

            if (string.IsNullOrWhiteSpace(context.AccountNumber))
            {
                return CarrierLabelResult.Permanent(
                    $"Shipping provider '{context.Provider.Name}' has no UPS shipper number (AccountNumber) configured.");
            }

            var body = new
            {
                ShipmentRequest = new
                {
                    Shipment = new
                    {
                        Shipper = new
                        {
                            Name = config.Sender.Name,
                            ShipperNumber = context.AccountNumber,
                            Address = new
                            {
                                AddressLine = new[] { config.Sender.Street },
                                City = config.Sender.City,
                                PostalCode = config.Sender.Zip,
                                CountryCode = config.Sender.CountryCode
                            }
                        },
                        ShipTo = new
                        {
                            Name = request.RecipientName,
                            AttentionName = request.RecipientCompany ?? request.RecipientName,
                            Phone = request.RecipientPhone == null ? null : new { Number = request.RecipientPhone },
                            Address = new
                            {
                                AddressLine = new[] { request.Street },
                                City = request.City,
                                PostalCode = request.Zip,
                                CountryCode = request.CountryIsoCode
                            }
                        },
                        PaymentInformation = new
                        {
                            ShipmentCharge = new
                            {
                                Type = "01",
                                BillShipper = new { AccountNumber = context.AccountNumber }
                            }
                        },
                        Service = new { Code = config.ServiceCode },
                        Package = new
                        {
                            Packaging = new { Code = "02" },
                            Dimensions = request.LengthCm.HasValue && request.WidthCm.HasValue && request.HeightCm.HasValue
                                ? new
                                {
                                    UnitOfMeasurement = new { Code = "CM" },
                                    Length = request.LengthCm.Value.ToString(CultureInfo.InvariantCulture),
                                    Width = request.WidthCm.Value.ToString(CultureInfo.InvariantCulture),
                                    Height = request.HeightCm.Value.ToString(CultureInfo.InvariantCulture)
                                }
                                : null,
                            PackageWeight = new
                            {
                                UnitOfMeasurement = new { Code = "KGS" },
                                Weight = request.WeightKg.ToString(CultureInfo.InvariantCulture)
                            }
                        },
                        ReferenceNumber = new { Value = request.Reference }
                    },
                    LabelSpecification = new
                    {
                        LabelImageFormat = new { Code = "GIF" }
                    }
                }
            };

            var http = await CreateClientAsync(context);
            var url = $"{BaseUrlFor(context)}/api/shipments/{ShipApiVersion}/ship";
            var response = await http.PostAsJsonAsync(url, body, JsonOptions, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = $"UPS label creation failed ({(int)response.StatusCode}): {Truncate(payload, 500)}";
                return IsPermanentStatusCode(response.StatusCode)
                    ? CarrierLabelResult.Permanent(error)
                    : CarrierLabelResult.Transient(error);
            }

            using var doc = JsonDocument.Parse(payload);
            var results = doc.RootElement.GetProperty("ShipmentResponse").GetProperty("ShipmentResults");
            var shipmentNumber = results.GetProperty("ShipmentIdentificationNumber").GetString();

            var packageResults = results.GetProperty("PackageResults");
            var firstPackage = packageResults.ValueKind == JsonValueKind.Array ? packageResults[0] : packageResults;
            var labelB64 = firstPackage.GetProperty("ShippingLabel").GetProperty("GraphicImage").GetString();

            if (string.IsNullOrEmpty(shipmentNumber) || string.IsNullOrEmpty(labelB64))
            {
                return CarrierLabelResult.Permanent($"UPS response missing shipment number or label: {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(
                shipmentNumber,
                shipmentNumber,
                Convert.FromBase64String(labelB64),
                labelFormat: "image/gif",
                trackingUrl: $"https://www.ups.com/track?tracknum={shipmentNumber}");
        }, "UPS");

    public Task<CarrierTrackingResult> GetTrackingStatusAsync(ShippingCarrierContext context, string trackingNumber)
        => ExecuteTrackingCallAsync(async () =>
        {
            var http = await CreateClientAsync(context);
            var url = $"{BaseUrlFor(context)}/api/track/v1/details/{Uri.EscapeDataString(trackingNumber)}?locale=en_US";
            var response = await http.GetAsync(url, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return CarrierTrackingResult.Failed(
                    $"UPS tracking failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            using var doc = JsonDocument.Parse(payload);
            var shipments = doc.RootElement.GetProperty("trackResponse").GetProperty("shipment");
            if (shipments.GetArrayLength() == 0)
            {
                return CarrierTrackingResult.Ok(CarrierTrackingStatus.Unknown, "No tracking data available yet.");
            }

            var packages = shipments[0].GetProperty("package");
            var package = packages.ValueKind == JsonValueKind.Array ? packages[0] : packages;
            var activities = package.GetProperty("activity");
            var activity = activities.ValueKind == JsonValueKind.Array ? activities[0] : activities;
            var status = activity.GetProperty("status");

            var type = status.TryGetProperty("type", out var t) ? t.GetString() : null;
            var description = status.TryGetProperty("description", out var d) ? d.GetString() : null;

            // [verify] full UPS status type/code vocabulary against real responses.
            var mapped = type?.ToUpperInvariant() switch
            {
                "M" or "MV" or "P" => CarrierTrackingStatus.PreTransit,
                "I" when description != null && description.Contains("OUT FOR DELIVERY", StringComparison.OrdinalIgnoreCase)
                    => CarrierTrackingStatus.OutForDelivery,
                "I" => CarrierTrackingStatus.InTransit,
                "O" => CarrierTrackingStatus.OutForDelivery,
                "D" => CarrierTrackingStatus.Delivered,
                "RS" => CarrierTrackingStatus.ReturnedToSender,
                "X" => CarrierTrackingStatus.DeliveryFailed,
                _ => CarrierTrackingStatus.Unknown
            };

            return CarrierTrackingResult.Ok(mapped, description ?? type);
        }, "UPS");

    public async Task<CarrierCancelResult> CancelShipmentAsync(ShippingCarrierContext context, string carrierShipmentId)
    {
        var result = await ExecuteLabelCallAsync(async () =>
        {
            var http = await CreateClientAsync(context);
            var url = $"{BaseUrlFor(context)}/api/shipments/{ShipApiVersion}/void/cancel/{Uri.EscapeDataString(carrierShipmentId)}";
            var response = await http.DeleteAsync(url, context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);
                return CarrierLabelResult.Permanent(
                    $"UPS void failed ({(int)response.StatusCode}): {Truncate(payload, 300)}");
            }

            return CarrierLabelResult.Ok(string.Empty, string.Empty, Array.Empty<byte>());
        }, "UPS");

        return result.Success ? CarrierCancelResult.Ok() : CarrierCancelResult.Failed(result.ErrorMessage ?? "unknown");
    }
}
