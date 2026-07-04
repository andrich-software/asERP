using ClickHouse.Client.ADO.Parameters;
using asERP.Analytics.ClickHouse;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.WebAnalytics;
using Microsoft.Extensions.Logging;

namespace asERP.Analytics.Query;

/// <summary>
/// ClickHouse-backed dashboard reads. SECURITY: ClickHouse has no EF global tenant filter, so every
/// query here injects the current tenant id (read from <see cref="ITenantContext"/>) as a parameter and
/// fails closed — returning empty — when no tenant is in context. Tenant id is never taken from a caller.
/// Scoped, so it sees the request's tenant context.
/// </summary>
internal sealed class ClickHouseWebAnalyticsQueryService : IWebAnalyticsQueryService
{
    private readonly IClickHouseConnectionFactory _connectionFactory;
    private readonly ITenantContext _tenantContext;
    private readonly ILogger<ClickHouseWebAnalyticsQueryService> _logger;

    public ClickHouseWebAnalyticsQueryService(
        IClickHouseConnectionFactory connectionFactory,
        ITenantContext tenantContext,
        ILogger<ClickHouseWebAnalyticsQueryService> logger)
    {
        _connectionFactory = connectionFactory;
        _tenantContext = tenantContext;
        _logger = logger;
    }

    public async Task<WebSessionsSummaryDto> GetSessionsSummaryAsync(Guid salesChannelId, CancellationToken cancellationToken = default)
    {
        var dto = new WebSessionsSummaryDto { SalesChannelId = salesChannelId };

        var tenantId = RequireTenant();
        if (tenantId is null)
        {
            return dto; // fail closed — never run an unscoped query
        }

        var settings = await _connectionFactory.GetSettingsAsync(cancellationToken);
        if (!settings.Enabled)
        {
            return dto;
        }

        await using var connection = await _connectionFactory.OpenConnectionAsync(false, cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText = @"
SELECT
    uniqIf(session_id, event_date = today())                                                          AS sessions_today,
    uniqIf(session_id, event_date = yesterday())                                                      AS sessions_yesterday,
    uniqIf(session_id, event_date >= toMonday(today()))                                               AS sessions_this_week,
    uniqIf(session_id, event_date >= toMonday(today()) - 7 AND event_date < toMonday(today()))        AS sessions_last_week
FROM web_events
WHERE tenant_id = {tenant_id:UUID}
  AND sales_channel_id = {sales_channel_id:UUID}";

        AddParameter(command, "tenant_id", tenantId.Value);
        AddParameter(command, "sales_channel_id", salesChannelId);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            dto.SessionsToday = ToLong(reader.GetValue(0));
            dto.SessionsYesterday = ToLong(reader.GetValue(1));
            dto.SessionsThisWeek = ToLong(reader.GetValue(2));
            dto.SessionsLastWeek = ToLong(reader.GetValue(3));
        }

        return dto;
    }

    public async Task<WebTopProductsDto> GetTopProductsAsync(
        Guid salesChannelId,
        DateTime startUtc,
        DateTime endUtc,
        int count,
        CancellationToken cancellationToken = default)
    {
        var dto = new WebTopProductsDto
        {
            StartDate = startUtc,
            EndDate = endUtc
        };

        var tenantId = RequireTenant();
        if (tenantId is null)
        {
            return dto; // fail closed
        }

        var settings = await _connectionFactory.GetSettingsAsync(cancellationToken);
        if (!settings.Enabled)
        {
            return dto;
        }

        // Inclusive end date → exclusive upper bound on event_time.
        var endExclusive = DateTime.SpecifyKind(endUtc.Date.AddDays(1), DateTimeKind.Utc);
        var start = DateTime.SpecifyKind(startUtc.Date, DateTimeKind.Utc);

        await using var connection = await _connectionFactory.OpenConnectionAsync(false, cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText = @"
SELECT
    product_ref,
    argMax(product_name, event_time) AS product_name,
    count()                          AS views,
    uniq(session_id)                 AS unique_visitors
FROM web_events
WHERE tenant_id = {tenant_id:UUID}
  AND sales_channel_id = {sales_channel_id:UUID}
  AND event_type = 'ProductView'
  AND product_ref != ''
  AND event_time >= {start:DateTime}
  AND event_time <  {end:DateTime}
GROUP BY product_ref
ORDER BY views DESC
LIMIT {count:UInt32}";

        AddParameter(command, "tenant_id", tenantId.Value);
        AddParameter(command, "sales_channel_id", salesChannelId);
        AddParameter(command, "start", start);
        AddParameter(command, "end", endExclusive);
        AddParameter(command, "count", (uint)count);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            dto.Products.Add(new WebTopProductDto
            {
                ProductRef = reader.GetValue(0)?.ToString() ?? string.Empty,
                ProductName = reader.GetValue(1)?.ToString() ?? string.Empty,
                Views = ToLong(reader.GetValue(2)),
                UniqueVisitors = ToLong(reader.GetValue(3))
            });
        }

        return dto;
    }

    private Guid? RequireTenant()
    {
        var tenantId = _tenantContext.GetCurrentTenantId();
        if (tenantId is null || tenantId == Guid.Empty)
        {
            _logger.LogWarning("Web analytics query attempted without a tenant in context — returning empty (fail closed).");
            return null;
        }
        return tenantId;
    }

    private static void AddParameter(System.Data.Common.DbCommand command, string name, object value)
    {
        command.Parameters.Add(new ClickHouseDbParameter { ParameterName = name, Value = value });
    }

    private static long ToLong(object value) =>
        value is null || value is DBNull ? 0L : Convert.ToInt64(value);
}
