using System.Text.Json.Nodes;
using asERP.Application.Features.ShippingProvider;
using asERP.Application.Services;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// Unit tests for the redact/merge contract of the free-form config blobs: a secret leaves the
/// server only as <see cref="ConfigJsonSecretRedactor.RedactedValue"/>, and the placeholder coming
/// back means "keep the stored value".
/// </summary>
public class ConfigJsonSecretRedactorTests
{
    private static readonly ConfigJsonSecretRedactor Shipping = ShippingProviderConfigSecrets.Redactor;

    private const string StoredConfig =
        """{"Procedure":"01","TrackingApiKey":"live-dhl-tracking-key","Sender":{"Name":"ACME","Zip":"01067"}}""";

    private static string? Value(string? json, string key)
        => (JsonNode.Parse(json!) as JsonObject)?[key]?.GetValue<string>();

    private static bool HasKey(string? json, string key)
        => (JsonNode.Parse(json!) as JsonObject)?.ContainsKey(key) == true;

    [Fact]
    public void Redact_ReplacesSecretValueWithConstantPlaceholder()
    {
        var redacted = Shipping.Redact(StoredConfig);

        Assert.Equal(ConfigJsonSecretRedactor.RedactedValue, Value(redacted, "TrackingApiKey"));
        Assert.DoesNotContain("live-dhl-tracking-key", redacted);
        Assert.Equal("01", Value(redacted, "Procedure"));
    }

    [Fact]
    public void Redact_MatchesKeysCaseInsensitively()
    {
        var redacted = Shipping.Redact("""{"trackingapikey":"live-dhl-tracking-key"}""");

        Assert.Equal(ConfigJsonSecretRedactor.RedactedValue, Value(redacted, "trackingapikey"));
    }

    [Fact]
    public void Redact_LeavesConfigWithoutSecretsUntouched()
    {
        const string json = """{"Procedure":"01","ContactId":"276","ServiceCode":"11"}""";

        Assert.Equal(json, Shipping.Redact(json));
    }

    [Fact]
    public void Redact_CoversNestedObjectsAndArrays()
    {
        var redactor = new ConfigJsonSecretRedactor(["ApiSecret"]);

        var redacted = redactor.Redact("""{"Auth":{"ApiSecret":"nested"},"Extra":[{"ApiSecret":"in-array"}]}""");

        Assert.DoesNotContain("nested", redacted);
        Assert.DoesNotContain("in-array", redacted);
    }

    [Fact]
    public void Redact_KeepsAnEmptySecretValueAsItIs()
    {
        var redacted = Shipping.Redact("""{"TrackingApiKey":""}""");

        Assert.Equal(string.Empty, Value(redacted, "TrackingApiKey"));
    }

    [Fact]
    public void Redact_WithMalformedJson_SuppressesTheBlobInsteadOfThrowing()
    {
        Assert.Null(Shipping.Redact("""{"TrackingApiKey":"live-dhl-tracking-key",}"""));
    }

    [Fact]
    public void Redact_WithNonObjectOrEmptyBlob_ReturnsItUnchanged()
    {
        Assert.Equal("\"plain string\"", Shipping.Redact("\"plain string\""));
        Assert.Equal("   ", Shipping.Redact("   "));
        Assert.Null(Shipping.Redact(null));
    }

    [Fact]
    public void Merge_WithPlaceholder_KeepsTheStoredSecret()
    {
        var merged = Shipping.Merge(Shipping.Redact(StoredConfig), StoredConfig);

        Assert.Equal("live-dhl-tracking-key", Value(merged, "TrackingApiKey"));
        Assert.Equal("01", Value(merged, "Procedure"));
    }

    [Fact]
    public void Merge_WithMissingKey_ClearsTheStoredSecret()
    {
        var merged = Shipping.Merge("""{"Procedure":"02"}""", StoredConfig);

        Assert.False(HasKey(merged, "TrackingApiKey"));
        Assert.Equal("02", Value(merged, "Procedure"));
    }

    [Fact]
    public void Merge_WithNewValue_ReplacesTheStoredSecret()
    {
        var merged = Shipping.Merge("""{"TrackingApiKey":"rotated-key"}""", StoredConfig);

        Assert.Equal("rotated-key", Value(merged, "TrackingApiKey"));
    }

    [Fact]
    public void Merge_MatchesKeysCaseInsensitively()
    {
        var merged = Shipping.Merge("""{"trackingapikey":"********"}""", StoredConfig);

        Assert.Equal("live-dhl-tracking-key", Value(merged, "trackingapikey"));
    }

    [Fact]
    public void Merge_WithPlaceholderButNothingStored_DropsTheKey()
    {
        var merged = Shipping.Merge("""{"TrackingApiKey":"********","Procedure":"01"}""", null);

        Assert.False(HasKey(merged, "TrackingApiKey"));
        Assert.Equal("01", Value(merged, "Procedure"));
    }

    [Fact]
    public void Merge_CoversNestedObjects()
    {
        var redactor = new ConfigJsonSecretRedactor(["ApiSecret"]);
        const string stored = """{"Auth":{"ApiSecret":"nested"}}""";

        var merged = redactor.Merge(redactor.Redact(stored), stored);

        Assert.Equal("nested", (JsonNode.Parse(merged!) as JsonObject)?["Auth"]?["ApiSecret"]?.GetValue<string>());
    }

    [Fact]
    public void Merge_WithMalformedOrEmptyBlob_ReturnsItUnchanged()
    {
        Assert.Equal("not json at all", Shipping.Merge("not json at all", StoredConfig));
        Assert.Equal(string.Empty, Shipping.Merge(string.Empty, StoredConfig));
        Assert.Null(Shipping.Merge(null, StoredConfig));
    }

    [Fact]
    public void Merge_WithMalformedStoredBlob_DropsThePlaceholderInsteadOfKeepingIt()
    {
        var merged = Shipping.Merge("""{"TrackingApiKey":"********"}""", "{broken");

        Assert.False(HasKey(merged, "TrackingApiKey"));
    }

    [Theory]
    [InlineData("TrackingApiKey")]
    [InlineData("SomeFutureApiKey")]
    [InlineData("webhookSecret")]
    [InlineData("Password")]
    [InlineData("AccessToken")]
    public void IsSecretKey_CoversTheExplicitListAndTheNameSuffixes(string key)
        => Assert.True(Shipping.IsSecretKey(key));

    [Theory]
    [InlineData("Procedure")]
    [InlineData("Participation")]
    [InlineData("Product")]
    [InlineData("ReturnReceiverId")]
    [InlineData("ReturnProcedure")]
    [InlineData("LabelSize")]
    [InlineData("ReturnProduct")]
    [InlineData("ContactId")]
    [InlineData("ServiceCode")]
    [InlineData("Sender")]
    [InlineData("CountryCode")]
    [InlineData("Email")]
    public void IsSecretKey_NeverCoversAKnownCarrierSetting(string key)
        => Assert.False(Shipping.IsSecretKey(key));

    [Fact]
    public void IsSecretKey_KnownPlainKeyWins_OverTheNameSuffixes()
    {
        var redactor = new ConfigJsonSecretRedactor([], ["PublicKey"]);

        Assert.False(redactor.IsSecretKey("publickey"));
        Assert.True(redactor.IsSecretKey("PrivateKey"));
    }
}
