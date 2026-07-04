using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.RevenueChart;

public class RevenueChartHandler : IRequestHandler<RevenueChartQuery, Result<RevenueChartDto>>
{
    private readonly IAppLogger<RevenueChartHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public RevenueChartHandler(
        IAppLogger<RevenueChartHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<Result<RevenueChartDto>> Handle(RevenueChartQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle RevenueChartQuery from {0} to {1}", request.StartDate, request.EndDate);

            // Normalise to inclusive day boundaries in UTC. Npgsql timestamptz only accepts UTC.
            var startDay = DateTime.SpecifyKind(request.StartDate.Date, DateTimeKind.Utc);
            var endDay = DateTime.SpecifyKind(request.EndDate.Date, DateTimeKind.Utc);

            if (endDay < startDay)
            {
                (startDay, endDay) = (endDay, startDay);
            }

            // Upper bound is exclusive end-of-day so the whole end date is included.
            var endExclusive = endDay.AddDays(1);

            var baseQuery = _salesRepository.Entities.AsQueryable();
            if (request.SalesChannelId.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.SalesChannelId == request.SalesChannelId.Value);
            }

            var grouped = await baseQuery
                .Where(o => o.DateSalesed >= startDay && o.DateSalesed < endExclusive)
                .GroupBy(o => o.DateSalesed.Date)
                .Select(g => new { Date = g.Key, Revenue = g.Sum(o => o.Total) })
                .ToListAsync(cancellationToken);

            var revenueByDay = grouped.ToDictionary(g => g.Date.Date, g => g.Revenue);

            // Emit a continuous series with zero-filled gaps so the line chart has a point per day.
            var dto = new RevenueChartDto
            {
                StartDate = startDay,
                EndDate = endDay
            };

            for (var day = startDay; day <= endDay; day = day.AddDays(1))
            {
                var revenue = revenueByDay.TryGetValue(day.Date, out var value) ? value : 0m;
                dto.Points.Add(new RevenueChartPointDto { Date = day, Revenue = revenue });
                dto.TotalRevenue += revenue;
            }

            return Result<RevenueChartDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while calculating revenue chart: {0}", ex.Message);
            return Result<RevenueChartDto>.Fail(ResultStatusCode.InternalServerError, "Error while calculating revenue chart");
        }
    }
}
