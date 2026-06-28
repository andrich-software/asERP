using Asp.Versioning;
using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.WebAnalytics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace asToolkit.Server.Controllers.Api.V1;

/// <summary>
/// Public storefront ingest endpoint for web-analytics beacons. It is intentionally NOT named
/// "track"/"analytics"/"collect" so it doesn't match ad-blocker lists — and since the shop plugin proxies
/// beacons server-side, the browser never sees this URL anyway. Authentication is by the per-channel
/// secret token (header), not a logged-in user; the endpoint is anonymous + rate-limited and always
/// returns 202 with no body so it never leaks whether a token is valid.
/// </summary>
[ApiController]
[AllowAnonymous]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/storefront")]
[EnableRateLimiting("analytics")]
public class StorefrontController : ControllerBase
{
    private const string TokenHeader = "X-Storefront-Token";

    private readonly ITrackingTokenResolver _tokenResolver;
    private readonly IWebAnalyticsIngestService _ingestService;

    public StorefrontController(ITrackingTokenResolver tokenResolver, IWebAnalyticsIngestService ingestService)
    {
        _tokenResolver = tokenResolver;
        _ingestService = ingestService;
    }

    /// <summary>Accepts a single tracking beacon forwarded by the shop plugin.</summary>
    [HttpPost("e")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [RequestSizeLimit(16 * 1024)] // hard cap — beacons are tiny; reject oversized bodies
    public async Task<IActionResult> Collect([FromBody] TrackingBeaconDto? beacon, CancellationToken cancellationToken)
    {
        // Always 202, regardless of outcome — no information is reflected to the caller.
        if (beacon is null)
        {
            return Accepted();
        }

        var token = Request.Headers[TokenHeader].FirstOrDefault();
        if (string.IsNullOrWhiteSpace(token))
        {
            return Accepted();
        }

        var channel = await _tokenResolver.ResolveAsync(token, cancellationToken);
        if (channel is null)
        {
            return Accepted();
        }

        // Visitor IP + UA are forwarded server-side by the plugin (the connection IP here is the shop
        // server). Used transiently for the session hash + masking; the raw IP is never persisted.
        var visitorIp = ResolveVisitorIp();
        var userAgent = Request.Headers.UserAgent.FirstOrDefault();

        _ingestService.TryIngest(channel, beacon, visitorIp, userAgent);
        return Accepted();
    }

    private string? ResolveVisitorIp()
    {
        var forwarded = Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(forwarded))
        {
            // First hop is the original visitor when the plugin sets it.
            return forwarded.Split(',')[0].Trim();
        }
        return HttpContext.Connection.RemoteIpAddress?.ToString();
    }
}
