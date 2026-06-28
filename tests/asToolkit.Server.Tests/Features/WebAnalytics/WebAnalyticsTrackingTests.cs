#nullable disable
using System.Net;
using System.Net.Http.Json;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.WebAnalytics;

/// <summary>
/// Covers the web-analytics tracking surface: token rotation (tenant-scoped, pure EF) and the anonymous
/// storefront ingest endpoint. The ClickHouse query path is exercised via the live stack, not here — the
/// hosted ClickHouse services are deliberately not registered in the Testing environment.
/// </summary>
public class WebAnalyticsTrackingTests : TenantIsolatedTestBase
{
    // Seeded by TestDataSeeder.
    private static readonly Guid WooCommerceTenant1Id = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1");
    private static readonly Guid EbayTenant2Id = Guid.Parse("d3d3d3d3-d3d3-d3d3-d3d3-d3d3d3d3d3d3");

    [Fact]
    public async Task RotateTrackingToken_OwnChannel_ReturnsTokenAndEnablesTracking()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking-token", null);

        TestAssertions.AssertHttpSuccess(response);
        var dto = await ReadResponseAsync<SalesChannelTrackingTokenDto>(response);
        Assert.NotNull(dto);
        Assert.False(string.IsNullOrWhiteSpace(dto.Token));
        Assert.True(dto.TrackingEnabled);

        // The token is stored hashed (not as plaintext) and tracking is enabled.
        DbContext.ChangeTracker.Clear();
        var channel = await DbContext.SalesChannel.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(s => s.Id == WooCommerceTenant1Id);
        Assert.True(channel.TrackingEnabled);
        Assert.False(string.IsNullOrEmpty(channel.TrackingTokenHash));
        Assert.NotEqual(dto.Token, channel.TrackingTokenHash); // hash, not the plaintext token
    }

    [Fact]
    public async Task RotateTrackingToken_CrossTenant_ReturnsNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        // Tenant 2 must not be able to rotate Tenant 1's channel token.
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.PostAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking-token", null);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        // And nothing was written to the foreign channel.
        DbContext.ChangeTracker.Clear();
        var channel = await DbContext.SalesChannel.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(s => s.Id == WooCommerceTenant1Id);
        Assert.False(channel.TrackingEnabled);
        Assert.True(string.IsNullOrEmpty(channel.TrackingTokenHash));
    }

    [Fact]
    public async Task TrackingStatus_AfterRotate_ReportsEnabledAndConfigured()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await Client.PostAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking-token", null);

        var statusResponse = await Client.GetAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking");

        TestAssertions.AssertHttpSuccess(statusResponse);
        var status = await ReadResponseAsync<SalesChannelTrackingStatusDto>(statusResponse);
        Assert.NotNull(status);
        Assert.True(status.TrackingEnabled);
        Assert.True(status.HasToken);
    }

    [Fact]
    public async Task DisableTracking_TurnsOffButKeepsToken()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await Client.PostAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking-token", null);
        var disableResponse = await Client.DeleteAsync($"/api/v1/SalesChannels/{WooCommerceTenant1Id}/tracking");

        Assert.Equal(HttpStatusCode.NoContent, disableResponse.StatusCode);

        DbContext.ChangeTracker.Clear();
        var channel = await DbContext.SalesChannel.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(s => s.Id == WooCommerceTenant1Id);
        Assert.False(channel.TrackingEnabled);
        Assert.False(string.IsNullOrEmpty(channel.TrackingTokenHash)); // token kept for re-enabling
    }

    [Fact]
    public async Task Ingest_AnonymousBeacon_IsAcceptedWithoutTenantHeader()
    {
        // The storefront ingest endpoint is anonymous and token-authenticated; it must accept a beacon
        // without an X-Tenant-Id header (it is on the TenantMiddleware skip-list).
        RemoveTenantHeader();

        var beacon = new { eventType = "PageView", vid = "test-visitor", hostname = "shop.example.com" };
        var response = await Client.PostAsJsonAsync("/api/v1/storefront/e", beacon);

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }

    [Fact]
    public async Task Ingest_UnknownToken_StillReturnsAccepted()
    {
        // Unknown/invalid tokens must not be distinguishable from valid ones (no information leak).
        RemoveTenantHeader();
        Client.DefaultRequestHeaders.Remove("X-Storefront-Token");
        Client.DefaultRequestHeaders.Add("X-Storefront-Token", "definitely-not-a-real-token");

        var beacon = new { eventType = "ProductView", vid = "v", productRef = "1" };
        var response = await Client.PostAsJsonAsync("/api/v1/storefront/e", beacon);

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }
}
