using System.Net;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Validators;
using asERP.SalesChannels;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using asERP.SalesChannels.Models.WooCommerceDatabase;
using Microsoft.Extensions.Logging.Abstractions;
using MySqlConnector;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the pure/config parts of the direct-MySQL WooCommerce connector: channel config
/// parsing + validation, the tolerant <c>_product_attributes</c> parser, registry wiring and
/// the type-specific validation rules. The SQL paths need a live MySQL and are exercised
/// manually / in staging.
/// </summary>
public class WooCommerceDatabaseConnectorTests
{
    /// <summary>
    /// The operator's outbound-host policy. Private addresses are only reachable when an
    /// installation-wide CIDR allow-list says so — the channel config cannot grant it any more.
    /// </summary>
    private static SalesChannelHostPolicy PolicyAllowing(params string[] networks) =>
        new(new SalesChannelHostPolicyOptions { AllowedPrivateNetworks = networks });

    // --- Registry / type wiring --------------------------------------------------------------------

    [Fact]
    public void Connector_IsResolvableByType_AndMirrorsRestCapabilities()
    {
        var connector = new WooCommerceDatabaseConnector(
            null!, null!, null!, null!, null!, null!, NullLogger<WooCommerceDatabaseConnector>.Instance,
            SalesChannelHostPolicy.DenyAll);
        var registry = new SalesChannelConnectorRegistry(new ISalesChannelConnector[] { connector });

        Assert.Same(connector, registry.Get(SalesChannelType.WooCommerceDatabase));

        // Categories are the exception to the REST mirror: import-only (no ExportCategories /
        // UpdateProductCategories — direct SQL term writes are too fragile against a live WordPress).
        var expected =
            SalesChannelCapabilities.ImportProducts |
            SalesChannelCapabilities.ImportSaless |
            SalesChannelCapabilities.ImportCustomers |
            SalesChannelCapabilities.ImportStock |
            SalesChannelCapabilities.ImportCategories |
            SalesChannelCapabilities.ImportShipments |
            SalesChannelCapabilities.PushShipments |
            SalesChannelCapabilities.UpdateStock |
            SalesChannelCapabilities.UpdatePrice;
        Assert.Equal(expected, connector.Capabilities);
    }

    // --- Channel config ----------------------------------------------------------------------------

    [Fact]
    public void Config_MissingJson_UsesDefaults_AndFailsValidationOnMissingHost()
    {
        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(new SalesChannel());

        Assert.Equal(3306, config.Port);
        Assert.Equal("wp_", config.TablePrefix);
        Assert.NotNull(config.Validate(SalesChannelHostPolicy.DenyAll));
    }

    [Fact]
    public void Config_ParsesJson_AndBuildsConnectionString()
    {
        var channel = new SalesChannel
        {
            // A literal address the operator allow-listed below: no DNS lookup, so the test stays
            // deterministic and offline — it exercises JSON parsing and connection-string building,
            // not host resolution.
            AdditionalConfigJson = """{"host":"10.10.0.5","port":3307,"database":"shop","tablePrefix":"wpx_"}""",
        };

        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(channel);

        Assert.Null(config.Validate(PolicyAllowing("10.0.0.0/8")));
        Assert.Equal("10.10.0.5", config.Host);
        Assert.Equal(3307, config.Port);
        Assert.Equal("shop", config.Database);
        Assert.Equal("wpx_", config.TablePrefix);

        var connectionString = config.BuildConnectionString("woo", "secret", SalesChannelHostPolicy.DenyAll);
        Assert.Contains("10.10.0.5", connectionString);
        Assert.Contains("shop", connectionString);
        Assert.Contains("3307", connectionString);
    }

    [Fact]
    public void Config_EmptyTablePrefix_FallsBackToDefault()
    {
        var channel = new SalesChannel
        {
            AdditionalConfigJson = """{"host":"h","database":"d","tablePrefix":""}""",
        };

        Assert.Equal("wp_", WooCommerceDatabaseChannelConfig.FromSalesChannel(channel).TablePrefix);
    }

    [Theory]
    [InlineData("wp_; DROP TABLE x--")] // injection attempt
    [InlineData("wp-")]                 // dash not allowed
    [InlineData("wp ")]                 // whitespace not allowed
    public void Config_RejectsUnsafeTablePrefix(string prefix)
    {
        // An allow-listed literal host, so validation actually reaches the prefix rule instead of
        // stopping at the host guard (and passing for the wrong reason).
        var config = new WooCommerceDatabaseChannelConfig { Host = "10.0.0.7", Database = "d", TablePrefix = prefix };

        var error = config.Validate(PolicyAllowing("10.0.0.0/8"));

        Assert.NotNull(error);
        Assert.Contains("Table prefix", error);
    }

    [Theory]
    [InlineData("wp_")]
    [InlineData("wp2_")]
    [InlineData("WordPress")]
    public void Config_AcceptsSafeTablePrefix(string prefix)
    {
        Assert.True(WooCommerceDatabaseChannelConfig.IsSafeIdentifierPrefix(prefix));

        var config = new WooCommerceDatabaseChannelConfig { Host = "10.0.0.7", Database = "d", TablePrefix = prefix };
        Assert.Null(config.Validate(PolicyAllowing("10.0.0.0/8")));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(70000)]
    public void Config_RejectsOutOfRangePort(int port)
    {
        var config = new WooCommerceDatabaseChannelConfig { Host = "h", Database = "d", Port = port };
        Assert.NotNull(config.Validate(SalesChannelHostPolicy.DenyAll));
    }

    // --- Private-host guard: operator-owned, not tenant-owned --------------------------------------

    private const string PrivateHostConfig =
        """{"host":"10.0.0.7","port":3306,"database":"wp","tablePrefix":"wp_"}""";

    [Fact]
    public void Config_PrivateHost_IsRefusedWhenTheOperatorAllowedNothing()
    {
        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(
            new SalesChannel { AdditionalConfigJson = PrivateHostConfig });

        Assert.NotNull(config.Validate(SalesChannelHostPolicy.DenyAll));
    }

    [Fact]
    public void Config_PrivateHost_IsPermittedOnlyByTheOperatorAllowList()
    {
        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(
            new SalesChannel { AdditionalConfigJson = PrivateHostConfig });

        Assert.Null(config.Validate(PolicyAllowing("10.0.0.0/8")));
        Assert.NotNull(config.Validate(PolicyAllowing("192.168.0.0/16")));
    }

    [Fact]
    public void Config_AllowPrivateHostInTheBlob_DoesNotEnableIt()
    {
        // The flag the finding exploited: supplied in the same document as the host it unlocked.
        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(new SalesChannel
        {
            AdditionalConfigJson =
                """{"host":"10.0.0.7","database":"wp","allowPrivateHost":true,"allowInsecureTransport":true}""",
        });

        var error = config.Validate(SalesChannelHostPolicy.DenyAll);

        Assert.NotNull(error);
        Assert.Contains("not permitted", error);
    }

    // --- TLS: verifying by default, anything weaker only through the operator switches -------------

    private static WooCommerceDatabaseChannelConfig TlsConfig() =>
        new() { Host = "10.0.0.7", Database = "wp" };

    private static MySqlConnectionStringBuilder BuildWith(SalesChannelHostPolicy policy) =>
        new(TlsConfig().BuildConnectionString("woo", "secret", policy));

    private static MySqlConnectionStringBuilder BuildWith(SalesChannelHostPolicyOptions options) =>
        BuildWith(new SalesChannelHostPolicy(options));

    [Fact]
    public void Config_ByDefault_VerifiesTheCertificateChainAndTheHostName()
    {
        // Required encrypts but authenticates nobody: an on-path attacker answering the connect with
        // any self-signed certificate is handed the MySQL credentials in the authentication packet.
        var built = BuildWith(SalesChannelHostPolicy.DenyAll);

        Assert.Equal(MySqlSslMode.VerifyFull, built.SslMode);
        Assert.Equal(string.Empty, built.SslCa);
    }

    [Fact]
    public void Config_OperatorCaPath_ReachesSslCaWithoutWeakeningTheMode()
    {
        var built = BuildWith(new SalesChannelHostPolicyOptions { SslCaPath = "  /etc/ssl/shop-ca.pem  " });

        Assert.Equal("/etc/ssl/shop-ca.pem", built.SslCa);
        Assert.Equal(MySqlSslMode.VerifyFull, built.SslMode);
    }

    [Fact]
    public void Config_HostnameMismatchSwitch_StillVerifiesTheChain()
    {
        var built = BuildWith(new SalesChannelHostPolicyOptions { AllowCertificateHostnameMismatch = true });

        Assert.Equal(MySqlSslMode.VerifyCA, built.SslMode);
    }

    [Fact]
    public void Config_InsecureTransport_IsTheOnlyRouteToANonVerifyingMode()
    {
        MySqlSslMode[] verifying = [MySqlSslMode.VerifyCA, MySqlSslMode.VerifyFull];

        // Everything else an operator can turn on leaves the peer authenticated.
        SalesChannelHostPolicyOptions[] withoutTheHatch =
        [
            new(),
            new() { AllowedPrivateNetworks = ["10.0.0.0/8"] },
            new() { SslCaPath = "/etc/ssl/shop-ca.pem" },
            new() { AllowCertificateHostnameMismatch = true },
            new() { SslCaPath = "/etc/ssl/shop-ca.pem", AllowCertificateHostnameMismatch = true },
        ];

        foreach (var options in withoutTheHatch)
        {
            Assert.Contains(BuildWith(options).SslMode, verifying);
        }

        Assert.Equal(
            MySqlSslMode.Preferred,
            BuildWith(new SalesChannelHostPolicyOptions { AllowInsecureTransport = true }).SslMode);
    }

    [Fact]
    public void Config_TlsKeysInTheBlob_AreIgnored()
    {
        // The blob arrives in the same request as the host it would unlock, and a CA path in it
        // would be a filesystem path the server opens because the caller named it — neither is
        // channel data.
        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(new SalesChannel
        {
            AdditionalConfigJson = """{"host":"10.0.0.7","database":"wp","allowInsecureTransport":true,"sslCaPath":"/etc/ssl/attacker-ca.pem","allowCertificateHostnameMismatch":true}""",
        });

        var built = new MySqlConnectionStringBuilder(
            config.BuildConnectionString("woo", "secret", PolicyAllowing("10.0.0.0/8")));

        Assert.Equal(MySqlSslMode.VerifyFull, built.SslMode);
        Assert.Equal(string.Empty, built.SslCa);
    }

    // --- Host policy -------------------------------------------------------------------------------

    [Fact]
    public void HostPolicy_WithoutConfiguration_AllowsNothing()
    {
        Assert.False(SalesChannelHostPolicy.DenyAll.IsAllowedPrivateAddress(IPAddress.Parse("10.0.0.7")));
        Assert.False(SalesChannelHostPolicy.DenyAll.AllowInsecureTransport);
        Assert.False(SalesChannelHostPolicy.DenyAll.AllowCertificateHostnameMismatch);
        Assert.Null(SalesChannelHostPolicy.DenyAll.SslCaPath);
    }

    [Fact]
    public void HostPolicy_IgnoresEntriesThatAreNotValidCidr()
    {
        // A typo must leave the policy narrower, never wider.
        var policy = PolicyAllowing("not-a-cidr", "10.0.0.0/8", "");

        Assert.True(policy.IsAllowedPrivateAddress(IPAddress.Parse("10.1.2.3")));
        Assert.False(policy.IsAllowedPrivateAddress(IPAddress.Parse("192.168.1.1")));
    }

    [Fact]
    public void HostPolicy_MatchesIPv4MappedAddressesAgainstIPv4Networks()
    {
        // ::ffff:10.0.0.7 is the same host; the block-list normalizes it, so the allow-list must too.
        Assert.True(PolicyAllowing("10.0.0.0/8").IsAllowedPrivateAddress(IPAddress.Parse("::ffff:10.0.0.7")));
    }

    // --- _product_attributes parser ----------------------------------------------------------------

    // Real-world shape: one global (taxonomy) attribute and one custom attribute with a
    // multi-byte name — the byte-length prefixes of PHP serialization must not trip the parser.
    private const string SerializedAttributes =
        "a:2:{s:8:\"pa_farbe\";a:6:{s:4:\"name\";s:8:\"pa_farbe\";s:5:\"value\";s:0:\"\";" +
        "s:8:\"position\";i:1;s:10:\"is_visible\";i:1;s:12:\"is_variation\";i:1;s:11:\"is_taxonomy\";i:1;}" +
        "s:7:\"groesse\";a:6:{s:4:\"name\";s:7:\"Größe\";s:5:\"value\";s:9:\"S | M | L\";" +
        "s:8:\"position\";i:0;s:10:\"is_visible\";i:1;s:12:\"is_variation\";i:1;s:11:\"is_taxonomy\";i:0;}}";

    [Fact]
    public void AttributesParser_ExtractsKeysNamesPositionsAndVariationFlags()
    {
        var attributes = WooProductAttributesParser.Parse(SerializedAttributes);

        Assert.Equal(2, attributes.Count);

        var taxonomy = Assert.Single(attributes, a => a.Key == "pa_farbe");
        Assert.Equal("pa_farbe", taxonomy.Name);
        Assert.Equal(1, taxonomy.Position);
        Assert.True(taxonomy.IsVariation);

        var custom = Assert.Single(attributes, a => a.Key == "groesse");
        Assert.Equal("Größe", custom.Name);
        Assert.Equal(0, custom.Position);
        Assert.True(custom.IsVariation);
    }

    [Fact]
    public void AttributesParser_NonVariationAttribute_IsFlaggedFalse()
    {
        const string serialized =
            "a:1:{s:8:\"material\";a:6:{s:4:\"name\";s:8:\"Material\";s:5:\"value\";s:5:\"Wolle\";" +
            "s:8:\"position\";i:0;s:10:\"is_visible\";i:1;s:12:\"is_variation\";i:0;s:11:\"is_taxonomy\";i:0;}}";

        var attribute = Assert.Single(WooProductAttributesParser.Parse(serialized));
        Assert.False(attribute.IsVariation);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("not php serialized at all")]
    public void AttributesParser_ToleratesGarbage(string? input)
    {
        Assert.Empty(WooProductAttributesParser.Parse(input));
    }

    // --- Validation rules --------------------------------------------------------------------------

    [Fact]
    public void Validator_RequiresUrlForWooCommerceDatabase()
    {
        var validator = new SalesChannelBaseValidator<SalesChannelInputDto>();
        var input = new SalesChannelInputDto
        {
            SalesChannelType = SalesChannelType.WooCommerceDatabase,
            Name = "Shop DB",
            Url = string.Empty,
            Username = "mysql",
            Password = "secret",
        };

        var result = validator.Validate(input);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(SalesChannelInputDto.Url));
    }

    [Fact]
    public void Validator_AcceptsCompleteWooCommerceDatabaseInput()
    {
        var validator = new SalesChannelBaseValidator<SalesChannelInputDto>();
        var input = new SalesChannelInputDto
        {
            SalesChannelType = SalesChannelType.WooCommerceDatabase,
            Name = "Shop DB",
            Url = "https://shop.example.com",
            Username = "mysql",
            Password = "secret",
            WarehouseIds = new List<Guid> { Guid.NewGuid() }, // At least one warehouse is required
        };

        Assert.True(validator.Validate(input).IsValid);
    }
}
