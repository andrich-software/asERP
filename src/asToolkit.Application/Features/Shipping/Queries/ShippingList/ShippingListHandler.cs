using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Mediator;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingList;

public class ShippingListHandler : IRequestHandler<ShippingListQuery, PaginatedResult<ShipmentListItemDto>>
{
    private const string DefaultSort = "ShippedAt Descending";

    /// <summary>A shipped, undelivered parcel older than this is flagged as a problem.</summary>
    private static readonly TimeSpan OverdueAfter = TimeSpan.FromDays(4);

    private readonly IAppLogger<ShippingListHandler> _logger;
    private readonly IShippingRepository _shippingRepository;

    public ShippingListHandler(
        IAppLogger<ShippingListHandler> logger,
        IShippingRepository shippingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
    }

    public async Task<PaginatedResult<ShipmentListItemDto>> Handle(ShippingListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ShippingListHandler.Handle: Retrieving shipments (page {Page}).", request.PageNumber);

        var filterSpec = new ShippingFilterSpecification(request.SearchString);

        var query = _shippingRepository.Entities
            .Specify(filterSpec);

        if (request.Status.HasValue)
        {
            query = query.Where(s => s.Status == request.Status.Value);
        }

        if (request.SalesId.HasValue)
        {
            query = query.Where(s => s.SalesId == request.SalesId.Value);
        }

        // Computed as a C# parameter so the comparison stays SQL-translatable on every provider.
        var overdueCutoff = DateTime.UtcNow.Subtract(OverdueAfter);
        var labelOutbox = _shippingRepository.GetContext<ShippingLabelOutbox>();

        var projected = query.Select(s => new ShipmentListItemDto
        {
            Id = s.Id,
            SalesId = s.SalesId,
            SalesNumber = s.Sales.SalesId,
            RecipientName = s.Sales.DeliveryAddressCompanyName != string.Empty
                ? s.Sales.DeliveryAddressCompanyName
                : (s.Sales.DeliveryAddressFirstName + " " + s.Sales.DeliveryAddressLastName).Trim(),
            ProviderName = s.ShippingProvider.Name,
            RateName = s.ShippingProviderRate != null ? s.ShippingProviderRate.Name : string.Empty,
            TrackingNumber = s.TrackingNumber,
            TrackingUrl = s.TrackingUrl,
            Status = s.Status,
            ShippedAt = s.ShippedAt,
            DeliveredAt = s.DeliveredAt,
            HasLabel = s.LabelData != null && s.LabelData.Length > 0,
            IsProblem = s.Status == ShippingStatus.Lost
                || s.Status == ShippingStatus.ReturnedToSender
                || s.Status == ShippingStatus.DeliveryFailed
                || (s.ShippedAt != null && s.Status != ShippingStatus.Delivered && s.ShippedAt < overdueCutoff)
                || labelOutbox.Any(o => o.ShippingId == s.Id && o.Status == ShippingOutboxStatus.DeadLetter),
            DateCreated = s.DateCreated
        });

        if (request.ProblemsOnly)
        {
            projected = projected.Where(x => x.IsProblem);
        }

        // Sorting happens after the projection so computed columns (IsProblem, RecipientName)
        // are sortable too.
        var sort = request.SalesBy.Any() ? string.Join(",", request.SalesBy) : DefaultSort;
        projected = projected.OrderBy(sort);

        return await projected.ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
