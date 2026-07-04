using System.Text.RegularExpressions;

namespace asERP.SalesChannels.Models.WooCommerceDatabase;

/// <summary>
/// One attribute definition from a variable product's <c>_product_attributes</c> postmeta.
/// <paramref name="Key"/> is the sanitized array key WordPress uses (matches the suffix of the
/// variation's <c>attribute_{key}</c> meta), <paramref name="Name"/> the raw name field
/// (taxonomy slug like <c>pa_farbe</c>, or the display name for custom attributes).
/// </summary>
internal sealed record WooProductAttribute(string Key, string Name, int Position, bool IsVariation);

/// <summary>
/// Tolerant extractor for the PHP-serialized <c>_product_attributes</c> postmeta of a WooCommerce
/// product. A full PHP unserializer is overkill for this one flat structure: the meta is an array of
/// arrays whose values are all scalars, so each attribute block contains no nested braces and can be
/// matched with a regex. Anything that does not match is simply skipped — callers fall back to
/// deriving the variation axes from the variations' own <c>attribute_*</c> metas.
/// </summary>
internal static partial class WooProductAttributesParser
{
    // Matches one `"key" => array(...)` entry; the inner array holds only scalars, so its body
    // is brace-free and the lazy [^{}]* cannot overrun into a sibling entry.
    [GeneratedRegex("""s:\d+:"(?<key>[^"]*)";a:\d+:\{(?<body>[^{}]*)\}""")]
    private static partial Regex AttributeBlockRegex();

    [GeneratedRegex("""s:4:"name";s:\d+:"(?<name>[^"]*)";""")]
    private static partial Regex NameRegex();

    [GeneratedRegex("""s:8:"position";(?:i:(?<pos>-?\d+)|s:\d+:"(?<posStr>-?\d+)");""")]
    private static partial Regex PositionRegex();

    [GeneratedRegex("""s:12:"is_variation";(?:i:(?<val>\d+)|b:(?<bool>[01]))""")]
    private static partial Regex IsVariationRegex();

    public static IReadOnlyList<WooProductAttribute> Parse(string? serialized)
    {
        if (string.IsNullOrWhiteSpace(serialized))
        {
            return [];
        }

        var result = new List<WooProductAttribute>();
        foreach (Match block in AttributeBlockRegex().Matches(serialized))
        {
            var key = block.Groups["key"].Value;
            var body = block.Groups["body"].Value;
            if (string.IsNullOrEmpty(key))
            {
                continue;
            }

            var nameMatch = NameRegex().Match(body);
            var posMatch = PositionRegex().Match(body);
            var isVarMatch = IsVariationRegex().Match(body);

            var position = 0;
            if (posMatch.Success)
            {
                var raw = posMatch.Groups["pos"].Success ? posMatch.Groups["pos"].Value : posMatch.Groups["posStr"].Value;
                _ = int.TryParse(raw, out position);
            }

            var isVariation = isVarMatch.Success &&
                (isVarMatch.Groups["val"].Value == "1" || isVarMatch.Groups["bool"].Value == "1");

            result.Add(new WooProductAttribute(
                Key: key,
                Name: nameMatch.Success && nameMatch.Groups["name"].Value.Length > 0 ? nameMatch.Groups["name"].Value : key,
                Position: position,
                IsVariation: isVariation));
        }

        return result;
    }
}
