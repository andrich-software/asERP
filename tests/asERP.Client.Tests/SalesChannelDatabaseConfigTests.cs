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

    private static System.Text.Json.Nodes.JsonObject Parse(string json)
        => (System.Text.Json.Nodes.JsonObject)System.Text.Json.Nodes.JsonNode.Parse(json)!;

    [Test]
    public void BuildDatabaseConfigJson_KeepsTheKeysThisFormDoesNotOwn()
    {
        // The blob is connector-owned and holds settings no field on this form shows. Rebuilding it
        // from the four MySQL values dropped them, so an ordinary save silently reverted them.
        var stored = Build("{ *host*: *old*, *port*: 1, *database*: *old*, *tablePrefix*: *old_*, "
            + "*shipmentTrackingMetaKey*: *_my_key*, *somethingElse*: { *nested*: true } }");

        var json = SalesChannelEditModel.BuildDatabaseConfigJson("db", "3306", "wp", "wp_", stored);
        var config = Parse(json);

        Assert.That(config["shipmentTrackingMetaKey"]!.ToString(), Is.EqualTo("_my_key"));
        Assert.That(config["somethingElse"]!["nested"]!.GetValue<bool>(), Is.True);
    }

    [Test]
    public void BuildDatabaseConfigJson_OverwritesTheFourFieldsItDoesOwn()
    {
        var stored = MakeStored();

        var json = SalesChannelEditModel.BuildDatabaseConfigJson(
            " new.example.org ", "3307", " newdb ", " new_ ", stored);

        var parsed = SalesChannelEditModel.TryParseDatabaseConfig(json);

        Assert.That(parsed, Is.Not.Null);
        Assert.That(parsed!.Value.Host, Is.EqualTo("new.example.org"));
        Assert.That(parsed.Value.Port, Is.EqualTo("3307"));
        Assert.That(parsed.Value.Database, Is.EqualTo("newdb"));
        Assert.That(parsed.Value.TablePrefix, Is.EqualTo("new_"));
        Assert.That(Parse(json)["keep"]!.ToString(), Is.EqualTo("me"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("not json")]
    [TestCase("[1,2,3]")]
    public void BuildDatabaseConfigJson_StoredValueIsNotAnObject_StartsFresh(string? stored)
    {
        // Nothing can be merged into a non-object, so it is replaced rather than half-kept — the
        // same choice the shipping form's CarrierConfigEditor makes on a broken blob.
        var json = SalesChannelEditModel.BuildDatabaseConfigJson("db", "3306", "wp", "wp_", stored);
        var config = Parse(json);

        Assert.That(config.Count, Is.EqualTo(4));
        Assert.That(config["host"]!.ToString(), Is.EqualTo("db"));
        Assert.That(config["port"]!.GetValue<int>(), Is.EqualTo(3306));
    }

    [Test]
    public void TryParseDatabaseConfig_PortStoredAsString_IsStillRead()
    {
        // This form writes the port as a number, but the blob is connector-owned and another writer
        // may have stored it as text; GetValue<int> would have thrown past the JsonException catch.
        var config = SalesChannelEditModel.TryParseDatabaseConfig(PortAsText());

        Assert.That(config, Is.Not.Null);
        Assert.That(config!.Value.Port, Is.EqualTo("3307"));
    }

    [Test]
    public void TryParseDatabaseConfig_RepeatedKey_ReturnsNullInsteadOfThrowing()
    {
        // Parses, then throws ArgumentException on the first read. The Server suppresses such a blob
        // on the read path since 883b075c, so this is depth rather than a reachable case today.
        Assert.That(SalesChannelEditModel.TryParseDatabaseConfig(RepeatedKey()), Is.Null);
    }

    private static string MakeStored()
        => Build("{ *host*: *old*, *port*: 1, *database*: *old*, *tablePrefix*: *old_*, *keep*: *me* }");

    private static string PortAsText()
        => Build("{ *host*: *db*, *port*: *3307*, *database*: *wp*, *tablePrefix*: *wp_* }");

    private static string RepeatedKey()
        => Build("{ *host*: *a*, *host*: *b* }");

    private static string Build(string pattern) => pattern.Replace('*', '"');
}
