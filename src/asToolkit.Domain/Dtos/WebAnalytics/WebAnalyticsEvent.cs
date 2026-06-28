namespace asToolkit.Domain.Dtos.WebAnalytics;

/// <summary>
/// A fully server-enriched analytics event, ready to be written to ClickHouse. Built from a
/// <see cref="TrackingBeaconDto"/> plus request context (resolved tenant/channel, masked IP, derived
/// browser/OS/device, daily-salted session id). The tenant id travels WITH the event on the write
/// path — it is never read from ambient context inside the background writer.
/// </summary>
public sealed class WebAnalyticsEvent
{
    public Guid TenantId { get; init; }
    public Guid SalesChannelId { get; init; }

    /// <summary>Server receive time, UTC.</summary>
    public DateTime EventTime { get; init; }

    /// <summary>Event type, stored as its enum name.</summary>
    public string EventType { get; init; } = string.Empty;

    /// <summary>Concrete name for custom events (empty otherwise).</summary>
    public string EventName { get; init; } = string.Empty;

    /// <summary>Plausible-style daily-salted session hash (sessionisation; forgets overnight).</summary>
    public string SessionId { get; init; } = string.Empty;

    /// <summary>Persistent first-party visitor id (visitor continuity / stitching).</summary>
    public string Vid { get; init; } = string.Empty;

    /// <summary>Pseudonymised customer reference; empty when anonymous.</summary>
    public string Cid { get; init; } = string.Empty;

    public string Url { get; init; } = string.Empty;
    public string Path { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Referrer { get; init; } = string.Empty;
    public string Hostname { get; init; } = string.Empty;

    // Device / source
    public int ScreenWidth { get; init; }
    public int ScreenHeight { get; init; }
    public int ViewportWidth { get; init; }
    public int ViewportHeight { get; init; }
    public int ScrollDepth { get; init; }
    public string Language { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;

    /// <summary>Masked IP only (e.g. last octet zeroed). Full IP is never persisted.</summary>
    public string IpMasked { get; init; } = string.Empty;

    public string UaBrowser { get; init; } = string.Empty;
    public string UaOs { get; init; } = string.Empty;
    public string UaDevice { get; init; } = string.Empty;

    // UTM
    public string UtmSource { get; init; } = string.Empty;
    public string UtmMedium { get; init; } = string.Empty;
    public string UtmCampaign { get; init; } = string.Empty;
    public string UtmTerm { get; init; } = string.Empty;
    public string UtmContent { get; init; } = string.Empty;

    // Ad click ids
    public string Gclid { get; init; } = string.Empty;
    public string Gbraid { get; init; } = string.Empty;
    public string Wbraid { get; init; } = string.Empty;
    public string GadSource { get; init; } = string.Empty;
    public string Msclkid { get; init; } = string.Empty;
    public string Fbclid { get; init; } = string.Empty;

    // Commerce
    public string ProductRef { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public decimal Value { get; init; }
    public string Currency { get; init; } = string.Empty;
}
