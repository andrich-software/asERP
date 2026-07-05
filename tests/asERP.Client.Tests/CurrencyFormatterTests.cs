using System.Globalization;
using asERP.Client.Core.Formatting;

namespace asERP.Client.Tests;

/// <summary>
/// Verifies the WASM/ICU workaround: when the active culture has no currency symbol
/// (generic "¤" placeholder), the Euro sign is substituted while the culture's number
/// formatting is preserved.
/// </summary>
public class CurrencyFormatterTests
{
    private CultureInfo _originalCulture = CultureInfo.CurrentCulture;

    [SetUp]
    public void RememberCulture() => _originalCulture = CultureInfo.CurrentCulture;

    [TearDown]
    public void RestoreCulture() => CultureInfo.CurrentCulture = _originalCulture;

    [Test]
    public void Format_GenericCurrencySign_IsReplacedByEuro()
    {
        // Invariant culture uses the generic "¤" placeholder — the WASM failure mode.
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        var result = CurrencyFormatter.Format(1234.5m);

        Assert.That(result, Does.Contain("€"));
        Assert.That(result, Does.Not.Contain("¤"));
        Assert.That(result, Does.Contain("1,234.50"));
    }

    [Test]
    public void Format_CultureWithCurrencySymbol_KeepsItsSymbolAndSeparators()
    {
        CultureInfo.CurrentCulture = new CultureInfo("de-DE");

        var result = CurrencyFormatter.Format(1234.5m);

        Assert.That(result, Does.Contain("€"));
        Assert.That(result, Does.Contain("1.234,50"));
    }

    [Test]
    public void Format_RespectsDecimalsParameter()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Assert.That(CurrencyFormatter.Format(9.876m, 0), Does.Contain("10"));
        Assert.That(CurrencyFormatter.Format(9.876m, 3), Does.Contain("9.876"));
    }

    [Test]
    public void Format_DoubleAndIntOverloads_MatchDecimalBehavior()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Assert.That(CurrencyFormatter.Format(2.5), Does.Contain("2.50"));
        Assert.That(CurrencyFormatter.Format(2), Does.Contain("2.00"));
    }
}
