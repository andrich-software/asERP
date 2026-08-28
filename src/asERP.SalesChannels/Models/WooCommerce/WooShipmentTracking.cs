using System.Text.Json;

namespace asERP.SalesChannels.Models.WooCommerce;

/// <summary>
/// Shared rules for reading and writing WooCommerce tracking numbers, used by both the REST and the
/// direct-MySQL connector so a channel behaves identically whichever transport it is configured for.
/// <para>
/// WooCommerce core has no shipment entity — tracking numbers live in order meta written by a
/// shipping plugin. The key differs per plugin, so it is configurable per channel via
/// <c>shipmentTrackingMetaKey</c> in <c>AdditionalConfigJson</c>; the default is the key German
/// Market writes.
/// </para>
/// </summary>
public static class WooShipmentTracking
{
    /// <summary>Order meta key German Market writes the shipment numbers to.</summary>
    public const string DefaultMetaKey = "_order_shipment_numbers";

    private const string MetaKeyConfigProperty = "shipmentTrackingMetaKey";

    /// <summary>Separator used when writing several parcels of one order back to the shop.</summary>
    private const string JoinSeparator = ", ";

    private static readonly char[] Separators = [',', ';', '|', '\n', '\r'];

    /// <summary>
    /// Order meta key configured for the channel, falling back to <see cref="DefaultMetaKey"/>.
    /// A malformed config never fails the run — it falls back like a missing one.
    /// </summary>
    public static string ResolveMetaKey(string? additionalConfigJson)
    {
        if (string.IsNullOrWhiteSpace(additionalConfigJson))
        {
            return DefaultMetaKey;
        }

        try
        {
            using var document = JsonDocument.Parse(additionalConfigJson);
            if (document.RootElement.ValueKind == JsonValueKind.Object
                && document.RootElement.TryGetProperty(MetaKeyConfigProperty, out var value)
                && value.ValueKind == JsonValueKind.String)
            {
                var key = value.GetString();
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return key.Trim();
                }
            }
        }
        catch (JsonException)
        {
            // Connector config is operator-editable free text; fall back rather than fail the run.
        }

        return DefaultMetaKey;
    }

    /// <summary>
    /// Splits a stored meta value into individual tracking numbers. Only the plain delimited format
    /// is understood — a PHP-serialized value (what some tracking plugins store) yields nothing
    /// instead of a guess, because pulling strings out of such a blob would just as happily return
    /// provider names and dates as tracking numbers.
    /// </summary>
    public static IReadOnlyList<string> ParseNumbers(string? metaValue)
    {
        if (string.IsNullOrWhiteSpace(metaValue) || IsPhpSerialized(metaValue))
        {
            return [];
        }

        return metaValue
            .Split(Separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Distinct(StringComparer.Ordinal)
            .ToList();
    }

    /// <summary>Renders the tracking numbers of one order into a single meta value.</summary>
    public static string FormatNumbers(IEnumerable<string> trackingNumbers)
        => string.Join(JoinSeparator, trackingNumbers
            .Where(n => !string.IsNullOrWhiteSpace(n))
            .Select(n => n.Trim())
            .Distinct(StringComparer.Ordinal));

    /// <summary>
    /// True for a PHP <c>serialize()</c> payload (<c>a:2:{...}</c>, <c>s:12:"..."</c>, ...) — the
    /// format the WooCommerce Shipment Tracking family of plugins uses.
    /// </summary>
    public static bool IsPhpSerialized(string value)
    {
        var trimmed = value.TrimStart();
        return trimmed.StartsWith("a:", StringComparison.Ordinal)
               || trimmed.StartsWith("O:", StringComparison.Ordinal)
               || trimmed.StartsWith("s:", StringComparison.Ordinal);
    }
}
