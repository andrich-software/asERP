using System.Globalization;
using System.Text;

namespace asERP.Domain.Services;

/// <summary>
/// Pure helper that derives a URL-safe slug from a category name (used when the user leaves the
/// slug empty). German umlauts are transliterated the way shop systems expect (ä → ae, ...).
/// </summary>
public static class CategorySlugGenerator
{
    public static string Generate(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }

        var lowered = name.Trim().ToLowerInvariant()
            .Replace("ä", "ae")
            .Replace("ö", "oe")
            .Replace("ü", "ue")
            .Replace("ß", "ss");

        // Strip remaining diacritics (é → e, ...) via canonical decomposition.
        var normalized = lowered.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(normalized.Length);
        var lastWasDash = true; // suppress leading dashes

        foreach (var ch in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) == UnicodeCategory.NonSpacingMark)
            {
                continue;
            }

            if (ch is >= 'a' and <= 'z' or >= '0' and <= '9')
            {
                builder.Append(ch);
                lastWasDash = false;
            }
            else if (!lastWasDash)
            {
                builder.Append('-');
                lastWasDash = true;
            }
        }

        return builder.ToString().TrimEnd('-');
    }
}
