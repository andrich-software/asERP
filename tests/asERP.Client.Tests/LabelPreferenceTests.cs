using asERP.Client.Features.Shippings.Services;

namespace asERP.Client.Tests;

public class LabelPreferenceTests
{
    [Test]
    public void SerializeAndParse_RoundTripsPrintWithPrinter()
    {
        var pref = new LabelActionPreference(LabelAction.Print, "HP LaserJet Pro M404");

        var parsed = LabelActionPreference.TryParse(pref.Serialize());

        Assert.That(parsed, Is.EqualTo(pref));
    }

    [Test]
    public void SerializeAndParse_RoundTripsSaveWithoutPrinter()
    {
        var pref = new LabelActionPreference(LabelAction.Save, null);

        var parsed = LabelActionPreference.TryParse(pref.Serialize());

        Assert.That(parsed, Is.EqualTo(pref));
    }

    [Test]
    public void TryParse_PrinterNameWithSeparator_KeepsFullName()
    {
        var parsed = LabelActionPreference.TryParse("Print|Etiketten|Lager 2");

        Assert.That(parsed, Is.Not.Null);
        Assert.That(parsed!.PrinterName, Is.EqualTo("Etiketten|Lager 2"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("garbage")]
    [TestCase("NotAnAction|printer")]
    public void TryParse_InvalidInput_ReturnsNull(string? value)
    {
        Assert.That(LabelActionPreference.TryParse(value), Is.Null);
    }
}
