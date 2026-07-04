using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptList;

public class GoodsReceiptListHandler : IRequestHandler<GoodsReceiptListQuery, PaginatedResult<GoodsReceiptListDto>>
{
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

        if (string.IsNullOrEmpty(request.SalesBy))
        {
            var goodsReceipts = await _goodsReceiptRepository.Entities
               .Specify(filterSpec)
               .Select(gr => MapToGoodsReceiptListDto(gr))
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return goodsReceipts;
        }

        var salesedGoodsReceipts = await _goodsReceiptRepository.Entities
            .Specify(filterSpec)
            .OrderBy(request.SalesBy)
            .Select(gr => MapToGoodsReceiptListDto(gr))
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);

        return salesedGoodsReceipts;
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