using System.Globalization;

namespace asERP.Client.Core.Formatting;

/// <summary>
/// Formats monetary values as currency.
/// <para>
/// Works around a WASM/ICU gap: in the browser-WASM runtime the number formatting
/// data (decimal/grouping separators) is present, but the currency-symbol data is
/// often missing, so <c>ToString("C")</c> falls back to the generic currency
/// placeholder "¤" (U+00A4) instead of "€". This helper detects that placeholder
/// and substitutes the Euro symbol while preserving the active culture's number
/// formatting (separators and symbol position).
/// </para>
/// </summary>
public static class CurrencyFormatter
{
    /// <summary>The generic currency sign .NET emits when no currency symbol is available.</summary>
    private const string GenericCurrencySign = "¤";

    private const string EuroSign = "€";

    /// <summary>
    /// Formats <paramref name="value"/> as currency with the given number of decimals,
    /// guaranteeing the Euro symbol is shown even when ICU currency data is unavailable.
    /// </summary>
    public static string Format(decimal value, int decimals = 2)
        => value.ToString("C" + decimals, GetFormat());

    public static string Format(double value, int decimals = 2)
        => value.ToString("C" + decimals, GetFormat());

    public static string Format(int value, int decimals = 2)
        => value.ToString("C" + decimals, GetFormat());

    private static NumberFormatInfo GetFormat()
    {
        var format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        if (string.IsNullOrEmpty(format.CurrencySymbol) || format.CurrencySymbol == GenericCurrencySign)
        {
            format.CurrencySymbol = EuroSign;
        }

        return format;
    }
}
