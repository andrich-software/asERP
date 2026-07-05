using asERP.Client.Features.Shippings.Models;
using Microsoft.UI.Xaml;

namespace asERP.Client.Tests;

/// <summary>Verifies the x:Bind helper functions used by the shipping list row templates.</summary>
public class ShippingRowVisualsTests
{
    [Test]
    public void ProblemVisibility_VisibleOnlyForProblems()
    {
        Assert.That(ShippingRowVisuals.ProblemVisibility(true), Is.EqualTo(Visibility.Visible));
        Assert.That(ShippingRowVisuals.ProblemVisibility(false), Is.EqualTo(Visibility.Collapsed));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void HasText_BlankValues_AreCollapsed(string? value)
    {
        Assert.That(ShippingRowVisuals.HasText(value), Is.EqualTo(Visibility.Collapsed));
        Assert.That(ShippingRowVisuals.NoText(value), Is.EqualTo(Visibility.Visible));
    }

    [Test]
    public void HasText_NonBlankValue_IsVisible()
    {
        Assert.That(ShippingRowVisuals.HasText("1Z999"), Is.EqualTo(Visibility.Visible));
        Assert.That(ShippingRowVisuals.NoText("1Z999"), Is.EqualTo(Visibility.Collapsed));
    }

    [Test]
    public void FormatDate_Null_ReturnsEmpty()
    {
        Assert.That(ShippingRowVisuals.FormatDate(null), Is.Empty);
        Assert.That(ShippingRowVisuals.FormatDateTime(null), Is.Empty);
    }

    [Test]
    public void FormatDate_Value_UsesLocalShortDate()
    {
        var utc = new DateTime(2026, 7, 4, 12, 0, 0, DateTimeKind.Utc);

        Assert.That(ShippingRowVisuals.FormatDate(utc), Is.EqualTo(utc.ToLocalTime().ToString("d")));
        Assert.That(ShippingRowVisuals.FormatDateTime(utc), Is.EqualTo(utc.ToLocalTime().ToString("g")));
    }
}
