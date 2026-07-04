using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Validators;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using asERP.SalesChannels.Models.WooCommerceDatabase;
using Microsoft.Extensions.Logging.Abstractions;
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
    // --- Registry / type wiring --------------------------------------------------------------------

    [Fact]
    public void Connector_IsResolvableByType_AndMirrorsRestCapabilities()
    {
        var connector = new WooCommerceDatabaseConnector(
            null!, null!, null!, null!, NullLogger<WooCommerceDatabaseConnector>.Instance);
        var registry = new SalesChannelConnectorRegistry(new ISalesChannelConnector[] { connector });

        Assert.Same(connector, registry.Get(SalesChannelType.WooCommerceDatabase));

        var expected =
            SalesChannelCapabilities.ImportProducts |
            SalesChannelCapabilities.ImportSaless |
            SalesChannelCapabilities.ImportCustomers |
            SalesChannelCapabilities.ImportStock |
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
        Assert.NotNull(config.Validate());
    }

    [Fact]
    public void Config_ParsesJson_AndBuildsConnectionString()
    {
        var channel = new SalesChannel
        {
            AdditionalConfigJson = """{"host":"db.example.com","port":3307,"database":"shop","tablePrefix":"wpx_"}""",
        };

        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(channel);

        Assert.Null(config.Validate());
        Assert.Equal("db.example.com", config.Host);
        Assert.Equal(3307, config.Port);
        Assert.Equal("shop", config.Database);
        Assert.Equal("wpx_", config.TablePrefix);

        var connectionString = config.BuildConnectionString("woo", "secret");
        Assert.Contains("db.example.com", connectionString);
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
        var config = new WooCommerceDatabaseChannelConfig { Host = "h", Database = "d", TablePrefix = prefix };
        Assert.NotNull(config.Validate());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(70000)]
    public void Config_RejectsOutOfRangePort(int port)
    {
        var config = new WooCommerceDatabaseChannelConfig { Host = "h", Database = "d", Port = port };
        Assert.NotNull(config.Validate());
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
        };

        Assert.True(validator.Validate(input).IsValid);
    }
}
