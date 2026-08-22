using asERP.Application.Contracts.Services;
using asERP.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace asERP.Shop.Hosting;

/// <summary>
/// Maps incoming requests to shop channels by Host header (+ effective public port). On a hit it
/// marks the request with <see cref="IShopRequestFeature"/> and binds the tenant context from the
/// domain row (the established anonymous tenant-from-row pattern, cf. FeedController). On a miss
/// the request passes through untouched — unknown hosts behave exactly as before this middleware
/// existed. Must run after UseForwardedHeaders (it reads the public scheme/host/port).
/// </summary>
public class ShopHostMiddleware
{
    /// <summary>
    /// Path prefixes that are never shop-routed, so the ERP API and infrastructure endpoints keep
    /// working on EVERY host — including hosts that are also bound to a shop. /_blazor is
    /// deliberately NOT listed: circuit traffic must carry the shop marker so TenantMiddleware
    /// skips it.
    /// </summary>
    private static readonly string[] ReservedPathPrefixes =
    [
        "/api",
        "/swagger",
        "/metrics",
        "/health",
        "/feed",
        "/_framework",
        "/_content"
    ];

    private readonly RequestDelegate _next;
    private readonly IShopHostResolver _resolver;

    public ShopHostMiddleware(RequestDelegate next, IShopHostResolver resolver)
    {
        _next = next;
        _resolver = resolver;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
    {
        var path = context.Request.Path;
        foreach (var prefix in ReservedPathPrefixes)
        {
            if (path.StartsWithSegments(prefix, StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
        }

        if (!ShopHostNormalizer.TryNormalize(context.Request.Host.Host, out var host))
        {
            await _next(context);
            return;
        }

        // After UseForwardedHeaders this reflects the public edge values — which is what the
        // operator configured on the binding.
        var port = context.Request.Host.Port ?? (context.Request.IsHttps ? 443 : 80);

        var binding = await _resolver.ResolveAsync(host, port, context.RequestAborted);
        if (binding is null)
        {
            await _next(context);
            return;
        }

        if (binding.RedirectToPrimary && !binding.IsPrimary && !string.Equals(binding.PrimaryHost, host, StringComparison.Ordinal))
        {
            // Preserve method semantics: 301 for safe requests, 308 for everything else.
            var statusCode = HttpMethods.IsGet(context.Request.Method) || HttpMethods.IsHead(context.Request.Method)
                ? StatusCodes.Status301MovedPermanently
                : StatusCodes.Status308PermanentRedirect;

            var location = $"{context.Request.Scheme}://{binding.PrimaryHost}{context.Request.PathBase}{path}{context.Request.QueryString}";
            context.Response.StatusCode = statusCode;
            context.Response.Headers.Location = location;

            var logger = context.RequestServices.GetRequiredService<ILogger<ShopHostMiddleware>>();
            logger.LogDebug("Shop host {Host} redirected to primary {PrimaryHost}", host, binding.PrimaryHost);
            return;
        }

        context.Features.Set<IShopRequestFeature>(new ShopRequestFeature(binding));

        // Anonymous tenant-from-row: the whole request pipeline (EF query filters included) is
        // now bound to the shop's tenant. TenantMiddleware skips shop-marked requests.
        tenantContext.SetCurrentTenantId(binding.TenantId);

        await _next(context);
    }
}
