using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.SalesChannel.Commands;

/// <summary>
/// Carrier translations on the sales channel form: round-trip through create/detail/update, and the
/// tenant boundary — the provider id arrives in the request body and the database foreign key is
/// tenant-blind, so a foreign id must be rejected rather than silently linked.
/// </summary>
public class SalesChannelCarrierMappingTests : TenantIsolatedTestBase
{
    private static readonly Guid Tenant1ProviderId = new("aaaaaaaa-1111-1111-1111-aaaaaaaaaaaa");
    private static readonly Guid Tenant1SecondProviderId = new("aaaaaaaa-2222-2222-2222-aaaaaaaaaaaa");
    private static readonly Guid Tenant2ProviderId = new("bbbbbbbb-1111-1111-1111-bbbbbbbbbbbb");

    // Seeded by TestDataSeeder. Every channel needs at least one warehouse (base validator).
    private static readonly Guid Tenant1WarehouseId = new("10000001-0001-0001-0001-000000000001");

    private async Task SeedProvidersAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            if (await DbContext.ShippingProvider.IgnoreQueryFilters()
                    .AnyAsync(p => p.Id == Tenant1ProviderId))
            {
                return;
            }

            DbContext.ShippingProvider.AddRange(
                new asERP.Domain.Entities.ShippingProvider
                {
                    Id = Tenant1ProviderId,
                    Name = "DHL (Tenant 1)",
                    Type = ShippingProviderType.Dhl,
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.ShippingProvider
                {
                    Id = Tenant1SecondProviderId,
                    Name = "DPD (Tenant 1)",
                    Type = ShippingProviderType.Dpd,
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.ShippingProvider
                {
                    Id = Tenant2ProviderId,
                    Name = "DHL (Tenant 2)",
                    Type = ShippingProviderType.Dhl,
                    TenantId = TenantConstants.TestTenant2Id
                });

            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private static SalesChannelInputDto NewChannelDto(
        ShipmentTrackingMode mode = ShipmentTrackingMode.None,
        params SalesChannelCarrierMappingInputDto[] mappings) => new()
        {
            SalesChannelType = SalesChannelType.WooCommerce,
            Name = "Carrier Mapping Shop",
            Url = "https://carrier-mapping.example.com",
            Username = "ck_test",
            Password = "cs_test",
            ImportSaless = true,
            ShipmentTrackingMode = mode,
            CarrierMappings = mappings.ToList(),
            WarehouseIds = new List<Guid> { Tenant1WarehouseId }
        };

    private static SalesChannelCarrierMappingInputDto Mapping(string code, Guid providerId)
        => new() { RemoteCarrierCode = code, ShippingProviderId = providerId };

    private async Task<Guid> CreateChannelAsync(SalesChannelInputDto dto)
    {
        var response = await PostAsJsonAsync("/api/v1/SalesChannels", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertNotNull(result);
        return result!.Data;
    }

    private async Task<SalesChannelDetailDto> GetChannelAsync(Guid id)
    {
        var response = await Client.GetAsync($"/api/v1/SalesChannels/{id}");
        TestAssertions.AssertHttpSuccess(response);
        var detail = await ReadResponseAsync<Result<SalesChannelDetailDto>>(response);
        TestAssertions.AssertNotNull(detail?.Data);
        return detail!.Data!;
    }

    [Fact]
    public async Task Create_WithCarrierMappings_PersistsModeAndMappings()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("DHL_Home_Delivery", Tenant1ProviderId)));

        var detail = await GetChannelAsync(channelId);

        TestAssertions.AssertEqual(ShipmentTrackingMode.Import, detail.ShipmentTrackingMode);
        var mapping = Assert.Single(detail.CarrierMappings);
        // Codes are normalized on write so matching is case-insensitive across all three providers.
        TestAssertions.AssertEqual("dhl_home_delivery", mapping.RemoteCarrierCode);
        TestAssertions.AssertEqual(Tenant1ProviderId, mapping.ShippingProviderId);
        TestAssertions.AssertEqual("DHL (Tenant 1)", mapping.ShippingProviderName);
    }

    [Fact]
    public async Task Create_WithForeignShippingProvider_ShouldReturnBadRequest()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/SalesChannels", NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant2ProviderId)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.False(await DbContext.SalesChannelCarrierMapping.IgnoreQueryFilters()
            .AnyAsync(m => m.ShippingProviderId == Tenant2ProviderId));
    }

    [Fact]
    public async Task Update_WithForeignShippingProvider_ShouldReturnBadRequest_AndKeepStoredMappings()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant1ProviderId)));

        var update = NewChannelDto(ShipmentTrackingMode.Import, Mapping("dhl_home_delivery", Tenant2ProviderId));
        update.Id = channelId;

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}", update);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);

        // The rejected update must not have touched the stored mapping.
        var detail = await GetChannelAsync(channelId);
        TestAssertions.AssertEqual(Tenant1ProviderId, Assert.Single(detail.CarrierMappings).ShippingProviderId);
    }

    [Fact]
    public async Task Update_ReplacesTheWholeMappingSet()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant1ProviderId),
            Mapping("flat_rate", Tenant1ProviderId)));

        var update = NewChannelDto(
            ShipmentTrackingMode.Push,
            Mapping("flat_rate", Tenant1SecondProviderId));
        update.Id = channelId;

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}", update);
        TestAssertions.AssertHttpSuccess(response);

        var detail = await GetChannelAsync(channelId);
        TestAssertions.AssertEqual(ShipmentTrackingMode.Push, detail.ShipmentTrackingMode);
        var mapping = Assert.Single(detail.CarrierMappings);
        TestAssertions.AssertEqual("flat_rate", mapping.RemoteCarrierCode);
        TestAssertions.AssertEqual(Tenant1SecondProviderId, mapping.ShippingProviderId);
    }

    [Fact]
    public async Task Update_WithEmptyMappingSet_ClearsStoredMappings()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant1ProviderId)));

        var update = NewChannelDto(ShipmentTrackingMode.None);
        update.Id = channelId;

        var response = await PutAsJsonAsync($"/api/v1/SalesChannels/{channelId}", update);
        TestAssertions.AssertHttpSuccess(response);

        var detail = await GetChannelAsync(channelId);
        TestAssertions.AssertEqual(ShipmentTrackingMode.None, detail.ShipmentTrackingMode);
        Assert.Empty(detail.CarrierMappings);
    }

    [Fact]
    public async Task Mappings_OfAnotherTenantsChannel_AreNotVisible()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant1ProviderId)));

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync($"/api/v1/SalesChannels/{channelId}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeletingTheChannel_RemovesItsCarrierMappings()
    {
        await SeedProvidersAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channelId = await CreateChannelAsync(NewChannelDto(
            ShipmentTrackingMode.Import,
            Mapping("dhl_home_delivery", Tenant1ProviderId)));

        var response = await Client.DeleteAsync($"/api/v1/SalesChannels/{channelId}");
        TestAssertions.AssertHttpSuccess(response);

        Assert.Empty(await DbContext.SalesChannelCarrierMapping.IgnoreQueryFilters()
            .Where(m => m.SalesChannelId == channelId).ToListAsync());
    }
}
