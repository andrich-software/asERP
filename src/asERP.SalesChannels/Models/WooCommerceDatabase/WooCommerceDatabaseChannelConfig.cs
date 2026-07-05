using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using asERP.Domain.Entities;
using MySqlConnector;

namespace asERP.SalesChannels.Models.WooCommerceDatabase;

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

    /// <summary>
    /// Opt-out for the private-range host guard, for genuine self-hosted LAN deployments where the MySQL
    /// server legitimately sits on a private/internal address. Off by default: a tenant cannot point the
    /// connector at internal infrastructure (SSRF/port-scan primitive) unless the operator explicitly
    /// allows it per channel.
    /// </summary>
    [JsonPropertyName("allowPrivateHost")]
    public bool AllowPrivateHost { get; set; }

    /// <summary>
    /// Opt-out for requiring TLS on the MySQL connection. Off by default, so the connection uses
    /// <c>SslMode.Required</c> (no silent cleartext downgrade). Set only for a trusted LAN link where the
    /// server has no certificate.
    /// </summary>
    [JsonPropertyName("allowInsecureTransport")]
    public bool AllowInsecureTransport { get; set; }

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
        if (!AllowPrivateHost && ResolvesToBlockedAddress(Host))
        {
            return $"MySQL host '{Host}' resolves to a private or reserved address; set allowPrivateHost=true " +
                   "in AdditionalConfigJson to permit a self-hosted LAN database.";
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
            // TLS is required by default so credentials never traverse the wire in cleartext. A trusted
            // LAN link without a server certificate can opt back down to Preferred per channel.
            SslMode = AllowInsecureTransport ? MySqlSslMode.Preferred : MySqlSslMode.Required,
            ConnectionTimeout = 15,
            DefaultCommandTimeout = 120,
        }.ConnectionString;

    /// <summary>
    /// True when the host is a private/reserved IP, or a DNS name that resolves to one — the same guard the
    /// HTTP channel URLs use, applied to the MySQL host so a tenant cannot repurpose the connector as an
    /// internal port/credential scanner. Fails closed: an unresolvable host is treated as blocked.
    /// </summary>
    private static bool ResolvesToBlockedAddress(string host)
    {
        if (IPAddress.TryParse(host, out var literal))
        {
            return SalesChannelUrlValidator.IsBlockedAddress(literal);
        }

        try
        {
            var addresses = Dns.GetHostAddresses(host);
            return addresses.Length == 0 || addresses.Any(SalesChannelUrlValidator.IsBlockedAddress);
        }
        catch (SocketException)
        {
            return true;
        }
    }
}
