#nullable disable
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.Common;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Models.eBay;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Connectors.Ebay;

/// <summary>
/// eBay Sell-API connector (Inventory + Fulfillment APIs).
///
/// Imports: inventory items (incl. variation groups and photos) via the Inventory API; orders and
/// buyers via the Fulfillment API's <c>getOrders</c>. Customers are derived from orders — eBay does
/// not expose a customer list endpoint — so <see cref="ImportCustomersAsync"/> walks the same order
/// pages and keeps the buyers.
///
/// Exports: <see cref="ExportProductAsync"/> pushes the inventory item and creates/publishes an
/// offer when the channel's <see cref="EbayChannelConfig"/> carries the seller's business policies;
/// stock and price updates go through <c>bulkUpdatePriceQuantity</c> (the granular endpoint — a
/// <c>createOrReplaceInventoryItem</c>/<c>updateOffer</c> PUT would REPLACE the whole resource and
/// wipe every field not sent). <see cref="UpdateSalesAsync"/> confirms shipment via
/// <c>createShippingFulfillment</c>; <see cref="DelistProductAsync"/> withdraws the offer.
/// </summary>
public sealed class EbayConnector : ConnectorBase
{
    private const int InventoryPageSize = 100;
    private const int OrdersPageSize = 100;

    private readonly EbayAuthHelper _authHelper;
    private readonly IProductImportRepository _productImportRepository;
    private readonly ISalesImportRepository _salesImportRepository;
    private readonly ICustomerImportRepository _customerImportRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly ILogger<EbayConnector> _logger;

    public EbayConnector(
        EbayAuthHelper authHelper,
        IProductImportRepository productImportRepository,
        ISalesImportRepository salesImportRepository,
        ICustomerImportRepository customerImportRepository,
        ISalesChannelRepository salesChannelRepository,
        ILogger<EbayConnector> logger)
    {
        _authHelper = authHelper;
        _productImportRepository = productImportRepository;
        _salesImportRepository = salesImportRepository;
        _customerImportRepository = customerImportRepository;
        _salesChannelRepository = salesChannelRepository;
        _logger = logger;
    }

    public override SalesChannelType Type => SalesChannelType.eBay;

    public override SalesChannelCapabilities Capabilities =>
        SalesChannelCapabilities.ImportProducts |
        SalesChannelCapabilities.ImportSaless |
        SalesChannelCapabilities.ImportCustomers |
        SalesChannelCapabilities.ExportProducts |
        SalesChannelCapabilities.UpdateStock |
        SalesChannelCapabilities.UpdatePrice |
        SalesChannelCapabilities.UpdateSaless |
        SalesChannelCapabilities.DelistProducts |
        SalesChannelCapabilities.OAuth;

    public override async Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context)
    {
        try
        {
            var token = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            return string.IsNullOrEmpty(token)
                ? new ConnectionTestResult(false, "No access token returned")
                : new ConnectionTestResult(true);
        }
        catch (Exception ex)
        {
            return new ConnectionTestResult(false, ex.Message);
        }
    }

    public override async Task<SyncResult> ImportProductsAsync(SalesChannelContext context)
    {
        var salesChannel = context.SalesChannel;
        try
        {
            SalesChannelUrlValidator.Validate(salesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        var processed = 0;
        var failed = 0;
        var offset = 0;
        var total = 0;

        // Variation listings: remember per-SKU data and the group keys seen during the walk,
        // then import each inventory item group as a variant parent afterwards (best effort).
        var groupKeys = new HashSet<string>();
        var itemsBySku = new Dictionary<string, (EbayInventoryItem Item, decimal Price)>();

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(salesChannel);
            ConfigureBearer(context, accessToken);

            do
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                var requestUrl = $"{salesChannel.Url}/sell/inventory/v1/inventory_item?limit={InventoryPageSize}&offset={offset}";
                var response = await context.HttpClient.GetAsync(requestUrl, context.CancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                    _logger.LogError("eBay inventory list HTTP {Status}: {Body}", (int)response.StatusCode, body);
                    failed++;
                    break;
                }

                var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
                var inventoryItems = JsonSerializer.Deserialize<EbayInventoryItemResponse>(raw);
                if (inventoryItems?.InventoryItems is null || inventoryItems.InventoryItems.Length == 0) break;
                total = inventoryItems.Total;

                foreach (var item in inventoryItems.InventoryItems)
                {
                    try
                    {
                        var offerUrl = $"{salesChannel.Url}/sell/inventory/v1/offer?sku={Uri.EscapeDataString(item.Sku)}";
                        var offerResponse = await context.HttpClient.GetAsync(offerUrl, context.CancellationToken);
                        if (!offerResponse.IsSuccessStatusCode)
                        {
                            failed++;
                            continue;
                        }

                        var offerRaw = await offerResponse.Content.ReadAsStringAsync(context.CancellationToken);
                        var offers = JsonSerializer.Deserialize<EbayOfferResponse>(offerRaw);
                        if (offers?.Offers is null || offers.Offers.Length == 0)
                        {
                            continue;
                        }

                        var offer = offers.Offers[0];
                        var importProduct = new SalesChannelImportProduct
                        {
                            RemoteProductId = item.Sku,
                            Name = item.Product.Title,
                            Sku = item.Sku,
                            Ean = item.Product.Ean is { Length: > 0 } ? item.Product.Ean[0] : string.Empty,
                            Price = offer.PricingSummary.Price.Value,
                            TaxRate = 19,
                            Description = Truncate(item.Product.Description ?? string.Empty, 4000),
                            Images = MapImages(item.Product.ImageUrls),
                        };

                        await _productImportRepository.ImportOrUpdateFromSalesChannel(salesChannel.Id, importProduct);
                        processed++;

                        if (item.GroupIds is { Length: > 0 })
                        {
                            itemsBySku[item.Sku] = (item, offer.PricingSummary.Price.Value);
                            foreach (var groupKey in item.GroupIds)
                            {
                                groupKeys.Add(groupKey);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        _logger.LogError(ex, "eBay product import failed for SKU {Sku}", item.Sku);
                    }
                }

                if (context.ReportProgressAsync is not null)
                {
                    await context.ReportProgressAsync(processed, failed, context.CancellationToken);
                }

                offset += InventoryPageSize;
            }
            while (total > 0 && offset < total);

            // Best-effort variation grouping: import each seen inventory item group as a
            // variant parent. The member SKUs were already imported flat above; the import
            // repository converts them to variants via its SKU matching.
            foreach (var groupKey in groupKeys)
            {
                try
                {
                    var groupUrl = $"{salesChannel.Url}/sell/inventory/v1/inventory_item_group/{Uri.EscapeDataString(groupKey)}";
                    var groupResponse = await context.HttpClient.GetAsync(groupUrl, context.CancellationToken);
                    if (!groupResponse.IsSuccessStatusCode)
                    {
                        failed++;
                        _logger.LogWarning("eBay inventory item group {GroupKey} fetch failed with HTTP {Status}",
                            groupKey, (int)groupResponse.StatusCode);
                        continue;
                    }

                    var groupRaw = await groupResponse.Content.ReadAsStringAsync(context.CancellationToken);
                    var group = JsonSerializer.Deserialize<EbayInventoryItemGroup>(groupRaw);
                    if (group?.VariantSkus is null || group.VariantSkus.Length == 0)
                    {
                        continue;
                    }

                    var axisNames = group.VariesBy?.Specifications?
                        .Select(s => s.Name)
                        .Where(n => !string.IsNullOrEmpty(n))
                        .ToList() ?? [];

                    var parentImport = new SalesChannelImportProduct
                    {
                        RemoteProductId = group.InventoryItemGroupKey,
                        Name = group.Title ?? group.InventoryItemGroupKey,
                        Sku = group.InventoryItemGroupKey,
                        TaxRate = 19,
                        Description = Truncate(group.Description ?? string.Empty, 4000),
                        IsVariantParent = true,
                        VariantAxes = axisNames,
                        Images = MapImages(group.ImageUrls),
                        Variants = group.VariantSkus
                            .Where(sku => itemsBySku.ContainsKey(sku))
                            .Select((sku, index) =>
                            {
                                var (item, price) = itemsBySku[sku];
                                return new SalesChannelImportVariant
                                {
                                    RemoteVariantId = sku,
                                    Sku = sku,
                                    Ean = item.Product?.Ean is { Length: > 0 } ? item.Product.Ean[0] : null,
                                    Price = price,
                                    Stock = item.Availability?.ShipToLocationAvailability?.Quantity ?? 0,
                                    SortOrder = index,
                                    // The varying aspects per SKU come from the item's product aspects
                                    Options = axisNames
                                        .Select(axis => new SalesChannelImportVariantOption
                                        {
                                            AttributeName = axis,
                                            Value = item.Product?.Aspects != null
                                                    && item.Product.Aspects.TryGetValue(axis, out var values)
                                                    && values is { Length: > 0 }
                                                ? values[0]
                                                : string.Empty,
                                        })
                                        .Where(o => !string.IsNullOrEmpty(o.Value))
                                        .ToList(),
                                };
                            }).ToList(),
                    };

                    await _productImportRepository.ImportOrUpdateFromSalesChannel(salesChannel.Id, parentImport);
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "eBay variation group import failed for {GroupKey}", groupKey);
                }
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        if (!salesChannel.InitialProductImportCompleted)
        {
            salesChannel.InitialProductImportCompleted = true;
            await _salesChannelRepository.UpdateAsync(salesChannel);
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
    {
        var salesChannel = context.SalesChannel;
        try
        {
            SalesChannelUrlValidator.Validate(salesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        var processed = 0;
        var failed = 0;

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(salesChannel);
            ConfigureBearer(context, accessToken);

            await WalkOrdersAsync(context, async order =>
            {
                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, MapSales(order));
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "eBay sales import failed for order {Id}", order.OrderId);
                }
            }, () => (processed, failed));
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return processed > 0 ? new SyncResult(processed, failed + 1) : SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<SyncResult> ImportCustomersAsync(SalesChannelContext context)
    {
        var salesChannel = context.SalesChannel;
        try
        {
            SalesChannelUrlValidator.Validate(salesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        var processed = 0;
        var failed = 0;
        var seenBuyers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(salesChannel);
            ConfigureBearer(context, accessToken);

            await WalkOrdersAsync(context, async order =>
            {
                var username = order.Buyer?.Username;
                if (string.IsNullOrEmpty(username) || !seenBuyers.Add(username))
                {
                    return;
                }

                try
                {
                    await _customerImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, MapCustomer(order));
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "eBay customer import failed for buyer {Buyer}", username);
                }
            }, () => (processed, failed));
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return processed > 0 ? new SyncResult(processed, failed + 1) : SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    /// <summary>
    /// Walks the Fulfillment API's order pages (offset paging over <c>total</c>) and invokes
    /// <paramref name="handleOrderAsync"/> per order. Scheduled runs pull incrementally via the
    /// <c>lastmodifieddate</c> filter from <see cref="SalesChannelContext.IncrementalSince"/>
    /// (manual runs come with a null watermark → full sweep, capped by eBay's 90-day order
    /// retention). A seen-set guards against an endpoint repeating pages.
    /// </summary>
    private async Task WalkOrdersAsync(
        SalesChannelContext context,
        Func<EbayOrder, Task> handleOrderAsync,
        Func<(int Processed, int Failed)> counts)
    {
        var salesChannel = context.SalesChannel;
        var offset = 0;
        var seen = new HashSet<string>();

        var filter = context.IncrementalSince is { } since
            ? $"&filter=lastmodifieddate:%5B{since.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.fff}Z..%5D"
            : string.Empty;

        while (true)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var url = $"{salesChannel.Url}/sell/fulfillment/v1/order?limit={OrdersPageSize}&offset={offset}{filter}";
            var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                throw new InvalidOperationException($"eBay getOrders failed with HTTP {(int)response.StatusCode}: {Truncate(body, 300)}");
            }

            var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
            var page = JsonSerializer.Deserialize<EbayOrdersResponse>(raw);
            if (page?.Orders is null || page.Orders.Length == 0)
            {
                break;
            }

            context.SyncRun.ItemsTotal ??= page.Total;

            var newInPage = 0;
            foreach (var order in page.Orders)
            {
                if (string.IsNullOrEmpty(order.OrderId) || !seen.Add(order.OrderId))
                {
                    continue;
                }
                newInPage++;

                await handleOrderAsync(order);
            }

            if (context.ReportProgressAsync is not null)
            {
                var (processed, failedCount) = counts();
                await context.ReportProgressAsync(processed, failedCount, context.CancellationToken);
            }

            offset += OrdersPageSize;

            // Short page, endpoint repeating rows, or walked past the reported total → done.
            if (page.Orders.Length < OrdersPageSize || newInPage == 0 || (page.Total > 0 && offset >= page.Total))
            {
                break;
            }
        }
    }

    public override async Task<ExportResult> ExportProductAsync(SalesChannelContext context, ProductExportPayload payload)
    {
        if (string.IsNullOrEmpty(payload.Sku))
        {
            return ExportResult.Fail("eBay requires a SKU to export a product");
        }

        var config = EbayChannelConfig.FromSalesChannel(context.SalesChannel);

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            ConfigureBearer(context, accessToken);

            // 1. Push the inventory item. createOrReplaceInventoryItem is a full replace, which is
            //    exactly right here: asERP is the source of truth for exported products.
            var itemUrl = $"{context.SalesChannel.Url}/sell/inventory/v1/inventory_item/{Uri.EscapeDataString(payload.Sku)}";
            var itemBody = new Dictionary<string, object>
            {
                ["product"] = BuildInventoryProduct(payload),
                ["availability"] = new { shipToLocationAvailability = new { quantity = payload.Stock } },
                ["condition"] = "NEW",
            };
            var itemRequest = new HttpRequestMessage(HttpMethod.Put, itemUrl) { Content = JsonContent.Create(itemBody) };
            itemRequest.Content.Headers.ContentLanguage.Add(config.ContentLanguage);
            var itemResponse = await context.HttpClient.SendAsync(itemRequest, context.CancellationToken);
            if (!itemResponse.IsSuccessStatusCode)
            {
                var body = await itemResponse.Content.ReadAsStringAsync(context.CancellationToken);
                return ExportResult.Fail($"createOrReplaceInventoryItem HTTP {(int)itemResponse.StatusCode}: {Truncate(body, 300)}");
            }

            // 2. Offer: update the existing one, or create + publish a new listing when the
            //    channel is configured for it.
            var offerId = payload.ExternalListingId;
            if (string.IsNullOrEmpty(offerId))
            {
                offerId = await FindOfferIdBySkuAsync(context, payload.Sku);
            }

            if (!string.IsNullOrEmpty(offerId))
            {
                // Listing already exists — sync price + quantity via the granular bulk endpoint.
                var update = await BulkUpdatePriceQuantityAsync(
                    context, payload.Sku, payload.Stock, offerId, payload.Price, payload.Currency);
                return update.Success
                    ? ExportResult.Ok(payload.Sku, offerId)
                    : update;
            }

            var categoryId = ResolveCategoryId(payload.MetadataJson, config);
            var missing = config.MissingOfferSettings();
            if (missing is not null || string.IsNullOrEmpty(categoryId))
            {
                var missingAll = string.IsNullOrEmpty(categoryId)
                    ? missing is null ? "categoryId" : $"{missing}, categoryId"
                    : missing;
                return ExportResult.Fail(
                    $"Inventory item {payload.Sku} pushed, but no offer exists and the channel configuration " +
                    $"is missing: {missingAll}. Configure them in the eBay channel's additional settings to publish listings.");
            }

            var offerBody = new Dictionary<string, object>
            {
                ["sku"] = payload.Sku,
                ["marketplaceId"] = config.MarketplaceId,
                ["format"] = "FIXED_PRICE",
                ["availableQuantity"] = payload.Stock,
                ["categoryId"] = categoryId,
                ["merchantLocationKey"] = config.MerchantLocationKey,
                ["listingDescription"] = Truncate(payload.Description ?? payload.Name, 4000),
                ["listingPolicies"] = new
                {
                    fulfillmentPolicyId = config.FulfillmentPolicyId,
                    paymentPolicyId = config.PaymentPolicyId,
                    returnPolicyId = config.ReturnPolicyId,
                },
                ["pricingSummary"] = new
                {
                    price = new
                    {
                        currency = payload.Currency ?? "EUR",
                        value = payload.Price.ToString(CultureInfo.InvariantCulture),
                    },
                },
            };

            var createRequest = new HttpRequestMessage(
                HttpMethod.Post, $"{context.SalesChannel.Url}/sell/inventory/v1/offer")
            {
                Content = JsonContent.Create(offerBody),
            };
            createRequest.Content.Headers.ContentLanguage.Add(config.ContentLanguage);
            var createResponse = await context.HttpClient.SendAsync(createRequest, context.CancellationToken);
            if (!createResponse.IsSuccessStatusCode)
            {
                var body = await createResponse.Content.ReadAsStringAsync(context.CancellationToken);
                return ExportResult.Fail($"createOffer HTTP {(int)createResponse.StatusCode}: {Truncate(body, 300)}");
            }

            var created = await createResponse.Content.ReadFromJsonAsync<EbayOffer>(cancellationToken: context.CancellationToken);
            offerId = created?.OfferId;
            if (string.IsNullOrEmpty(offerId))
            {
                return ExportResult.Fail("createOffer succeeded but returned no offerId");
            }

            var publishResponse = await context.HttpClient.PostAsync(
                $"{context.SalesChannel.Url}/sell/inventory/v1/offer/{Uri.EscapeDataString(offerId)}/publish",
                content: null,
                context.CancellationToken);
            if (!publishResponse.IsSuccessStatusCode)
            {
                var body = await publishResponse.Content.ReadAsStringAsync(context.CancellationToken);
                return ExportResult.Fail($"Offer {offerId} created but publish failed with HTTP {(int)publishResponse.StatusCode}: {Truncate(body, 300)}");
            }

            return ExportResult.Ok(payload.Sku, offerId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.Sku))
        {
            return ExportResult.Fail("eBay SKU is required for stock updates");
        }

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            ConfigureBearer(context, accessToken);

            return await BulkUpdatePriceQuantityAsync(context, payload.Sku, payload.Quantity, offerId: null, price: null, currency: null);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.Sku))
        {
            return ExportResult.Fail("eBay SKU is required for price updates");
        }

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            ConfigureBearer(context, accessToken);

            // Price lives on the offer; resolve the offer id from the payload or by SKU lookup.
            var offerId = payload.ExternalListingId;
            if (string.IsNullOrEmpty(offerId))
            {
                offerId = await FindOfferIdBySkuAsync(context, payload.Sku);
            }
            if (string.IsNullOrEmpty(offerId))
            {
                return ExportResult.Fail($"No eBay offer found for SKU {payload.Sku} — export the product first");
            }

            var result = await BulkUpdatePriceQuantityAsync(context, payload.Sku, quantity: null, offerId, payload.Price, payload.Currency);
            return result.Success
                ? ExportResult.Ok(payload.RemoteProductId, offerId)
                : result;
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdateSalesAsync(SalesChannelContext context, SalesUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteSalesId))
        {
            return ExportResult.Fail("eBay order id (RemoteSalesId) is required for order updates");
        }

        // Only a shipment is propagated to eBay. Cancellations/refunds need buyer-driven flows
        // in eBay's own tooling; every other local status change is a no-op by design.
        if (!Enum.TryParse<SalesStatus>(payload.Status, out var status)
            || status is not (SalesStatus.Completed or SalesStatus.PartiallyDelivered))
        {
            return ExportResult.Ok(payload.RemoteSalesId);
        }

        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            ConfigureBearer(context, accessToken);

            var orderUrl = $"{context.SalesChannel.Url}/sell/fulfillment/v1/order/{Uri.EscapeDataString(payload.RemoteSalesId)}";
            var orderResponse = await context.HttpClient.GetAsync(orderUrl, context.CancellationToken);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return ExportResult.Fail($"getOrder HTTP {(int)orderResponse.StatusCode}");
            }

            var order = JsonSerializer.Deserialize<EbayOrder>(
                await orderResponse.Content.ReadAsStringAsync(context.CancellationToken));
            if (order?.LineItems is null || order.LineItems.Length == 0)
            {
                return ExportResult.Fail($"eBay order {payload.RemoteSalesId} has no line items to fulfill");
            }
            if (string.Equals(order.OrderFulfillmentStatus, "FULFILLED", StringComparison.OrdinalIgnoreCase))
            {
                return ExportResult.Ok(payload.RemoteSalesId);
            }

            var body = new Dictionary<string, object>
            {
                ["lineItems"] = order.LineItems
                    .Select(li => new { lineItemId = li.LineItemId, quantity = li.Quantity })
                    .ToArray(),
                ["shippedDate"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
            };
            // eBay requires tracking number and carrier together or not at all.
            if (!string.IsNullOrEmpty(payload.TrackingNumber) && !string.IsNullOrEmpty(payload.ShippingProvider))
            {
                body["trackingNumber"] = payload.TrackingNumber;
                body["shippingCarrierCode"] = payload.ShippingProvider;
            }

            var response = await context.HttpClient.PostAsync(
                $"{orderUrl}/shipping_fulfillment",
                JsonContent.Create(body),
                context.CancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync(context.CancellationToken);
                return ExportResult.Fail($"createShippingFulfillment HTTP {(int)response.StatusCode}: {Truncate(responseBody, 300)}");
            }

            return ExportResult.Ok(payload.RemoteSalesId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> DelistProductAsync(SalesChannelContext context, DelistPayload payload)
    {
        try
        {
            var accessToken = await _authHelper.GetAccessTokenAsync(context.SalesChannel);
            ConfigureBearer(context, accessToken);

            var offerId = payload.ExternalListingId;
            if (string.IsNullOrEmpty(offerId) && !string.IsNullOrEmpty(payload.Sku))
            {
                offerId = await FindOfferIdBySkuAsync(context, payload.Sku);
            }
            if (string.IsNullOrEmpty(offerId))
            {
                // Nothing listed on eBay for this product — delist is already satisfied.
                return ExportResult.Ok(payload.RemoteProductId);
            }

            var response = await context.HttpClient.PostAsync(
                $"{context.SalesChannel.Url}/sell/inventory/v1/offer/{Uri.EscapeDataString(offerId)}/withdraw",
                content: null,
                context.CancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                return ExportResult.Fail($"withdrawOffer HTTP {(int)response.StatusCode}: {Truncate(body, 300)}");
            }

            return ExportResult.Ok(payload.RemoteProductId, offerId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    /// <summary>
    /// Granular price/quantity sync via <c>bulkUpdatePriceQuantity</c>. Unlike the resource PUTs
    /// (<c>createOrReplaceInventoryItem</c> / <c>updateOffer</c>), this endpoint only touches the
    /// fields sent — a stock update cannot wipe the listing's title/description/aspects. The HTTP
    /// call returns 200 even when individual entries fail, so the per-entry status is checked too.
    /// </summary>
    private static async Task<ExportResult> BulkUpdatePriceQuantityAsync(
        SalesChannelContext context,
        string sku,
        int? quantity,
        string offerId,
        decimal? price,
        string currency)
    {
        var request = new Dictionary<string, object> { ["sku"] = sku };
        if (quantity.HasValue)
        {
            request["shipToLocationAvailability"] = new { quantity = quantity.Value };
        }
        if (price.HasValue && !string.IsNullOrEmpty(offerId))
        {
            request["offers"] = new object[]
            {
                new
                {
                    offerId,
                    price = new
                    {
                        currency = currency ?? "EUR",
                        value = price.Value.ToString(CultureInfo.InvariantCulture),
                    },
                },
            };
        }

        var response = await context.HttpClient.PostAsync(
            $"{context.SalesChannel.Url}/sell/inventory/v1/bulk_update_price_quantity",
            JsonContent.Create(new { requests = new[] { request } }),
            context.CancellationToken);

        var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return ExportResult.Fail($"bulkUpdatePriceQuantity HTTP {(int)response.StatusCode}: {Truncate(raw, 300)}");
        }

        var result = JsonSerializer.Deserialize<EbayBulkPriceQuantityResponse>(raw);
        var entry = result?.Responses?.FirstOrDefault();
        if (entry is not null && entry.StatusCode is < 200 or >= 300)
        {
            return ExportResult.Fail($"bulkUpdatePriceQuantity entry for {sku} failed with status {entry.StatusCode}: {Truncate(raw, 300)}");
        }

        return ExportResult.Ok(sku, offerId);
    }

    private static async Task<string> FindOfferIdBySkuAsync(SalesChannelContext context, string sku)
    {
        var response = await context.HttpClient.GetAsync(
            $"{context.SalesChannel.Url}/sell/inventory/v1/offer?sku={Uri.EscapeDataString(sku)}",
            context.CancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var offers = JsonSerializer.Deserialize<EbayOfferResponse>(
            await response.Content.ReadAsStringAsync(context.CancellationToken));
        return offers?.Offers is { Length: > 0 } ? offers.Offers[0].OfferId : null;
    }

    /// <summary>Product payload for createOrReplaceInventoryItem; eBay caps titles at 80 chars.</summary>
    private static Dictionary<string, object> BuildInventoryProduct(ProductExportPayload payload)
    {
        var product = new Dictionary<string, object>
        {
            ["title"] = Truncate(payload.Name, 80),
        };
        if (!string.IsNullOrEmpty(payload.Description))
        {
            product["description"] = Truncate(payload.Description, 4000);
        }
        if (!string.IsNullOrEmpty(payload.Brand))
        {
            product["brand"] = payload.Brand;
        }
        if (!string.IsNullOrEmpty(payload.Mpn))
        {
            product["mpn"] = payload.Mpn;
        }
        var ean = payload.Ean ?? payload.Gtin;
        if (!string.IsNullOrEmpty(ean))
        {
            product["ean"] = new[] { ean };
        }
        return product;
    }

    /// <summary>Product-level category override from ProductSalesChannel.MetadataJson, else the channel default.</summary>
    private static string ResolveCategoryId(string metadataJson, EbayChannelConfig config)
    {
        if (!string.IsNullOrEmpty(metadataJson))
        {
            try
            {
                using var doc = JsonDocument.Parse(metadataJson);
                if (doc.RootElement.ValueKind == JsonValueKind.Object
                    && doc.RootElement.TryGetProperty("categoryId", out var category)
                    && category.ValueKind == JsonValueKind.String
                    && !string.IsNullOrEmpty(category.GetString()))
                {
                    return category.GetString();
                }
            }
            catch (JsonException)
            {
                // Malformed metadata never blocks the export — fall through to the channel default.
            }
        }

        return config.CategoryId;
    }

    private static void ConfigureBearer(SalesChannelContext context, string accessToken)
    {
        context.HttpClient.DefaultRequestHeaders.Accept.Clear();
        context.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        context.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    private static SalesChannelImportSales MapSales(EbayOrder order)
    {
        var shipTo = GetShipTo(order);
        // Name/email/phone live on the registration contact; the shipTo contact is the fallback.
        var contact = order.Buyer?.BuyerRegistrationAddress ?? shipTo;
        var (firstname, lastname) = SplitFullName(contact?.FullName);

        var billingAddress = MapAddress(contact, firstname, lastname);
        var shippingAddress = MapShippingAddress(shipTo, billingAddress);

        var sales = new SalesChannelImportSales
        {
            RemoteSalesId = order.OrderId,
            RemoteCustomerId = order.Buyer?.Username ?? string.Empty,
            DateSalesed = ToUtc(order.CreationDate),
            Subtotal = order.PricingSummary?.PriceSubtotal?.Value ?? 0m,
            ShippingCost = order.PricingSummary?.DeliveryCost?.Value ?? 0m,
            TotalTax = order.PricingSummary?.Tax?.Value ?? 0m,
            Total = order.PricingSummary?.Total?.Value ?? 0m,
            Status = MapSalesStatus(order),
            PaymentStatus = MapPaymentStatus(order.OrderPaymentStatus),
            PaymentMethod = "eBay",
            PaymentProvider = "eBay",
            CustomerNote = order.BuyerCheckoutNotes ?? string.Empty,
            Customer = new SalesChannelImportCustomer
            {
                RemoteCustomerId = order.Buyer?.Username ?? string.Empty,
                Email = contact?.Email ?? string.Empty,
                Firstname = firstname,
                Lastname = lastname,
                CompanyName = contact?.CompanyName ?? string.Empty,
                Phone = contact?.PrimaryPhone?.PhoneNumber ?? string.Empty,
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = ToUtc(order.CreationDate),
                BillingAddress = billingAddress,
                ShippingAddress = shippingAddress,
            },
            BillingAddress = billingAddress,
            ShippingAddress = shippingAddress,
            SalesItems = (order.LineItems ?? [])
                .Select(line => new SalesChannelImportSalesItem
                {
                    Name = line.Title ?? string.Empty,
                    Sku = line.Sku ?? string.Empty,
                    Quantity = line.Quantity,
                    Price = line.Quantity > 0 ? (line.LineItemCost?.Value ?? 0m) / line.Quantity : line.LineItemCost?.Value ?? 0m,
                    TaxRate = ComputeLineTaxRate(line),
                }).ToList(),
        };

        return sales;
    }

    private static SalesChannelImportCustomer MapCustomer(EbayOrder order)
    {
        var shipTo = GetShipTo(order);
        var contact = order.Buyer?.BuyerRegistrationAddress ?? shipTo;
        var (firstname, lastname) = SplitFullName(contact?.FullName);

        var billingAddress = MapAddress(contact, firstname, lastname);
        var shippingAddress = MapShippingAddress(shipTo, billingAddress);

        return new SalesChannelImportCustomer
        {
            RemoteCustomerId = order.Buyer?.Username ?? string.Empty,
            Email = contact?.Email ?? string.Empty,
            Firstname = firstname,
            Lastname = lastname,
            CompanyName = contact?.CompanyName ?? string.Empty,
            Phone = contact?.PrimaryPhone?.PhoneNumber ?? string.Empty,
            CustomerStatus = CustomerStatus.Active,
            DateEnrollment = ToUtc(order.CreationDate),
            BillingAddress = billingAddress,
            ShippingAddress = shippingAddress,
        };
    }

    private static SalesChannelImportCustomerAddress MapAddress(EbayOrderContact contact, string firstname, string lastname)
    {
        var address = contact?.ContactAddress;
        var street = address?.AddressLine1 ?? string.Empty;
        if (!string.IsNullOrEmpty(address?.AddressLine2))
        {
            street = string.IsNullOrEmpty(street) ? address.AddressLine2 : $"{street} {address.AddressLine2}";
        }

        return new SalesChannelImportCustomerAddress
        {
            Firstname = firstname,
            Lastname = lastname,
            CompanyName = contact?.CompanyName ?? string.Empty,
            Street = street,
            City = address?.City ?? string.Empty,
            Zip = address?.PostalCode ?? string.Empty,
            Country = address?.CountryCode ?? string.Empty,
            Phone = contact?.PrimaryPhone?.PhoneNumber ?? string.Empty,
        };
    }

    private static SalesChannelImportCustomerAddress MapShippingAddress(
        EbayOrderContact shipTo,
        SalesChannelImportCustomerAddress fallback)
    {
        if (shipTo is null)
        {
            return fallback;
        }

        var (firstname, lastname) = SplitFullName(shipTo.FullName);
        return MapAddress(shipTo, firstname, lastname);
    }

    private static EbayOrderContact GetShipTo(EbayOrder order)
    {
        var instructions = order.FulfillmentStartInstructions;
        return instructions is { Length: > 0 } ? instructions[0].ShippingStep?.ShipTo : null;
    }

    /// <summary>eBay only carries a single fullName; the last token becomes the last name.</summary>
    private static (string Firstname, string Lastname) SplitFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return (string.Empty, string.Empty);
        }

        var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parts.Length == 1
            ? (string.Empty, parts[0])
            : (string.Join(' ', parts[..^1]), parts[^1]);
    }

    // eBay exposes a line's tax as a money amount, not a rate — derive the percentage from the
    // line cost. 0 when untaxed (typical for DE marketplace orders where eBay remits the VAT).
    private static double ComputeLineTaxRate(EbayLineItem line)
    {
        var cost = line.LineItemCost?.Value ?? 0m;
        var tax = line.Taxes?.Sum(t => t.Amount?.Value ?? 0m) ?? 0m;
        if (cost <= 0m || tax <= 0m)
        {
            return 0;
        }

        return (double)Math.Round(tax / cost * 100m, 0);
    }

    private static List<SalesChannelImportImage> MapImages(string[] imageUrls)
    {
        if (imageUrls is null || imageUrls.Length == 0)
        {
            return [];
        }

        // eBay has no separate media id — the EPS URL itself is the stable remote key.
        return imageUrls
            .Where(url => !string.IsNullOrWhiteSpace(url))
            .Select((url, index) => new SalesChannelImportImage
            {
                RemoteImageId = url,
                Url = url,
                SortOrder = index,
            })
            .ToList();
    }

    private static DateTime ToUtc(DateTime value) =>
        value.Kind == DateTimeKind.Utc ? value : DateTime.SpecifyKind(value, DateTimeKind.Utc);

    private static SalesStatus MapSalesStatus(EbayOrder order)
    {
        if (string.Equals(order.CancelStatus?.CancelState, "CANCELED", StringComparison.OrdinalIgnoreCase))
        {
            return SalesStatus.Cancelled;
        }

        return order.OrderFulfillmentStatus?.ToUpperInvariant() switch
        {
            "NOT_STARTED" => SalesStatus.Pending,
            "IN_PROGRESS" => SalesStatus.Processing,
            "FULFILLED" => SalesStatus.Completed,
            _ => SalesStatus.Unknown,
        };
    }

    private static PaymentStatus MapPaymentStatus(string status) => status?.ToUpperInvariant() switch
    {
        "PAID" => PaymentStatus.CompletelyPaid,
        "PENDING" => PaymentStatus.Invoiced,
        "PARTIALLY_REFUNDED" => PaymentStatus.ReCrediting,
        "FULLY_REFUNDED" => PaymentStatus.ReCrediting,
        "FAILED" => PaymentStatus.Unknown,
        _ => PaymentStatus.Unknown,
    };

    private static string Truncate(string value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value ?? string.Empty;
        return value.Length <= max ? value : value[..max];
    }
}
