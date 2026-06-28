using asToolkit.Domain.Dtos.WebAnalytics;

namespace asToolkit.Application.Contracts.Infrastructure;

/// <summary>
/// Write side of the web-analytics pipeline. The server's anonymous ingest endpoint calls this after
/// resolving the token to a channel. The implementation enriches the beacon (daily-salted session hash,
/// UA parse, IP masking) and hands it to a bounded in-memory queue drained by a background batch writer.
/// </summary>
public interface IWebAnalyticsIngestService
{
    /// <summary>
    /// Non-blocking enqueue of a single beacon. Returns <c>false</c> when the event was dropped (queue
    /// full or pipeline disabled). MUST never block or throw — losing an analytics event is acceptable,
    /// stalling the shop's beacon request is not. <paramref name="visitorIp"/> is the real visitor IP
    /// forwarded by the plugin (used transiently for the session hash + masking, never persisted raw).
    /// </summary>
    bool TryIngest(SalesChannelTrackingRef channel, TrackingBeaconDto beacon, string? visitorIp, string? userAgent);
}
