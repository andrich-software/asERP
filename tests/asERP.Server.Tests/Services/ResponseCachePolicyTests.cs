using System.Security.Claims;
using asERP.Server.Middleware;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// Guards the shared-cache policy: authenticated, per-tenant and API responses must
/// never be marked publicly cacheable, otherwise a CDN/reverse proxy would serve one
/// query window's response for a different one (e.g. dashboard KPIs across periods).
/// </summary>
public class ResponseCachePolicyTests
{
    private static HttpRequest Request(string method, string path, bool authenticated = false, bool withAuthHeader = false)
    {
        var context = new DefaultHttpContext();
        context.Request.Method = method;
        context.Request.Path = path;

        if (withAuthHeader)
            context.Request.Headers.Authorization = "Bearer token";

        if (authenticated)
            context.User = new ClaimsPrincipal(new ClaimsIdentity(authenticationType: "Test"));

        return context.Request;
    }

    [Theory]
    [InlineData("GET")]
    [InlineData("HEAD")]
    public void AnonymousNonApiReadRequest_IsPubliclyCacheable(string method)
    {
        Assert.True(ResponseCachePolicy.ShouldCachePublicly(Request(method, "/tracking/123")));
    }

    [Theory]
    [InlineData("/api/v1/Statistics/SalesToday")]
    [InlineData("/api/v1/Customers")]
    public void ApiRequest_IsNeverPubliclyCacheable(string path)
    {
        Assert.False(ResponseCachePolicy.ShouldCachePublicly(Request("GET", path)));
    }

    [Fact]
    public void RequestWithAuthorizationHeader_IsNeverPubliclyCacheable()
    {
        Assert.False(ResponseCachePolicy.ShouldCachePublicly(Request("GET", "/tracking/123", withAuthHeader: true)));
    }

    [Fact]
    public void AuthenticatedRequest_IsNeverPubliclyCacheable()
    {
        Assert.False(ResponseCachePolicy.ShouldCachePublicly(Request("GET", "/tracking/123", authenticated: true)));
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("PUT")]
    [InlineData("DELETE")]
    public void NonReadMethod_IsNeverPubliclyCacheable(string method)
    {
        Assert.False(ResponseCachePolicy.ShouldCachePublicly(Request(method, "/tracking/123")));
    }
}
