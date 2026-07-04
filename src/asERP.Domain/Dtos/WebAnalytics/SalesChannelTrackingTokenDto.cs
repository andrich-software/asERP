namespace asERP.Domain.Dtos.WebAnalytics;

/// <summary>
/// Returned once when a tracking token is generated/rotated. The plaintext <see cref="Token"/> is shown
/// a single time so the admin can paste it into the shop plugin — it is stored only encrypted + hashed.
/// </summary>
public class SalesChannelTrackingTokenDto
{
    public Guid SalesChannelId { get; set; }

    /// <summary>Plaintext token — only available in this response, never readable again.</summary>
    public string Token { get; set; } = string.Empty;

    public bool TrackingEnabled { get; set; }
}

/// <summary>Non-secret tracking status for a channel (for admin UI: is it configured / enabled).</summary>
public class SalesChannelTrackingStatusDto
{
    public Guid SalesChannelId { get; set; }
    public bool TrackingEnabled { get; set; }
    public bool HasToken { get; set; }
}
