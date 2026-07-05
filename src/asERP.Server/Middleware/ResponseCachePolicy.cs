using Microsoft.Net.Http.Headers;

namespace asERP.Server.Middleware;

/// <summary>
/// Decides whether a response may be marked as publicly cacheable by a shared
/// cache (CDN / reverse proxy).
///
/// Authenticated, per-tenant and API responses must never be public: a shared
/// cache keys by path only and would serve one request's response for a different
/// query value (e.g. dashboard KPIs for <c>?hours=24</c> served for <c>?hours=720</c>),
/// because the <c>Vary</c> header cannot express query parameters. Such responses
/// are marked <c>no-store</c> instead.
/// </summary>
public static class ResponseCachePolicy
{
    public static bool ShouldCachePublicly(HttpRequest request)
    {
        var isReadMethod = HttpMethods.IsGet(request.Method) || HttpMethods.IsHead(request.Method);

        return isReadMethod
            && !request.Headers.ContainsKey(HeaderNames.Authorization)
            && request.HttpContext.User?.Identity?.IsAuthenticated != true
            && !request.Path.StartsWithSegments("/api");
    }
}
