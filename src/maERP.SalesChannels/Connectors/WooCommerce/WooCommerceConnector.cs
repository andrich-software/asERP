#nullable disable
using maERP.Application.Contracts.Persistence;
using maERP.Domain.Enums;
using maERP.SalesChannels.Abstractions;
using maERP.SalesChannels.Connectors.Common;
using maERP.SalesChannels.Contracts;
using maERP.SalesChannels.Models;
using Microsoft.Extensions.Logging;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace maERP.SalesChannels.Connectors.WooCommerce;

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
            var remoteProducts = await GetAllProductsAsync(wc, context.CancellationToken);
            foreach (var remoteProduct in remoteProducts)
            {
                if (string.IsNullOrEmpty(remoteProduct.sku))
                {
                    _logger.LogDebug("Product {Name} has no SKU, skipping", remoteProduct.name);
                    continue;
                }

                try
                {
                    await _productImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel.Id, new SalesChannelImportProduct
                    {
                        Name = remoteProduct.name,
                        // Variable/grouped products carry no own price (null) — default to 0 instead of
                        // letting the cast throw and dropping the row as a failed import.
                        Price = remoteProduct.price ?? 0m,
                        Sku = remoteProduct.sku,
                        TaxRate = 19,
                        Description = remoteProduct.description,
                    });
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce product import failed for SKU {Sku}", remoteProduct.sku);
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

        var processed = 0;
        var failed = 0;

        try
        {
            var wc = BuildClient(context);
            var remoteSaless = await GetAllOrdersAsync(wc, context.CancellationToken);

            foreach (var remoteSales in remoteSaless)
            {
                try
                {
                    decimal subtotal = (remoteSales.total ?? 0) - (remoteSales.total_tax ?? 0) - (remoteSales.shipping_total ?? 0);

                    var importSales = new SalesChannelImportSales
                    {
                        RemoteSalesId = remoteSales.id.ToString(),
                        DateSalesed = remoteSales.date_created ?? DateTime.UtcNow,
                        Status = MapSalesStatus(remoteSales.status),
                        PaymentStatus = PaymentStatus.Unknown,
                        PaymentMethod = remoteSales.payment_method,
                        PaymentProvider = remoteSales.payment_method_title,
                        PaymentTransactionId = remoteSales.transaction_id,
                        Subtotal = subtotal,
                        ShippingCost = remoteSales.shipping_total ?? 0,
                        TotalTax = remoteSales.total_tax ?? 0,
                        Total = remoteSales.total ?? 0,
                        Customer = new SalesChannelImportCustomer
                        {
                            Firstname = remoteSales.billing.first_name,
                            Lastname = remoteSales.billing.last_name,
                            CompanyName = remoteSales.billing.company,
                            Email = remoteSales.billing.email,
                            Phone = remoteSales.billing.phone,
                            DateEnrollment = remoteSales.date_created_gmt ?? DateTime.UtcNow,
                        },
                        BillingAddress = new SalesChannelImportCustomerAddress
                        {
                            Firstname = remoteSales.billing.first_name,
                            Lastname = remoteSales.billing.last_name,
                            CompanyName = remoteSales.billing.company,
                            Street = remoteSales.billing.address_1,
                            City = remoteSales.billing.city,
                            Zip = remoteSales.billing.postcode,
                            Country = remoteSales.billing.country,
                        },
                        ShippingAddress = new SalesChannelImportCustomerAddress
                        {
                            Firstname = remoteSales.shipping.first_name,
                            Lastname = remoteSales.shipping.last_name,
                            CompanyName = remoteSales.shipping.company,
                            Street = remoteSales.shipping.address_1,
                            City = remoteSales.shipping.city,
                            Zip = remoteSales.shipping.postcode,
                            Country = remoteSales.shipping.country,
                        },
                        SalesItems = remoteSales.line_items.Select(item => new SalesChannelImportSalesItem
                        {
                            Name = item.name,
                            Sku = item.sku,
                            Quantity = (double)item.quantity!,
                            Price = (decimal)item.price!,
                            TaxRate = string.IsNullOrEmpty(item.tax_class) ? 0 : Convert.ToDouble(item.tax_class),
                        }).ToList(),
                    };

                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, importSales);
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce sales import failed for {Id}", remoteSales.id);
                }
            }
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
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
                });
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
            await wc.Product.Update(productId, new Product
            {
                stock_quantity = payload.Quantity,
                manage_stock = true,
            });
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
            await wc.Product.Update(productId, new Product
            {
                regular_price = payload.Price,
            });
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

    /// <summary>
    /// WooCommerce returns products in pages (default 10, max 100 per request). <c>GetAll()</c> with no
    /// parameters only fetches the first page, so a shop with more than one page would import a partial
    /// catalogue. Page through with the maximum page size until the API stops yielding <em>new</em> rows.
    /// </summary>
    private static Task<List<Product>> GetAllProductsAsync(WCObject wc, CancellationToken cancellationToken) =>
        GetAllPagedAsync(parms => wc.Product.GetAll(parms), p => p.id, cancellationToken);

    /// <summary>
    /// Pages through all WooCommerce orders for the same reason as <see cref="GetAllProductsAsync"/>:
    /// <c>GetAll()</c> with no parameters returns only the first page, which would silently truncate
    /// the sales import on shops with more than one page of orders.
    /// </summary>
    private static Task<List<Order>> GetAllOrdersAsync(WCObject wc, CancellationToken cancellationToken) =>
        GetAllPagedAsync(parms => wc.Order.GetAll(parms), o => o.id, cancellationToken);

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
            });

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

    private static WCObject BuildClient(SalesChannelContext context)
    {
        var sc = context.SalesChannel;
        var rest = new RestAPI(BuildApiUrl(sc.Url), sc.Username, context.Password);
        return new WCObject(rest);
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
}
