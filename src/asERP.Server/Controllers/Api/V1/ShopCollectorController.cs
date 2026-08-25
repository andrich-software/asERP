using asERP.Application.Contracts.Infrastructure;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Shop.Hosting;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Same-origin web-analytics collector for built-in asShop storefronts. Unlike the plugin-served
/// channels (<see cref="StorefrontController"/>), beacons come straight from visitors' browsers and
/// no token travels anywhere: the channel + tenant come from the <see cref="ShopHostMiddleware"/>
/// binding of the request's Host header, and the visitor IP/User-Agent are those of the request
/// itself (ForwardedHeaders already applied). On a shop host it always returns 202 so the channel's
/// tracking state is not observable; on a non-shop host it 404s like every other shop route.
/// </summary>
[ApiController]
[AllowAnonymous]
[ApiVersionNeutral]
[Route("/asshop")]
[EnableRateLimiting("shop-analytics")]
public class ShopCollectorController(IWebAnalyticsIngestService ingestService) : ControllerBase
{
    /// <summary>Accepts a single tracking beacon sent by the asShop storefront tracker.</summary>
    [HttpPost("e")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [RequestSizeLimit(16 * 1024)] // hard cap — beacons are tiny; reject oversized bodies
    public IActionResult Collect([FromBody] TrackingBeaconDto? beacon)
    {
        var binding = HttpContext.Features.Get<IShopRequestFeature>()?.Binding;
        if (binding is null)
        {
            // Not a shop host — behave like every other shop route (cf. the App.razor root guard).
            return NotFound();
        }

        if (beacon is null || !binding.TrackingEnabled)
        {
            return Accepted();
        }

        // The plugin flow computes the pseudonymised customer reference server-side; here the body
        // comes straight from the browser, so a caller-supplied cid is untrusted — drop it. When the
        // shop gets customer logins the server will stamp it itself.
        beacon.Cid = null;

        var channel = new SalesChannelTrackingRef
        {
            SalesChannelId = binding.SalesChannelId,
            TenantId = binding.TenantId
        };

        // Visitor IP/UA are used transiently for the session hash + masking; never persisted raw.
        var visitorIp = HttpContext.Connection.RemoteIpAddress?.ToString();
        var userAgent = Request.Headers.UserAgent.FirstOrDefault();

        ingestService.TryIngest(channel, beacon, visitorIp, userAgent);
        return Accepted();
    }
}
