using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Repositories;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Import of shop-side tracking numbers into local shipments: carrier mapping resolution, the
/// deliberate skip for unmapped carriers (Shipping.ShippingProviderId is not nullable), duplicate
/// suppression on re-import, and shipments for orders that have not been imported yet.
/// </summary>
public class ShipmentImportRepositoryTests : TenantIsolatedTestBase
{
    private SalesChannel _channel = null!;
    private Guid _dhlProviderId;

    private async Task SeedAsync(bool withCarrierMapping = true)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        _dhlProviderId = Guid.NewGuid();
        _channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerceDatabase,
            Name = "Shipment Import Test Channel",
            Url = "https://shop.example.com",
            Username = "dbuser",
            Password = "secret",
            IsEnabled = true,
            ShipmentTrackingMode = ShipmentTrackingMode.Import,
            TenantId = TenantConstants.TestTenant1Id,
            SyncState = new SalesChannelSyncState { TenantId = TenantConstants.TestTenant1Id }
        };

        try
        {
            DbContext.ShippingProvider.Add(new ShippingProvider
            {
                Id = _dhlProviderId,
                Name = "DHL",
                Type = ShippingProviderType.Dhl,
                IsEnabled = true,
                TenantId = TenantConstants.TestTenant1Id
            });
            DbContext.SalesChannel.Add(_channel);

            if (withCarrierMapping)
            {
                DbContext.SalesChannelCarrierMapping.Add(new SalesChannelCarrierMapping
                {
                    Id = Guid.NewGuid(),
                    SalesChannelId = _channel.Id,
                    RemoteCarrierCode = "dhl_home_delivery",
                    ShippingProviderId = _dhlProviderId,
                    TenantId = TenantConstants.TestTenant1Id
                });
            }

            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        SetTenantHeader(TenantConstants.TestTenant1Id);
    }

    private async Task<Guid> SeedOrderAsync(string remoteSalesId)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var salesId = Guid.NewGuid();
        try
        {
            DbContext.Sales.Add(new Sales
            {
                Id = salesId,
                SalesChannelId = _channel.Id,
                RemoteSalesId = remoteSalesId,
                Status = SalesStatus.Processing,
                PaymentStatus = PaymentStatus.CompletelyPaid,
                TenantId = TenantConstants.TestTenant1Id
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        return salesId;
    }

    private ShipmentImportRepository CreateRepository() =>
        new(DbContext, NullLogger<ShipmentImportRepository>.Instance);

    private static SalesChannelImportShipment Shipment(string remoteSalesId, string tracking, string carrier = "dhl_home_delivery") => new()
    {
        RemoteSalesId = remoteSalesId,
        TrackingNumber = tracking,
        RemoteCarrierCode = carrier
    };

    [Fact]
    public async Task Import_MappedCarrier_CreatesShipmentOnTheOrder()
    {
        await SeedAsync();
        var salesId = await SeedOrderAsync("6920719");

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("6920719", "00340434666768541089") });

        Assert.Equal(1, outcome.Created);
        Assert.Empty(outcome.UnmappedCarrierCodes);

        var shipment = await DbContext.Shipping.IgnoreQueryFilters().SingleAsync(s => s.SalesId == salesId);
        Assert.Equal("00340434666768541089", shipment.TrackingNumber);
        Assert.Equal(_dhlProviderId, shipment.ShippingProviderId);
        Assert.Equal(ShippingStatus.Shipped, shipment.Status);
        Assert.Equal(TenantConstants.TestTenant1Id, shipment.TenantId);
    }

    [Fact]
    public async Task Import_CarrierCodeCasing_IsIgnoredWhenMatching()
    {
        await SeedAsync();
        await SeedOrderAsync("6920719");

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("6920719", "ABC123", "DHL_Home_Delivery") });

        Assert.Equal(1, outcome.Created);
    }

    [Fact]
    public async Task Import_UnmappedCarrier_SkipsAndReportsTheCode()
    {
        await SeedAsync(withCarrierMapping: false);
        await SeedOrderAsync("6920719");

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("6920719", "00340434666768541089") });

        Assert.Equal(0, outcome.Created);
        Assert.Equal(1, outcome.Skipped);
        Assert.Equal(new[] { "dhl_home_delivery" }, outcome.UnmappedCarrierCodes);
        Assert.False(await DbContext.Shipping.IgnoreQueryFilters().AnyAsync());
    }

    [Fact]
    public async Task Import_SameTrackingNumberTwice_CreatesOnlyOneShipment()
    {
        await SeedAsync();
        var salesId = await SeedOrderAsync("6920719");
        var repository = CreateRepository();

        await repository.ImportShipmentsAsync(_channel, new[] { Shipment("6920719", "00340434666768541089") });
        var second = await repository.ImportShipmentsAsync(_channel, new[] { Shipment("6920719", "00340434666768541089") });

        Assert.Equal(0, second.Created);
        Assert.Equal(1, second.Skipped);
        Assert.Equal(1, await DbContext.Shipping.IgnoreQueryFilters().CountAsync(s => s.SalesId == salesId));
    }

    [Fact]
    public async Task Import_SeveralParcelsOfOneOrder_CreatesOneShipmentEach()
    {
        await SeedAsync();
        var salesId = await SeedOrderAsync("6920719");

        var outcome = await CreateRepository().ImportShipmentsAsync(_channel, new[]
        {
            Shipment("6920719", "00340434666768541089"),
            Shipment("6920719", "00340434666768541072")
        });

        Assert.Equal(2, outcome.Created);
        Assert.Equal(2, await DbContext.Shipping.IgnoreQueryFilters().CountAsync(s => s.SalesId == salesId));
    }

    [Fact]
    public async Task Import_UnknownOrder_IsSkippedForALaterRun()
    {
        await SeedAsync();

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("does-not-exist-yet", "ABC123") });

        Assert.Equal(0, outcome.Created);
        Assert.Equal(new[] { "does-not-exist-yet" }, outcome.UnknownRemoteSalesIds);
        Assert.False(await DbContext.Shipping.IgnoreQueryFilters().AnyAsync());
    }

    [Fact]
    public async Task Import_OrderOfAnotherChannel_IsNotMatched()
    {
        await SeedAsync();

        // Same remote id, but the order belongs to a different channel. Remote ids are only unique
        // per shop, so matching must always be scoped to the channel.
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            DbContext.Sales.Add(new Sales
            {
                Id = Guid.NewGuid(),
                SalesChannelId = Guid.NewGuid(),
                RemoteSalesId = "6920719",
                Status = SalesStatus.Processing,
                TenantId = TenantConstants.TestTenant1Id
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("6920719", "ABC123") });

        Assert.Equal(0, outcome.Created);
        Assert.False(await DbContext.Shipping.IgnoreQueryFilters().AnyAsync());
    }

    [Fact]
    public async Task Import_BlankTrackingNumber_IsIgnored()
    {
        await SeedAsync();
        await SeedOrderAsync("6920719");

        var outcome = await CreateRepository().ImportShipmentsAsync(
            _channel, new[] { Shipment("6920719", "   ") });

        Assert.Equal(0, outcome.Created);
        Assert.Equal(1, outcome.Skipped);
        Assert.False(await DbContext.Shipping.IgnoreQueryFilters().AnyAsync());
    }
}
