using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Domain.Dtos.Company;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Shipping.Services;

public class ShippingDocumentDataService : IShippingDocumentDataService
{
    private readonly IShippingRepository _shippingRepository;
    private readonly IProductRepository _productRepository;
    private readonly ITenantRepository _tenantRepository;

    public ShippingDocumentDataService(
        IShippingRepository shippingRepository,
        IProductRepository productRepository,
        ITenantRepository tenantRepository)
    {
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
    }

    public async Task<PackingSlipData?> GetPackingSlipDataAsync(Guid shippingId, CancellationToken cancellationToken = default)
    {
        var shipping = await _shippingRepository.GetWithDetailsAsync(shippingId);
        if (shipping == null)
        {
            return null;
        }

        var items = await _shippingRepository.GetAssignedSalesItemsWithSerialsAsync(shippingId);
        var productById = await LoadProductsAsync(items, cancellationToken);

        // "Paket x von y" — position among all shipments of the order, in creation order.
        var siblings = await _shippingRepository.GetBySalesIdAsync(shipping.SalesId);
        var ordered = siblings
            .OrderBy(s => s.DateCreated)
            .ThenBy(s => s.Id)
            .ToList();
        var packageIndex = ordered.FindIndex(s => s.Id == shippingId) + 1;

        var showPrices = false;
        var company = new CompanySenderInfo();
        if (shipping.TenantId.HasValue)
        {
            var tenant = await _tenantRepository.GetByIdAsync(shipping.TenantId.Value, asNoTracking: true);
            if (tenant != null)
            {
                showPrices = tenant.PackingSlipShowPrices;
                company = tenant.ToCompanySenderInfo();
            }
        }

        var sales = shipping.Sales;

        return new PackingSlipData
        {
            TenantId = shipping.TenantId,
            Company = company,
            SalesNumber = sales.SalesId,
            SalesDate = sales.DateSalesed,
            TrackingNumber = shipping.TrackingNumber,
            PackageIndex = packageIndex > 0 ? packageIndex : 1,
            PackageCount = Math.Max(ordered.Count, 1),
            ShowPrices = showPrices,
            DeliveryFirstName = sales.DeliveryAddressFirstName,
            DeliveryLastName = sales.DeliveryAddressLastName,
            DeliveryCompanyName = sales.DeliveryAddressCompanyName,
            DeliveryStreet = sales.DeliveryAddressStreet,
            DeliveryZip = sales.DeliveryAddressZip,
            DeliveryCity = sales.DeliveryAddressCity,
            DeliveryCountry = sales.DeliveryAddressCountry,
            Items = items.Select(item =>
            {
                var product = productById.GetValueOrDefault(item.ProductId);
                return new PackingSlipItem
                {
                    Quantity = item.Quantity,
                    Name = item.Name,
                    Sku = product?.Sku is { Length: > 0 } sku ? sku : item.MissingProductSku,
                    Ean = product?.Ean is { Length: > 0 } ean ? ean : item.MissingProductEan,
                    Price = item.Price,
                    SerialNumbers = item.SerialNumbers
                        .Select(sn => sn.SerialNumber)
                        .Where(sn => !string.IsNullOrWhiteSpace(sn))
                        .ToList()
                };
            }).ToList()
        };
    }

    public async Task<PickListData?> GetPickListDataAsync(IReadOnlyCollection<Guid> shippingIds, CancellationToken cancellationToken = default)
    {
        var itemsWithSales = new List<(SalesItem Item, int SalesNumber)>();
        var salesNumbers = new List<int>();
        Guid? tenantId = null;
        var anyFound = false;

        foreach (var shippingId in shippingIds.Distinct())
        {
            var shipping = await _shippingRepository.GetWithDetailsAsync(shippingId);
            if (shipping == null)
            {
                continue;
            }

            anyFound = true;
            tenantId ??= shipping.TenantId;
            if (!salesNumbers.Contains(shipping.Sales.SalesId))
            {
                salesNumbers.Add(shipping.Sales.SalesId);
            }

            var items = await _shippingRepository.GetAssignedSalesItemsWithSerialsAsync(shippingId);
            itemsWithSales.AddRange(items.Select(i => (i, shipping.Sales.SalesId)));
        }

        if (!anyFound)
        {
            return null;
        }

        var productById = await LoadProductsAsync(itemsWithSales.Select(x => x.Item).ToList(), cancellationToken);

        var productIds = productById.Keys.ToList();
        var stocks = await _productRepository.GetContext<ProductStock>()
            .Where(ps => productIds.Contains(ps.ProductId))
            .Select(ps => new { ps.ProductId, ps.StorageLocation, WarehouseName = ps.Warehouse.Name })
            .ToListAsync(cancellationToken);
        var stocksByProduct = stocks
            .GroupBy(s => s.ProductId)
            .ToDictionary(g => g.Key, g => g.ToList());

        var company = new CompanySenderInfo();
        if (tenantId.HasValue)
        {
            var tenant = await _tenantRepository.GetByIdAsync(tenantId.Value, asNoTracking: true);
            if (tenant != null)
            {
                company = tenant.ToCompanySenderInfo();
            }
        }

        var rows = new List<PickListItem>();
        foreach (var (item, salesNumber) in itemsWithSales)
        {
            var product = productById.GetValueOrDefault(item.ProductId);
            var sku = product?.Sku is { Length: > 0 } s ? s : item.MissingProductSku;
            var productStocks = product != null
                ? stocksByProduct.GetValueOrDefault(item.ProductId)
                : null;

            if (productStocks is { Count: > 0 })
            {
                // One row per storage location (v1: all locations, the picker chooses).
                rows.AddRange(productStocks.Select(stock => new PickListItem
                {
                    Quantity = item.Quantity,
                    Name = item.Name,
                    Sku = sku,
                    SalesNumber = salesNumber,
                    WarehouseName = stock.WarehouseName,
                    StorageLocation = stock.StorageLocation
                }));
            }
            else
            {
                rows.Add(new PickListItem
                {
                    Quantity = item.Quantity,
                    Name = item.Name,
                    Sku = sku,
                    SalesNumber = salesNumber,
                    WarehouseName = string.Empty,
                    StorageLocation = null
                });
            }
        }

        return new PickListData
        {
            TenantId = tenantId,
            Company = company,
            SalesNumbers = salesNumbers,
            Items = rows
                .OrderBy(r => r.StorageLocation == null)
                .ThenBy(r => r.StorageLocation)
                .ThenBy(r => r.Name)
                .ToList()
        };
    }

    private async Task<Dictionary<Guid, ProductLookup>> LoadProductsAsync(List<SalesItem> items, CancellationToken cancellationToken)
    {
        var productIds = items.Select(i => i.ProductId).Distinct().ToList();
        if (productIds.Count == 0)
        {
            return new Dictionary<Guid, ProductLookup>();
        }

        var products = await _productRepository.Entities
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new ProductLookup(p.Id, p.Sku, p.Ean))
            .ToListAsync(cancellationToken);

        return products.ToDictionary(p => p.Id);
    }

    private sealed record ProductLookup(Guid Id, string Sku, string? Ean);
}
