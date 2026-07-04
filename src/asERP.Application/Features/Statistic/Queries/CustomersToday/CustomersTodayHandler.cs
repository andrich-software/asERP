using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.CustomersToday;

public class CustomersTodayHandler : IRequestHandler<CustomersTodayQuery, Result<CustomersTodayDto>>
{
    private readonly IAppLogger<CustomersTodayHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomersTodayHandler(
        IAppLogger<CustomersTodayHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<Result<CustomersTodayDto>> Handle(CustomersTodayQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle CustomersTodayQuery");

            var dto = new CustomersTodayDto();

            var now = DateTime.UtcNow;
            var monthStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var lastMonthStart = monthStart.AddMonths(-1);
            var lastMonthEnd = monthStart;

            // Customer calculations
            dto.CustomersTotal = await _customerRepository.Entities.CountAsync(cancellationToken);

            dto.CustomersNewThisMonth = await _customerRepository.Entities
                .Where(c => c.DateCreated >= monthStart)
                .CountAsync(cancellationToken);

            // Period window: last N hours when requested, otherwise the current month
            var periodStart = request.Hours.HasValue ? now.AddHours(-request.Hours.Value) : monthStart;
            dto.CustomersNew = request.Hours.HasValue
                ? await _customerRepository.Entities
                    .Where(c => c.DateCreated >= periodStart)
                    .CountAsync(cancellationToken)
                : dto.CustomersNewThisMonth;

            // Change vs the preceding window of equal length (hours mode) or vs last month (legacy mode)
            var previousStart = request.Hours.HasValue ? periodStart.AddHours(-request.Hours.Value) : lastMonthStart;
            var previousEnd = request.Hours.HasValue ? periodStart : lastMonthEnd;
            var customersPrevious = await _customerRepository.Entities
                .Where(c => c.DateCreated >= previousStart && c.DateCreated < previousEnd)
                .CountAsync(cancellationToken);

            dto.CustomersChangePercent = customersPrevious > 0
                ? ((decimal)(dto.CustomersNew - customersPrevious) / customersPrevious) * 100
                : dto.CustomersNew > 0 ? 100 : 0;

            return Result<CustomersTodayDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while calculating customer statistics: {0}", ex.Message);
            return Result<CustomersTodayDto>.Fail(ResultStatusCode.InternalServerError, "Error while calculating customer statistics");
        }
    }
}
