using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.SalesChannel.Queries.SalesChannelList;

public class SalesChannelListHandler : IRequestHandler<SalesChannelListQuery, PaginatedResult<SalesChannelListDto>>
{
    // Ordering runs on the SalesChannel entity (before Select). Only safe display columns surfaced in
    // SalesChannelListDto are sortable; secret columns (Password, AccessToken, RefreshToken, TrackingToken,
    // TrackingTokenHash, WebhookSecret) are never exposed to client-supplied sorting.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.SalesChannel.Id),
        nameof(Domain.Entities.SalesChannel.Type),
        nameof(Domain.Entities.SalesChannel.Name),
        nameof(Domain.Entities.SalesChannel.DateCreated),
        nameof(Domain.Entities.SalesChannel.Url),
        nameof(Domain.Entities.SalesChannel.Username),
        nameof(Domain.Entities.SalesChannel.ImportProducts),
        nameof(Domain.Entities.SalesChannel.ExportProducts),
        nameof(Domain.Entities.SalesChannel.ImportCustomers),
        nameof(Domain.Entities.SalesChannel.ExportCustomers),
        nameof(Domain.Entities.SalesChannel.ImportSaless),
        nameof(Domain.Entities.SalesChannel.ExportSaless)
    };

    private readonly IAppLogger<SalesChannelListHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;

    public SalesChannelListHandler(
        IAppLogger<SalesChannelListHandler> logger,
        ISalesChannelRepository salesChannelRepository)
    {
        _logger = logger;
        _salesChannelRepository = salesChannelRepository;
    }

    public async Task<PaginatedResult<SalesChannelListDto>> Handle(SalesChannelListQuery request, CancellationToken cancellationToken)
    {
        var salesChannelFilterSpec = new SalesChannelFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle SalesChannelListQuery: {0}", request);

        return await _salesChannelRepository.Entities
            .Specify(salesChannelFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(entity => new SalesChannelListDto
            {
                Id = entity.Id,
                SalesChannelType = entity.Type,
                Name = entity.Name,
                DateCreated = entity.DateCreated,
                Url = entity.Url,
                Username = entity.Username,
                ImportProducts = entity.ImportProducts,
                ImportCustomers = entity.ImportCustomers,
                ImportSaless = entity.ImportSaless,
                ExportProducts = entity.ExportProducts,
                ExportCustomers = entity.ExportCustomers,
                ExportSaless = entity.ExportSaless,
                Warehouses = entity.Warehouses.Select(w => new WarehouseDetailDto
                {
                    Id = w.Id,
                    Name = w.Name
                }).ToList()
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
