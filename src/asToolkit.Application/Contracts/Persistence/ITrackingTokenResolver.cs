using asToolkit.Domain.Dtos.WebAnalytics;

namespace asToolkit.Application.Contracts.Persistence;

/// <summary>
/// Resolves a raw web-analytics tracking token to its owning sales channel + tenant on the anonymous
/// ingest path. Implementations hash the token (SHA-256) and match it against a short-lived in-memory
/// cache of enabled tracking channels, so the hot path avoids a database round-trip per beacon.
/// Returns <c>null</c> for unknown/disabled tokens — the caller must then silently drop the beacon.
/// </summary>
public interface ITrackingTokenResolver
{
    Task<SalesChannelTrackingRef?> ResolveAsync(string token, CancellationToken cancellationToken = default);
}
