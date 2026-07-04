namespace asERP.Domain.Dtos.WebAnalytics;

/// <summary>
/// The minimal channel identity a tracking token resolves to. Loaded cross-tenant (the ingest path is
/// anonymous) and used to stamp every event with the owning tenant + channel. Carries no secrets.
/// </summary>
public sealed class SalesChannelTrackingRef
{
    public Guid SalesChannelId { get; init; }

    /// <summary>Owning tenant — stamped onto every ingested event so the write path is tenant-bound.</summary>
    public Guid TenantId { get; init; }

    /// <summary>SHA-256 (hex) of the channel's tracking token; the lookup key.</summary>
    public string TrackingTokenHash { get; init; } = string.Empty;
}
