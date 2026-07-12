using asERP.Client.Features.SalesChannels.Models;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for the WooCommerceDatabase connector-config JSON on <see cref="SalesChannelEditModel"/>:
/// <c>BuildDatabaseConfigJson</c> (form → AdditionalConfigJson) and <c>TryParseDatabaseConfig</c>
/// (stored JSON → form fields). The JSON shape is connector-owned — the WooCommerce database
/// connector on the Server reads the same keys, so the field names are part of the contract.
/// </summary>
public class SalesChannelDatabaseConfigTests
{
    [Test]
    public void BuildDatabaseConfigJson_TrimsValuesAndParsesPort()
    {
        var json = SalesChannelEditModel.BuildDatabaseConfigJson(
            "  db.example.org  ", "3307", " wordpress ", " wp2_ ");

        Assert.That(json, Is.EqualTo(
            """{"host":"db.example.org","port":3307,"database":"wordpress","tablePrefix":"wp2_"}"""));
    }

    [TestCase("")]
    [TestCase("   ")]
    [TestCase("abc")]
    public void BuildDatabaseConfigJson_UnparsablePort_FallsBackToDefault(string port)
    {
        var json = SalesChannelEditModel.BuildDatabaseConfigJson("db", port, "wp", "wp_");

        Assert.That(json, Does.Contain("\"port\":3306"));
    }

    [TestCase("")]
    [TestCase("   ")]
    public void BuildDatabaseConfigJson_EmptyTablePrefix_FallsBackToDefault(string prefix)
    {
        var json = SalesChannelEditModel.BuildDatabaseConfigJson("db", "3306", "wp", prefix);

        Assert.That(json, Does.Contain("\"tablePrefix\":\"wp_\""));
    }

    [Test]
    public void TryParseDatabaseConfig_RoundTripsBuiltJson()
    {
        var json = SalesChannelEditModel.BuildDatabaseConfigJson("db.example.org", "3307", "wordpress", "wp2_");

        var config = SalesChannelEditModel.TryParseDatabaseConfig(json);

        Assert.That(config, Is.EqualTo(("db.example.org", "3307", "wordpress", "wp2_")));
    }

    [Test]
    public void TryParseDatabaseConfig_MissingKeys_FallBackToDefaults()
    {
        var config = SalesChannelEditModel.TryParseDatabaseConfig("{}");

        Assert.That(config, Is.EqualTo((string.Empty, "3306", string.Empty, "wp_")));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase("not json")]
    [TestCase("[1,2,3]")]
    public void TryParseDatabaseConfig_EmptyOrMalformed_ReturnsNull(string? json)
    {
        Assert.That(SalesChannelEditModel.TryParseDatabaseConfig(json), Is.Null);
    }
}
