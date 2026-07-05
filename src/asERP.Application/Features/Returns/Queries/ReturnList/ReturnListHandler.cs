using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Queries.ReturnList;

public class ReturnListHandler : IRequestHandler<ReturnListQuery, PaginatedResult<ReturnShipmentListItemDto>>
{
    private const string DefaultSort = "DateCreated Descending";

    // Ordering runs on the projected ReturnShipmentListItemDto; only columns surfaced in the list DTO
    // are sortable. Client sort terms outside this set are ignored (falling back to no client ordering).
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(ReturnShipmentListItemDto.Id),
        nameof(ReturnShipmentListItemDto.SalesId),
        nameof(ReturnShipmentListItemDto.SalesNumber),
        nameof(ReturnShipmentListItemDto.Status),
        nameof(ReturnShipmentListItemDto.TrackingNumber),
        nameof(ReturnShipmentListItemDto.TrackingUrl),
        nameof(ReturnShipmentListItemDto.ItemCount),
        nameof(ReturnShipmentListItemDto.HasLabel),
        nameof(ReturnShipmentListItemDto.ReceivedAt),
        nameof(ReturnShipmentListItemDto.DateCreated)
    };

    private readonly IAppLogger<ReturnListHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;

    public ReturnListHandler(
        IAppLogger<ReturnListHandler> logger,
        IReturnShipmentRepository returnShipmentRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
    }

    public async Task<PaginatedResult<ReturnShipmentListItemDto>> Handle(ReturnListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ReturnListHandler.Handle: Retrieving returns (page {Page}).", request.PageNumber);

        var query = _returnShipmentRepository.Entities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var search = request.SearchString.Trim();
            query = query.Where(r => r.TrackingNumber.Contains(search)
                || r.Sales.SalesId.ToString().Contains(search));
        }

        if (request.Status.HasValue)
        {
            query = query.Where(r => r.Status == request.Status.Value);
        }

        if (request.SalesId.HasValue)
        {
            query = query.Where(r => r.SalesId == request.SalesId.Value);
        }

        var projected = query.Select(r => new ReturnShipmentListItemDto
        {
            Id = r.Id,
            SalesId = r.SalesId,
            SalesNumber = r.Sales.SalesId,
            Status = r.Status,
            TrackingNumber = r.TrackingNumber,
            TrackingUrl = r.TrackingUrl,
            ItemCount = r.Items.Count,
            HasLabel = r.LabelData != null && r.LabelData.Length > 0,
            ReceivedAt = r.ReceivedAt,
            DateCreated = r.DateCreated
        });

        projected = request.SalesBy.Any()
            ? projected.ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            : projected.OrderBy(DefaultSort);

        return await projected.ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
