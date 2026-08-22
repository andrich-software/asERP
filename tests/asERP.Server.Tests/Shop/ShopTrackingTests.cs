using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Shop;

/// <summary>
/// Built-in web analytics of asShop storefronts: the tracker script is embedded only when the
/// channel has tracking enabled, and the same-origin collector (/asshop/e) is anonymous, resolves
/// the channel from the Host header (no token anywhere) and never leaks the tracking state.
/// </summary>
public class ShopTrackingTests : TenantIsolatedTestBase
{
    private const string TrackerScriptPath = "/_content/asERP.Shop/aserp-shop.js";

    private async Task<SalesChannel> SeedShopChannelAsync(Guid tenantId, string host, bool trackingEnabled)
    {
        TenantContext.SetCurrentTenantId(tenantId);

        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Name = $"asShop {host}",
            Type = SalesChannelType.AsShop,
            IsEnabled = true,
            TrackingEnabled = trackingEnabled,
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

        DbContext.SalesChannel.Add(channel);
        await DbContext.SaveChangesAsync();
        return channel;
    }

    private static HttpRequestMessage BeaconRequestForHost(string host, object? beacon = null)
    {
        beacon ??= new { eventType = "PageView", vid = "test-visitor", hostname = host };
        var request = new HttpRequestMessage(HttpMethod.Post, "/asshop/e")
        {
            Content = new StringContent(JsonSerializer.Serialize(beacon), Encoding.UTF8, "application/json")
        };
        request.Headers.Host = host;
        return request;
    }

    [Fact]
    public async Task TrackingEnabledChannel_HomePageEmbedsTrackerScript()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "trackshop.local", trackingEnabled: true);

        var request = new HttpRequestMessage(HttpMethod.Get, "/");
        request.Headers.Host = "trackshop.local";
        var response = await Client.SendAsync(request);

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains(TrackerScriptPath, body);
    }

    [Fact]
    public async Task TrackingDisabledChannel_HomePageHasNoTrackerScript()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "ohnetracking.local", trackingEnabled: false);

        var request = new HttpRequestMessage(HttpMethod.Get, "/");
        request.Headers.Host = "ohnetracking.local";
        var response = await Client.SendAsync(request);

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.DoesNotContain(TrackerScriptPath, body);
    }

    [Fact]
    public async Task Beacon_OnTrackingEnabledShopHost_ReturnsAccepted()
    {
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "beaconshop.local", trackingEnabled: true);
        RemoveTenantHeader();

        var response = await Client.SendAsync(BeaconRequestForHost("beaconshop.local"));

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }

    [Fact]
    public async Task Beacon_OnTrackingDisabledShopHost_StillReturnsAccepted()
    {
        // Tracking state must not be observable from the outside — disabled channels answer
        // exactly like enabled ones (the beacon is just dropped).
        await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "stillershop.local", trackingEnabled: false);
        RemoveTenantHeader();

        var response = await Client.SendAsync(BeaconRequestForHost("stillershop.local"));

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }

    [Fact]
    public async Task Beacon_OnUnknownHost_ReturnsNotFound()
    {
        RemoveTenantHeader();

        var response = await Client.SendAsync(BeaconRequestForHost("keinshop.local"));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task EnableTracking_WithoutToken_TurnsTrackingOn()
    {
        var channel = await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "aktivierbar.local", trackingEnabled: false);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/SalesChannels/{channel.Id}/tracking", null);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        DbContext.ChangeTracker.Clear();
        var reloaded = await DbContext.SalesChannel.AsNoTracking().FirstAsync(s => s.Id == channel.Id);
        Assert.True(reloaded.TrackingEnabled);
        Assert.True(string.IsNullOrEmpty(reloaded.TrackingTokenHash)); // asShop needs no token
    }

    [Fact]
    public async Task EnableTracking_CrossTenant_ReturnsNotFound()
    {
        var channel = await SeedShopChannelAsync(TenantConstants.TestTenant1Id, "fremdshop.local", trackingEnabled: false);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.PostAsync($"/api/v1/SalesChannels/{channel.Id}/tracking", null);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        DbContext.ChangeTracker.Clear();
        var reloaded = await DbContext.SalesChannel.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(s => s.Id == channel.Id);
        Assert.False(reloaded.TrackingEnabled);
    }

    [Fact]
    public async Task CreateAsShopChannel_EnablesTrackingByDefault()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var warehouseId = (await DbContext.Warehouse.AsNoTracking().FirstAsync()).Id;
        var dto = new SalesChannelInputDto
        {
            SalesChannelType = SalesChannelType.AsShop,
            Name = "Neuer asShop",
            WarehouseIds = [warehouseId]
        };

        var response = await PostAsJsonAsync("/api/v1/SalesChannels", dto);

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<Guid>>(response);

        DbContext.ChangeTracker.Clear();
        var created = await DbContext.SalesChannel.AsNoTracking().FirstAsync(s => s.Id == result.Data);
        Assert.True(created.TrackingEnabled);
    }
}
