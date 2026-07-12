namespace asERP.Client.Core.Helpers;

/// <summary>
/// Decides whether a server's minimum-client-version requirement blocks this client
/// (login overlay update banner, see <c>LoginOverlay.ApplyServerCompatibility</c>).
/// Unstamped builds (dev — <see cref="ClientVersionInfo.Stamped"/> is null) are never
/// blocked client-side, and a missing or unparsable server minimum never blocks either.
/// </summary>
public static class ClientVersionGate
{
    public static bool IsUpdateRequired(Version? current, string? minimumClientVersion) =>
        current is not null
        && Version.TryParse(minimumClientVersion, out var minimum)
        && current < minimum;
}
