namespace asERP.Domain.Dtos.SalesChannel;

/// <summary>
/// What the explicit cascade of a sales-channel delete actually touched. Returned by the repository
/// so the caller can publish the follow-up notifications (host-map invalidation, analytics purge) and
/// log the cleanup without re-querying rows that no longer exist.
/// </summary>
public sealed class SalesChannelDeletionSummary
{
    /// <summary>Owning tenant of the deleted channel — scopes the follow-up cleanups outside the ERP database.</summary>
    public Guid? TenantId { get; init; }

    public int ShopDomains { get; init; }
    public int CategoryLinks { get; init; }
    public int CustomerLinks { get; init; }
    public int ProductLinks { get; init; }
    public int OAuthStates { get; init; }

    /// <summary>Outbox rows, sync runs, sync log lines, sync state and per-operation scheduler state.</summary>
    public int SyncRows { get; init; }

    /// <summary>Product images whose channel origin was cleared — the images themselves are kept.</summary>
    public int DetachedProductImages { get; init; }

    /// <summary>Feeds whose channel link was cleared — the feeds themselves are kept.</summary>
    public int DetachedFeeds { get; init; }
}
