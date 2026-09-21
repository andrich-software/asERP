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
/// The connector config blob carries the Shopware 6 / Amazon API secrets, so it follows the same
/// rule as the password: redacted on read, and the placeholder coming back means "keep the stored
/// value". Everything else of the blob still round-trips verbatim.
/// </summary>
public class SalesChannelConfigSecretTests : TenantIsolatedTestBase
{
    private const string ChannelName = "Shopware Store With Config";

    private const string ConfigWithSecrets =
        """{"apiClientId":"SWIAxxxx","apiClientSecret":"live-shopware-secret","lwaClientSecret":"live-amazon-secret","merchantLocationKey":"WAREHOUSE-1"}""";

    private Guid _warehouseId;

    private async Task<Guid> SeedChannelAsync(string configJson = ConfigWithSecrets)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        Guid channelId;
        try
        {
            var warehouse = await DbContext.Warehouse.IgnoreQueryFilters()
                .FirstAsync(w => w.TenantId == TenantConstants.TestTenant1Id);
            _warehouseId = warehouse.Id;

            var channel = new asERP.Domain.Entities.SalesChannel
            {
                Id = Guid.NewGuid(),
                Type = SalesChannelType.Shopware6,
                Name = ChannelName,
                Url = "https://shop.example.com",
                Username = "shopware-user",
                Password = "shopware-password",
                AdditionalConfigJson = configJson,
                TenantId = TenantConstants.TestTenant1Id,
                Warehouses = new List<asERP.Domain.Entities.Warehouse> { warehouse }
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

    private SalesChannelInputDto UpdateDto(Guid id, string configJson) => new()
    {
        Id = id,
        SalesChannelType = SalesChannelType.Shopware6,
        Name = ChannelName,
        Url = "https://shop.example.com",
        Username = "shopware-user",
        AdditionalConfigJson = configJson,
        WarehouseIds = new List<Guid> { _warehouseId }
    };

    private async Task<string> StoredConfigJsonAsync(Guid channelId)
    {
        DbContext.ChangeTracker.Clear();
        var stored = await DbContext.SalesChannel.IgnoreQueryFilters()
            .FirstAsync(c => c.Id == channelId);
        return stored.AdditionalConfigJson;
    }

    private async Task<JsonObject> StoredConfigAsync(Guid channelId)
        => JsonNode.Parse(await StoredConfigJsonAsync(channelId))!.AsObject();

    [Fact]
    public async Task GetSalesChannelDetail_ShouldRedactTheConnectorSecrets()
    {
        var channelId = await SeedChannelAsync();

        var response = await Client.GetAsync($"/api/v1/SalesChannels/{channelId}");

        TestAssertions.AssertHttpSuccess(response);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertFalse(raw.Contains("live-shopware-secret", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the Shopware API client secret.");
        TestAssertions.AssertFalse(raw.Contains("live-amazon-secret", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the Amazon LWA client secret.");

        var result = await ReadResponseAsync<Result<SalesChannelDetailDto>>(response);
        var config = JsonNode.Parse(result.Data.AdditionalConfigJson)!.AsObject();
        TestAssertions.AssertEqual("********", config["apiClientSecret"]!.GetValue<string>());
        TestAssertions.AssertEqual("********", config["lwaClientSecret"]!.GetValue<string>());
        TestAssertions.AssertEqual("SWIAxxxx", config["apiClientId"]!.GetValue<string>());
        TestAssertions.AssertEqual("WAREHOUSE-1", config["merchantLocationKey"]!.GetValue<string>());
    }

    [Fact]
    public async Task GetSalesChannelDetail_WithDifferentlyCasedSecretKey_ShouldStillRedact()
    {
        var channelId = await SeedChannelAsync("""{"ApiClientSecret":"live-shopware-secret"}""");

        var response = await Client.GetAsync($"/api/v1/SalesChannels/{channelId}");

        TestAssertions.AssertHttpSuccess(response);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertFalse(raw.Contains("live-shopware-secret", StringComparison.OrdinalIgnoreCase),
            "Key matching must be case-insensitive - the connectors deserialize the blob that way.");
    }

    [Fact]
    public async Task GetSalesChannelDetail_WithDuplicatedKey_ShouldSuppressTheBlobInsteadOfFailing()
    {
        var channelId = await SeedChannelAsync(
            """{"apiClientSecret":"live-shopware-secret","apiClientSecret":"live-shopware-secret"}""");

        var response = await Client.GetAsync($"/api/v1/SalesChannels/{channelId}");

        TestAssertions.AssertHttpSuccess(response);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertFalse(raw.Contains("live-shopware-secret", StringComparison.OrdinalIgnoreCase),
            "A blob that cannot be read must be suppressed, not echoed.");
        var result = await ReadResponseAsync<Result<SalesChannelDetailDto>>(response);
        TestAssertions.AssertNull(result.Data.AdditionalConfigJson);
    }

    [Fact]
    public async Task UpdateSalesChannel_WithRedactedSecret_ShouldKeepTheStoredSecret()
    {
        var channelId = await SeedChannelAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, """{"apiClientId":"SWIAyyyy","apiClientSecret":"********"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredConfigAsync(channelId);
        TestAssertions.AssertEqual("live-shopware-secret", config["apiClientSecret"]!.GetValue<string>());
        TestAssertions.AssertEqual("SWIAyyyy", config["apiClientId"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateSalesChannel_WithNewSecret_ShouldReplaceTheStoredSecret()
    {
        var channelId = await SeedChannelAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, """{"apiClientSecret":"rotated-shopware-secret"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredConfigAsync(channelId);
        TestAssertions.AssertEqual("rotated-shopware-secret", config["apiClientSecret"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateSalesChannel_WithoutTheSecretKey_ShouldClearIt()
    {
        var channelId = await SeedChannelAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, """{"apiClientId":"SWIAxxxx"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredConfigAsync(channelId);
        TestAssertions.AssertFalse(config.ContainsKey("apiClientSecret"),
            "A key the user removed must be cleared, not restored.");
    }

    [Fact]
    public async Task UpdateSalesChannel_WithNullConfig_ShouldLeaveTheStoredBlobUntouched()
    {
        var channelId = await SeedChannelAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, null));

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual(ConfigWithSecrets, await StoredConfigJsonAsync(channelId));
    }

    [Fact]
    public async Task UpdateSalesChannel_WithEmptyConfig_ShouldClearTheStoredBlob()
    {
        var channelId = await SeedChannelAsync();

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, string.Empty));

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertNull(await StoredConfigJsonAsync(channelId));
    }

    [Fact]
    public async Task UpdateSalesChannel_WithDuplicatedKey_ShouldNotFail()
    {
        var channelId = await SeedChannelAsync();
        const string duplicated = """{"apiClientId":"SWIAxxxx","apiClientId":"SWIAxxxx"}""";

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}",
            UpdateDto(channelId, duplicated));

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual(duplicated, await StoredConfigJsonAsync(channelId));
    }

    [Fact]
    public async Task CreateSalesChannel_WithRedactedSecret_ShouldNotStoreThePlaceholder()
    {
        await SeedChannelAsync();

        var createDto = UpdateDto(Guid.Empty, """{"apiClientId":"SWIAzzzz","apiClientSecret":"********"}""");
        createDto.Name = "Shopware Store Created With Placeholder";
        // Required on create for credential-based channel types (empty only means "keep" on update).
        createDto.Password = "shopware-password";

        var response = await PostAsJsonAsync("/api/v1/SalesChannels", createDto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        var config = await StoredConfigAsync(result.Data);
        TestAssertions.AssertFalse(config.ContainsKey("apiClientSecret"),
            "The redaction placeholder must never become a stored credential.");
        TestAssertions.AssertEqual("SWIAzzzz", config["apiClientId"]!.GetValue<string>());
    }
}
