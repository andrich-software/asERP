using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Statistic.Queries.SalesToday;

public class SalesTodayHandler : IRequestHandler<SalesTodayQuery, Result<SalesTodayDto>>
{
    private readonly IAppLogger<SalesTodayHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalesTodayHandler(
        IAppLogger<SalesTodayHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<Result<SalesTodayDto>> Handle(SalesTodayQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle SalesTodayQuery");

            var dto = new SalesTodayDto();

            var now = DateTime.UtcNow;
            var todayStart = now.Date;
            var weekStart = todayStart.AddDays(-(int)todayStart.DayOfWeek);
            var monthStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var baseQuery = _salesRepository.Entities.AsQueryable();
            if (request.SalesChannelId.HasValue)
                baseQuery = baseQuery.Where(o => o.SalesChannelId == request.SalesChannelId.Value);

            // Period window: last N hours when requested, otherwise the legacy calendar day
            var periodStart = request.Hours.HasValue ? now.AddHours(-request.Hours.Value) : todayStart;

            dto.RevenueToday = await baseQuery
                .Where(o => o.DateSalesed >= periodStart)
                .SumAsync(o => o.Total, cancellationToken);

            dto.RevenueThisWeek = await baseQuery
                .Where(o => o.DateSalesed >= weekStart)
                .SumAsync(o => o.Total, cancellationToken);

            dto.RevenueThisMonth = await baseQuery
                .Where(o => o.DateSalesed >= monthStart)
                .SumAsync(o => o.Total, cancellationToken);

            // Change vs the preceding window of equal length (hours mode)
            // or vs last week's same day (legacy mode)
            var previousStart = request.Hours.HasValue
                ? periodStart.AddHours(-request.Hours.Value)
                : todayStart.AddDays(-7);
            var previousEnd = request.Hours.HasValue ? periodStart : previousStart.AddDays(1);
            var revenuePrevious = await baseQuery
                .Where(o => o.DateSalesed >= previousStart && o.DateSalesed < previousEnd)
                .SumAsync(o => o.Total, cancellationToken);

            dto.RevenueChangePercent = revenuePrevious > 0
                ? ((dto.RevenueToday - revenuePrevious) / revenuePrevious) * 100
                : dto.RevenueToday > 0 ? 100 : 0;

            return Result<SalesTodayDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while calculating sales statistics: {0}", ex.Message);
            return Result<SalesTodayDto>.Fail(ResultStatusCode.InternalServerError, "Error while calculating sales statistics");
        }
    }
}
