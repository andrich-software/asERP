using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptList;

public class GoodsReceiptListHandler : IRequestHandler<GoodsReceiptListQuery, PaginatedResult<GoodsReceiptListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    // ProductName/ProductSku/WarehouseName are navigation-derived and have no direct orderable
    // entity property, so they are intentionally omitted.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.GoodsReceipt.Id),
        nameof(Domain.Entities.GoodsReceipt.ReceiptDate),
        nameof(Domain.Entities.GoodsReceipt.Quantity),
        nameof(Domain.Entities.GoodsReceipt.Supplier),
        nameof(Domain.Entities.GoodsReceipt.CreatedBy),
        nameof(Domain.Entities.GoodsReceipt.DateCreated)
    };

    private readonly IAppLogger<GoodsReceiptListHandler> _logger;
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;

    public GoodsReceiptListHandler(
        IAppLogger<GoodsReceiptListHandler> logger,
        IGoodsReceiptRepository goodsReceiptRepository)
    {
        _logger = logger;
        _goodsReceiptRepository = goodsReceiptRepository;
    }

    public async Task<PaginatedResult<GoodsReceiptListDto>> Handle(GoodsReceiptListQuery request, CancellationToken cancellationToken)
    {
        var filterSpec = new GoodsReceiptFilterSpecification(request.SearchTerm);

        _logger.LogInformation("Handle GoodsReceiptListQuery: {0}", request);

        return await _goodsReceiptRepository.Entities
            .Specify(filterSpec)
            .ApplySafeOrdering(new[] { request.SalesBy }, AllowedSortFields)
            .Select(gr => MapToGoodsReceiptListDto(gr))
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }

    private static GoodsReceiptListDto MapToGoodsReceiptListDto(Domain.Entities.GoodsReceipt goodsReceipt)
    {
        return new GoodsReceiptListDto
        {
            Id = goodsReceipt.Id,
            ReceiptDate = goodsReceipt.ReceiptDate,
            ProductName = goodsReceipt.Product?.Name ?? "Unknown Product",
            ProductSku = goodsReceipt.Product?.Sku ?? "Unknown SKU",
            Quantity = goodsReceipt.Quantity,
            WarehouseName = goodsReceipt.Warehouse?.Name ?? "Unknown Warehouse",
            Supplier = goodsReceipt.Supplier,
            CreatedBy = goodsReceipt.CreatedBy,
            DateCreated = goodsReceipt.DateCreated
        };
    }
}
