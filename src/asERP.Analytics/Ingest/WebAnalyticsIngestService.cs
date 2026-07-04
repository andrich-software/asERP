using asERP.Analytics.Enrichment;
using asERP.Application.Contracts.Infrastructure;
using asERP.Domain.Dtos.WebAnalytics;
using Microsoft.Extensions.Logging;

namespace asERP.Analytics.Ingest;

/// <summary>
/// Enriches an inbound beacon (session hash, UA classification, IP masking, length clamping) and hands
/// it to the bounded queue. Singleton, stateless beyond its dependencies; never blocks or throws on the
/// request path. The tenant id is taken from the resolved channel and travels with the event.
/// </summary>
internal sealed class WebAnalyticsIngestService : IWebAnalyticsIngestService
{
    private readonly WebAnalyticsIngestQueue _queue;
    private readonly ISessionHasher _sessionHasher;
    private readonly ILogger<WebAnalyticsIngestService> _logger;

    public WebAnalyticsIngestService(
        WebAnalyticsIngestQueue queue,
        ISessionHasher sessionHasher,
        ILogger<WebAnalyticsIngestService> logger)
    {
        _queue = queue;
        _sessionHasher = sessionHasher;
        _logger = logger;
    }

    public bool TryIngest(SalesChannelTrackingRef channel, TrackingBeaconDto beacon, string? visitorIp, string? userAgent)
    {
        try
        {
            var ua = userAgent ?? string.Empty;
            var uaLower = ua.ToLowerInvariant();
            if (UserAgentParser.IsBot(uaLower))
            {
                // Drop known bots/crawlers — they would inflate session and product counts.
                return false;
            }

            var uaInfo = UserAgentParser.Parse(ua);
            var host = Clamp(beacon.Hostname, 255);
            var ip = visitorIp ?? string.Empty;

            var evt = new WebAnalyticsEvent
            {
                TenantId = channel.TenantId,
                SalesChannelId = channel.SalesChannelId,
                EventTime = DateTime.UtcNow,
                EventType = beacon.EventType.ToString(),
                EventName = Clamp(beacon.EventName, 128),
                SessionId = _sessionHasher.Compute(host, ip, ua),
                Vid = Clamp(beacon.Vid, 64),
                Cid = Clamp(beacon.Cid, 128),
                Url = StripQuery(Clamp(beacon.Url, 2048)),
                Path = Clamp(beacon.Path, 2048),
                Title = Clamp(beacon.Title, 512),
                Referrer = StripQuery(Clamp(beacon.Referrer, 2048)),
                Hostname = host,
                ScreenWidth = ClampDimension(beacon.ScreenWidth),
                ScreenHeight = ClampDimension(beacon.ScreenHeight),
                ViewportWidth = ClampDimension(beacon.ViewportWidth),
                ViewportHeight = ClampDimension(beacon.ViewportHeight),
                ScrollDepth = Math.Clamp(beacon.ScrollDepth, 0, 100),
                Language = Clamp(beacon.Language, 35),
                Country = string.Empty,
                IpMasked = IpMasker.Mask(ip),
                UaBrowser = uaInfo.Browser,
                UaOs = uaInfo.Os,
                UaDevice = uaInfo.Device,
                UtmSource = Clamp(beacon.UtmSource, 255),
                UtmMedium = Clamp(beacon.UtmMedium, 255),
                UtmCampaign = Clamp(beacon.UtmCampaign, 255),
                UtmTerm = Clamp(beacon.UtmTerm, 255),
                UtmContent = Clamp(beacon.UtmContent, 255),
                Gclid = Clamp(beacon.Gclid, 255),
                Gbraid = Clamp(beacon.Gbraid, 255),
                Wbraid = Clamp(beacon.Wbraid, 255),
                GadSource = Clamp(beacon.GadSource, 64),
                Msclkid = Clamp(beacon.Msclkid, 255),
                Fbclid = Clamp(beacon.Fbclid, 255),
                ProductRef = Clamp(beacon.ProductRef, 128),
                ProductName = Clamp(beacon.ProductName, 512),
                Value = beacon.Value is { } v && v > 0 ? decimal.Round(v, 4) : 0m,
                Currency = Clamp(beacon.Currency, 3)
            };

            var written = _queue.TryWrite(evt);
            if (!written)
            {
                // Sampled at Debug — overflow under load shouldn't spam the log.
                _logger.LogDebug("Web analytics queue full — beacon dropped for channel {Channel}.", channel.SalesChannelId);
            }
            return written;
        }
        catch (Exception ex)
        {
            // The ingest path must never throw back to the caller.
            _logger.LogDebug(ex, "Failed to enqueue web analytics beacon for channel {Channel}.", channel.SalesChannelId);
            return false;
        }
    }

    private static int ClampDimension(int value) => Math.Clamp(value, 0, ushort.MaxValue);

    private static string Clamp(string? value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        return value.Length <= maxLength ? value : value[..maxLength];
    }

    private static string StripQuery(string url)
    {
        if (string.IsNullOrEmpty(url)) return string.Empty;
        var idx = url.IndexOf('?');
        return idx >= 0 ? url[..idx] : url;
    }
}
