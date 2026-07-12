using System.Diagnostics;

namespace asERP.Client.Core.Helpers;

/// <summary>
/// The running client's build version. CI stamps release builds with the YYYY.MM.DD.run scheme
/// via -p:Version; dev builds carry 1.0.* and count as unstamped. <see cref="Stamped"/> is null
/// for those, which switches off all version gating (X-Client-Version header and the login
/// overlay's minimum-version check) — dev builds must never be blocked by a server's minimum.
/// </summary>
public static class ClientVersionInfo
{
    /// <summary>Versions below this major are dev/unstamped builds (the scheme is year-based).</summary>
    private const int MinimumStampedMajor = 2000;

    public static Version? Stamped { get; } = Compute();

    private static Version? Compute()
    {
        try
        {
            if (!OperatingSystem.IsBrowser() && Environment.ProcessPath is { } processPath)
            {
                var fileVersion = FileVersionInfo.GetVersionInfo(processPath).FileVersion;
                if (Version.TryParse(fileVersion, out var fromFile) && fromFile.Major >= MinimumStampedMajor)
                {
                    return fromFile;
                }
            }
        }
        catch
        {
            // FileVersionInfo is unavailable on some heads — fall through to the assembly version.
        }

        var assemblyVersion = typeof(ClientVersionInfo).Assembly.GetName().Version;
        return assemblyVersion is not null && assemblyVersion.Major >= MinimumStampedMajor
            ? assemblyVersion
            : null;
    }
}
