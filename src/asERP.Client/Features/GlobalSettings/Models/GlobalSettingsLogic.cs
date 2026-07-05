using asERP.Domain.Dtos.GlobalSettings;

namespace asERP.Client.Features.GlobalSettings.Models;

/// <summary>
/// UI-free grouping and save-payload rules behind <see cref="GlobalSettingsModel"/>, kept
/// static so they are unit-testable (same pattern as ShipmentDraftLogic).
/// </summary>
public static class GlobalSettingsLogic
{
    public enum Tab { General, Email, Authentication, Observability }

    /// <summary>Key prefix → tab. Prefixes not listed here land on the "General" tab.</summary>
    private static readonly Dictionary<string, Tab> TabByPrefix = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Email"] = Tab.Email,
        ["Jwt"] = Tab.Authentication,
        ["Telemetry"] = Tab.Observability,
        ["Grafana"] = Tab.Observability,
        ["ClickHouse"] = Tab.Observability,
    };

    /// <summary>Fixed group order on the "General" tab; unknown prefixes follow alphabetically.</summary>
    private static readonly string[] GeneralGroupOrder = ["Company", "System", "Invoice", "Sales", "Notification"];

    public static string GroupPrefix(string key)
    {
        var separator = key.IndexOf('.');
        return separator > 0 ? key[..separator] : key;
    }

    public static Tab ResolveTab(string prefix) =>
        TabByPrefix.TryGetValue(prefix, out var tab) ? tab : Tab.General;

    public static int GeneralOrderIndex(string prefix)
    {
        var index = Array.FindIndex(GeneralGroupOrder,
            p => p.Equals(prefix, StringComparison.OrdinalIgnoreCase));
        return index >= 0 ? index : GeneralGroupOrder.Length;
    }

    /// <summary>
    /// Groups the flat Setting rows into per-tab card lists: one group per key prefix, entries
    /// sorted by key. The "General" tab uses <see cref="GeneralGroupOrder"/>, all other tabs
    /// sort groups alphabetically.
    /// </summary>
    public static IReadOnlyDictionary<Tab, IReadOnlyList<GlobalSettingGroup>> BuildTabGroups(
        IEnumerable<GlobalSettingDto> settings,
        Func<string, string> resolveGroupTitle)
    {
        var groups = settings
            .GroupBy(s => GroupPrefix(s.Key), StringComparer.OrdinalIgnoreCase)
            .Select(g => new
            {
                Prefix = g.Key,
                Group = new GlobalSettingGroup(
                    resolveGroupTitle(g.Key),
                    g.OrderBy(s => s.Key, StringComparer.OrdinalIgnoreCase)
                        .Select(s => new GlobalSettingEntry(s.Key, s.Value, s.IsSecret, s.HasValue))
                        .ToList()),
            })
            .ToList();

        var result = new Dictionary<Tab, IReadOnlyList<GlobalSettingGroup>>
        {
            [Tab.General] = groups
                .Where(g => ResolveTab(g.Prefix) == Tab.General)
                .OrderBy(g => GeneralOrderIndex(g.Prefix))
                .ThenBy(g => g.Prefix, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Group)
                .ToList(),
        };

        foreach (var tab in new[] { Tab.Email, Tab.Authentication, Tab.Observability })
        {
            result[tab] = groups
                .Where(g => ResolveTab(g.Prefix) == tab)
                .OrderBy(g => g.Prefix, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Group)
                .ToList();
        }

        return result;
    }

    /// <summary>
    /// Builds the bulk write payload. Secrets are write-only: an empty field means "keep the
    /// stored value", so the row is not sent at all. Non-secrets are sent as-is; the server
    /// skips unchanged values.
    /// </summary>
    public static GlobalSettingsUpdateInputDto BuildUpdateInput(IEnumerable<GlobalSettingGroup> groups)
    {
        var input = new GlobalSettingsUpdateInputDto();
        foreach (var entry in groups.SelectMany(g => g.Entries))
        {
            if (entry.IsSecret && entry.Value.Length == 0)
            {
                continue;
            }
            input.Settings.Add(new GlobalSettingValueInputDto { Key = entry.Key, Value = entry.Value });
        }
        return input;
    }
}
