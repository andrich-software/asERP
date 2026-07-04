using asERP.Client.Features.Shippings.Models;
using asERP.Domain.Enums;

namespace asERP.Client.Tests;

public class SalesShipmentRulesTests
{
    [TestCase(SalesStatus.Pending, ExpectedResult = true)]
    [TestCase(SalesStatus.Processing, ExpectedResult = true)]
    [TestCase(SalesStatus.ReadyForDelivery, ExpectedResult = true)]
    [TestCase(SalesStatus.PartiallyDelivered, ExpectedResult = true)]
    [TestCase(SalesStatus.Completed, ExpectedResult = false)]
    [TestCase(SalesStatus.Cancelled, ExpectedResult = false)]
    [TestCase(SalesStatus.Returned, ExpectedResult = false)]
    [TestCase(SalesStatus.Refunded, ExpectedResult = false)]
    [TestCase(SalesStatus.OnHold, ExpectedResult = false)]
    [TestCase(SalesStatus.Failed, ExpectedResult = false)]
    [TestCase(SalesStatus.Unknown, ExpectedResult = false)]
    public bool CanShip_GatesByOrderStatus(SalesStatus status) =>
        SalesShipmentRules.CanShip(status);

    [TestCase(SalesStatus.Pending, ExpectedResult = true)]
    [TestCase(SalesStatus.Processing, ExpectedResult = true)]
    [TestCase(SalesStatus.ReadyForDelivery, ExpectedResult = true)]
    [TestCase(SalesStatus.OnHold, ExpectedResult = true)]
    [TestCase(SalesStatus.PartiallyDelivered, ExpectedResult = false)]
    [TestCase(SalesStatus.Completed, ExpectedResult = false)]
    [TestCase(SalesStatus.Cancelled, ExpectedResult = false)]
    [TestCase(SalesStatus.Returned, ExpectedResult = false)]
    [TestCase(SalesStatus.Refunded, ExpectedResult = false)]
    [TestCase(SalesStatus.Failed, ExpectedResult = false)]
    [TestCase(SalesStatus.Unknown, ExpectedResult = false)]
    public bool CanCancel_GatesByOrderStatus(SalesStatus status) =>
        SalesShipmentRules.CanCancel(status);

    [TestCase(ShippingStatus.Open, ExpectedResult = true)]
    [TestCase(ShippingStatus.InProgess, ExpectedResult = true)]
    [TestCase(ShippingStatus.ReadyForShipping, ExpectedResult = true)]
    [TestCase(ShippingStatus.LabelCreated, ExpectedResult = true)]
    [TestCase(ShippingStatus.Shipped, ExpectedResult = true)]
    [TestCase(ShippingStatus.InTransit, ExpectedResult = true)]
    [TestCase(ShippingStatus.OutForDelivery, ExpectedResult = true)]
    [TestCase(ShippingStatus.DeliveryFailed, ExpectedResult = true)]
    [TestCase(ShippingStatus.Delivered, ExpectedResult = false)]
    [TestCase(ShippingStatus.Cancelled, ExpectedResult = false)]
    [TestCase(ShippingStatus.ReturnedToSender, ExpectedResult = false)]
    [TestCase(ShippingStatus.Lost, ExpectedResult = false)]
    public bool CanCancelShipment_GatesByShipmentStatus(ShippingStatus status) =>
        SalesShipmentRules.CanCancelShipment(status);
}
