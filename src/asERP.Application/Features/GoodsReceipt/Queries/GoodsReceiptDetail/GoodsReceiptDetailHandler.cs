using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;

public class GoodsReceiptDetailHandler : IRequestHandler<GoodsReceiptDetailQuery, Result<GoodsReceiptDetailDto>>
{
    private readonly IAppLogger<GoodsReceiptDetailHandler> _logger;
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;

    public GoodsReceiptDetailHandler(
        IAppLogger<GoodsReceiptDetailHandler> logger,
        IGoodsReceiptRepository goodsReceiptRepository)
    {
        _logger = logger;
        _goodsReceiptRepository = goodsReceiptRepository;
    }

    public async Task<Result<GoodsReceiptDetailDto>> Handle(GoodsReceiptDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle GoodsReceiptDetailQuery for ID: {Id}", request.Id);

        var goodsReceipt = await _goodsReceiptRepository.GetByIdWithDetailsAsync(request.Id);

        if (goodsReceipt == null)
        {
            return Result<GoodsReceiptDetailDto>.NotFound(ErrorCodes.GoodsReceipt.NotFound, $"Goods receipt with ID {request.Id} not found.");
        }

        var dto = MapToGoodsReceiptDetailDto(goodsReceipt);

        _logger.LogInformation("Successfully retrieved goods receipt details for ID: {Id}", request.Id);

        return Result<GoodsReceiptDetailDto>.Ok(dto);
    }

    private static GoodsReceiptDetailDto MapToGoodsReceiptDetailDto(Domain.Entities.GoodsReceipt goodsReceipt)
    {
        return new GoodsReceiptDetailDto
        {
            Id = goodsReceipt.Id,
            ReceiptDate = goodsReceipt.ReceiptDate,
            ProductId = goodsReceipt.ProductId,
            ProductName = goodsReceipt.Product?.Name ?? "Unknown Product",
            ProductSku = goodsReceipt.Product?.Sku ?? "Unknown SKU",
            Quantity = goodsReceipt.Quantity,
            WarehouseId = goodsReceipt.WarehouseId,
            WarehouseName = goodsReceipt.Warehouse?.Name ?? "Unknown Warehouse",
            Supplier = goodsReceipt.Supplier,
            Notes = goodsReceipt.Notes,
            CreatedBy = goodsReceipt.CreatedBy,
            DateCreated = goodsReceipt.DateCreated,
            DateModified = goodsReceipt.DateModified
        };
    }
}
