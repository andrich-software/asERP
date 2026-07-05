using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Repositories;

public class SalesImportRepository : ISalesImportRepository
{
    private readonly ILogger<SalesImportRepository> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IProductRepository _productRepository;
    private readonly ApplicationDbContext _dbContext;

    // Process-wide id allocator for the per-tenant SalesId/CustomerId sequences (seeded from MAX once,
    // then atomic increments). Shared across all concurrent runs so the sales and customer imports of a
    // channel can run in parallel without handing out duplicate ids.
    private readonly ImportIdAllocator _idAllocator;

    private readonly IStockLedgerService _stockLedger;

    // Per-run cache of the channel's booking warehouse (first linked warehouse). Guid.Empty = channel has
    // no warehouse → stock booking is skipped for the whole run.
    private Guid? _bookingWarehouseId;

    // Per-run lookup caches. The country set is tiny and static, and product SKUs repeat heavily across a
    // page of orders — caching turns the per-order (country ×2) and per-line-item (SKU) queries into a
    // handful of lookups per run. Scoped lifetime keeps them naturally run-local (no cross-run staleness).
    // Countries are cached as plain id/name pairs, NOT tracked entities: the tracker is trimmed after every
    // order (TrimCommittedEntries), and re-attaching a detached Country via a navigation would insert a
    // duplicate. With only CountryId set, EF never needs the entity.
    private readonly Dictionary<string, (Guid Id, string Name)?> _countryCache = new();
    private readonly Dictionary<string, Guid?> _productIdBySkuCache = new();

    public SalesImportRepository(
        ILogger<SalesImportRepository> logger,
        ISalesRepository salesRepository,
        ICustomerRepository customerRepository,
        ICountryRepository countryRepository,
        IProductRepository productRepository,
        ApplicationDbContext dbContext,
        ImportIdAllocator idAllocator,
        IStockLedgerService stockLedger)
    {
        _logger = logger;
        _salesRepository = salesRepository;
        _customerRepository = customerRepository;
        _countryRepository = countryRepository;
        _productRepository = productRepository;
        _dbContext = dbContext;
        _idAllocator = idAllocator;
        _stockLedger = stockLedger;
    }

    public async Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportSales importSales)
    {
        // Every repository in this run shares one scoped DbContext. If an order fails mid-save its
        // half-applied Added/Modified entries stay tracked and poison the next SaveChanges, turning one bad
        // order into a run-wide cascade. Each order is self-contained and prior orders are already persisted,
        // so on failure we revert just this order's pending changes (rather than ChangeTracker.Clear(), which
        // would also detach the dispatcher's run row and drop the per-run identity cache) and rethrow so the
        // connector logs and counts the single failure.
        try
        {
            await ImportOrUpdateCoreAsync(salesChannel, importSales);

            // Everything this order committed is now Unchanged ballast; drop it so DetectChanges stays
            // cheap for the thousands of orders that follow (run row + channel entity stay tracked).
            _dbContext.TrimCommittedEntries();
        }
        catch
        {
            _dbContext.DiscardPendingChanges();
            throw;
        }
    }

    private async Task ImportOrUpdateCoreAsync(SalesChannel salesChannel, SalesChannelImportSales importSales)
    {
        var existingSales = await _salesRepository.GetByRemoteSalesIdAsync(salesChannel.Id, importSales.RemoteSalesId);

        if (existingSales == null)
        {
            _logger.LogDebug("Sales {0}: does not exist, create sales...", importSales.RemoteSalesId);

            // try to find customer in sales channel
            var customer = await _customerRepository.GetCustomerByRemoteCustomerIdAsync(salesChannel.Id, importSales.RemoteCustomerId);

            // when not found, try to find via email
            if (customer == null && importSales.Customer != null && !string.IsNullOrEmpty(importSales.Customer.Email))
            {
                customer = await _customerRepository.GetCustomerByEmailAsync(importSales.Customer.Email);

                // when found, add to CustomerSalesChannel
                if (customer != null)
                {
                    AddCustomerSalesChannelLink(customer.Id, salesChannel.Id, importSales.RemoteCustomerId);
                    _logger.LogDebug("CustomerSalesChannel added for Customer {0} ", customer.Id);
                }
            }

            // when still not found, create new customer
            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    // Assign the per-tenant CustomerId from the shared allocator (not a MAX scan per row) so
                    // the order's FK is resolved before the single SaveChanges below inserts the whole graph.
                    CustomerId = await _idAllocator.NextAsync(salesChannel.TenantId, ImportIdAllocator.CustomerKind,
                        async () => await _customerRepository.GetMaxCustomerIdAsync()),
                    Email = importSales.Customer?.Email ?? string.Empty,
                    Firstname = importSales.Customer?.Firstname ?? string.Empty,
                    Lastname = importSales.Customer?.Lastname ?? string.Empty,
                    CompanyName = importSales.Customer?.CompanyName ?? string.Empty,
                    Phone = importSales.Customer?.Phone ?? string.Empty,
                    Website = importSales.Customer?.Website ?? string.Empty,
                    VatNumber = importSales.Customer?.VatNumber ?? string.Empty,
                    Note = importSales.Customer?.Note ?? string.Empty,
                    CustomerStatus = importSales.Customer?.CustomerStatus ?? CustomerStatus.Active,
                    DateEnrollment = importSales.Customer?.DateEnrollment ?? DateTime.UtcNow,
                };

                // Deferred: added to the context now, committed with the order in one SaveChanges below.
                _dbContext.Customer.Add(newCustomer);
                _logger.LogDebug("Customer {0} created", importSales.Customer?.Email);
                customer = newCustomer;

                AddCustomerSalesChannelLink(newCustomer.Id, salesChannel.Id, importSales.RemoteCustomerId);
                _logger.LogDebug("CustomerSalesChannel added for Customer {0} ", customer.Id);
            }

            // A customer must never be "newer" than an order they placed. An existing customer may have been
            // created earlier from a later order (or out of order), leaving DateEnrollment after this order.
            // Mutation only — persisted by the single SaveChanges after the order graph is built.
            FloorCustomerEnrollment(customer, importSales.DateSalesed);

            Guid billingAddressId = Guid.Empty;
            Guid shippingAddressId = Guid.Empty;
            var customerAddresses = await _customerRepository.GetCustomerAddressByCustomerIdAsync(customer.Id);

            var billingAddressCountry = await MapCountryFromStringAsync(importSales.BillingAddress.Country);
            var shippingAddressCountry = await MapCountryFromStringAsync(importSales.ShippingAddress.Country);

            // An unresolved country must not drop the whole order. Keep the raw country string on the sales
            // record (below) and skip only the structured CustomerAddress, which needs a Country FK.
            if (billingAddressCountry == null && !string.IsNullOrWhiteSpace(importSales.BillingAddress.Country))
            {
                _logger.LogWarning("Sales {0}: billing country {1} not found, importing with raw country string", importSales.RemoteSalesId, importSales.BillingAddress.Country);
            }

            if (shippingAddressCountry == null && !string.IsNullOrWhiteSpace(importSales.ShippingAddress.Country))
            {
                _logger.LogWarning("Sales {0}: shipping country {1} not found, importing with raw country string", importSales.RemoteSalesId, importSales.ShippingAddress.Country);
            }

            foreach (var address in customerAddresses)
            {
                if (address.Firstname == importSales.BillingAddress.Firstname &&
                    address.Lastname == importSales.BillingAddress.Lastname &&
                    address.CompanyName == importSales.BillingAddress.CompanyName &&
                    address.Street == importSales.BillingAddress.Street &&
                    address.City == importSales.BillingAddress.City &&
                    address.Zip == importSales.BillingAddress.Zip)
                {
                    billingAddressId = address.Id;
                }

                if (address.Firstname == importSales.ShippingAddress.Firstname &&
                    address.Lastname == importSales.ShippingAddress.Lastname &&
                    address.CompanyName == importSales.ShippingAddress.CompanyName &&
                    address.Street == importSales.ShippingAddress.Street &&
                    address.City == importSales.ShippingAddress.City &&
                    address.Zip == importSales.ShippingAddress.Zip)
                {
                    shippingAddressId = address.Id;
                }

                if (billingAddressId != Guid.Empty && shippingAddressId != Guid.Empty)
                {
                    break;
                }
            }

            // Add the billing address only when it is not already on file and its country resolved (the FK is
            // required). A missing country is logged above and the order still imports with the raw string.
            if (billingAddressId == Guid.Empty && billingAddressCountry is { } billingCountry)
            {
                var newAddress = new CustomerAddress
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    Firstname = importSales.BillingAddress.Firstname,
                    Lastname = importSales.BillingAddress.Lastname,
                    CompanyName = importSales.BillingAddress.CompanyName,
                    Street = importSales.BillingAddress.Street,
                    City = importSales.BillingAddress.City,
                    Zip = importSales.BillingAddress.Zip,
                    CountryId = billingCountry.Id
                };

                _dbContext.CustomerAddress.Add(newAddress);
            }

            // Add the shipping address only when it is not already on file, differs from billing, and its
            // country resolved. The previous condition was inverted (created only when already present).
            if (shippingAddressId == Guid.Empty
                && shippingAddressCountry is { } shippingCountry
                && !AddressesEqual(importSales.BillingAddress, importSales.ShippingAddress))
            {
                var newAddress = new CustomerAddress
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    Firstname = importSales.ShippingAddress.Firstname,
                    Lastname = importSales.ShippingAddress.Lastname,
                    CompanyName = importSales.ShippingAddress.CompanyName,
                    Street = importSales.ShippingAddress.Street,
                    City = importSales.ShippingAddress.City,
                    Zip = importSales.ShippingAddress.Zip,
                    CountryId = shippingCountry.Id,
                };

                _dbContext.CustomerAddress.Add(newAddress);
            }

            var newSales = new Sales
            {
                SalesId = await _idAllocator.NextAsync(salesChannel.TenantId, ImportIdAllocator.SalesKind,
                    async () => await _salesRepository.GetMaxSalesIdAsync()),
                SalesChannelId = salesChannel.Id,
                RemoteSalesId = importSales.RemoteSalesId,
                CustomerId = customer.CustomerId,
                Status = importSales.Status,

                PaymentStatus = importSales.PaymentStatus,
                PaymentMethod = importSales.PaymentMethod,
                PaymentProvider = importSales.PaymentProvider,
                PaymentTransactionId = importSales.PaymentTransactionId,

                Subtotal = importSales.Subtotal,
                ShippingCost = importSales.ShippingCost,
                TotalTax = importSales.TotalTax,
                Total = importSales.Total,

                InvoiceAddressFirstName = importSales.BillingAddress.Firstname,
                InvoiceAddressLastName = importSales.BillingAddress.Lastname,
                InvoiceAddressCompanyName = importSales.BillingAddress.CompanyName,
                InvoiceAddressStreet = importSales.BillingAddress.Street,
                InvoiceAddressCity = importSales.BillingAddress.City,
                InvoiceAddressZip = importSales.BillingAddress.Zip,
                InvoiceAddressCountry = billingAddressCountry?.Name ?? importSales.BillingAddress.Country ?? string.Empty,

                DeliveryAddressFirstName = importSales.ShippingAddress.Firstname,
                DeliveryAddressLastName = importSales.ShippingAddress.Lastname,
                DeliveryAddressCompanyName = importSales.ShippingAddress.CompanyName,
                DeliveryAddressStreet = importSales.ShippingAddress.Street,
                DeliveryAddressCity = importSales.ShippingAddress.City,
                DeliveryAddressZip = importSales.ShippingAddress.Zip,
                DeliveryAddressCountry = shippingAddressCountry?.Name ?? importSales.ShippingAddress.Country ?? string.Empty,

                DateSalesed = importSales.DateSalesed.ToUniversalTime()
            };

            if (importSales.SalesItems != null && importSales.SalesItems.Count > 0)
            {
                foreach (var item in importSales.SalesItems)
                {
                    var newSalesItem = new SalesItem
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        TaxRate = item.TaxRate
                    };

                    // A line with no SKU (e.g. a fee or a custom/legacy position) cannot match a product —
                    // treat it like a not-found product rather than dropping the whole order.
                    var productId = string.IsNullOrEmpty(item.Sku)
                        ? null
                        : await ResolveProductIdBySkuAsync(item.Sku);

                    if (productId is { } resolvedProductId)
                    {
                        newSalesItem.ProductId = resolvedProductId;
                        _logger.LogDebug("Sales {0}: Add Item {1}", importSales.RemoteSalesId, item.Name);
                    }
                    else
                    {
                        // Keep the line with its SKU/EAN so the order total stays correct and the missing
                        // product can be reconciled later (ProductId stays empty).
                        newSalesItem.MissingProductSku = item.Sku;
                        newSalesItem.MissingProductEan = item.Ean;

                        _logger.LogDebug("Sales {0}: product with SKU '{1}' not found, importing as missing-product line", importSales.RemoteSalesId, item.Sku);
                    }

                    newSales.SalesItems.Add(newSalesItem);
                }
            }

            newSales.SalesHistories = new List<SalesHistory>
            {
                new SalesHistory
                {
                    UserId = Guid.Empty,
                    SalesId = newSales.Id,
                    SalesStatusNew = newSales.Status,
                    PaymentStatusNew = newSales.PaymentStatus,
                    // TODO: implement ShippingStatus on import
                    // ShippingStatusNew = newSales.ShippingStatus,
                    Description = $"Imported from {salesChannel.Name}",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                }
            };

            _dbContext.Sales.Add(newSales);

            // Single commit for the whole order graph built above — new customer + sales-channel link +
            // addresses + sales + items + history + any DateEnrollment floor — in one round-trip, instead of
            // the 5-6 separate SaveChanges the per-entity repository calls used to issue per order.
            await _dbContext.SaveChangesAsync();
            _logger.LogDebug("Sales {0}: created", importSales.RemoteSalesId);

            await BookSaleMovementsAsync(salesChannel, newSales);
        }
        else
        {
            _logger.LogDebug("Sales {0}: already exists, check for changes", existingSales.RemoteSalesId);
            bool somethingChanged = false;

            // Heal the enrollment date even for orders already imported: a full re-sweep then corrects any
            // customer whose DateEnrollment ended up after one of their (already-existing) orders.
            var customerFloored = false;
            var existingCustomer = await _customerRepository.GetByCustomerIdAsync(existingSales.CustomerId);
            if (existingCustomer != null)
            {
                customerFloored = FloorCustomerEnrollment(existingCustomer, importSales.DateSalesed);
            }

            if (existingSales.Status != importSales.Status)
            {
                // Local terminal states win: a locally cancelled/returned/refunded order must not be
                // resurrected by a stale remote status — e.g. while a local cancel is still on its way
                // to the shop via the CancelSales outbox. Otherwise the import and the push ping-pong.
                if (IsCancelledStatus(existingSales.Status) && !IsCancelledStatus(importSales.Status))
                {
                    _logger.LogInformation("Sales {0}: keeping local terminal status {1}, remote reports {2}",
                        importSales.RemoteSalesId, existingSales.Status, importSales.Status);
                }
                else
                {
                    _logger.LogInformation("Sales {0}: Status updated, new status is {1}", importSales.RemoteSalesId, importSales.Status);
                    var becameCancelled = !IsCancelledStatus(existingSales.Status) && IsCancelledStatus(importSales.Status);
                    existingSales.Status = importSales.Status;
                    somethingChanged = true;

                    if (becameCancelled)
                    {
                        await BookCancellationMovementsAsync(salesChannel, existingSales);
                    }
                }
            }

            if (existingSales.PaymentStatus != importSales.PaymentStatus)
            {
                _logger.LogInformation("Sales {0}: PaymentStatus updated, new status is {1}", importSales.RemoteSalesId, importSales.PaymentStatus);
                existingSales.PaymentStatus = importSales.PaymentStatus;
                somethingChanged = true;
            }

            // TODO: implement check for changed shipping status

            if (somethingChanged)
            {
                // Saves all tracked changes for this order, including a floored customer enrollment.
                await _salesRepository.UpdateAsync(existingSales);
                _logger.LogInformation("Sales {0}: updated", importSales.RemoteSalesId);
            }
            else
            {
                // The order itself is unchanged, but a DateEnrollment floor still needs persisting.
                if (customerFloored)
                {
                    await _dbContext.SaveChangesAsync();
                }
                _logger.LogDebug("Sales {0}: has no changes", importSales.RemoteSalesId);
            }
        }
    }

    /// <summary>
    /// Books ledger decrements for a newly imported order. Only in the shop-mirror model's "other
    /// channel" role: the stock-master channel (<see cref="SalesChannel.ImportStock"/>) already
    /// decremented itself and the mirror follows it, and the historical backfill must never book
    /// (those sales are already reflected in the mirrored level). Idempotent per (SalesItemId, Type).
    /// </summary>
    private async Task BookSaleMovementsAsync(SalesChannel salesChannel, Sales newSales)
    {
        if (salesChannel.ImportStock || !salesChannel.InitialSalesImportCompleted || IsCancelledStatus(newSales.Status))
        {
            return;
        }

        var warehouseId = await ResolveBookingWarehouseIdAsync(salesChannel);
        if (warehouseId == Guid.Empty)
        {
            return;
        }

        foreach (var salesItem in newSales.SalesItems)
        {
            // Missing-product lines have no ProductId — nothing to book.
            if (salesItem.ProductId == Guid.Empty || salesItem.Quantity == 0)
            {
                continue;
            }

            await _stockLedger.ApplyMovementAsync(new StockMovementRequest(
                salesItem.ProductId,
                warehouseId,
                -salesItem.Quantity,
                StockMovementType.SaleImport,
                SalesItemId: salesItem.Id,
                SalesChannelId: salesChannel.Id,
                TenantId: salesChannel.TenantId), CancellationToken.None);
        }
    }

    /// <summary>
    /// Books compensating (positive) movements when an order flips to a cancelled-like status — but only
    /// for lines whose decrement was actually booked (backfilled orders never were), so a cancellation
    /// can never create phantom stock. Idempotent per (SalesItemId, SaleCancelled).
    /// </summary>
    private async Task BookCancellationMovementsAsync(SalesChannel salesChannel, Sales existingSales)
    {
        var warehouseId = await ResolveBookingWarehouseIdAsync(salesChannel);
        if (warehouseId == Guid.Empty)
        {
            return;
        }

        var items = await _dbContext.SalesItem
            .Where(i => i.SalesId == existingSales.Id && i.ProductId != Guid.Empty)
            .Select(i => new { i.Id, i.ProductId, i.Quantity })
            .ToListAsync();

        if (items.Count == 0)
        {
            return;
        }

        var itemIds = items.Select(i => i.Id).ToList();
        var bookedItemIds = await _dbContext.StockMovement
            .Where(m => m.SalesItemId != null
                        && itemIds.Contains(m.SalesItemId.Value)
                        && m.Type == StockMovementType.SaleImport)
            .Select(m => m.SalesItemId!.Value)
            .ToListAsync();

        foreach (var item in items.Where(i => bookedItemIds.Contains(i.Id)))
        {
            await _stockLedger.ApplyMovementAsync(new StockMovementRequest(
                item.ProductId,
                warehouseId,
                item.Quantity,
                StockMovementType.SaleCancelled,
                SalesItemId: item.Id,
                SalesChannelId: salesChannel.Id,
                TenantId: salesChannel.TenantId), CancellationToken.None);
        }
    }

    private static bool IsCancelledStatus(SalesStatus status) =>
        status is SalesStatus.Cancelled or SalesStatus.Returned or SalesStatus.Refunded or SalesStatus.Failed;

    /// <summary>First linked warehouse of the channel, resolved once per run (Guid.Empty = none).</summary>
    private async Task<Guid> ResolveBookingWarehouseIdAsync(SalesChannel salesChannel)
    {
        if (_bookingWarehouseId is { } cached)
        {
            return cached;
        }

        var warehouseId = await _dbContext.SalesChannel
            .IgnoreQueryFilters()
            .Where(s => s.Id == salesChannel.Id)
            .SelectMany(s => s.Warehouses)
            .Select(w => (Guid?)w.Id)
            .FirstOrDefaultAsync() ?? Guid.Empty;

        if (warehouseId == Guid.Empty)
        {
            _logger.LogWarning("SalesChannel {Channel} has no linked warehouse — stock movements are skipped", salesChannel.Id);
        }

        _bookingWarehouseId = warehouseId;
        return warehouseId;
    }

    private async Task<(Guid Id, string Name)?> MapCountryFromStringAsync(string countryString)
    {
        if (string.IsNullOrEmpty(countryString))
        {
            return null;
        }

        // Country is a tiny static table hit twice per order (billing + shipping). Cache per run so repeated
        // country strings resolve in memory instead of a query each time.
        if (_countryCache.TryGetValue(countryString, out var cached))
        {
            return cached;
        }

        var country = await _countryRepository.GetCountryByString(countryString);
        var pair = country is null ? ((Guid Id, string Name)?)null : (country.Id, country.Name);
        _countryCache[countryString] = pair;
        return pair;
    }

    /// <summary>Adds a customer↔sales-channel link to the context (deferred; committed with the order).</summary>
    private void AddCustomerSalesChannelLink(Guid customerId, Guid salesChannelId, string remoteCustomerId)
    {
        _dbContext.CustomerSalesChannel.Add(new CustomerSalesChannel
        {
            CustomerId = customerId,
            SalesChannelId = salesChannelId,
            RemoteCustomerId = remoteCustomerId,
        });
    }

    /// <summary>
    /// Resolves a line item's SKU to a ProductId, caching per run. Order lines reference the same products
    /// repeatedly, so caching turns the per-line-item lookup into a handful of queries per run instead of one
    /// per position. Caches misses (null) too, so an unknown SKU is only queried once.
    /// </summary>
    private async Task<Guid?> ResolveProductIdBySkuAsync(string sku)
    {
        if (_productIdBySkuCache.TryGetValue(sku, out var cached))
        {
            return cached;
        }

        var product = await _productRepository.GetBySkuAsync(sku);
        var id = product?.Id;
        _productIdBySkuCache[sku] = id;
        return id;
    }

    /// <summary>
    /// Lowers the tracked customer's DateEnrollment down to <paramref name="orderDate"/> when the order
    /// predates it (a customer is never newer than an order they placed), and returns whether it changed.
    /// Only ever moves the date earlier, so it is safe and idempotent across repeated imports. Does NOT
    /// save — the caller persists it as part of the order's single SaveChanges (or an explicit save when
    /// the order itself is otherwise unchanged).
    /// </summary>
    private bool FloorCustomerEnrollment(Customer customer, DateTime orderDate)
    {
        if (orderDate == default)
        {
            return false;
        }

        var floor = new DateTimeOffset(DateTime.SpecifyKind(orderDate, DateTimeKind.Utc));
        if (floor < customer.DateEnrollment)
        {
            _logger.LogDebug("Customer {0}: lowering DateEnrollment from {1} to order date {2}", customer.Id, customer.DateEnrollment, floor);
            customer.DateEnrollment = floor;
            return true;
        }

        return false;
    }

    private static bool AddressesEqual(SalesChannelImportCustomerAddress a, SalesChannelImportCustomerAddress b)
    {
        return a.Firstname == b.Firstname &&
               a.Lastname == b.Lastname &&
               a.CompanyName == b.CompanyName &&
               a.Street == b.Street &&
               a.City == b.City &&
               a.Zip == b.Zip &&
               a.Country == b.Country;
    }
}
