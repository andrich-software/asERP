namespace asERP.Client.UITests;

/// <summary>
/// Test-target configuration. The WASM head under test is served externally — locally via
/// <c>dotnet run -f net10.0-browserwasm</c> (or <c>dotnet serve</c> on a publish output), in CI
/// by the <c>aserp-client-uitest.yml</c> workflow. Override the defaults via environment variables.
/// </summary>
public static class Constants
{
    /// <summary>Where the WASM head is served; defaults to the dev port from launchSettings.json.</summary>
    public static readonly string TargetUri =
        Environment.GetEnvironmentVariable("ASERP_UITEST_TARGET_URI") ?? "http://localhost:5001";

    /// <summary>Set <c>ASERP_UITEST_HEADED=1</c> to watch the browser locally.</summary>
    public static readonly bool Headless =
        Environment.GetEnvironmentVariable("ASERP_UITEST_HEADED") != "1";

    /// <summary>
    /// The first load downloads and starts the .NET WASM runtime — allow a generous
    /// cold-start budget (slow CI runners) before declaring the app dead.
    /// </summary>
    public const float BootTimeoutMs = 180_000;
}
