namespace asERP.Application.Contracts.Persistence;

/// <summary>
/// Erases the analytics store's rows of a deleted entity. ClickHouse lives outside the ERP database and
/// has no foreign key to it, so nothing removes a channel's events when its row goes away — the delete
/// path has to say so explicitly.
///
/// Like the read gateway, implementations MUST take the tenant from <c>ITenantContext</c> and fail
/// closed when none is in context — never accept a tenant id from a caller. And they are best effort:
/// they swallow their own errors (analytics may be disabled or unreachable) so a failed purge never
/// blocks or rolls back the ERP-side delete.
/// </summary>
public interface IWebAnalyticsPurgeService
{
    /// <summary>Deletes all web-analytics rows of one sales channel of the current tenant.</summary>
    Task PurgeSalesChannelAsync(Guid salesChannelId, CancellationToken cancellationToken = default);
}
