#nullable disable
using System.Globalization;
using System.Text.Json;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Enums;
using asToolkit.SalesChannels.Abstractions;
using asToolkit.SalesChannels.Connectors.Common;
using asToolkit.SalesChannels.Contracts;
using asToolkit.SalesChannels.Models;
using asToolkit.SalesChannels.Models.WooCommerce;
using Microsoft.Extensions.Logging;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace asToolkit.SalesChannels.Connectors.WooCommerce;

/// <summary>
/// WooCommerce REST API connector via the <c>WooCommerceNET</c> SDK. Migrated from
/// <c>WooCommerceProductImportTask</c> + <c>WooCommerceSalesImportTask</c>; same SDK, same
/// mappings, but routed through the connector contract so the orchestrator owns scheduling.
/// </summary>
public sealed class WooCommerceConnector : ConnectorBase
{
    private readonly IProductImportRepository _productImportRepository;
    private readonly ISalesImportRepository _salesImportRepository;
    private readonly ICustomerImportRepository _customerImportRepository;
    private readonly ILogger<WooCommerceConnector> _logger;

    public WooCommerceConnector(
        IProductImportRepository productImportRepository,
        ISalesImportRepository salesImportRepository,
        ICustomerImportRepository customerImportRepository,
        ILogger<WooCommerceConnector> logger)
    {
        _productImportRepository = productImportRepository;
        _salesImportRepository = salesImportRepository;
        _customerImportRepository = customerImportRepository;
        _logger = logger;
    }

    public override SalesChannelType Type => SalesChannelType.WooCommerce;

    public override SalesChannelCapabilities Capabilities =>
        SalesChannelCapabilities.ImportProducts |
        SalesChannelCapabilities.ImportSaless |
        SalesChannelCapabilities.ImportCustomers |
        SalesChannelCapabilities.UpdateStock |
        SalesChannelCapabilities.UpdatePrice;

    public override async Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context)
    {
        try
        {
            SalesChannelUrlValidator.Validate(context.SalesChannel.Url);
            var wc = BuildClient(context);
            await wc.Product.GetAll(new Dictionary<string, string> { ["per_page"] = "1" });
            return new ConnectionTestResult(true);
        }
        catch (Exception ex)
        {
            return new ConnectionTestResult(false, ex.Message);
        }
    }

    public override async Task<SyncResult> ImportProductsAsync(SalesChannelContext context)
    {
        try
        {
            SalesChannelUrlValidator.Validate(context.SalesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        var processed = 0;
        var failed = 0;

        try
        {
            var wc = BuildClient(context);
            var taxRateMap = await BuildTaxRateMapAsync(wc, context.CancellationToken);
            var remoteProducts = await GetAllProductsAsync(wc, context.CancellationToken);
            foreach (var remoteProduct in remoteProducts)
            {
                var isVariable = remoteProduct.type == "variable";

                // Variable parents occasionally have no own SKU — synthesize a stable one from the
                // remote id so the parent (and with it all variations) is not dropped. Plain products
                // without SKU stay skipped as before.
                var sku = remoteProduct.sku;
                if (string.IsNullOrEmpty(sku))
                {
                    if (!isVariable)
                    {
                        _logger.LogDebug("Product {Name} has no SKU, skipping", remoteProduct.name);
                        continue;
                    }

                    sku = $"WOO-{remoteProduct.id}";
                }

                try
                {
                    var importProduct = new SalesChannelImportProduct
                    {
                        RemoteProductId = remoteProduct.id?.ToString() ?? string.Empty,
                        Name = remoteProduct.name,
                        // Variable/grouped products carry no own price (null) — default to 0 instead of
                        // letting the cast throw and dropping the row as a failed import.
                        Price = remoteProduct.price ?? 0m,
                        Sku = sku,
                        TaxRate = ResolveTaxRate(remoteProduct, taxRateMap),
                        Description = remoteProduct.description,
                        IsVariantParent = isVariable,
                        Images = MapImages(remoteProduct.images),
                    };

                    if (isVariable && remoteProduct.id.HasValue)
                    {
                        // The axes are the product attributes flagged for variation use
                        importProduct.VariantAxes = remoteProduct.attributes?
                            .Where(a => a.variation == true && !string.IsNullOrEmpty(a.name))
                            .OrderBy(a => a.position ?? 0)
                            .Select(a => a.name)
                            .ToList() ?? [];

                        var variations = await GetAllVariationsAsync(wc, remoteProduct.id.Value, context.CancellationToken);
                        importProduct.Variants = variations
                            .Where(v => v.id.HasValue)
                            .Select(v => new SalesChannelImportVariant
                            {
                                RemoteVariantId = v.id!.Value.ToString(),
                                Sku = v.sku,
                                Ean = null,
                                Price = v.price,
                                Stock = v.stock_quantity ?? 0,
                                SortOrder = (int)v.menu_order,
                                Options = v.attributes?
                                    .Where(a => !string.IsNullOrEmpty(a.name) && !string.IsNullOrEmpty(a.option))
                                    .Select(a => new SalesChannelImportVariantOption
                                    {
                                        AttributeName = a.name,
                                        Value = a.option,
                                    }).ToList() ?? [],
                            }).ToList();
                    }

                    await _productImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel.Id, importProduct);
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce product import failed for SKU {Sku}", sku);
                }
            }
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
    {
        try
        {
            SalesChannelUrlValidator.Validate(context.SalesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        RestAPI rest;
        try
        {
            rest = BuildRestApi(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        // Two modes, picked by the channel's backfill state:
        //  - Backfill (InitialSalesImportCompleted == false): walk the WHOLE order history oldest-first and
        //    resume across runs from a persisted cursor, so a large shop is filled completely without ever
        //    restarting from page 1. See ImportSalesBackfillAsync.
        //  - Incremental (completed): pull only orders changed since the last successful run (modified_after),
        //    which also catches edits/refunds to existing orders. See ImportSalesIncrementalAsync.
        return context.SalesChannel.InitialSalesImportCompleted
            ? await ImportSalesIncrementalAsync(context, rest)
            : await ImportSalesBackfillAsync(context, rest);
    }

    /// <summary>
    /// Resumable, oldest-first backfill of the full order history. WooCommerce's REST <c>orders</c> endpoint
    /// has no "id greater than" filter, but <c>date_created</c> is immutable, so <c>orderby=date&amp;order=asc</c>
    /// is a stable walk: new orders only ever append at the tail and nothing an earlier page already returned
    /// can shift (unlike <c>modified</c>, which jumps a touched order to a later page mid-walk). We persist the
    /// <c>date_created</c> of the furthest order imported as the channel's cursor after every page, so an
    /// interrupted run (timeout, page failure, graceful shutdown) resumes from there next time instead of
    /// starting over. The boundary second is re-fetched (<c>after</c> is exclusive, we step back 1s) but upserts
    /// are idempotent. The cursor never advances past an order that failed to import, so failures are retried
    /// rather than skipped. When a short page proves we walked off the end with no error, we flip
    /// <see cref="SalesChannel.InitialSalesImportCompleted"/> and the channel switches to incremental mode.
    /// </summary>
    private async Task<SyncResult> ImportSalesBackfillAsync(SalesChannelContext context, RestAPI rest)
    {
        var processed = 0;
        var failed = 0;

        var baseParameters = new Dictionary<string, string>
        {
            ["per_page"] = PageSize.ToString(),
            ["orderby"] = "date",
            ["order"] = "asc",
            ["dates_are_gmt"] = "true",
        };

        var startCursor = context.SalesChannel.SalesImportBackfillCursor;
        if (startCursor is { } c)
        {
            // 'after' is exclusive; step back a second so orders sharing the cursor's timestamp are not skipped.
            baseParameters["after"] = c.AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ss");
        }

        // Highest date_created we can safely claim as "everything below is imported". Frozen the moment an
        // order fails so the cursor never advances past a gap; the next run resumes at the failure and retries.
        var cursorAdvance = startCursor;
        var frozen = false;
        var reachedEnd = false;
        var fetchFailed = false;
        var seen = new HashSet<string>();

        for (var page = 1; page <= MaxPages; page++)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            List<WooOrder> batch;
            try
            {
                var parameters = new Dictionary<string, string>(baseParameters) { ["page"] = page.ToString() };
                batch = await GetOrderPageWithRetryAsync(rest, parameters, page, context.CancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WooCommerce order backfill page {Page} fetch failed after {Attempts} attempts", page, PageFetchAttempts);
                fetchFailed = true;
                break;
            }

            if (batch is null || batch.Count == 0)
            {
                reachedEnd = true;
                break;
            }

            var newInBatch = 0;
            foreach (var remoteSales in batch)
            {
                // Guard against an endpoint that ignores 'page' and keeps returning the same rows.
                var key = remoteSales.id?.ToString() ?? $"__noid_{processed}_{failed}";
                if (!seen.Add(key))
                {
                    continue;
                }
                newInBatch++;

                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, MapOrder(remoteSales));
                    processed++;

                    if (!frozen)
                    {
                        var orderedAt = ToUtc(remoteSales.date_created_gmt ?? remoteSales.date_created);
                        if (cursorAdvance is null || orderedAt > cursorAdvance)
                        {
                            cursorAdvance = orderedAt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    failed++;
                    frozen = true;
                    _logger.LogError(ex, "WooCommerce sales backfill failed for {Id}", remoteSales.id);
                }
            }

            // Persist progress after every page (in-memory on the tracked entity; the orchestrator/CloseRun
            // saves it) so a shutdown-canceled or failed run still resumes from here.
            if (cursorAdvance is { } adv && adv != context.SalesChannel.SalesImportBackfillCursor)
            {
                context.SalesChannel.SalesImportBackfillCursor = adv;
            }

            if (batch.Count < PageSize)
            {
                reachedEnd = true;
                break;
            }
            if (newInBatch == 0)
            {
                break;
            }
        }

        // Only declare the history fully imported when we walked off the end cleanly — no fetch error and no
        // order left behind. Otherwise stay in backfill mode so the next run keeps filling from the cursor.
        if (reachedEnd && !fetchFailed && !frozen)
        {
            context.SalesChannel.InitialSalesImportCompleted = true;
        }

        if (fetchFailed && failed == 0)
        {
            // Page fetch died but everything pulled so far is kept. Report partial (not clean Success) when we
            // imported something, so this run does not become an incremental watermark ahead of un-fetched orders.
            return processed > 0
                ? new SyncResult(processed, 1)
                : SyncResult.Failed("WooCommerce order backfill page fetch failed");
        }

        return new SyncResult(processed, failed);
    }

    /// <summary>
    /// Incremental order pull for a caught-up channel. Sorted by 'id' (immutable), NOT 'modified': offset
    /// pagination over a result set sorted by a mutable key is unstable — with orderby=modified, any order
    /// touched mid-walk jumps to a later page and slips past the cursor. 'id' never changes, so every order is
    /// paged exactly once even while the shop keeps taking orders. 'modified_after' (from the previous
    /// successful run's watermark) still filters the set, independent of the sort key, so a steady shop only
    /// pulls the handful of new/changed orders per tick. Upserts are idempotent, so the overlap window and any
    /// retry simply refill what is missing.
    /// </summary>
    private async Task<SyncResult> ImportSalesIncrementalAsync(SalesChannelContext context, RestAPI rest)
    {
        var processed = 0;
        var failed = 0;

        var baseParameters = new Dictionary<string, string>
        {
            ["per_page"] = PageSize.ToString(),
            ["orderby"] = "id",
            ["order"] = "asc",
        };

        if (context.IncrementalSince is { } since)
        {
            // WooCommerce compares 'modified_after' against the GMT timestamp when dates_are_gmt=true.
            baseParameters["modified_after"] = since.ToString("yyyy-MM-ddTHH:mm:ss");
            baseParameters["dates_are_gmt"] = "true";
        }

        var seen = new HashSet<string>();
        for (var page = 1; page <= MaxPages; page++)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            List<WooOrder> batch;
            try
            {
                var parameters = new Dictionary<string, string>(baseParameters) { ["page"] = page.ToString() };
                batch = await GetOrderPageWithRetryAsync(rest, parameters, page, context.CancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WooCommerce order page {Page} fetch failed after {Attempts} attempts", page, PageFetchAttempts);
                return processed > 0
                    ? new SyncResult(processed, failed + 1)
                    : SyncResult.Failed(ex.Message);
            }

            if (batch is null || batch.Count == 0)
            {
                break;
            }

            var newInBatch = 0;
            foreach (var remoteSales in batch)
            {
                // Guard against an endpoint that ignores 'page' and keeps returning the same rows.
                var key = remoteSales.id?.ToString() ?? $"__noid_{processed}_{failed}";
                if (!seen.Add(key))
                {
                    continue;
                }
                newInBatch++;

                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, MapOrder(remoteSales));
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce sales import failed for {Id}", remoteSales.id);
                }
            }

            if (newInBatch == 0 || batch.Count < PageSize)
            {
                break;
            }
        }

        return new SyncResult(processed, failed);
    }

    /// <summary>
    /// Fetches one page of orders, retrying a handful of times on transient failures (timeouts, 5xx,
    /// brief DNS/TLS hiccups, a Cloudflare interstitial). Without this, a single transient blip on any
    /// page aborts the whole run as a PartialFailure — which used to advance the incremental watermark
    /// and permanently skip every order the run never reached. Retrying lets a run actually complete and
    /// reach Success. Cancellation (server shutdown) is never retried; it propagates to end the walk.
    /// </summary>
    private async Task<List<WooOrder>> GetOrderPageWithRetryAsync(RestAPI rest, Dictionary<string, string> parameters, int page, CancellationToken cancellationToken)
    {
        for (var attempt = 1; ; attempt++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                return await GetOrderPageAsync(rest, parameters, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "WooCommerce order page {Page} fetch attempt {Attempt}/{Max} failed", page, attempt, PageFetchAttempts);
                if (attempt >= PageFetchAttempts)
                {
                    throw;
                }

                // Linear backoff: 3s, 6s, ... gives a brief outage or rate-limit window time to clear.
                await Task.Delay(PageRetryDelay * attempt, cancellationToken);
            }
        }
    }

    /// <summary>
    /// Fetches one page of orders as raw JSON and parses it with the tolerant DTOs. Going through
    /// the raw REST endpoint (instead of <c>wc.Order.GetAll</c>) avoids WooCommerceNET's strict
    /// deserializer, which aborts the entire page when a single order has an empty-string numeric
    /// field (e.g. <c>"customer_id":""</c> on a line/fee/meta entry).
    /// </summary>
    private static async Task<List<WooOrder>> GetOrderPageAsync(RestAPI rest, Dictionary<string, string> parameters, CancellationToken cancellationToken)
    {
        var json = await rest.GetRestful("orders", parameters).WaitAsync(PageFetchTimeout, cancellationToken);
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<WooOrder>();
        }

        return JsonSerializer.Deserialize<List<WooOrder>>(json, WooJson.Options) ?? new List<WooOrder>();
    }

    private static SalesChannelImportSales MapOrder(WooOrder remoteSales)
    {
        var subtotal = (remoteSales.total ?? 0) - (remoteSales.total_tax ?? 0) - (remoteSales.shipping_total ?? 0);
        // Guest orders carry customer_id 0 — leave the remote id empty so the import falls back to email
        // matching / creation instead of linking every guest order to a single phantom customer 0.
        var remoteCustomerId = (remoteSales.customer_id ?? 0) > 0 ? remoteSales.customer_id!.ToString() : string.Empty;
        var orderedAt = ToUtc(remoteSales.date_created_gmt ?? remoteSales.date_created);

        return new SalesChannelImportSales
        {
            RemoteSalesId = remoteSales.id?.ToString() ?? string.Empty,
            RemoteCustomerId = remoteCustomerId,
            DateSalesed = orderedAt,
            Status = MapSalesStatus(remoteSales.status),
            PaymentStatus = MapPaymentStatus(remoteSales),
            PaymentMethod = remoteSales.payment_method ?? string.Empty,
            PaymentProvider = remoteSales.payment_method_title ?? string.Empty,
            PaymentTransactionId = remoteSales.transaction_id ?? string.Empty,
            CustomerNote = remoteSales.customer_note ?? string.Empty,
            Subtotal = subtotal,
            ShippingCost = remoteSales.shipping_total ?? 0,
            TotalTax = remoteSales.total_tax ?? 0,
            Total = remoteSales.total ?? 0,
            Customer = new SalesChannelImportCustomer
            {
                RemoteCustomerId = remoteCustomerId,
                Firstname = remoteSales.billing?.first_name ?? string.Empty,
                Lastname = remoteSales.billing?.last_name ?? string.Empty,
                CompanyName = remoteSales.billing?.company ?? string.Empty,
                Email = remoteSales.billing?.email ?? string.Empty,
                Phone = remoteSales.billing?.phone ?? string.Empty,
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = orderedAt,
            },
            BillingAddress = new SalesChannelImportCustomerAddress
            {
                Firstname = remoteSales.billing?.first_name,
                Lastname = remoteSales.billing?.last_name,
                CompanyName = remoteSales.billing?.company,
                Street = remoteSales.billing?.address_1,
                City = remoteSales.billing?.city,
                Zip = remoteSales.billing?.postcode,
                Country = remoteSales.billing?.country,
                Phone = remoteSales.billing?.phone,
            },
            ShippingAddress = new SalesChannelImportCustomerAddress
            {
                Firstname = remoteSales.shipping?.first_name,
                Lastname = remoteSales.shipping?.last_name,
                CompanyName = remoteSales.shipping?.company,
                Street = remoteSales.shipping?.address_1,
                City = remoteSales.shipping?.city,
                Zip = remoteSales.shipping?.postcode,
                Country = remoteSales.shipping?.country,
            },
            SalesItems = remoteSales.line_items?.Select(item => new SalesChannelImportSalesItem
            {
                Name = item.name ?? string.Empty,
                Sku = item.sku ?? string.Empty,
                Quantity = (double)(item.quantity ?? 0),
                Price = item.price ?? 0m,
                TaxRate = ComputeLineTaxRate(item.subtotal, item.subtotal_tax),
            }).ToList() ?? new List<SalesChannelImportSalesItem>(),
        };
    }

    // WooCommerce exposes a line item's tax as money amounts, not a rate; the 'tax_class' field is a label
    // ("", "reduced-rate", …), never a number — so deriving the percentage from subtotal vs. subtotal_tax is
    // the only reliable way. Falls back to 0 when the line is untaxed or has no subtotal to divide by.
    private static double ComputeLineTaxRate(decimal? subtotal, decimal? subtotalTax)
    {
        var lineSubtotal = subtotal ?? 0m;
        var lineSubtotalTax = subtotalTax ?? 0m;
        if (lineSubtotal <= 0m || lineSubtotalTax <= 0m)
        {
            return 0;
        }

        return (double)Math.Round(lineSubtotalTax / lineSubtotal * 100m, 0);
    }

    // Last-resort tax rate when the shop exposes no usable tax configuration at all (taxes disabled or
    // the /taxes endpoint returns nothing). German standard VAT — keeps imports working out of the box
    // and matches the previously hard-coded value, so shops without REST tax data behave as before.
    private const double DefaultTaxRate = 19;

    /// <summary>
    /// Builds a map of WooCommerce tax-class slug → percentage from the shop's /taxes endpoint. A product
    /// only carries its tax-class label ("", "reduced-rate", …), never the number, so the actual rate must
    /// come from here. A class can hold several rows (one per country/state); the highest is taken as the
    /// representative full rate (e.g. a German shop maps 'standard' → 19, 'reduced-rate' → 7). The empty
    /// slug used by standard-rate products is normalized to "standard". Returns an empty map (callers fall
    /// back to <see cref="DefaultTaxRate"/>) if the shop has taxes disabled or the endpoint is unavailable.
    /// </summary>
    private async Task<Dictionary<string, double>> BuildTaxRateMapAsync(WCObject wc, CancellationToken cancellationToken)
    {
        List<TaxRate> rates;
        try
        {
            rates = await GetAllPagedAsync(parms => wc.TaxRate.GetAll(parms), t => t.id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "WooCommerce tax rates could not be fetched; falling back to default tax rate {Rate}", DefaultTaxRate);
            return new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        }

        var map = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        foreach (var taxRate in rates)
        {
            if (!double.TryParse(taxRate.rate, NumberStyles.Any, CultureInfo.InvariantCulture, out var rate))
            {
                continue;
            }

            var slug = string.IsNullOrEmpty(taxRate._class) ? "standard" : taxRate._class;
            if (!map.TryGetValue(slug, out var existing) || rate > existing)
            {
                map[slug] = rate;
            }
        }

        return map;
    }

    // Resolves a product's effective tax percentage from its tax-class label via the shop's rate map.
    // 'none' tax status means the product is not taxed; an unknown class falls back to the standard rate,
    // then to DefaultTaxRate when the shop exposed no rates at all.
    private static double ResolveTaxRate(Product product, IReadOnlyDictionary<string, double> taxRateMap)
    {
        if (string.Equals(product.tax_status, "none", StringComparison.OrdinalIgnoreCase))
        {
            return 0;
        }

        var slug = string.IsNullOrEmpty(product.tax_class) ? "standard" : product.tax_class;
        if (taxRateMap.TryGetValue(slug, out var rate))
        {
            return rate;
        }

        return taxRateMap.TryGetValue("standard", out var standardRate) ? standardRate : DefaultTaxRate;
    }

    public override async Task<SyncResult> ImportCustomersAsync(SalesChannelContext context)
    {
        try
        {
            SalesChannelUrlValidator.Validate(context.SalesChannel.Url);
        }
        catch (ArgumentException ex)
        {
            return SyncResult.Failed($"Invalid sales channel URL: {ex.Message}");
        }

        var processed = 0;
        var failed = 0;

        WCObject wc;
        try
        {
            wc = BuildClient(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        // Unlike products, the customer base on a large shop can take longer than a single HTTP
        // timeout window to walk end to end (observed: ~14 min then "operation has timed out"). Page
        // and persist incrementally so a late page failure keeps every customer imported so far —
        // buffering the whole list first would discard all progress on the first slow page. Upserts
        // are idempotent, so a subsequent run simply resumes filling in what is still missing.
        var seen = new HashSet<string>();
        for (var page = 1; page <= MaxPages; page++)
        {
            // WooCommerceNET's HTTP calls do not observe the token, so check between pages: a server
            // shutdown then ends the walk promptly and the dispatcher closes the run as canceled rather
            // than leaving it orphaned at "Running". Already-imported pages stay persisted.
            context.CancellationToken.ThrowIfCancellationRequested();

            List<Customer> batch;
            try
            {
                batch = await wc.Customer.GetAll(new Dictionary<string, string>
                {
                    ["per_page"] = PageSize.ToString(),
                    ["page"] = page.ToString(),
                }).WaitAsync(PageFetchTimeout, context.CancellationToken);
            }
            catch (Exception ex)
            {
                // Stop on a page-fetch failure but keep what we have: report a partial result when some
                // customers were imported, a hard failure only when the very first page never returned.
                _logger.LogError(ex, "WooCommerce customer page {Page} fetch failed", page);
                return processed > 0
                    ? new SyncResult(processed, failed + 1)
                    : SyncResult.Failed(ex.Message);
            }

            if (batch is null || batch.Count == 0)
            {
                break;
            }

            var newInBatch = 0;
            foreach (var remoteCustomer in batch)
            {
                // Guard against an endpoint that ignores `page` and keeps returning the same rows.
                var key = remoteCustomer.id?.ToString() ?? $"__noid_{processed}_{failed}";
                if (!seen.Add(key))
                {
                    continue;
                }
                newInBatch++;

                try
                {
                    await _customerImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, new SalesChannelImportCustomer
                    {
                        RemoteCustomerId = remoteCustomer.id?.ToString() ?? string.Empty,
                        Firstname = remoteCustomer.first_name,
                        Lastname = remoteCustomer.last_name,
                        CompanyName = remoteCustomer.billing?.company,
                        Email = remoteCustomer.email,
                        Phone = remoteCustomer.billing?.phone,
                        CustomerStatus = CustomerStatus.Active,
                        // Persisted into a PostgreSQL 'timestamp with time zone', which Npgsql only
                        // accepts at UTC offset 0. WooCommerce's date_created carries the shop's local
                        // offset, so use the GMT field and force UTC kind — otherwise the very first
                        // insert throws and the shared DbContext stays poisoned for the whole run.
                        DateEnrollment = ToUtc(remoteCustomer.date_created_gmt ?? remoteCustomer.date_created),
                        BillingAddress = MapAddress(remoteCustomer.billing),
                        ShippingAddress = MapAddress(remoteCustomer.shipping),
                    });
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce customer import failed for {Id}", remoteCustomer.id);
                }
            }

            // No new rows (endpoint repeated a page) or a short page → we have reached the end.
            if (newInBatch == 0 || batch.Count < PageSize)
            {
                break;
            }
        }

        return new SyncResult(processed, failed);
    }

    public override async Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteProductId) || !uint.TryParse(payload.RemoteProductId, out var productId))
        {
            return ExportResult.Fail("WooCommerce product id (numeric RemoteProductId) is required for stock updates");
        }

        try
        {
            var wc = BuildClient(context);

            // Variations are addressed under their parent: PUT products/{parent}/variations/{variation}
            if (!string.IsNullOrEmpty(payload.ParentRemoteProductId) && uint.TryParse(payload.ParentRemoteProductId, out var parentId))
            {
                await wc.Product.Variations.Update(productId, new Variation
                {
                    stock_quantity = payload.Quantity,
                    manage_stock = true,
                }, parentId);
            }
            else
            {
                await wc.Product.Update(productId, new Product
                {
                    stock_quantity = payload.Quantity,
                    manage_stock = true,
                });
            }

            return ExportResult.Ok(payload.RemoteProductId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteProductId) || !uint.TryParse(payload.RemoteProductId, out var productId))
        {
            return ExportResult.Fail("WooCommerce product id (numeric RemoteProductId) is required for price updates");
        }

        try
        {
            var wc = BuildClient(context);

            if (!string.IsNullOrEmpty(payload.ParentRemoteProductId) && uint.TryParse(payload.ParentRemoteProductId, out var parentId))
            {
                await wc.Product.Variations.Update(productId, new Variation
                {
                    regular_price = payload.Price,
                }, parentId);
            }
            else
            {
                await wc.Product.Update(productId, new Product
                {
                    regular_price = payload.Price,
                });
            }

            return ExportResult.Ok(payload.RemoteProductId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    private const string ApiPath = "/wp-json/wc/v3";

    // Max page size WooCommerce allows per request, and a hard ceiling on how many pages we will ever
    // pull. The page cap is a safety net so a misbehaving endpoint can never spin the import forever.
    private const int PageSize = 100;
    private const int MaxPages = 1000;

    // Retry budget for a single order-page fetch. Transient blips (timeout, 5xx, brief DNS/TLS hiccup,
    // Cloudflare interstitial) should not abort an otherwise-healthy run.
    private const int PageFetchAttempts = 3;
    private static readonly TimeSpan PageRetryDelay = TimeSpan.FromSeconds(3);

    /// <summary>
    /// WooCommerce returns products in pages (default 10, max 100 per request). <c>GetAll()</c> with no
    /// parameters only fetches the first page, so a shop with more than one page would import a partial
    /// catalogue. Page through with the maximum page size until the API stops yielding <em>new</em> rows.
    /// </summary>
    private static Task<List<Product>> GetAllProductsAsync(WCObject wc, CancellationToken cancellationToken) =>
        GetAllPagedAsync(parms => wc.Product.GetAll(parms), p => p.id, cancellationToken);

    /// <summary>
    /// Fetches all variations of a variable product, paged like the product list. A typical
    /// variable product holds well under one page of variations, but fabric shops with
    /// per-length variations can exceed it.
    /// </summary>
    private static Task<List<Variation>> GetAllVariationsAsync(WCObject wc, ulong parentId, CancellationToken cancellationToken) =>
        GetAllPagedAsync(parms => wc.Product.Variations.GetAll(parentId, parms), v => v.id, cancellationToken);

    /// <summary>
    /// Generic page-walker for the WooCommerce list endpoints. Terminates as soon as a page is empty,
    /// shorter than the page size, or — critically — contains no IDs we have not already seen. The
    /// last condition guarantees termination even if the endpoint ignores the <c>page</c> parameter and
    /// keeps returning the same first page (which would otherwise loop forever). A hard page cap backs
    /// this up. <paramref name="idSelector"/> yields a stable key per item used for the seen-check.
    /// </summary>
    private static async Task<List<T>> GetAllPagedAsync<T>(
        Func<Dictionary<string, string>, Task<List<T>>> fetchPage,
        Func<T, object> idSelector,
        CancellationToken cancellationToken)
    {
        var all = new List<T>();
        var seen = new HashSet<string>();

        for (var page = 1; page <= MaxPages; page++)
        {
            // The SDK's HTTP calls ignore the token; check between pages so a shutdown ends the walk.
            cancellationToken.ThrowIfCancellationRequested();

            var batch = await fetchPage(new Dictionary<string, string>
            {
                ["per_page"] = PageSize.ToString(),
                ["page"] = page.ToString(),
            }).WaitAsync(PageFetchTimeout, cancellationToken);

            if (batch is null || batch.Count == 0)
            {
                break;
            }

            var newInBatch = 0;
            foreach (var item in batch)
            {
                // Fall back to the running index when an item has no id, so distinct id-less rows are
                // still treated as new rather than collapsing to a single key.
                var key = idSelector(item)?.ToString() ?? $"__noid_{all.Count}";
                if (seen.Add(key))
                {
                    all.Add(item);
                    newInBatch++;
                }
            }

            // No progress (e.g. the endpoint ignored `page` and repeated rows) or a short page → done.
            if (newInBatch == 0 || batch.Count < PageSize)
            {
                break;
            }
        }

        return all;
    }

    // A browser-like User-Agent so the shop's CDN/WAF bot protection (e.g. Cloudflare managed challenge)
    // does not flag the API calls. WooCommerceNET's default UA gets challenged, which stalls the import
    // mid-walk after a burst of page requests.
    private const string BrowserUserAgent =
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";

    // Upper bound on a single list-page fetch. WooCommerceNET's own HttpClient has no effective cap here,
    // so a hung request (seen when a CDN stops responding) would block the orchestrator indefinitely.
    private static readonly TimeSpan PageFetchTimeout = TimeSpan.FromSeconds(60);

    private static WCObject BuildClient(SalesChannelContext context) => new(BuildRestApi(context));

    private static RestAPI BuildRestApi(SalesChannelContext context)
    {
        var sc = context.SalesChannel;
        return new RestAPI(BuildApiUrl(sc.Url), sc.Username, context.Password,
            requestFilter: req => req.UserAgent = BrowserUserAgent);
    }

    /// <summary>
    /// Builds the WooCommerce REST base URL. The stored channel URL may be either the shop's
    /// base address or already include <c>/wp-json/wc/v3</c> (the Client normalizes new entries
    /// to the full endpoint) — append the path only when it is not already present so the result
    /// is the same either way. The WooCommerceNET SDK expects a trailing slash.
    /// </summary>
    private static string BuildApiUrl(string url)
    {
        var trimmed = url.TrimEnd('/');
        if (!trimmed.EndsWith(ApiPath, StringComparison.OrdinalIgnoreCase))
        {
            trimmed += ApiPath;
        }
        return trimmed + "/";
    }

    // WooCommerce returns a product's photos as an ordered list (first entry is the featured image).
    // 'position' carries the gallery order; fall back to list index when absent. 'src' is the public
    // file URL the import downloads.
    private static List<SalesChannelImportImage> MapImages(List<ProductImage> images)
    {
        if (images is null || images.Count == 0)
        {
            return [];
        }

        return images
            .Where(img => !string.IsNullOrWhiteSpace(img.src))
            .Select((img, index) => new SalesChannelImportImage
            {
                RemoteImageId = img.id?.ToString() ?? string.Empty,
                Url = img.src,
                AltText = string.IsNullOrWhiteSpace(img.alt) ? img.name : img.alt,
                SortOrder = img.position ?? index,
            })
            .ToList();
    }

    // WooCommerce date fields come back without a usable Kind; treat the GMT value as UTC wall-clock so
    // the resulting DateTimeOffset has offset 0 (the only offset Npgsql writes to 'timestamptz').
    private static DateTime ToUtc(DateTime? value) =>
        value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : DateTime.UtcNow;

    private static SalesChannelImportCustomerAddress MapAddress(CustomerBilling billing) => new()
    {
        Firstname = billing?.first_name,
        Lastname = billing?.last_name,
        CompanyName = billing?.company,
        Street = billing?.address_1,
        City = billing?.city,
        Zip = billing?.postcode,
        Country = billing?.country,
        Phone = billing?.phone,
    };

    private static SalesChannelImportCustomerAddress MapAddress(CustomerShipping shipping) => new()
    {
        Firstname = shipping?.first_name,
        Lastname = shipping?.last_name,
        CompanyName = shipping?.company,
        Street = shipping?.address_1,
        City = shipping?.city,
        Zip = shipping?.postcode,
        Country = shipping?.country,
    };

    private static SalesStatus MapSalesStatus(string salesStatus) => salesStatus switch
    {
        "pending" => SalesStatus.Pending,
        "processing" => SalesStatus.Processing,
        "on-hold" => SalesStatus.OnHold,
        "completed" => SalesStatus.Completed,
        "cancelled" => SalesStatus.Cancelled,
        "refunded" => SalesStatus.Refunded,
        "failed" => SalesStatus.Failed,
        _ => SalesStatus.Unknown,
    };

    // WooCommerce has no explicit payment-status field; infer it from the order. A set 'date_paid' is the
    // strongest signal a payment was captured; 'completed'/'processing' likewise imply funds received. A
    // refund maps to re-crediting. Everything else (pending, on-hold, cancelled, failed) is treated as an
    // open invoice rather than paid.
    private static PaymentStatus MapPaymentStatus(WooOrder remoteSales)
    {
        var paidAt = remoteSales.date_paid_gmt ?? remoteSales.date_paid;
        if (paidAt.HasValue && paidAt.Value != default)
        {
            return PaymentStatus.CompletelyPaid;
        }

        return remoteSales.status switch
        {
            "completed" or "processing" => PaymentStatus.CompletelyPaid,
            "refunded" => PaymentStatus.ReCrediting,
            _ => PaymentStatus.Invoiced,
        };
    }
}
