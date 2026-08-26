namespace asERP.Domain.Constants;

/// <summary>
/// Keys of machine-managed rows in the global <c>Setting</c> table that are read or written
/// from more than one layer. Feature-local keys stay as literals next to their feature.
/// </summary>
public static class SettingKeys
{
    /// <summary>
    /// "True" once the initial server setup (first Superadmin + first tenant) has been
    /// completed. Gates the anonymous <c>/api/v1/setup</c> endpoint and is exposed to
    /// clients as <c>SetupRequired</c> via <c>/api/v1/server-info</c>. Maintained by
    /// <c>SettingsInitializer</c>, the setup handler and the superadmin CLI.
    /// </summary>
    public const string SetupCompleted = "System.SetupCompleted";
}
