using asERP.Client.Features.Statistics.Services;
using asERP.Domain.Dtos.Statistic;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Statistics.Models;

/// <summary>
/// Model for the revenue statistics page (MVUX). The line chart itself is drawn
/// imperatively in the page code-behind; this model owns the data access so the
/// page stays free of HTTP/service plumbing.
/// </summary>
public partial record RevenueModel
{
    private readonly IRevenueStatisticsService _revenueService;
    private readonly ILogger<RevenueModel> _logger;

    public RevenueModel(
        IRevenueStatisticsService revenueService,
        ILogger<RevenueModel> logger)
    {
        _revenueService = revenueService;
        _logger = logger;
    }

    /// <summary>
    /// Loads the daily revenue series for the given range. Returns an empty
    /// chart on failure so the page can render a "no data" state.
    /// </summary>
    public async Task<RevenueChartDto> LoadRevenueAsync(DateTime startDate, DateTime endDate, CancellationToken ct = default)
    {
        try
        {
            var data = await _revenueService.GetRevenueChartAsync(startDate, endDate, ct);
            return data ?? new RevenueChartDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading revenue chart data");
            return new RevenueChartDto();
        }
    }
}
