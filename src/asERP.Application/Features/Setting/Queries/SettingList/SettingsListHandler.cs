using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Setting.Queries.SettingList;

public class SettingListHandler : IRequestHandler<SettingListQuery, PaginatedResult<SettingListDto>>
{
    private readonly IAppLogger<SettingListHandler> _logger;
    private readonly ISettingRepository _SettingRepository;

    public SettingListHandler(
        IAppLogger<SettingListHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger;
        _SettingRepository = settingRepository;
    }

    public async Task<PaginatedResult<SettingListDto>> Handle(SettingListQuery request, CancellationToken cancellationToken)
    {
        var settingFilterSpec = new SettingFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle SettingListQuery: {0}", request);

        IQueryable<Domain.Entities.Setting> query = _SettingRepository.Entities.Specify(settingFilterSpec);

        if (request.SalesBy.Any())
        {
            var salesing = string.Join(",", request.SalesBy);
            query = query.OrderBy(salesing);
        }

        // Use the standard pagination extension which handles zero-based pagination correctly
        var paginatedEntities = await query.ToPaginatedListAsync(request.PageNumber, request.PageSize);

        // Map to DTOs
        var dtos = paginatedEntities.Data.Select(entity => new SettingListDto
        {
            Id = entity.Id,
            Key = entity.Key,
            Value = entity.Value
        }).ToList();

        return PaginatedResult<SettingListDto>.Success(dtos, paginatedEntities.TotalCount, paginatedEntities.CurrentPage, paginatedEntities.PageSize);
    }
}