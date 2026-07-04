using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.SalesChannel.Queries.SalesChannelList;

public class SalesChannelListHandler : IRequestHandler<SalesChannelListQuery, PaginatedResult<SalesChannelListDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await _salesChannelRepository.Entities
               .Specify(salesChannelFilterSpec)
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

        var salesing = string.Join(",", request.SalesBy);

        return await _salesChannelRepository.Entities
            .Specify(salesChannelFilterSpec)
            .OrderBy(salesing)
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