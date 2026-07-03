using asToolkit.Domain.Enums;
using asToolkit.Shipping.Abstractions;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Services;

/// <summary>Pure unit tests for the carrier-status translation choke point.</summary>
public class TrackingStatusMapperTests
{
    [Theory]
    [InlineData(CarrierTrackingStatus.PreTransit, ShippingStatus.LabelCreated)]
    [InlineData(CarrierTrackingStatus.InTransit, ShippingStatus.InTransit)]
    [InlineData(CarrierTrackingStatus.OutForDelivery, ShippingStatus.OutForDelivery)]
    [InlineData(CarrierTrackingStatus.Delivered, ShippingStatus.Delivered)]
    [InlineData(CarrierTrackingStatus.DeliveryFailed, ShippingStatus.DeliveryFailed)]
    [InlineData(CarrierTrackingStatus.ReturnedToSender, ShippingStatus.ReturnedToSender)]
    [InlineData(CarrierTrackingStatus.Cancelled, ShippingStatus.Cancelled)]
    [InlineData(CarrierTrackingStatus.Lost, ShippingStatus.Lost)]
    public void Map_KnownCarrierStatus_ReturnsExpectedShippingStatus(
        CarrierTrackingStatus carrierStatus, ShippingStatus expected)
    {
        var mapped = TrackingStatusMapper.Map(carrierStatus);

        Assert.Equal(expected, mapped);
    }

    [Fact]
    public void Map_Unknown_ReturnsNull()
    {
        var mapped = TrackingStatusMapper.Map(CarrierTrackingStatus.Unknown);

        Assert.Null(mapped);
    }

    [Fact]
    public void IsUpgrade_SameStatus_ReturnsFalse()
    {
        Assert.False(TrackingStatusMapper.IsUpgrade(ShippingStatus.InTransit, ShippingStatus.InTransit));
    }

    [Theory]
    [InlineData(ShippingStatus.Delivered)]
    [InlineData(ShippingStatus.Cancelled)]
    [InlineData(ShippingStatus.ReturnedToSender)]
    [InlineData(ShippingStatus.Lost)]
    public void IsUpgrade_TerminalCurrentStatus_ReturnsFalse(ShippingStatus terminal)
    {
        Assert.False(TrackingStatusMapper.IsUpgrade(terminal, ShippingStatus.InTransit));
    }

    [Fact]
    public void IsUpgrade_LabelCreatedIncomingOnInTransit_ReturnsFalse()
    {
        Assert.False(TrackingStatusMapper.IsUpgrade(ShippingStatus.InTransit, ShippingStatus.LabelCreated));
    }

    [Fact]
    public void IsUpgrade_OpenToLabelCreated_ReturnsTrue()
    {
        Assert.True(TrackingStatusMapper.IsUpgrade(ShippingStatus.Open, ShippingStatus.LabelCreated));
    }

    [Theory]
    [InlineData(ShippingStatus.LabelCreated, ShippingStatus.InTransit)]
    [InlineData(ShippingStatus.InTransit, ShippingStatus.OutForDelivery)]
    [InlineData(ShippingStatus.OutForDelivery, ShippingStatus.Delivered)]
    [InlineData(ShippingStatus.DeliveryFailed, ShippingStatus.InTransit)]
    [InlineData(ShippingStatus.InTransit, ShippingStatus.Lost)]
    public void IsUpgrade_ValidTransitions_ReturnsTrue(ShippingStatus current, ShippingStatus incoming)
    {
        Assert.True(TrackingStatusMapper.IsUpgrade(current, incoming));
    }
}
