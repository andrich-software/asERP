using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Web;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.Common;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Models.Amazon;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Connectors.Amazon;

/// <summary>
/// Amazon Selling Partner API (SP-API) connector. One <see cref="SalesChannel"/> row maps to a
/// single (region × marketplace) — multi-marketplace sellers create one channel per marketplace.
///
/// Auth: LWA refresh-token via <see cref="AmazonAuthHelper"/>. AWS SigV4 is no longer required
/// since 2023 — bearer access token alone authenticates regular calls.
///
/// PR 13 ships <see cref="ImportSalessAsync"/> and the export plumbing (Listings PATCH for stock
/// and price); deeper coverage (full ExportProduct / FBA inventory / shipment confirmation feeds)
/// follows the same pattern and lands incrementally.
/// </summary>
public sealed class AmazonConnector : ConnectorBase
{
    private static readonly TimeSpan ImportWindow = TimeSpan.FromDays(30);

    private readonly AmazonAuthHelper _auth;
    private readonly ISalesImportRepository _salesImportRepository;
    private readonly ICustomerImportRepository _customerImportRepository;
    private readonly ILogger<AmazonConnector> _logger;

    public AmazonConnector(
        AmazonAuthHelper auth,
        ISalesImportRepository salesImportRepository,
        ICustomerImportRepository customerImportRepository,
        ILogger<AmazonConnector> logger)
    {
        _auth = auth;
        _salesImportRepository = salesImportRepository;
        _customerImportRepository = customerImportRepository;
        _logger = logger;
    }

    public override SalesChannelType Type => SalesChannelType.Amazon;

    public override SalesChannelCapabilities Capabilities =>
        SalesChannelCapabilities.ImportSaless |
        SalesChannelCapabilities.ImportCustomers |
        SalesChannelCapabilities.UpdateStock |
        SalesChannelCapabilities.UpdatePrice |
        SalesChannelCapabilities.OAuth |
        SalesChannelCapabilities.RequiresMarketplaceId;

    public override async Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context)
    {
        try
        {
            var (config, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken, config);

            // Smoke-test: fetch the seller's marketplace participation.
            var url = $"{config.GetEndpointBaseUrl()}/sellers/v1/marketplaceParticipations";
            var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
            if (response.IsSuccessStatusCode) return new ConnectionTestResult(true);

            var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
            return new ConnectionTestResult(false, $"HTTP {(int)response.StatusCode}: {Truncate(body, 250)}");
        }
        catch (Exception ex)
        {
            return new ConnectionTestResult(false, ex.Message);
        }
    }

    public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
    {
        var salesChannel = context.SalesChannel;
        if (string.IsNullOrEmpty(salesChannel.MarketplaceId))
        {
            return SyncResult.Failed("MarketplaceId is required for Amazon imports");
        }

        var processed = 0;
        var failed = 0;

        try
        {
            var (config, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken, config);

            var createdAfter = DateTime.UtcNow - ImportWindow;
            string? nextToken = null;
            var baseUrl = config.GetEndpointBaseUrl();
            // Guard against an endpoint that repeats a page (or a boundary re-read on token reuse).
            var seen = new HashSet<string>();

            do
            {
                var url = $"{baseUrl}/orders/v0/orders" +
                          $"?MarketplaceIds={HttpUtility.UrlEncode(salesChannel.MarketplaceId)}" +
                          $"&CreatedAfter={createdAfter:O}";
                if (!string.IsNullOrEmpty(nextToken))
                {
                    url += $"&NextToken={HttpUtility.UrlEncode(nextToken)}";
                }

                var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                    _logger.LogError("Amazon orders HTTP {Status}: {Body}", (int)response.StatusCode, Truncate(body, 500));
                    failed++;
                    break;
                }

                var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
                var salessResponse = JsonSerializer.Deserialize<AmazonSalessResponse>(raw);
                var payload = salessResponse?.Payload;
                if (payload?.Saless is null || payload.Saless.Count == 0) break;

                foreach (var sales in payload.Saless)
                {
                    if (string.IsNullOrEmpty(sales.AmazonSalesId) || !seen.Add(sales.AmazonSalesId))
                    {
                        continue;
                    }

                    try
                    {
                        var items = await FetchSalesItemsAsync(context, baseUrl, sales.AmazonSalesId);
                        var importSales = MapSales(sales, items);
                        await _salesImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, importSales);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        _logger.LogError(ex, "Amazon sales import failed for {Id}", sales.AmazonSalesId);
                    }
                }

                if (context.ReportProgressAsync is not null)
                {
                    await context.ReportProgressAsync(processed, failed, context.CancellationToken);
                }

                nextToken = payload.NextToken;
            }
            while (!string.IsNullOrEmpty(nextToken));
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<SyncResult> ImportCustomersAsync(SalesChannelContext context)
    {
        // Amazon does not expose a customer-list endpoint — customers are derived from saless.
        // We piggyback on the sales endpoint and persist buyers via the customer-import path.
        var salesChannel = context.SalesChannel;
        if (string.IsNullOrEmpty(salesChannel.MarketplaceId))
        {
            return SyncResult.Failed("MarketplaceId is required for Amazon imports");
        }

        var processed = 0;
        var failed = 0;

        try
        {
            var (config, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken, config);

            var createdAfter = DateTime.UtcNow - ImportWindow;
            var baseUrl = config.GetEndpointBaseUrl();
            string? nextToken = null;
            // Buyers derived from orders repeat across pages/orders — keep only the first per remote key.
            var seenBuyers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            do
            {
                var url = $"{baseUrl}/orders/v0/orders" +
                          $"?MarketplaceIds={HttpUtility.UrlEncode(salesChannel.MarketplaceId)}" +
                          $"&CreatedAfter={createdAfter:O}";
                if (!string.IsNullOrEmpty(nextToken))
                {
                    url += $"&NextToken={HttpUtility.UrlEncode(nextToken)}";
                }

                var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    return processed > 0
                        ? new SyncResult(processed, failed + 1)
                        : SyncResult.Failed($"Amazon orders HTTP {(int)response.StatusCode}");
                }

                var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
                var salessResponse = JsonSerializer.Deserialize<AmazonSalessResponse>(raw);
                var payload = salessResponse?.Payload;
                if (payload?.Saless is null || payload.Saless.Count == 0) break;

                foreach (var sales in payload.Saless)
                {
                    if (sales.BuyerInfo is null && sales.ShippingAddress is null) continue;

                    var buyerKey = sales.BuyerInfo?.BuyerEmail ?? sales.AmazonSalesId;
                    if (string.IsNullOrEmpty(buyerKey) || !seenBuyers.Add(buyerKey)) continue;

                    try
                    {
                        var importCustomer = MapCustomer(sales);
                        await _customerImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, importCustomer);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        _logger.LogError(ex, "Amazon customer import failed for sales {Id}", sales.AmazonSalesId);
                    }
                }

                nextToken = payload.NextToken;
            }
            while (!string.IsNullOrEmpty(nextToken));
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload)
    {
        try
        {
            var (config, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken, config);

            var url = $"{config.GetEndpointBaseUrl()}/listings/2021-08-01/items/{Uri.EscapeDataString(config.SellerId)}/{Uri.EscapeDataString(payload.Sku)}" +
                      $"?marketplaceIds={HttpUtility.UrlEncode(context.SalesChannel.MarketplaceId)}";

            var body = new
            {
                productType = "PRODUCT",
                patches = new[]
                {
                    new
                    {
                        op = "replace",
                        path = "/attributes/fulfillment_availability",
                        value = new[]
                        {
                            new
                            {
                                fulfillment_channel_code = "DEFAULT",
                                quantity = payload.Quantity,
                            },
                        },
                    },
                },
            };

            var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = JsonContent.Create(body) };
            var response = await context.HttpClient.SendAsync(request, context.CancellationToken);
            if (response.IsSuccessStatusCode) return ExportResult.Ok(payload.RemoteProductId);

            var responseBody = await response.Content.ReadAsStringAsync(context.CancellationToken);
            return ExportResult.Fail($"HTTP {(int)response.StatusCode}: {Truncate(responseBody, 300)}");
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload)
    {
        try
        {
            var (config, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken, config);

            var url = $"{config.GetEndpointBaseUrl()}/listings/2021-08-01/items/{Uri.EscapeDataString(config.SellerId)}/{Uri.EscapeDataString(payload.Sku)}" +
                      $"?marketplaceIds={HttpUtility.UrlEncode(context.SalesChannel.MarketplaceId)}";

            var body = new
            {
                productType = "PRODUCT",
                patches = new[]
                {
                    new
                    {
                        op = "replace",
                        path = "/attributes/purchasable_offer",
                        value = new[]
                        {
                            new
                            {
                                marketplace_id = context.SalesChannel.MarketplaceId,
                                currency = payload.Currency ?? "EUR",
                                our_price = new[]
                                {
                                    new { schedule = new[] { new { value_with_tax = payload.Price } } },
                                },
                            },
                        },
                    },
                },
            };

            var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = JsonContent.Create(body) };
            var response = await context.HttpClient.SendAsync(request, context.CancellationToken);
            if (response.IsSuccessStatusCode) return ExportResult.Ok(payload.RemoteProductId, payload.ExternalListingId);

            var responseBody = await response.Content.ReadAsStringAsync(context.CancellationToken);
            return ExportResult.Fail($"HTTP {(int)response.StatusCode}: {Truncate(responseBody, 300)}");
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    private async Task<(AmazonChannelConfig config, string accessToken)> PrepareAsync(SalesChannelContext context)
    {
        // Channel-specific config (region, sellerId, sandbox flag, ...) still lives in
        // AdditionalConfigJson. App credentials (LWA client_id/secret) are now resolved by the
        // helper itself via IOAuthAppSettingsService — tenant override → system fallback.
        var config = AmazonChannelConfig.FromSalesChannel(context.SalesChannel);
        if (string.IsNullOrEmpty(config.SellerId))
        {
            throw new InvalidOperationException(
                "Amazon channel is missing SellerId in AdditionalConfigJson");
        }

        var accessToken = await _auth.GetAccessTokenAsync(context.SalesChannel, context.CancellationToken);

        return (config, accessToken);
    }

    private static void ConfigureBearer(SalesChannelContext context, string accessToken, AmazonChannelConfig config)
    {
        context.HttpClient.DefaultRequestHeaders.Accept.Clear();
        context.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        context.HttpClient.DefaultRequestHeaders.Remove("x-amz-access-token");
        context.HttpClient.DefaultRequestHeaders.Add("x-amz-access-token", accessToken);
        context.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    /// <summary>
    /// Pulls all order-item pages for one order via GET /orders/v0/orders/{id}/orderItems, following
    /// the payload's NextToken. Order items are a separate SP-API resource — the order list never
    /// carries them — so each imported order needs this extra call to populate its positions.
    /// </summary>
    private async Task<List<AmazonSalesItem>> FetchSalesItemsAsync(SalesChannelContext context, string baseUrl, string amazonOrderId)
    {
        var items = new List<AmazonSalesItem>();
        string? nextToken = null;

        do
        {
            var url = $"{baseUrl}/orders/v0/orders/{Uri.EscapeDataString(amazonOrderId)}/orderItems";
            if (!string.IsNullOrEmpty(nextToken))
            {
                url += $"?NextToken={HttpUtility.UrlEncode(nextToken)}";
            }

            var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                throw new InvalidOperationException(
                    $"Amazon orderItems for {amazonOrderId} failed with HTTP {(int)response.StatusCode}: {Truncate(body, 300)}");
            }

            var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
            var payload = JsonSerializer.Deserialize<AmazonSalesItemsResponse>(raw)?.Payload;
            if (payload?.SalesItems is { Count: > 0 })
            {
                items.AddRange(payload.SalesItems);
            }

            nextToken = payload?.NextToken;
        }
        while (!string.IsNullOrEmpty(nextToken));

        return items;
    }

    private static SalesChannelImportSales MapSales(AmazonSales sales, IReadOnlyList<AmazonSalesItem> items)
    {
        var total = decimal.TryParse(sales.SalesTotal?.Amount, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var t) ? t : 0m;

        var salesItems = items
            .Select(i =>
            {
                var itemPrice = ParseMoney(i.ItemPrice?.Amount);
                var itemTax = ParseMoney(i.ItemTax?.Amount);
                var quantity = i.QuantityOrdered > 0 ? i.QuantityOrdered : 0;
                return new SalesChannelImportSalesItem
                {
                    Sku = i.SellerSku ?? string.Empty,
                    Name = i.Title ?? i.SellerSku ?? string.Empty,
                    Ean = string.Empty,
                    Quantity = quantity,
                    // ItemPrice is the line total (all units); the import model carries a unit price.
                    Price = quantity > 0 ? itemPrice / quantity : itemPrice,
                    TaxRate = ComputeLineTaxRate(itemPrice, itemTax),
                };
            })
            .ToList();

        var itemsTax = items.Sum(i => ParseMoney(i.ItemTax?.Amount));

        var billingAddress = sales.ShippingAddress is null
            ? new SalesChannelImportCustomerAddress()
            : new SalesChannelImportCustomerAddress
            {
                Street = sales.ShippingAddress.AddressLine1 ?? string.Empty,
                City = sales.ShippingAddress.City ?? string.Empty,
                Zip = sales.ShippingAddress.PostalCode ?? string.Empty,
                Country = sales.ShippingAddress.CountryCode ?? string.Empty,
            };

        var importSales = new SalesChannelImportSales
        {
            RemoteSalesId = sales.AmazonSalesId,
            DateSalesed = sales.PurchaseDate,
            Status = MapSalesStatus(sales.SalesStatus),
            PaymentStatus = PaymentStatus.CompletelyPaid,
            PaymentMethod = "Amazon",
            PaymentProvider = "Amazon",
            Subtotal = total - itemsTax,
            Total = total,
            ShippingCost = 0m,
            TotalTax = itemsTax,
            CustomerNote = string.Empty,
            SalesItems = salesItems,
            Customer = new SalesChannelImportCustomer
            {
                Email = sales.BuyerInfo?.BuyerEmail ?? string.Empty,
                Firstname = sales.BuyerInfo?.BuyerName ?? string.Empty,
                Lastname = string.Empty,
                Phone = sales.ShippingAddress?.Phone ?? string.Empty,
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = DateTime.UtcNow,
                BillingAddress = billingAddress,
                ShippingAddress = billingAddress,
            },
            BillingAddress = billingAddress,
            ShippingAddress = billingAddress,
        };

        return importSales;
    }

    private static SalesChannelImportCustomer MapCustomer(AmazonSales sales)
    {
        var addr = sales.ShippingAddress is null
            ? new SalesChannelImportCustomerAddress()
            : new SalesChannelImportCustomerAddress
            {
                Street = sales.ShippingAddress.AddressLine1 ?? string.Empty,
                City = sales.ShippingAddress.City ?? string.Empty,
                Zip = sales.ShippingAddress.PostalCode ?? string.Empty,
                Country = sales.ShippingAddress.CountryCode ?? string.Empty,
            };

        return new SalesChannelImportCustomer
        {
            RemoteCustomerId = sales.BuyerInfo?.BuyerEmail ?? sales.AmazonSalesId,
            Email = sales.BuyerInfo?.BuyerEmail ?? string.Empty,
            Firstname = sales.BuyerInfo?.BuyerName ?? string.Empty,
            Lastname = string.Empty,
            Phone = sales.ShippingAddress?.Phone ?? string.Empty,
            CustomerStatus = CustomerStatus.Active,
            DateEnrollment = DateTime.UtcNow,
            BillingAddress = addr,
            ShippingAddress = addr,
        };
    }

    private static SalesStatus MapSalesStatus(string status) => status?.ToLowerInvariant() switch
    {
        "pending" => SalesStatus.Pending,
        "unshipped" => SalesStatus.Processing,
        "partiallyshipped" => SalesStatus.Processing,
        "shipped" => SalesStatus.Completed,
        "canceled" or "cancelled" => SalesStatus.Cancelled,
        _ => SalesStatus.Unknown,
    };

    private static decimal ParseMoney(string? amount) =>
        decimal.TryParse(amount, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var v) ? v : 0m;

    // SP-API exposes a line's tax as a money amount, not a rate — derive the percentage from the
    // line total. Mirrors the eBay/WooCommerce line-tax computation.
    private static double ComputeLineTaxRate(decimal lineTotal, decimal lineTax)
    {
        var net = lineTotal - lineTax;
        if (net <= 0m || lineTax <= 0m)
        {
            return 0;
        }

        return (double)Math.Round(lineTax / net * 100m, 0);
    }

    private static string Truncate(string value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value ?? string.Empty;
        return value.Length <= max ? value : value[..max];
    }
}
