using System.Text.Json;
using System.Text.Json.Serialization;
using asToolkit.Domain.Entities;
using MySqlConnector;

namespace asToolkit.SalesChannels.Models.WooCommerceDatabase;

/// <summary>
/// Strongly-typed slice of <c>SalesChannel.AdditionalConfigJson</c> for the direct-MySQL
/// WooCommerce connector. <c>SalesChannel.Username</c>/<c>Password</c> carry the database
/// credentials; <c>SalesChannel.Url</c> stays the shop's public base URL, which is still needed
/// to build the product-image download links (images are fetched over HTTP as usual).
/// </summary>
public sealed class WooCommerceDatabaseChannelConfig
{
    /// <summary>MySQL server host name or IP address.</summary>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    [JsonPropertyName("port")]
    public int Port { get; set; } = 3306;

    /// <summary>Name of the WordPress database.</summary>
    [JsonPropertyName("database")]
    public string Database { get; set; } = string.Empty;

    /// <summary>WordPress table prefix as configured in wp-config.php. Defaults to <c>wp_</c>.</summary>
    [JsonPropertyName("tablePrefix")]
    public string TablePrefix { get; set; } = "wp_";

    public static WooCommerceDatabaseChannelConfig FromSalesChannel(SalesChannel salesChannel)
    {
        var config = string.IsNullOrEmpty(salesChannel.AdditionalConfigJson)
            ? new WooCommerceDatabaseChannelConfig()
            : JsonSerializer.Deserialize<WooCommerceDatabaseChannelConfig>(salesChannel.AdditionalConfigJson)
              ?? new WooCommerceDatabaseChannelConfig();

        if (string.IsNullOrWhiteSpace(config.TablePrefix))
        {
            config.TablePrefix = "wp_";
        }

        return config;
    }

    /// <summary>Human-readable description of what is missing; null when the config is usable.</summary>
    public string? Validate()
    {
        if (string.IsNullOrWhiteSpace(Host))
        {
            return "MySQL host is missing in AdditionalConfigJson";
        }
        if (Port is <= 0 or > 65535)
        {
            return $"MySQL port {Port} is out of range";
        }
        if (string.IsNullOrWhiteSpace(Database))
        {
            return "MySQL database name is missing in AdditionalConfigJson";
        }
        if (!IsSafeIdentifierPrefix(TablePrefix))
        {
            return $"Table prefix '{TablePrefix}' contains invalid characters (letters, digits and underscore only)";
        }
        return null;
    }

    /// <summary>
    /// The prefix is interpolated into SQL identifiers (it cannot be parameterized), so it is
    /// restricted to the character set WordPress itself allows for table prefixes.
    /// </summary>
    internal static bool IsSafeIdentifierPrefix(string prefix) =>
        !string.IsNullOrEmpty(prefix) && prefix.All(c => char.IsAsciiLetterOrDigit(c) || c == '_');

    public string BuildConnectionString(string username, string password) =>
        new MySqlConnectionStringBuilder
        {
            Server = Host,
            Port = (uint)Port,
            Database = Database,
            UserID = username,
            Password = password,
            // Shop databases frequently sit behind a TLS-terminating proxy or on a LAN host without
            // certificates — prefer TLS but do not require it.
            SslMode = MySqlSslMode.Preferred,
            ConnectionTimeout = 15,
            DefaultCommandTimeout = 120,
        }.ConnectionString;
}
