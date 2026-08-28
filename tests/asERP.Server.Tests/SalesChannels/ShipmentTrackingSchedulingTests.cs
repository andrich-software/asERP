using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerce;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using asERP.SalesChannels.Orchestration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Gating of the shipment-tracking exchange: which channel state makes the pull eligible, and which
/// connectors declare that they can perform it at all.
/// </summary>
public class ShipmentTrackingSchedulingTests
{
    private static SalesChannel NewChannel(ShipmentTrackingMode mode, bool initialSalesDone) => new()
    {
        Id = Guid.NewGuid(),
        Type = SalesChannelType.WooCommerce,
        Name = "test-shop",
        IsEnabled = true,
        ImportSaless = true,
        ShipmentTrackingMode = mode,
        SyncState = new SalesChannelSyncState
        {
            InitialProductImportCompleted = true,
            InitialSalesImportCompleted = initialSalesDone,
        },
    };

    [Fact]
    public void DueOperations_ScheduleShipmentImport_OnlyInImportMode()
    {
        var due = SalesChannelOrchestrator.ComputeDueOperations(NewChannel(ShipmentTrackingMode.Import, initialSalesDone: true));

        Assert.Contains(ChannelSyncOperation.ImportShipments, due);
    }

    [Theory]
    [InlineData(ShipmentTrackingMode.None)]
    [InlineData(ShipmentTrackingMode.Push)]
    public void DueOperations_NeverScheduleShipmentImport_OutsideImportMode(ShipmentTrackingMode mode)
    {
        // Push is an export driven by local shipment changes, not a scheduled pull — it must never
        // produce a scheduled import run.
        var due = SalesChannelOrchestrator.ComputeDueOperations(NewChannel(mode, initialSalesDone: true));

        Assert.DoesNotContain(ChannelSyncOperation.ImportShipments, due);
    }

    [Fact]
    public void DueOperations_WithholdShipmentImport_UntilInitialSalesImportCompleted()
    {
        // Shipments attach to already imported orders; running the pull against a half-imported
        // order history would resolve almost nothing and burn API calls.
        var due = SalesChannelOrchestrator.ComputeDueOperations(NewChannel(ShipmentTrackingMode.Import, initialSalesDone: false));

        Assert.DoesNotContain(ChannelSyncOperation.ImportShipments, due);
    }

    [Fact]
    public void ShipmentImport_IsPartOfTheScheduledOperationSet()
    {
        // The operation needs a durable per-(channel, operation) state row, which is only created for
        // operations listed here — without it the pull would never become due.
        Assert.Contains(ChannelSyncOperation.ImportShipments, SalesChannelOrchestrator.ScheduledImportOperations);
    }

    [Fact]
    public void BothWooCommerceConnectors_DeclareTrackingCapabilities()
    {
        ISalesChannelConnector rest = new WooCommerceConnector(
            null!, null!, null!, null!, null!, null!, NullLogger<WooCommerceConnector>.Instance);
        ISalesChannelConnector direct = new WooCommerceDatabaseConnector(
            null!, null!, null!, null!, null!, null!, NullLogger<WooCommerceDatabaseConnector>.Instance);

        foreach (var connector in new[] { rest, direct })
        {
            Assert.True(connector.Supports(ChannelSyncOperation.ImportShipments));
            Assert.True(connector.Supports(ChannelSyncOperation.PushShipment));
        }
    }

    [Fact]
    public void ConnectorsWithoutTrackingSupport_AreNotDispatched()
    {
        // The capability gate is what keeps a channel whose connector cannot exchange tracking
        // numbers from producing a failed run every interval / dead outbox rows.
        var connector = new NoCapabilityConnector();

        Assert.False(connector.Supports(ChannelSyncOperation.ImportShipments));
        Assert.False(connector.Supports(ChannelSyncOperation.PushShipment));
    }

    private sealed class NoCapabilityConnector : asERP.SalesChannels.Connectors.Common.ConnectorBase
    {
        public override SalesChannelType Type => SalesChannelType.PointOfSale;
        public override SalesChannelCapabilities Capabilities => SalesChannelCapabilities.None;
    }
}
