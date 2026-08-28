using asERP.Analytics.ClickHouse;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using ClickHouse.Client.ADO.Parameters;
using Microsoft.Extensions.Logging;

namespace asERP.Analytics.Maintenance;

/// <summary>
/// ClickHouse-backed erasure of a channel's analytics data, run when the channel is deleted. Issues a
/// lightweight mutation (<c>ALTER TABLE ... DELETE</c>) per table, which ClickHouse applies in the
/// background — the caller is not blocked by the merge work.
///
/// SECURITY: mirrors the read gateway — the tenant comes from <see cref="ITenantContext"/> (never from a
/// caller), is injected as a query parameter, and the mutation is skipped entirely when no tenant is in
/// context. Scoped, so it sees the request's tenant context.
/// </summary>
internal sealed class ClickHouseWebAnalyticsPurgeService : IWebAnalyticsPurgeService
{
    private readonly IClickHouseConnectionFactory _connectionFactory;
    private readonly ITenantContext _tenantContext;
    private readonly ILogger<ClickHouseWebAnalyticsPurgeService> _logger;

    public ClickHouseWebAnalyticsPurgeService(
        IClickHouseConnectionFactory connectionFactory,
        ITenantContext tenantContext,
        ILogger<ClickHouseWebAnalyticsPurgeService> logger)
    {
        _connectionFactory = connectionFactory;
        _tenantContext = tenantContext;
        _logger = logger;
    }

    public async Task PurgeSalesChannelAsync(Guid salesChannelId, CancellationToken cancellationToken = default)
    {
        var tenantId = _tenantContext.GetCurrentTenantId();
        if (tenantId is null || tenantId == Guid.Empty || salesChannelId == Guid.Empty)
        {
            // fail closed — never run an unscoped mutation
            _logger.LogWarning(
                "Web-analytics purge for sales channel {SalesChannelId} skipped: no tenant in context.",
                salesChannelId);
            return;
        }

        try
        {
            var settings = await _connectionFactory.GetSettingsAsync(cancellationToken);
            if (!settings.Enabled)
            {
                return;
            }

            await using var connection = await _connectionFactory.OpenConnectionAsync(false, cancellationToken);

            foreach (var table in new[] { "web_events", "web_identities" })
            {
                await using var command = connection.CreateCommand();
                command.CommandText =
                    $"ALTER TABLE {table} DELETE WHERE tenant_id = {{tenant_id:UUID}} AND sales_channel_id = {{sales_channel_id:UUID}}";
                command.Parameters.Add(new ClickHouseDbParameter { ParameterName = "tenant_id", Value = tenantId.Value });
                command.Parameters.Add(new ClickHouseDbParameter { ParameterName = "sales_channel_id", Value = salesChannelId });

                await command.ExecuteNonQueryAsync(cancellationToken);
            }

            _logger.LogInformation(
                "Queued web-analytics purge for sales channel {SalesChannelId} of tenant {TenantId}.",
                salesChannelId, tenantId.Value);
        }
        catch (Exception ex)
        {
            // Best effort by contract: the channel is already gone from the ERP database, and the
            // analytics rows age out via the table TTL. Never surface this as a failed delete.
            _logger.LogWarning(ex,
                "Web-analytics purge failed for sales channel {SalesChannelId}; analytics rows are left to their TTL.",
                salesChannelId);
        }
    }
}
