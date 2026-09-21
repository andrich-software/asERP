using System.Text.Json.Nodes;
using asERP.Application.Services;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// The stripper removes keys a caller must not own from a config blob. Unlike
/// <see cref="ConfigJsonSecretRedactor"/> it never writes a value, which is what makes it safe to
/// run over a document that came from the request body and is not persisted.
/// </summary>
public class ConfigJsonKeyStripperTests
{
    private static readonly ConfigJsonKeyStripper Stripper =
        new(["allowPrivateHost", "allowInsecureTransport"]);

    private static JsonObject Strip(string json) => JsonNode.Parse(Stripper.Strip(json)!)!.AsObject();

    [Fact]
    public void Strip_RemovesTheConfiguredKeysAndKeepsTheRest()
    {
        var config = Strip(
            """{"host":"10.0.0.7","allowPrivateHost":true,"database":"wp","allowInsecureTransport":true}""");

        Assert.False(config.ContainsKey("allowPrivateHost"));
        Assert.False(config.ContainsKey("allowInsecureTransport"));
        Assert.Equal("10.0.0.7", config["host"]!.GetValue<string>());
        Assert.Equal("wp", config["database"]!.GetValue<string>());
    }

    [Theory]
    [InlineData("AllowPrivateHost")]
    [InlineData("ALLOWPRIVATEHOST")]
    [InlineData("allowprivatehost")]
    public void Strip_MatchesTheKeyNameCaseInsensitively(string key)
    {
        var config = Strip($$"""{"host":"h","{{key}}":true}""");

        Assert.Single(config);
        Assert.True(config.ContainsKey("host"));
    }

    [Fact]
    public void Strip_AlsoRemovesNestedOccurrences()
    {
        var stripped = Stripper.Strip("""{"nested":{"allowPrivateHost":true},"list":[{"allowPrivateHost":true}]}""");

        Assert.DoesNotContain("allowPrivateHost", stripped);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("not json at all")]
    public void Strip_LeavesWhatItCannotWalkUnchanged(string? json)
    {
        // Nothing is exposed by passing it through: a blob the stripper cannot read is a blob the
        // connector's typed config cannot bind either — and the operator-owned keys are no longer
        // members of that config in the first place.
        Assert.Equal(json, Stripper.Strip(json));
    }

    [Fact]
    public void Strip_WithoutAMatchingKey_ReturnsTheOriginalText()
    {
        const string json = """{"host":"10.0.0.7","database":"wp"}""";

        Assert.Equal(json, Stripper.Strip(json));
    }
}
