using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Middleware;

/// <summary>
/// Rejects API requests from asERP clients older than the configured minimum client version
/// (env var SERVER_MINIMUM_CLIENT_VERSION) with 426 Upgrade Required + RFC 7807 problem details.
///
/// Enforcement is opt-in twice: it only applies when a minimum is configured AND the caller
/// identifies itself via the X-Client-Version header. CI-stamped asERP clients always send the
/// header; dev builds, curl and third-party integrations don't and are never blocked.
/// The anonymous /server-info endpoint stays reachable so an outdated client can still discover
/// the required version and drive its update UI.
/// </summary>
public class ClientVersionMiddleware
{
    private readonly RequestDelegate _next;

    public ClientVersionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IServerInfoService serverInfo)
    {
        var minimum = serverInfo.MinimumClientVersion;
        if (minimum is null
            || !context.Request.Path.StartsWithSegments("/api")
            || context.Request.Path.Value?.EndsWith("/server-info", StringComparison.OrdinalIgnoreCase) == true
            || !context.Request.Headers.TryGetValue(ApiHeaders.ClientVersion, out var rawVersion)
            || !Version.TryParse(rawVersion.ToString(), out var clientVersion)
            || clientVersion >= minimum)
        {
            await _next(context);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status426UpgradeRequired;
        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status426UpgradeRequired,
            Title = "Client update required",
            Detail = $"This server requires asERP client version {minimum} or newer " +
                     $"(client reported {clientVersion}). Please update the client.",
            Extensions =
            {
                ["minimumClientVersion"] = minimum.ToString(),
                ["clientVersion"] = clientVersion.ToString()
            }
        }, options: null, contentType: "application/problem+json");
    }
}
