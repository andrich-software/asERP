using asERP.Client.Features.Shippings.Models;
using asERP.Domain.Enums;
using Microsoft.UI.Xaml;

namespace asERP.Client.Tests;

/// <summary>Verifies the x:Bind helper functions used by the tracking-timeline templates.</summary>
public class ShippingTimelineVisualsTests
{
    [Test]
    public void BadgeStatus_KnownEnumName_ReturnsParsedEnum()
    {
        Assert.That(ShippingTimelineVisuals.BadgeStatus("Delivered"), Is.EqualTo(ShippingStatus.Delivered));
        Assert.That(ShippingTimelineVisuals.BadgeStatus("InTransit"), Is.EqualTo(ShippingStatus.InTransit));
    }

    [Test]
    public void BadgeStatus_UnknownName_ReturnsRawString()
    {
        Assert.That(ShippingTimelineVisuals.BadgeStatus("CarrierSpecificState"), Is.EqualTo("CarrierSpecificState"));
    }

    [Test]
    public void BadgeStatus_Null_ReturnsNull()
    {
        Assert.That(ShippingTimelineVisuals.BadgeStatus(null), Is.Null);
    }

    [TestCase(null, Visibility.Collapsed)]
    [TestCase("", Visibility.Collapsed)]
    [TestCase("   ", Visibility.Collapsed)]
    [TestCase("Delivered", Visibility.Visible)]
    public void HasStatus_BlankValuesAreCollapsed(string? status, Visibility expected)
    {
        Assert.That(ShippingTimelineVisuals.HasStatus(status), Is.EqualTo(expected));
    }

    [Test]
    public void EntryOpacity_DimsSystemGeneratedEntries()
    {
        Assert.That(ShippingTimelineVisuals.EntryOpacity(true), Is.EqualTo(0.6));
        Assert.That(ShippingTimelineVisuals.EntryOpacity(false), Is.EqualTo(1.0));
    }

    [Test]
    public void FormatTimestamp_UsesLocalGeneralFormat()
    {
        var utc = new DateTime(2026, 7, 4, 12, 0, 0, DateTimeKind.Utc);

        Assert.That(ShippingTimelineVisuals.FormatTimestamp(utc), Is.EqualTo(utc.ToLocalTime().ToString("g")));
    }
}
