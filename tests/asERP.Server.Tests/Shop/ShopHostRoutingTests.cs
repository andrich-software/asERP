using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace asERP.Server.Tests.Shop;

/// <summary>
/// Host-header routing of asShop storefront requests: bound hosts serve the shop, unknown hosts
/// keep today's 404 behavior, /api stays functional on every host, and non-primary hosts
/// redirect to the primary domain.
/// </summary>
public class ShopHostRoutingTests : TenantIsolatedTestBase
{
    private async Task<SalesChannel> SeedShopChannelAsync(
        Guid tenantId,
        string host,
        bool isEnabled = true,
        (string Host, bool RedirectToPrimary)? secondaryDomain = null)
    {
        TenantContext.SetCurrentTenantId(tenantId);

        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Name = $"asShop {host}",
            Type = SalesChannelType.AsShop,
            IsEnabled = isEnabled,
            TenantId = tenantId,
            SyncState = new SalesChannelSyncState { TenantId = tenantId },
            ShopDomains =
            [
                new ShopDomain
                {
                    Id = Guid.NewGuid(),
                    Host = host,
                    Port = 0,
                    IsPrimary = true,
                    RedirectToPrimary = false,
                    TenantId = tenantId
                }
            ]
        };

        if (secondaryDomain != null)
        {
            channel.ShopDomains.Add(new ShopDomain
            {
                Id = Guid.NewGuid(),
                Host = secondaryDomain.Value.Host,
                Port = 0,
                IsPrimary = false,
                RedirectToPrimary = secondaryDomain.Value.RedirectToPrimary,
                TenantId = tenantId
            });
        }

        DbContext.SalesChannel.Add(channel);
        await DbContext.SaveChangesAsync();
        return channel;
    }

    private HttpRequestMessage RequestForHost(string host, string path = "/")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        request.Headers.Host = host;
        return request;
    }

    [Fact]
    public async Task BoundHost_ServesShopHomePage()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "testshop.local");

        var response = await Client.SendAsync(RequestForHost("testshop.local"));

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("Willkommen", body);
        Assert.Contains("testshop.local", body);
    }

    [Fact]
    public async Task UnknownHost_RootReturns404()
    {
        var response = await Client.SendAsync(RequestForHost("unbekannt.local"));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DisabledChannel_HostReturns404()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "abgeschaltet.local", isEnabled: false);

        var response = await Client.SendAsync(RequestForHost("abgeschaltet.local"));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ShopHost_GetsShopContentSecurityPolicy()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "csptest.local");

        var response = await Client.SendAsync(RequestForHost("csptest.local"));

        var csp = Assert.Single(response.Headers.GetValues("Content-Security-Policy"));
        Assert.Contains("script-src 'self'", csp);
        Assert.Contains("connect-src 'self' wss:", csp);
    }

    [Fact]
    public async Task NonShopHost_KeepsDefaultContentSecurityPolicy()
    {
        var response = await Client.SendAsync(RequestForHost("unbekannt.local", "/health"));

        var csp = Assert.Single(response.Headers.GetValues("Content-Security-Policy"));
        Assert.Equal("default-src 'self'", csp);
    }

    [Fact]
    public async Task ApiEndpoint_StillWorksOnShopHost()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "apitest.local");

        var response = await Client.SendAsync(RequestForHost("apitest.local", "/api/v1/server-info"));

        TestAssertions.AssertHttpSuccess(response);
    }

    [Fact]
    public async Task HealthEndpoint_StillWorksOnShopHost()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "healthtest.local");

        var response = await Client.SendAsync(RequestForHost("healthtest.local", "/health"));

        TestAssertions.AssertHttpSuccess(response);
    }

    [Fact]
    public async Task SecondaryHost_RedirectsPermanentlyToPrimary()
    {
        await SeedShopChannelAsync(
            TenantConstants.TestTenant1Id,
            "hauptshop.local",
            secondaryDomain: ("www.hauptshop.local", true));

        using var client = Factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        var request = new HttpRequestMessage(HttpMethod.Get, "/produkte?farbe=rot");
        request.Headers.Host = "www.hauptshop.local";

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.MovedPermanently, response.StatusCode);
        Assert.Equal("http://hauptshop.local/produkte?farbe=rot", response.Headers.Location?.ToString());
    }

    [Fact]
    public async Task SecondaryHost_WithoutRedirectFlag_ServesShopDirectly()
    {
        await SeedShopChannelAsync(
            TenantConstants.TestTenant1Id,
            "zweitshop.local",
            secondaryDomain: ("alias.zweitshop.local", false));

        var response = await Client.SendAsync(RequestForHost("alias.zweitshop.local"));

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("Willkommen", body);
    }

    [Fact]
    public async Task DomainDeletedViaApi_HostStopsServingImmediately()
    {
        var channel = await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "kurzlebig.local");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var first = await Client.SendAsync(RequestForHost("kurzlebig.local"));
        TestAssertions.AssertHttpSuccess(first);

        var domainId = channel.ShopDomains.Single().Id;
        var deleteResponse = await Client.DeleteAsync($"/api/v1/shopdomains/{domainId}");
        TestAssertions.AssertHttpSuccess(deleteResponse);

        // The delete published ShopDomainChangedNotification → resolver invalidated → the very
        // next request must miss without waiting for the 30s TTL.
        var second = await Client.SendAsync(RequestForHost("kurzlebig.local"));
        Assert.Equal(HttpStatusCode.NotFound, second.StatusCode);
    }
}
