using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Sales.Queries.SalesReadyToShipList;

public class SalesReadyToShipListHandler : IRequestHandler<SalesReadyToShipListQuery, PaginatedResult<SalesReadyToShipListDto>>
{
    private static readonly SalesStatus[] ReadyToShipStatuses =
    {
        SalesStatus.Pending,
        SalesStatus.Processing,
        SalesStatus.ReadyForDelivery,
        SalesStatus.PartiallyDelivered
    };

    private readonly IAppLogger<SalesReadyToShipListHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public SalesReadyToShipListHandler(
        IAppLogger<SalesReadyToShipListHandler> logger,
        ISalesRepository salesRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
        _productRepository = productRepository;
    }

    public async Task<PaginatedResult<SalesReadyToShipListDto>> Handle(SalesReadyToShipListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle SalesReadyToShipListQuery: {0}", request);

        var query = _salesRepository.Entities
            .Where(o => ReadyToShipStatuses.Contains(o.Status)
                        && o.SalesItems.Any(i => i.ShippingId == null));

        if (request.SalesBy.Any())
        {
            query = query.OrderBy(string.Join(",", request.SalesBy));
        }

        var page = await query
            .Select(o => new SalesReadyToShipListDto
            {
                Id = o.Id,
                SalesId = o.SalesId,
                CustomerId = o.CustomerId,
                DeliveryAddressFirstName = o.DeliveryAddressFirstName,
                DeliveryAddressLastName = o.DeliveryAddressLastName,
                DeliveryAddressCompanyName = o.DeliveryAddressCompanyName,
                DeliveryAddressCountry = o.DeliveryAddressCountry,
                Status = o.Status,
                PaymentStatus = o.PaymentStatus,
                DateSalesed = o.DateSalesed,
                OpenItemCount = o.SalesItems.Count(i => i.ShippingId == null)
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);

        await ApplyStockFlagsAsync(page.Data, cancellationToken);

        return page;
    }

    private async Task ApplyStockFlagsAsync(List<SalesReadyToShipListDto> page, CancellationToken cancellationToken)
    {
        if (page.Count == 0)
        {
            return;
        }

        var salesIds = page.Select(d => d.Id).ToList();

        var openItems = await _salesRepository.GetContext<SalesItem>()
            .Where(i => salesIds.Contains(i.SalesId) && i.ShippingId == null)
            .Select(i => new { i.SalesId, i.ProductId, i.Quantity })
            .ToListAsync(cancellationToken);

        var productIds = openItems.Select(i => i.ProductId).Distinct().ToList();

        var existingProductIds = (await _productRepository.Entities
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var stockSums = await _productRepository.GetContext<ProductStock>()
            .Where(ps => productIds.Contains(ps.ProductId))
            .GroupBy(ps => ps.ProductId)
            .Select(g => new { ProductId = g.Key, Stock = g.Sum(ps => ps.Stock) })
            .ToListAsync(cancellationToken);
        var stockByProduct = stockSums.ToDictionary(s => s.ProductId, s => s.Stock);

        // Demand is aggregated per product within one order so two lines of the same product
        // don't both pass against the same stock.
        var demandBySales = openItems
            .GroupBy(i => i.SalesId)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(i => i.ProductId)
                      .Select(pg => new { ProductId = pg.Key, Quantity = pg.Sum(i => i.Quantity) })
                      .ToList());

        foreach (var dto in page)
        {
            dto.AllItemsInStock = demandBySales.TryGetValue(dto.Id, out var demands)
                && demands.All(d => existingProductIds.Contains(d.ProductId)
                    && stockByProduct.GetValueOrDefault(d.ProductId) >= d.Quantity);
        }
    }
}
