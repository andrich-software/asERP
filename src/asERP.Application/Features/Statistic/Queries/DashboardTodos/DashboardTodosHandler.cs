using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Features.Product.Shared;
using asERP.Application.Features.Sales.Shared;
using asERP.Application.Features.Shipping.Shared;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.DashboardTodos;

public class DashboardTodosHandler : IRequestHandler<DashboardTodosQuery, Result<DashboardTodosDto>>
{
    private readonly IAppLogger<DashboardTodosHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingRepository _shippingRepository;
    private readonly IProductRepository _productRepository;

    public DashboardTodosHandler(
        IAppLogger<DashboardTodosHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
        _shippingRepository = shippingRepository;
        _productRepository = productRepository;
    }

    public async Task<Result<DashboardTodosDto>> Handle(DashboardTodosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle DashboardTodosQuery");

            var now = DateTime.UtcNow;
            var dto = new DashboardTodosDto();

            dto.SalessReadyToShip = await _salesRepository.Entities
                .CountAsync(SalesQuickFilterPredicates.ReadyToShip(), cancellationToken);

            dto.SalessPaymentOverdue = await _salesRepository.Entities
                .CountAsync(
                    SalesQuickFilterPredicates.PaymentOverdue(now.Subtract(SalesQuickFilterPredicates.PaymentOverdueAfter)),
                    cancellationToken);

            var labelOutbox = _shippingRepository.GetContext<ShippingLabelOutbox>();
            dto.ShippingProblems = await _shippingRepository.Entities
                .CountAsync(
                    ShippingProblemFilter.IsProblem(labelOutbox, now.Subtract(ShippingProblemFilter.OverdueAfter)),
                    cancellationToken);

            dto.ProductsToReorder = await _productRepository.Entities
                .CountAsync(ProductStockFilters.LowStock, cancellationToken);

            return Result<DashboardTodosDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while calculating dashboard todos: {0}", ex.Message);
            return Result<DashboardTodosDto>.Fail(ResultStatusCode.InternalServerError, "Error while calculating dashboard todos");
        }
    }
}
