using System.Globalization;

namespace asERP.Client.Presentation;

/// <summary>
/// Renders a sales-history entry in the current UI language.
///
/// The server stores a resource key plus arguments instead of display text (see
/// <c>asERP.Domain.Entities.SalesHistoryMessage</c>). Each argument is itself resolved as a
/// resource key with the literal value as fallback, so enum tokens like "SalesStatus.Processing"
/// localize while free text (a channel or carrier name) passes through untouched.
///
/// Entries written before localization carry no key — those fall back to the English
/// audit description, as does an entry whose key has no resource in this language.
/// </summary>
public static class HistoryMessageFormatter
{
    public static string Format(string? messageKey, IReadOnlyList<string>? args, string fallback)
    {
        if (string.IsNullOrEmpty(messageKey))
        {
            return fallback;
        }

        var format = LocalizationHelper.GetLocalizedString(messageKey, fallback);
        if (args is not { Count: > 0 })
        {
            return format;
        }

        var localizedArgs = new object[args.Count];
        for (var i = 0; i < args.Count; i++)
        {
            localizedArgs[i] = LocalizationHelper.GetLocalizedString(args[i], args[i]);
        }

        try
        {
            return string.Format(CultureInfo.CurrentCulture, format, localizedArgs);
        }
        catch (FormatException)
        {
            // Placeholder count drifted from the argument list, or the fallback description
            // contains stray braces — the audit text is always safe to show.
            return fallback;
        }
    }
}
