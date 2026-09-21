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

    // Deliberately no allowPrivateHost / allowInsecureTransport members, and no sslCaPath either.
    // The first two used to be read from this blob, which the caller posts in the same request that
    // is being guarded — so the caller supplied the switch that turned the guard off. They are
    // operator configuration now (SalesChannelHostPolicyOptions), and so is the TLS trust anchor: a
    // CA path taken from this blob would be a filesystem path the server opens because a tenant
    // named it, and would let that tenant pick the trust anchor for their own connection. Not binding
    // here is what makes a blob written before that change inert: the keys are stripped from every
    // incoming blob, and a stored one that still carries them is ignored, never honoured.

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

    /// <summary>
    /// The MySQL credentials and the whole replicated dataset travel over this link to a host the
    /// tenant named, so the server is authenticated and not merely encrypted to:
    /// <see cref="ResolveSslMode"/> yields a verifying mode unless the operator says otherwise. The
    /// CA path, operator-owned as well, is added as an extra trust anchor for a privately issued
    /// server certificate.
    /// </summary>
    public string BuildConnectionString(string username, string password, SalesChannelHostPolicy hostPolicy)
    {
        ArgumentNullException.ThrowIfNull(hostPolicy);

        var builder = new MySqlConnectionStringBuilder
        {
            Server = Host,
            Port = (uint)Port,
            Database = Database,
            UserID = username,
            Password = password,
            SslMode = ResolveSslMode(hostPolicy),
            ConnectionTimeout = 15,
            DefaultCommandTimeout = 120,
        };

        if (hostPolicy.SslCaPath is { Length: > 0 } caPath)
        {
            builder.SslCa = caPath;
        }

        return builder.ConnectionString;
    }

    /// <summary>
    /// The TLS mode the operator policy leads to.
    ///
    /// <c>VerifyFull</c> by default: <c>Required</c> encrypts but validates neither the certificate
    /// chain nor the host name, so an on-path attacker answering the connect with any self-signed
    /// certificate receives the authentication packet — the shop database user and password — and
    /// can then proxy to the real server and rewrite the stream. Worse: the <c>Required</c> branch of
    /// <c>ValidateRemoteCertificate</c> returns before <c>m_sslPolicyErrors</c> is assigned, so a
    /// forged certificate still counts as a verified server identity, and a fake server that asks for
    /// <c>mysql_clear_password</c> is handed the password itself rather than a challenge response.
    /// Only <c>VerifyCA</c> and <c>VerifyFull</c> authenticate the peer at all, and <c>VerifyFull</c>
    /// ends the session before any query runs.
    ///
    /// The two steps down are operator configuration and nothing else. <c>VerifyCA</c> still verifies
    /// the chain and only forgives a name mismatch; <c>Preferred</c> verifies nothing and can be
    /// stripped to a cleartext session by an active attacker, which is why it hangs off the one
    /// switch that says "insecure" in its name.
    /// </summary>
    internal static MySqlSslMode ResolveSslMode(SalesChannelHostPolicy hostPolicy) =>
        hostPolicy.AllowInsecureTransport ? MySqlSslMode.Preferred
            : hostPolicy.AllowCertificateHostnameMismatch ? MySqlSslMode.VerifyCA
            : MySqlSslMode.VerifyFull;

    /// <summary>
    /// True when the host is a private/reserved IP, or a DNS name that resolves to one — the same guard the
    /// HTTP channel URLs use, applied to the MySQL host so a tenant cannot repurpose the connector as an
    /// internal port/credential scanner. Fails closed: an unresolvable host is treated as blocked.
    /// An address the operator allow-listed in <paramref name="hostPolicy"/> passes.
    ///
    /// This is a pre-flight resolution and the connection is then opened by name, so a rebinding name
    /// can answer publicly here and internally at connect time. The HTTP clients close that gap with
    /// <c>SocketsHttpHandler.ConnectCallback</c> (<c>SalesChannelServiceRegistration</c>); MySqlConnector
    /// 2.6.2 has no equivalent hook — <c>UseConnectionOpenedCallback</c> runs after the handshake — and
    /// the gap is left open here deliberately, in favour of the certificate check.
    ///
    /// Pinning the validated IP into <c>Server=</c> would close it, but that same string is the TLS
    /// target host, so <c>VerifyFull</c> would then demand a certificate issued for the IP. Keeping
    /// the name verified while dialling the pinned address is not on offer either: MySqlConnector
    /// takes <c>MySqlDataSourceBuilder.UseRemoteCertificateValidationCallback</c> only when
    /// <c>SslMode</c> is <c>Preferred</c> or <c>Required</c> and no <c>SslCa</c> is set
    /// (<c>ServerSession.InitSslAsync</c> logs that it is ignoring the callback otherwise), so the
    /// callback is an alternative to the library verification, never an addition to it. It would put
    /// the whole chain and name check into hand-written code, which goes subtly wrong far more often
    /// than DNS is attacker-controlled: the rebinding window needs a hostile resolver, a broken
    /// validator is on for every connection.
    ///
    /// What is left is a dial at a private address, not a credential leak — whatever answers still
    /// has to present a certificate this trust store accepts for the configured name. That bound is
    /// the default mode talking: under
    /// <see cref="SalesChannelHostPolicyOptions.AllowCertificateHostnameMismatch"/> any certificate
    /// chaining to a trusted CA passes whatever name it carries, and only the trust store is left of
    /// it. Neither the connection test nor the import paths report the outcome any more: every dial
    /// goes through <c>WooCommerceDatabaseConnector.OpenAsync</c>, which wraps the failure in a
    /// <c>ChannelTransportException</c> carrying one constant message, so
    /// <c>ChannelSyncRun.ErrorSummary</c> and the captured sync log read the same whatever the rebind
    /// found. What stays observable is that the run failed, and when — so rebinding is unobservable in
    /// its outcome, not in its occurrence.
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
