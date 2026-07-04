using asToolkit.Client.Presentation;
using asToolkit.Domain.Enums;
using Kind = asToolkit.Client.Presentation.StatusVisuals.Kind;

namespace asToolkit.Client.Tests;

/// <summary>
/// Verifies the central status → semantic kind mapping used by the StatusBadge control.
/// The kinds must match the color semantics of the previous per-status converters.
/// Text assertions use the English fallbacks (no localizer host in unit tests).
/// </summary>
public class StatusVisualsTests
{
    [TestCase(SalesStatus.Completed, Kind.Success)]
    [TestCase(SalesStatus.ReadyForDelivery, Kind.Positive)]
    [TestCase(SalesStatus.Processing, Kind.Info)]
    [TestCase(SalesStatus.Pending, Kind.Warning)]
    [TestCase(SalesStatus.PartiallyDelivered, Kind.Warning)]
    [TestCase(SalesStatus.OnHold, Kind.Caution)]
    [TestCase(SalesStatus.Returned, Kind.Caution)]
    [TestCase(SalesStatus.Failed, Kind.Danger)]
    [TestCase(SalesStatus.Refunded, Kind.Special)]
    [TestCase(SalesStatus.Cancelled, Kind.Neutral)]
    [TestCase(SalesStatus.Unknown, Kind.Neutral)]
    public void SalesStatus_MapsToExpectedKind(SalesStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [TestCase(PaymentStatus.CompletelyPaid, Kind.Success)]
    [TestCase(PaymentStatus.Invoiced, Kind.Info)]
    [TestCase(PaymentStatus.Reserved, Kind.Info)]
    [TestCase(PaymentStatus.PartiallyPaid, Kind.Warning)]
    [TestCase(PaymentStatus.FirstReminder, Kind.Warning)]
    [TestCase(PaymentStatus.SecondReminder, Kind.Caution)]
    [TestCase(PaymentStatus.ThirdReminder, Kind.Caution)]
    [TestCase(PaymentStatus.Delayed, Kind.Caution)]
    [TestCase(PaymentStatus.Encashment, Kind.Danger)]
    [TestCase(PaymentStatus.NoCreditApproved, Kind.Danger)]
    [TestCase(PaymentStatus.ReviewNecessary, Kind.Danger)]
    [TestCase(PaymentStatus.ReCrediting, Kind.Special)]
    [TestCase(PaymentStatus.CreditPreliminarilyAccepted, Kind.Neutral)]
    [TestCase(PaymentStatus.Unknown, Kind.Neutral)]
    public void PaymentStatus_MapsToExpectedKind(PaymentStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [TestCase(InvoiceStatus.Paid, Kind.Success)]
    [TestCase(InvoiceStatus.Sent, Kind.Info)]
    [TestCase(InvoiceStatus.PartiallyPaid, Kind.Warning)]
    [TestCase(InvoiceStatus.Overdue, Kind.Caution)]
    [TestCase(InvoiceStatus.Disputed, Kind.Danger)]
    [TestCase(InvoiceStatus.Refunded, Kind.Special)]
    [TestCase(InvoiceStatus.Created, Kind.Neutral)]
    [TestCase(InvoiceStatus.Cancelled, Kind.Neutral)]
    [TestCase(InvoiceStatus.WrittenOff, Kind.Neutral)]
    [TestCase(InvoiceStatus.Archived, Kind.Neutral)]
    public void InvoiceStatus_MapsToExpectedKind(InvoiceStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [TestCase(CustomerStatus.Active, Kind.Success)]
    [TestCase(CustomerStatus.NoDoi, Kind.Warning)]
    [TestCase(CustomerStatus.Inactive, Kind.Neutral)]
    public void CustomerStatus_MapsToExpectedKind(CustomerStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [TestCase(ShippingStatus.Delivered, Kind.Success)]
    [TestCase(ShippingStatus.ReadyForShipping, Kind.Positive)]
    [TestCase(ShippingStatus.LabelCreated, Kind.Positive)]
    [TestCase(ShippingStatus.Shipped, Kind.Info)]
    [TestCase(ShippingStatus.InTransit, Kind.Info)]
    [TestCase(ShippingStatus.OutForDelivery, Kind.Info)]
    [TestCase(ShippingStatus.InProgess, Kind.Warning)]
    [TestCase(ShippingStatus.DeliveryFailed, Kind.Danger)]
    [TestCase(ShippingStatus.ReturnedToSender, Kind.Danger)]
    [TestCase(ShippingStatus.Lost, Kind.Danger)]
    [TestCase(ShippingStatus.Cancelled, Kind.Neutral)]
    [TestCase(ShippingStatus.Open, Kind.Neutral)]
    public void ShippingStatus_MapsToExpectedKind(ShippingStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [TestCase(ShippingOutboxStatus.Done, Kind.Success)]
    [TestCase(ShippingOutboxStatus.Pending, Kind.Warning)]
    [TestCase(ShippingOutboxStatus.InFlight, Kind.Warning)]
    [TestCase(ShippingOutboxStatus.DeadLetter, Kind.Danger)]
    public void ShippingOutboxStatus_MapsToExpectedKind(ShippingOutboxStatus status, Kind expected)
    {
        var (_, kind) = StatusVisuals.Resolve(status);
        Assert.That(kind, Is.EqualTo(expected));
    }

    [Test]
    public void BoolSyncFlag_MapsToSuccessOrNeutral()
    {
        Assert.That(StatusVisuals.Resolve(true).Kind, Is.EqualTo(Kind.Success));
        Assert.That(StatusVisuals.Resolve(false).Kind, Is.EqualTo(Kind.Neutral));
    }

    [Test]
    public void Null_ReturnsEmptyNeutral()
    {
        var (text, kind) = StatusVisuals.Resolve(null);
        Assert.That(text, Is.Empty);
        Assert.That(kind, Is.EqualTo(Kind.Neutral));
    }

    [Test]
    public void FallbackText_HumanizesPascalCase()
    {
        var (text, _) = StatusVisuals.Resolve(SalesStatus.ReadyForDelivery);
        Assert.That(text, Is.EqualTo("Ready For Delivery"));
    }
}
