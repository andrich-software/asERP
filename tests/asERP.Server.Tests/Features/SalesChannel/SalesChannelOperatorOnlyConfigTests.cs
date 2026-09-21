#nullable disable
using System.Net;
using System.Text.Json.Nodes;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.SalesChannel;

/// <summary>
/// <c>allowPrivateHost</c> and <c>allowInsecureTransport</c> decide whether the direct-MySQL
/// connector may dial a private address and whether it may drop TLS. They used to ride in the same
/// request body as the host they unlocked, so the caller supplied both the target and the
/// permission. They are operator configuration now, and every tenant-facing path strips them out of
/// the blob: create, update and the draft connection test.
/// </summary>
public class SalesChannelOperatorOnlyConfigTests : TenantIsolatedTestBase
{
    private const string ChannelName = "Woo DB Store";

    private const string ConfigWithOperatorFlags =
        """{"host":"10.0.0.7","port":3306,"database":"wp","tablePrefix":"wp_","allowPrivateHost":true,"allowInsecureTransport":true}""";

    private Guid _warehouseId;

    private async Task SeedAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var warehouse = await DbContext.Warehouse.IgnoreQueryFilters()
                .FirstAsync(w => w.TenantId == TenantConstants.TestTenant1Id);
            _warehouseId = warehouse.Id;
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        SetTenantHeader(TenantConstants.TestTenant1Id);
    }

    /// <summary>Seeds a channel whose stored blob still carries the flags, as pre-patch rows do.</summary>
    private async Task<Guid> SeedChannelWithStoredFlagsAsync()
    {
        await SeedAsync();

        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        Guid channelId;
        try
        {
            var warehouse = await DbContext.Warehouse.IgnoreQueryFilters().FirstAsync(w => w.Id == _warehouseId);
            var channel = new asERP.Domain.Entities.SalesChannel
            {
                Id = Guid.NewGuid(),
                Type = SalesChannelType.WooCommerceDatabase,
                Name = ChannelName,
                Url = "https://shop.example.com",
                Username = "mysql-user",
                Password = "mysql-password",
                AdditionalConfigJson = ConfigWithOperatorFlags,
                TenantId = TenantConstants.TestTenant1Id,
                Warehouses = new List<asERP.Domain.Entities.Warehouse> { warehouse },
            };

            DbContext.SalesChannel.Add(channel);
            await DbContext.SaveChangesAsync();
            channelId = channel.Id;
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        SetTenantHeader(TenantConstants.TestTenant1Id);
        return channelId;
    }

    private SalesChannelInputDto Dto(string configJson, Guid? id = null) => new()
    {
        Id = id ?? Guid.Empty,
        SalesChannelType = SalesChannelType.WooCommerceDatabase,
        Name = ChannelName,
        Url = "https://shop.example.com",
        Username = "mysql-user",
        Password = "mysql-password",
        AdditionalConfigJson = configJson,
        WarehouseIds = new List<Guid> { _warehouseId },
    };

    private async Task<JsonObject> StoredConfigAsync(Guid channelId)
    {
        DbContext.ChangeTracker.Clear();
        var stored = await DbContext.SalesChannel.IgnoreQueryFilters().FirstAsync(c => c.Id == channelId);
        return JsonNode.Parse(stored.AdditionalConfigJson)!.AsObject();
    }

    private static void AssertNoOperatorKeys(JsonObject config)
    {
        TestAssertions.AssertFalse(config.ContainsKey("allowPrivateHost"),
            "allowPrivateHost must never become channel data — it is server configuration.");
        TestAssertions.AssertFalse(config.ContainsKey("allowInsecureTransport"),
            "allowInsecureTransport must never become channel data — it is server configuration.");
    }

    [Fact]
    public async Task CreateSalesChannel_WithOperatorOnlyFlags_ShouldStripThem()
    {
        await SeedAsync();

        var response = await PostAsJsonAsync("/api/v1/SalesChannels", Dto(ConfigWithOperatorFlags));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var created = await ReadResponseAsync<Result<Guid>>(response);
        var config = await StoredConfigAsync(created.Data);

        AssertNoOperatorKeys(config);
        // The rest of the blob is the tenant's own and still round-trips.
        TestAssertions.AssertEqual("10.0.0.7", config["host"].GetValue<string>());
        TestAssertions.AssertEqual("wp", config["database"].GetValue<string>());
    }

    [Fact]
    public async Task CreateSalesChannel_WithDifferentlyCasedFlag_ShouldStillStripIt()
    {
        await SeedAsync();

        var response = await PostAsJsonAsync("/api/v1/SalesChannels",
            Dto("""{"host":"10.0.0.7","database":"wp","AllowPrivateHost":true}"""));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var created = await ReadResponseAsync<Result<Guid>>(response);
        var config = await StoredConfigAsync(created.Data);

        TestAssertions.AssertFalse(config.ContainsKey("AllowPrivateHost"),
            "Key matching must be case-insensitive — the connectors deserialize the blob that way.");
    }

    [Fact]
    public async Task UpdateSalesChannel_WithOperatorOnlyFlags_ShouldStripThem()
    {
        var channelId = await SeedChannelWithStoredFlagsAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            Dto(ConfigWithOperatorFlags, channelId));

        TestAssertions.AssertHttpSuccess(response);
        AssertNoOperatorKeys(await StoredConfigAsync(channelId));
    }

    [Fact]
    public async Task UpdateSalesChannel_ShouldNotCarryStoredFlagsForward()
    {
        // A row written before the flags became server configuration keeps them until it is next
        // saved; the update drops them rather than merging them back in.
        var channelId = await SeedChannelWithStoredFlagsAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            Dto("""{"host":"10.0.0.7","database":"wp","tablePrefix":"wp_"}""", channelId));

        TestAssertions.AssertHttpSuccess(response);
        AssertNoOperatorKeys(await StoredConfigAsync(channelId));
    }

    [Fact]
    public async Task DraftConnectionTest_WithAllowPrivateHost_ShouldStillRefuseThePrivateHost()
    {
        await SeedAsync();

        var response = await PostAsJsonAsync("/api/v1/saleschannels/test-connection",
            new SalesChannelConnectionTestInputDto
            {
                SalesChannelType = SalesChannelType.WooCommerceDatabase,
                // Public literal so the shop-URL guard needs no resolver; it is never dialled here.
                Url = "https://203.0.113.10/",
                Username = "root",
                Password = string.Empty,
                AdditionalConfigJson = ConfigWithOperatorFlags,
            });

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<SalesChannelConnectionTestResultDto>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertFalse(result.Success, "A private MySQL host must be refused.");
        TestAssertions.AssertTrue(result.Message.Contains("not permitted", StringComparison.Ordinal),
            "The request body must not be able to unlock the private-address guard.");
    }
}
