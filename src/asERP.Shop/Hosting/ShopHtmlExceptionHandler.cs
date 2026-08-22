using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace asERP.Shop.Hosting;

/// <summary>
/// Renders unhandled exceptions on shop-marked requests as a minimal HTML error page instead of
/// the API's JSON problem details. Registered BEFORE <c>GlobalExceptionHandler</c> — for non-shop
/// requests it returns false so the JSON behavior of /api is byte-identical to before.
/// </summary>
public sealed class ShopHtmlExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ShopHtmlExceptionHandler> _logger;

    public ShopHtmlExceptionHandler(ILogger<ShopHtmlExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (httpContext.Features.Get<IShopRequestFeature>() is null)
        {
            return false;
        }

        _logger.LogError(exception, "Unhandled exception rendering shop page {Path} on host {Host}",
            httpContext.Request.Path, httpContext.Request.Host.Host);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "text/html; charset=utf-8";

        // Deliberately generic (never leak internals) and dependency-free — a themed error page
        // would need the very rendering pipeline that may just have failed.
        await httpContext.Response.WriteAsync(
            "<!doctype html><html lang=\"de\"><head><meta charset=\"utf-8\"><title>Fehler</title></head>" +
            "<body style=\"font-family:system-ui,sans-serif;text-align:center;padding:4rem 1rem\">" +
            "<h1>Es ist ein Fehler aufgetreten</h1>" +
            "<p>Bitte versuchen Sie es in wenigen Minuten erneut.</p>" +
            "</body></html>",
            cancellationToken);

        return true;
    }
}
