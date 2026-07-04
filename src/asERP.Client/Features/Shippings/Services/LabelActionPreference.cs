namespace asERP.Client.Features.Shippings.Services;

public enum LabelAction
{
    Save,
    Download,
    Print,
}

/// <summary>Remembered post-label action ("Aktion merken"), persisted as "Action|PrinterName".</summary>
public sealed record LabelActionPreference(LabelAction Action, string? PrinterName)
{
    public string Serialize() => $"{Action}|{PrinterName}";

    public static LabelActionPreference? TryParse(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        // Printer names may contain '|' themselves — split on the first separator only.
        var separatorIndex = value.IndexOf('|');
        if (separatorIndex < 0)
        {
            return null;
        }

        if (!Enum.TryParse<LabelAction>(value[..separatorIndex], out var action))
        {
            return null;
        }

        var printer = value[(separatorIndex + 1)..];
        return new LabelActionPreference(action, printer.Length == 0 ? null : printer);
    }
}
