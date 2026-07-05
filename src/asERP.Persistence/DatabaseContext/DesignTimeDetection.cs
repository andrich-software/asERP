using System.Reflection;

namespace asERP.Persistence.DatabaseContext;

/// <summary>
/// Best-effort detection of an EF Core design-time context (running under <c>dotnet ef</c> /
/// migrations tooling) versus a live application host. Used to decide whether a no-op credential
/// encryptor fallback is acceptable (design-time) or must be flagged loudly (runtime).
/// </summary>
internal static class DesignTimeDetection
{
    public static bool IsDesignTime { get; } = DetectDesignTime();

    private static bool DetectDesignTime()
    {
        // EF's design-time tooling loads the app through the `ef` / `dotnet-ef` host process; the
        // entry assembly then is the tooling, not the application. It also loads the design assembly.
        var entryAssembly = Assembly.GetEntryAssembly()?.GetName().Name;
        if (entryAssembly is not null &&
            (entryAssembly.Equals("ef", StringComparison.OrdinalIgnoreCase) ||
             entryAssembly.StartsWith("dotnet-ef", StringComparison.OrdinalIgnoreCase)))
        {
            return true;
        }

        return AppDomain.CurrentDomain.GetAssemblies()
            .Any(a => a.GetName().Name?.StartsWith("Microsoft.EntityFrameworkCore.Design", StringComparison.OrdinalIgnoreCase) == true);
    }
}
