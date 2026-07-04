using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Statistic.Queries.SalessToday;

public class SalessTodayHandler : IRequestHandler<SalessTodayQuery, Result<SalessTodayDto>>
{
    private readonly IAppLogger<SalessTodayHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalessTodayHandler(
        IAppLogger<SalessTodayHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<Result<SalessTodayDto>> Handle(SalessTodayQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle SalessTodayQuery");

            var dto = new SalessTodayDto();

            var now = DateTime.UtcNow;
            var todayStart = now.Date;
            var weekStart = todayStart.AddDays(-(int)todayStart.DayOfWeek);
            var lastWeekStart = weekStart.AddDays(-7);
            var lastWeekEnd = weekStart;

            var baseQuery = _salesRepository.Entities.AsQueryable();
            if (request.SalesChannelId.HasValue)
                baseQuery = baseQuery.Where(o => o.SalesChannelId == request.SalesChannelId.Value);

            // Period window: last N hours when requested, otherwise the legacy calendar day
            var periodStart = request.Hours.HasValue ? now.AddHours(-request.Hours.Value) : todayStart;

            dto.SalessToday = await baseQuery
                .Where(o => o.DateSalesed >= periodStart)
                .CountAsync(cancellationToken);

            dto.SalessPending = await baseQuery
                .Where(o => o.Status == SalesStatus.Pending || o.Status == SalesStatus.Processing)
                .CountAsync(cancellationToken);

            dto.SalessThisWeek = await baseQuery
                .Where(o => o.DateSalesed >= weekStart)
                .CountAsync(cancellationToken);

            // Change vs the preceding window of equal length (hours mode)
            // or this week vs last week (legacy mode)
            var previousStart = request.Hours.HasValue ? periodStart.AddHours(-request.Hours.Value) : lastWeekStart;
            var previousEnd = request.Hours.HasValue ? periodStart : lastWeekEnd;
            var currentCount = request.Hours.HasValue ? dto.SalessToday : dto.SalessThisWeek;
            var salessPrevious = await baseQuery
                .Where(o => o.DateSalesed >= previousStart && o.DateSalesed < previousEnd)
                .CountAsync(cancellationToken);

            dto.SalessChangePercent = salessPrevious > 0
                ? ((decimal)(currentCount - salessPrevious) / salessPrevious) * 100
                : currentCount > 0 ? 100 : 0;

            return Result<SalessTodayDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while calculating saless statistics: {0}", ex.Message);
            return Result<SalessTodayDto>.Fail(ResultStatusCode.InternalServerError, "Error while calculating saless statistics");
        }
    }
}
