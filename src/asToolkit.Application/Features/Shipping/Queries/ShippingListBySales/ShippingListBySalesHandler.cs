using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingListBySales;

public class ShippingListBySalesHandler : IRequestHandler<ShippingListBySalesQuery, Result<List<ShippingListDto>>>
{
    private readonly IAppLogger<ShippingListBySalesHandler> _logger;
    private readonly IShippingRepository _shippingRepository;

    public ShippingListBySalesHandler(
        IAppLogger<ShippingListBySalesHandler> logger,
        IShippingRepository shippingRepository)
    {
        _logger = logger;
        _shippingRepository = shippingRepository;
    }

    public async Task<Result<List<ShippingListDto>>> Handle(ShippingListBySalesQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipments for sales {SalesId}", request.SalesId);

        var shippings = await _shippingRepository.GetBySalesIdAsync(request.SalesId);

        var data = shippings.Select(s => new ShippingListDto
        {
            Id = s.Id,
            SalesId = s.SalesId,
            ProviderName = s.ShippingProvider.Name,
            RateName = s.ShippingProviderRate?.Name ?? string.Empty,
            Status = s.Status,
            TrackingNumber = s.TrackingNumber,
            TrackingUrl = s.TrackingUrl,
            ShippingCost = s.ShippingCost,
            HasLabel = s.LabelData is { Length: > 0 },
            ShippedAt = s.ShippedAt,
            DeliveredAt = s.DeliveredAt,
            DateCreated = s.DateCreated
        }).ToList();

        return Result<List<ShippingListDto>>.Success(data);
    }
}
