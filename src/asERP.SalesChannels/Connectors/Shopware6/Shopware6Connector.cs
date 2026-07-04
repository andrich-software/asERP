using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.Common;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Models.Shopware6;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Connectors.Shopware6;

/// <summary>
/// Shopware 6 Admin-API connector. Auth: OAuth client_credentials (see <see cref="Shopware6AuthHelper"/>).
/// Imports go through the <c>/api/search/{entity}</c> endpoints with cursor-style paging via
/// <c>page</c> + <c>limit</c>. Stock and price updates use the standard PATCH on <c>/api/product/{id}</c>.
/// </summary>
public sealed class Shopware6Connector : ConnectorBase
{
    private const int PageSize = 100;

    private readonly Shopware6AuthHelper _auth;
    private readonly IProductImportRepository _productImportRepository;
    private readonly ISalesImportRepository _salesImportRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly ILogger<Shopware6Connector> _logger;

    public Shopware6Connector(
        Shopware6AuthHelper auth,
        IProductImportRepository productImportRepository,
        ISalesImportRepository salesImportRepository,
        ISalesChannelRepository salesChannelRepository,
        ILogger<Shopware6Connector> logger)
    {
        _auth = auth;
        _productImportRepository = productImportRepository;
        _salesImportRepository = salesImportRepository;
        _salesChannelRepository = salesChannelRepository;
        _logger = logger;
    }

    public override SalesChannelType Type => SalesChannelType.Shopware6;

    public override SalesChannelCapabilities Capabilities =>
        SalesChannelCapabilities.ImportProducts |
        SalesChannelCapabilities.ImportSaless |
        SalesChannelCapabilities.UpdateStock |
        SalesChannelCapabilities.UpdatePrice |
        SalesChannelCapabilities.OAuth;

    public override async Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context)
    {
        try
        {
            SalesChannelUrlValidator.Validate(context.SalesChannel.Url);
            var (_, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken);

            var url = context.SalesChannel.Url.TrimEnd('/') + "/api/_info/version";
            var response = await context.HttpClient.GetAsync(url, context.CancellationToken);
            return response.IsSuccessStatusCode
                ? new ConnectionTestResult(true)
                : new ConnectionTestResult(false, $"HTTP {(int)response.StatusCode}");
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
        var page = 1;

        try
        {
            var (_, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken);
            var baseUrl = salesChannel.Url.TrimEnd('/');

            while (true)
            {
                // Walk only top-level products (parentId == null); variants are fetched per parent below
                var requestBody = new
                {
                    page,
                    limit = PageSize,
                    filter = new object[]
                    {
                        new { type = "equals", field = "parentId", value = (string?)null },
                    },
                    // Load the photo gallery + featured image; the nested 'media' association is what
                    // carries the public file url we download. Without it only the join rows come back.
                    associations = new
                    {
                        media = new { associations = new { media = new { } } },
                        cover = new { associations = new { media = new { } } },
                    },
                    sort = new[] { new { field = "createdAt", order = "ASC" } },
                };
                var url = $"{baseUrl}/api/search/product";
                var response = await context.HttpClient.PostAsJsonAsync(url, requestBody, context.CancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                    _logger.LogError("Shopware6 product search HTTP {Status}: {Body}", (int)response.StatusCode, body);
                    failed++;
                    break;
                }

                var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
                var result = JsonSerializer.Deserialize<Sw6SearchResult<Sw6Product>>(raw);
                if (result?.Data is null || result.Data.Count == 0) break;

                foreach (var p in result.Data)
                {
                    if (string.IsNullOrEmpty(p.ProductNumber))
                    {
                        continue;
                    }

                    try
                    {
                        var description = p.Translated?.Description ?? p.Description ?? string.Empty;
                        if (description.Length > 4000) description = description[..4000];

                        var importProduct = new SalesChannelImportProduct
                        {
                            RemoteProductId = p.Id,
                            Sku = p.ProductNumber!,
                            Name = p.Translated?.Name ?? p.Name ?? string.Empty,
                            Ean = p.Ean ?? string.Empty,
                            Price = p.Price?.FirstOrDefault()?.Net ?? 0m,
                            TaxRate = 19,
                            Description = description,
                            IsVariantParent = (p.ChildCount ?? 0) > 0,
                            Images = MapImages(p),
                        };

                        if (importProduct.IsVariantParent)
                        {
                            importProduct.Variants = await FetchVariantsAsync(context, baseUrl, p, importProduct);
                            importProduct.VariantAxes = importProduct.Variants
                                .SelectMany(v => v.Options.Select(o => o.AttributeName))
                                .Distinct()
                                .ToList();
                        }

                        await _productImportRepository.ImportOrUpdateFromSalesChannel(salesChannel.Id, importProduct);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        _logger.LogError(ex, "Shopware6 product import failed for {Sku}", p.ProductNumber);
                    }
                }

                if (result.Data.Count < PageSize) break;
                page++;
            }
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

    /// <summary>
    /// Fetches the child variants of a Shopware parent product, paged. Inherited fields
    /// (price, name, ean) come back as null on children — they are resolved against the
    /// parent here so the import repository stays channel-agnostic.
    /// </summary>
    private async Task<List<SalesChannelImportVariant>> FetchVariantsAsync(
        SalesChannelContext context,
        string baseUrl,
        Sw6Product parent,
        SalesChannelImportProduct importParent)
    {
        var variants = new List<SalesChannelImportVariant>();
        var page = 1;

        while (true)
        {
            var requestBody = new
            {
                page,
                limit = PageSize,
                filter = new object[]
                {
                    new { type = "equals", field = "parentId", value = parent.Id },
                },
                associations = new
                {
                    options = new { associations = new { group = new { } } },
                },
                sort = new[] { new { field = "productNumber", order = "ASC" } },
            };

            var url = $"{baseUrl}/api/search/product";
            var response = await context.HttpClient.PostAsJsonAsync(url, requestBody, context.CancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
                throw new InvalidOperationException(
                    $"Shopware6 variant search for parent {parent.ProductNumber} failed with HTTP {(int)response.StatusCode}: {Truncate(body, 300)}");
            }

            var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
            var result = JsonSerializer.Deserialize<Sw6SearchResult<Sw6Product>>(raw);
            if (result?.Data is null || result.Data.Count == 0) break;

            foreach (var child in result.Data)
            {
                if (string.IsNullOrEmpty(child.ProductNumber))
                {
                    continue;
                }

                variants.Add(new SalesChannelImportVariant
                {
                    RemoteVariantId = child.Id,
                    Sku = child.ProductNumber,
                    // Inherited fields are null on the child — fall back to the parent's values
                    Ean = child.Ean ?? importParent.Ean,
                    Price = child.Price?.FirstOrDefault()?.Net,
                    Stock = child.Stock ?? 0,
                    SortOrder = variants.Count,
                    Options = child.Options?
                        .Select(o => new SalesChannelImportVariantOption
                        {
                            AttributeName = o.Group?.Translated?.Name ?? o.Group?.Name ?? string.Empty,
                            Value = o.Translated?.Name ?? o.Name ?? string.Empty,
                        })
                        .Where(o => !string.IsNullOrEmpty(o.AttributeName) && !string.IsNullOrEmpty(o.Value))
                        .ToList() ?? [],
                });
            }

            if (result.Data.Count < PageSize) break;
            page++;
        }

        return variants;
    }

    // Mirrors the WooCommerce sales-import structure: a resumable, time-boxed oldest-first backfill via
    // the immutable orderDateTime (cursor on the channel entity) plus an updatedAt-filtered incremental
    // pass. During backfill each run first refreshes recent orders so the shop sees current sales within
    // a cycle, then continues the historical walk from the cursor.
    private static readonly TimeSpan RecentSalesSeedWindow = TimeSpan.FromDays(14);
    private static readonly TimeSpan MaxBackfillRunDuration = TimeSpan.FromMinutes(15);

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

        string baseUrl;
        try
        {
            var (_, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken);
            baseUrl = salesChannel.Url.TrimEnd('/');
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        if (salesChannel.InitialSalesImportCompleted)
        {
            return await ImportSalesByUpdatedAsync(context, baseUrl, context.IncrementalSince);
        }

        var recentSince = context.IncrementalSince ?? DateTime.UtcNow - RecentSalesSeedWindow;
        var recent = await ImportSalesByUpdatedAsync(context, baseUrl, recentSince);
        var backfill = await ImportSalesBackfillAsync(context, baseUrl);

        return new SyncResult(
            recent.ItemsProcessed + backfill.ItemsProcessed,
            recent.ItemsFailed + backfill.ItemsFailed,
            backfill.ErrorSummary ?? recent.ErrorSummary);
    }

    /// <summary>
    /// Oldest-first backfill over orderDateTime. Instead of deep pagination, every iteration re-queries
    /// page 1 with the advanced cursor (range filter gte cursor−1s) — the sort key is immutable, so the
    /// walk is stable, and the persisted cursor lets an interrupted run resume exactly where it stopped.
    /// The boundary overlap is deduplicated by the seen-set and idempotent upserts.
    /// </summary>
    private async Task<SyncResult> ImportSalesBackfillAsync(SalesChannelContext context, string baseUrl)
    {
        var salesChannel = context.SalesChannel;
        var processed = 0;
        var failed = 0;
        var cursorAdvance = salesChannel.SalesImportBackfillCursor;
        var frozen = false;
        var reachedEnd = false;
        var fetchFailed = false;
        var seen = new HashSet<string>();
        var runStart = DateTime.UtcNow;

        while (true)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            object requestBody = BuildSalesSearchBody(
                page: 1,
                rangeField: "orderDateTime",
                rangeFrom: cursorAdvance?.AddSeconds(-1),
                sortField: "orderDateTime");

            List<Sw6Sales> batch;
            try
            {
                var result = await FetchSalesPageAsync(context, baseUrl, requestBody);
                batch = result.Data;

                // Remaining history from the cursor onward — lets the dashboard show a percentage.
                context.SyncRun.ItemsTotal ??= result.Total;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Shopware6 order backfill page fetch failed");
                fetchFailed = true;
                break;
            }

            if (batch.Count == 0)
            {
                reachedEnd = true;
                break;
            }

            var newInBatch = 0;
            foreach (var sales in batch)
            {
                if (!seen.Add(sales.Id))
                {
                    continue;
                }
                newInBatch++;

                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, MapSales(sales));
                    processed++;

                    if (!frozen && (cursorAdvance is null || sales.SalesDateTime > cursorAdvance))
                    {
                        cursorAdvance = sales.SalesDateTime;
                    }
                }
                catch (Exception ex)
                {
                    failed++;
                    frozen = true;   // never advance the cursor past a failed order
                    _logger.LogError(ex, "Shopware6 sales backfill failed for {Id}", sales.Id);
                }
            }

            // Persist progress on the tracked channel entity (the orchestrator saves it after the run).
            if (cursorAdvance is { } adv && adv != salesChannel.SalesImportBackfillCursor)
            {
                salesChannel.SalesImportBackfillCursor = adv;
            }

            if (context.ReportProgressAsync is not null)
            {
                await context.ReportProgressAsync(processed, failed, context.CancellationToken);
            }

            _logger.LogInformation("Shopware6 order backfill: {Processed} imported, {Failed} failed, cursor {Cursor:u}", processed, failed, cursorAdvance);

            if (batch.Count < PageSize)
            {
                reachedEnd = true;
                break;
            }
            // Only boundary re-reads left → the cursor cannot advance any further (e.g. a failure froze
            // it); stop rather than spinning on the same page.
            if (newInBatch == 0)
            {
                break;
            }
            if (DateTime.UtcNow - runStart >= MaxBackfillRunDuration)
            {
                break;
            }
        }

        if (reachedEnd && !fetchFailed && !frozen)
        {
            salesChannel.InitialSalesImportCompleted = true;
        }

        if (fetchFailed && failed == 0)
        {
            return processed > 0
                ? new SyncResult(processed, 1)
                : SyncResult.Failed("Shopware6 order backfill page fetch failed");
        }

        return new SyncResult(processed, failed);
    }

    /// <summary>
    /// Pulls orders updated at/after <paramref name="updatedSince"/> (null → all orders), paged with a
    /// stable id sort. Catches both new orders and edits/cancellations of existing ones.
    /// </summary>
    private async Task<SyncResult> ImportSalesByUpdatedAsync(SalesChannelContext context, string baseUrl, DateTime? updatedSince)
    {
        var salesChannel = context.SalesChannel;
        var processed = 0;
        var failed = 0;
        var seen = new HashSet<string>();

        for (var page = 1; ; page++)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            object requestBody = BuildSalesSearchBody(
                page,
                rangeField: updatedSince is null ? null : "updatedAt",
                rangeFrom: updatedSince,
                sortField: "id");

            List<Sw6Sales> batch;
            try
            {
                batch = (await FetchSalesPageAsync(context, baseUrl, requestBody)).Data;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Shopware6 order page {Page} fetch failed", page);
                return processed > 0
                    ? new SyncResult(processed, failed + 1)
                    : SyncResult.Failed(ex.Message);
            }

            if (batch.Count == 0)
            {
                break;
            }

            var newInBatch = 0;
            foreach (var sales in batch)
            {
                if (!seen.Add(sales.Id))
                {
                    continue;
                }
                newInBatch++;

                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(salesChannel, MapSales(sales));
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "Shopware6 sales import failed for {Id}", sales.Id);
                }
            }

            if (context.ReportProgressAsync is not null)
            {
                await context.ReportProgressAsync(processed, failed, context.CancellationToken);
            }

            if (newInBatch == 0 || batch.Count < PageSize)
            {
                break;
            }
        }

        return new SyncResult(processed, failed);
    }

    private static Dictionary<string, object> BuildSalesSearchBody(int page, string? rangeField, DateTime? rangeFrom, string sortField)
    {
        var filters = new List<object>();
        if (rangeField is not null && rangeFrom is { } from)
        {
            filters.Add(new
            {
                type = "range",
                field = rangeField,
                parameters = new Dictionary<string, string>
                {
                    // Shopware compares ISO-8601 datetimes; UTC with explicit offset avoids shop-TZ drift.
                    ["gte"] = from.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss+00:00"),
                },
            });
        }

        return new Dictionary<string, object>
        {
            ["page"] = page,
            ["limit"] = PageSize,
            ["filter"] = filters.ToArray(),
            // Exact total so the run can report ItemsTotal (dashboard percentage).
            ["total-count-mode"] = 1,
            ["associations"] = new
            {
                orderCustomer = new { },
                billingAddress = new { associations = new { country = new { } } },
                deliveries = new { associations = new { shippingOrderAddress = new { associations = new { country = new { } } } } },
                lineItems = new { },
                stateMachineState = new { },
            },
            ["sort"] = new[] { new { field = sortField, order = "ASC" } },
        };
    }

    private async Task<Sw6SearchResult<Sw6Sales>> FetchSalesPageAsync(SalesChannelContext context, string baseUrl, object requestBody)
    {
        var url = $"{baseUrl}/api/search/order";
        var response = await context.HttpClient.PostAsJsonAsync(url, requestBody, context.CancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(context.CancellationToken);
            throw new InvalidOperationException($"Shopware6 order search failed with HTTP {(int)response.StatusCode}: {Truncate(body, 300)}");
        }

        var raw = await response.Content.ReadAsStringAsync(context.CancellationToken);
        return JsonSerializer.Deserialize<Sw6SearchResult<Sw6Sales>>(raw) ?? new Sw6SearchResult<Sw6Sales>();
    }

    public override async Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteProductId))
        {
            return ExportResult.Fail("Shopware6 product id (RemoteProductId) is required for stock updates");
        }

        try
        {
            var (_, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken);

            var url = context.SalesChannel.Url.TrimEnd('/') + $"/api/product/{Uri.EscapeDataString(payload.RemoteProductId)}";
            var body = new { stock = payload.Quantity };
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
        if (string.IsNullOrEmpty(payload.RemoteProductId))
        {
            return ExportResult.Fail("Shopware6 product id (RemoteProductId) is required for price updates");
        }

        try
        {
            var (_, accessToken) = await PrepareAsync(context);
            ConfigureBearer(context, accessToken);

            var url = context.SalesChannel.Url.TrimEnd('/') + $"/api/product/{Uri.EscapeDataString(payload.RemoteProductId)}";
            var body = new
            {
                price = new[]
                {
                    new
                    {
                        gross = payload.Price,
                        net = payload.Price,
                        linked = false,
                        currencyId = "b7d2554b0ce847cd82f3ac9bd1c0dfca", // Shopware 6 default EUR currency id
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

    private async Task<(Shopware6ChannelConfig config, string accessToken)> PrepareAsync(SalesChannelContext context)
    {
        var config = Shopware6ChannelConfig.FromSalesChannel(context.SalesChannel);
        if (string.IsNullOrEmpty(config.ApiClientId) || string.IsNullOrEmpty(config.ApiClientSecret))
        {
            throw new InvalidOperationException(
                "Shopware6 channel is missing apiClientId / apiClientSecret in AdditionalConfigJson (or Username/Password fallback)");
        }
        var accessToken = await _auth.GetAccessTokenAsync(context.SalesChannel, config, context.CancellationToken);
        return (config, accessToken);
    }

    private static void ConfigureBearer(SalesChannelContext context, string accessToken)
    {
        context.HttpClient.DefaultRequestHeaders.Accept.Clear();
        context.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        context.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    private static SalesChannelImportSales MapSales(Sw6Sales sales)
    {
        var billing = sales.BillingAddress;
        var shipping = sales.Deliveries.FirstOrDefault()?.ShippingSalesAddress ?? billing;

        var billingAddress = new SalesChannelImportCustomerAddress
        {
            Firstname = billing?.FirstName ?? string.Empty,
            Lastname = billing?.LastName ?? string.Empty,
            CompanyName = billing?.Company ?? string.Empty,
            Street = billing?.Street ?? string.Empty,
            City = billing?.City ?? string.Empty,
            Zip = billing?.Zipcode ?? string.Empty,
            Country = billing?.Country?.Iso ?? string.Empty,
        };

        var shippingAddress = new SalesChannelImportCustomerAddress
        {
            Firstname = shipping?.FirstName ?? string.Empty,
            Lastname = shipping?.LastName ?? string.Empty,
            CompanyName = shipping?.Company ?? string.Empty,
            Street = shipping?.Street ?? string.Empty,
            City = shipping?.City ?? string.Empty,
            Zip = shipping?.Zipcode ?? string.Empty,
            Country = shipping?.Country?.Iso ?? string.Empty,
        };

        return new SalesChannelImportSales
        {
            RemoteSalesId = sales.Id,
            RemoteCustomerId = sales.SalesCustomer?.CustomerId ?? string.Empty,
            DateSalesed = sales.SalesDateTime,
            Status = MapSalesStatus(sales.StateMachineState?.TechnicalName),
            PaymentStatus = PaymentStatus.Unknown,
            Subtotal = sales.AmountNet,
            ShippingCost = sales.ShippingTotal,
            TotalTax = sales.AmountTotal - sales.AmountNet,
            Total = sales.AmountTotal,
            Customer = new SalesChannelImportCustomer
            {
                Firstname = sales.SalesCustomer?.FirstName ?? string.Empty,
                Lastname = sales.SalesCustomer?.LastName ?? string.Empty,
                CompanyName = sales.SalesCustomer?.Company ?? string.Empty,
                Email = sales.SalesCustomer?.Email ?? string.Empty,
                Phone = billing?.PhoneNumber ?? string.Empty,
                DateEnrollment = DateTime.UtcNow,
            },
            BillingAddress = billingAddress,
            ShippingAddress = shippingAddress,
            SalesItems = sales.LineItems
                // Promotions/credits come through as separate line-item types without a product.
                .Where(li => li.ItemType is null or "product")
                .Select(li => new SalesChannelImportSalesItem
                {
                    Name = li.Label ?? string.Empty,
                    Sku = li.Payload?.ProductNumber ?? string.Empty,
                    Quantity = li.Quantity,
                    Price = li.UnitPrice,
                    Ean = li.Payload?.Ean ?? string.Empty,
                    TaxRate = 19,
                }).ToList(),
        };
    }

    /// <summary>
    /// Maps a Shopware product's media gallery to import images. Each entry's public file URL lives on
    /// the nested Media entity; the join's 'position' gives the gallery order. The product's cover is
    /// promoted to the front (SortOrder -1) so it becomes the primary photo regardless of its position.
    /// </summary>
    private static List<SalesChannelImportImage> MapImages(Sw6Product p)
    {
        if (p.Media is null || p.Media.Count == 0)
        {
            return [];
        }

        var coverMediaId = p.Cover?.Media?.Id;
        var images = new List<SalesChannelImportImage>();

        foreach (var pm in p.Media)
        {
            var url = pm.Media?.Url;
            if (string.IsNullOrWhiteSpace(url))
            {
                continue;
            }

            var mediaId = pm.Media?.Id ?? pm.Id;
            var isCover = !string.IsNullOrEmpty(coverMediaId) && mediaId == coverMediaId;

            images.Add(new SalesChannelImportImage
            {
                RemoteImageId = mediaId,
                Url = url,
                AltText = pm.Media?.Alt,
                SortOrder = isCover ? -1 : pm.Position ?? images.Count,
            });
        }

        return images;
    }

    private static SalesStatus MapSalesStatus(string? technicalName) => technicalName switch
    {
        "open" => SalesStatus.Pending,
        "in_progress" => SalesStatus.Processing,
        "completed" => SalesStatus.Completed,
        "cancelled" => SalesStatus.Cancelled,
        _ => SalesStatus.Unknown,
    };

    private static string Truncate(string value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value ?? string.Empty;
        return value.Length <= max ? value : value[..max];
    }
}
