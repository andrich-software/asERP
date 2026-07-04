namespace asToolkit.Domain.Dtos.GlobalSettings;

/// <summary>
/// Read projection of one global <c>Setting</c> row for the Superadmin settings page.
/// Secret rows (encrypted or known-credential keys) never return their value —
/// <see cref="HasValue"/> reports presence only.
/// </summary>
public class GlobalSettingDto
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public bool IsSecret { get; set; }
    public bool HasValue { get; set; }
}

/// <summary>
/// One key/value pair of the bulk write payload. <c>Value</c> semantics: <c>null</c> = keep the
/// stored value; for secret keys an empty string also keeps it (the UI never sees the secret,
/// so an empty field means "not rotated").
/// </summary>
public class GlobalSettingValueInputDto
{
    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
}

/// <summary>Bulk write payload for the Superadmin global-settings endpoint.</summary>
public class GlobalSettingsUpdateInputDto
{
    public List<GlobalSettingValueInputDto> Settings { get; set; } = [];
}
