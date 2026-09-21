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

    // Deliberately no allowPrivateHost / allowInsecureTransport members. Both used to be read from
    // this blob, which the caller posts in the same request that is being guarded — so the caller
    // supplied the switch that turned the guard off. They are operator configuration now
    // (SalesChannelHostPolicyOptions). Not binding them here is what makes a blob written before
    // that change inert: the keys are stripped from every incoming blob, and a stored one that
    // still carries them is ignored, never honoured.

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
    /// <param name="hostPolicy">
    /// The operator's outbound-host policy — the only thing that can widen the private-address
    /// guard. Pass <see cref="SalesChannelHostPolicy.DenyAll"/> where no configuration applies.
    /// </param>
    public string? Validate(SalesChannelHostPolicy hostPolicy)
    {
        ArgumentNullException.ThrowIfNull(hostPolicy);

        if (string.IsNullOrWhiteSpace(Host))
        {
            return "MySQL host is missing in AdditionalConfigJson";
        }
        if (Port is <= 0 or > 65535)
        {
            return $"MySQL port {Port} is out of range";
        }
        if (ResolvesToBlockedAddress(Host, hostPolicy))
        {
            // One wording for "private/reserved" and for "does not resolve": telling the two apart
            // would answer which internal names exist for a caller who cannot query internal DNS.
            return $"MySQL host '{Host}' is not permitted. Only public addresses are dialled; a database " +
                   "on a private network has to be allow-listed by the server operator " +
                   $"({SalesChannelHostPolicyOptions.Section}:" +
                   $"{nameof(SalesChannelHostPolicyOptions.AllowedPrivateNetworks)}).";
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

    public string BuildConnectionString(string username, string password, SalesChannelHostPolicy hostPolicy)
    {
        ArgumentNullException.ThrowIfNull(hostPolicy);

        return new MySqlConnectionStringBuilder
        {
            Server = Host,
            Port = (uint)Port,
            Database = Database,
            UserID = username,
            Password = password,
            // TLS is required so credentials never traverse the wire in cleartext. Only the operator
            // can opt the installation down to Preferred (a trusted LAN link whose server has no
            // certificate); a tenant cannot, which is what the removed allowInsecureTransport key
            // used to allow.
            SslMode = hostPolicy.AllowInsecureTransport ? MySqlSslMode.Preferred : MySqlSslMode.Required,
            ConnectionTimeout = 15,
            DefaultCommandTimeout = 120,
        }.ConnectionString;
    }

    /// <summary>
    /// True when the host is a private/reserved IP, or a DNS name that resolves to one — the same guard the
    /// HTTP channel URLs use, applied to the MySQL host so a tenant cannot repurpose the connector as an
    /// internal port/credential scanner. Fails closed: an unresolvable host is treated as blocked.
    /// An address the operator allow-listed in <paramref name="hostPolicy"/> passes.
    ///
    /// This is a pre-flight resolution and the connection is then opened by name, so a rebinding name
    /// can answer publicly here and internally at connect time. The HTTP clients close that gap with
    /// <c>SocketsHttpHandler.ConnectCallback</c> (<c>SalesChannelServiceRegistration</c>); MySqlConnector
    /// 2.6.2 has no equivalent hook — <c>UseConnectionOpenedCallback</c> runs after the handshake, and
    /// pinning the validated IP into <c>Server=</c> would break the hostname verification that
    /// <c>SslMode</c> is due to gain. The connection test no longer reports the outcome, but the import
    /// paths still surface the raw connect error through <c>ChannelSyncRun.ErrorSummary</c>, so the
    /// oracle is closed on one endpoint only — do not treat rebinding as unobservable.
    /// </summary>
    private static bool ResolvesToBlockedAddress(string host, SalesChannelHostPolicy hostPolicy)
    {
        if (IPAddress.TryParse(host, out var literal))
        {
            return IsBlocked(literal, hostPolicy);
        }

        try
        {
            var addresses = Dns.GetHostAddresses(host);
            return addresses.Length == 0 || addresses.Any(address => IsBlocked(address, hostPolicy));
        }
        catch (SocketException)
        {
            return true;
        }
    }

    private static bool IsBlocked(IPAddress address, SalesChannelHostPolicy hostPolicy) =>
        SalesChannelUrlValidator.IsBlockedAddress(address) && !hostPolicy.IsAllowedPrivateAddress(address);
}
