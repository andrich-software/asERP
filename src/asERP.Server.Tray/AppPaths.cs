using Microsoft.Win32;

namespace asERP.Server.Tray;

/// <summary>
/// Well-known paths of an installed asERP server. Data lives in %ProgramData%\asERP
/// (created by the installer with Users-Modify ACLs); binaries live under
/// {ProgramFiles}\asERP Server\Server next to this tray app's ..\Tray folder.
/// </summary>
internal static class AppPaths
{
    public const string ServiceName = "asERPServer";

    public static string DataDirectory { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "asERP");

    public static string SettingsFile => Path.Combine(DataDirectory, "settings.json");
    public static string LogsDirectory => Path.Combine(DataDirectory, "logs");
    public static string BackupsDirectory => Path.Combine(DataDirectory, "backups");

    public static string ServerExePath { get; } = ResolveServerExePath();

    private static string ResolveServerExePath()
    {
        // Standard install layout: {app}\Tray\asERP.Server.Tray.exe, {app}\Server\asERP.Server.exe.
        var siblingPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "Server", "asERP.Server.exe"));
        if (File.Exists(siblingPath))
        {
            return siblingPath;
        }

        // Fallback for non-standard layouts: the installer records its target directory.
        if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\asERP", "InstallDir", null) is string installDir
            && !string.IsNullOrWhiteSpace(installDir))
        {
            var registryPath = Path.Combine(installDir, "Server", "asERP.Server.exe");
            if (File.Exists(registryPath))
            {
                return registryPath;
            }
        }

        return siblingPath;
    }
}
