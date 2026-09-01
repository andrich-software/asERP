using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.StatisticSalesOverview;

public class StatisticSalesOverviewHandler : IRequestHandler<StatisticSalesOverviewQuery, Result<StatisticSalesOverviewDto>>
{
    private readonly IAppLogger<StatisticSalesOverviewHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly ICustomerRepository _customerRepository;

    public StatisticSalesOverviewHandler(IAppLogger<StatisticSalesOverviewHandler> logger,
        ISalesRepository salesRepository,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Result<StatisticSalesOverviewDto>> Handle(StatisticSalesOverviewQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle StatisticSalesOverviewQuery: {0}", request);

        var statisticDto = new StatisticSalesOverviewDto();
        var thirtyDaysAgo = DateTime.UtcNow.Date.AddDays(-30);

        // Get basic statistics
        statisticDto.SalesTotal = await _salesRepository.Entities.CountAsync(cancellationToken);
        statisticDto.Sales30Days = await _salesRepository.Entities
            .Where(o => o.DateSalesed >= thirtyDaysAgo)
            .CountAsync(cancellationToken);
        statisticDto.CustomerTotal = await _customerRepository.Entities.CountAsync(cancellationToken);

        // Get daily statistics for the last 30 days
        var dailySaless = await _salesRepository.Entities
            .Where(o => o.DateSalesed >= thirtyDaysAgo)
            .GroupBy(o => o.DateSalesed.Date)
            .Select(g => new { Date = g.Key, SalesCount = g.Count() })
            .ToDictionaryAsync(x => x.Date, x => x.SalesCount, cancellationToken);

        var thirtyDaysAgoOffset = new DateTimeOffset(thirtyDaysAgo, TimeSpan.Zero);

        // Grouped by DateEnrollment (the customer's date in the shop), not by DateCreated: the latter is
        // the row's insert timestamp, so an import would report its whole customer base as new that day.
        // The window is 30 days, so grouping the fetched dates in memory keeps the query provider-agnostic.
        var enrollmentDates = await _customerRepository.Entities
            .Where(c => c.DateEnrollment >= thirtyDaysAgoOffset)
            .Select(c => c.DateEnrollment)
            .ToListAsync(cancellationToken);

        var dailyNewCustomers = enrollmentDates
            .GroupBy(d => d.UtcDateTime.Date)
            .ToDictionary(g => g.Key, g => g.Count());

        // Combine the results for each day
        for (var date = thirtyDaysAgo; date <= DateTime.UtcNow.Date; date = date.AddDays(1))
        {
            statisticDto.DailyStatistics.Add(new DailyStatistic
            {
                Date = date,
                SalesCount = dailySaless.GetValueOrDefault(date, 0),
                NewCustomerCount = dailyNewCustomers.GetValueOrDefault(date, 0)
            });
        }

        // Sort by date ascending
        statisticDto.DailyStatistics = statisticDto.DailyStatistics.OrderBy(x => x.Date).ToList();

        return Result<StatisticSalesOverviewDto>.Success(statisticDto);
    }
}
