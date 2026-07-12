using asERP.Client.Core.Helpers;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="ClientVersionGate"/> — the rule that decides whether a server's
/// minimum-client-version requirement blocks login (LoginOverlay update banner). The rule runs
/// identically on every head (Desktop, WASM, Android): unstamped dev builds (Stamped == null)
/// and unparsable/missing server minimums must never block.
/// </summary>
public class ClientVersionGateTests
{
    [TestCase(null, "2026.1.1", ExpectedResult = false, TestName = "Unstamped dev build is never blocked")]
    [TestCase("2026.1.1", null, ExpectedResult = false, TestName = "Server without minimum does not block")]
    [TestCase("2026.1.1", "", ExpectedResult = false, TestName = "Empty minimum does not block")]
    [TestCase("2026.1.1", "   ", ExpectedResult = false, TestName = "Whitespace minimum does not block")]
    [TestCase("2026.1.1", "not-a-version", ExpectedResult = false, TestName = "Unparsable minimum does not block")]
    [TestCase("2026.1.1", "2026.1.1", ExpectedResult = false, TestName = "Exactly the minimum is allowed")]
    [TestCase("2026.2.1", "2026.1.1", ExpectedResult = false, TestName = "Newer client is allowed")]
    [TestCase("2026.1.1", "2026.1.2", ExpectedResult = true, TestName = "Older client is blocked")]
    [TestCase("2025.12.31.99", "2026.1.1", ExpectedResult = true, TestName = "Older year is blocked despite higher run number")]
    [TestCase("2026.7.1.123", "2026.07.01", ExpectedResult = false, TestName = "Leading zeros in the minimum parse to the same version")]
    // System.Version treats a missing component as -1, so a 3-part client version is
    // below the same version written with an explicit ".0" — servers should therefore
    // configure 3-part minimums matching the CI stamp scheme (YYYY.MM.DD.run has 4 parts).
    [TestCase("2026.1.1", "2026.1.1.0", ExpectedResult = true, TestName = "Three-part client is below four-part minimum with zero revision")]
    public bool IsUpdateRequired(string? current, string? minimum) =>
        ClientVersionGate.IsUpdateRequired(current is null ? null : Version.Parse(current), minimum);
}
