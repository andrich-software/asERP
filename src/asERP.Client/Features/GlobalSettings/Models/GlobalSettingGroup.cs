namespace asERP.Client.Features.GlobalSettings.Models;

/// <summary>One card on a settings tab: all Setting rows sharing a key prefix (e.g. "Email").</summary>
public class GlobalSettingGroup
{
    public GlobalSettingGroup(string title, IReadOnlyList<GlobalSettingEntry> entries)
    {
        Title = title;
        Entries = entries;
    }

    public string Title { get; }
    public IReadOnlyList<GlobalSettingEntry> Entries { get; }
}
