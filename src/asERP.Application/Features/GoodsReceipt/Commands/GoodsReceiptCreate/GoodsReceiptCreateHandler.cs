using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;

public class GoodsReceiptCreateHandler : IRequestHandler<GoodsReceiptCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<GoodsReceiptCreateHandler> _logger;
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantContext _tenantContext;
    private readonly IMediator _mediator;

    public GoodsReceiptCreateHandler(
        IAppLogger<GoodsReceiptCreateHandler> logger,
        IGoodsReceiptRepository goodsReceiptRepository,
        IProductRepository productRepository,
        IWarehouseRepository warehouseRepository,
        IHttpContextAccessor httpContextAccessor,
        ITenantContext tenantContext,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _goodsReceiptRepository = goodsReceiptRepository ?? throw new ArgumentNullException(nameof(goodsReceiptRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(GoodsReceiptCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new goods receipt for Product ID: {ProductId}, Quantity: {Quantity}",
            request.ProductId, request.Quantity);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new GoodsReceiptCreateValidator(_productRepository, _warehouseRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(GoodsReceiptCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var createdBy = _httpContextAccessor.HttpContext.GetUserId() ?? "System";

            // Manual mapping
            var goodsReceiptToCreate = new Domain.Entities.GoodsReceipt
            {
                ReceiptDate = request.ReceiptDate,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                WarehouseId = request.WarehouseId,
                Supplier = request.Supplier,
                Notes = request.Notes,
                CreatedBy = createdBy
            };

            // The receipt document and the stock update are two separate writes; wrap them in one
            // transaction so a failure mid-way cannot record a receipt without the stock increment.
            await using var transaction = await _goodsReceiptRepository.BeginTransactionAsync(cancellationToken);

            // Add the new goods receipt to the database
            await _goodsReceiptRepository.CreateAsync(goodsReceiptToCreate);

            // Update product stock
            await UpdateProductStock(request.ProductId, request.WarehouseId, request.Quantity);

            await transaction.CommitAsync(cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = goodsReceiptToCreate.Id;

            _logger.LogInformation("Successfully created goods receipt with ID: {Id}", goodsReceiptToCreate.Id);

            // Stock changed → let channels mirror the new level. Published after commit so the
            // export never fires for a rolled-back receipt; a failed enqueue must not fail the receipt.
            try
            {
                await _mediator.Publish(
                    new StockChangedNotification(request.ProductId, request.WarehouseId, _tenantContext.GetCurrentTenantId()),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "StockChangedNotification failed for goods receipt {Id}", goodsReceiptToCreate.Id);
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add("An error occurred while creating the goods receipt.");

            _logger.LogError(ex, "Error creating goods receipt for product {ProductId}", request.ProductId);
        }

        return result;
    }

    private async Task UpdateProductStock(Guid productId, Guid warehouseId, int quantity)
    {
        try
        {
            // Atomic DB-side increment avoids the read-modify-write lost-update race when two receipts
            // book stock for the same (product, warehouse) concurrently.
            var affected = await _goodsReceiptRepository.IncrementProductStockAsync(productId, warehouseId, quantity);

            if (affected == 0)
            {
                // No stock row yet — create it. A concurrent create can lose the race; on a duplicate,
                // fall back to the atomic increment so no booked quantity is lost.
                try
                {
                    await _goodsReceiptRepository.CreateProductStockAsync(new Domain.Entities.ProductStock
                    {
                        ProductId = productId,
                        WarehouseId = warehouseId,
                        Stock = quantity
                    });
                }
                catch (DbUpdateException)
                {
                    await _goodsReceiptRepository.IncrementProductStockAsync(productId, warehouseId, quantity);
                }
            }

            _logger.LogInformation("Updated product stock for Product ID: {ProductId}, Warehouse ID: {WarehouseId}, Added Quantity: {Quantity}",
                productId, warehouseId, quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product stock for product {ProductId}", productId);
            throw;
        }
    }
}
