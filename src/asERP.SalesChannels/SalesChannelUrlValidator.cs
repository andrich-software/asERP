using System.Net;
using System.Net.Sockets;

namespace asERP.SalesChannels;

/// <summary>
/// Validates that an outbound URL (a sales-channel base URL or a product-image URL fetched from a remote
/// shop) is safe to request, to prevent SSRF against internal infrastructure.
///
/// Two layers of defense:
/// 1. <see cref="Validate"/> parses the URL, enforces the scheme, blocks literal internal hosts, and —
///    critically — resolves the DNS name and rejects the request if ANY resolved address is private,
///    loopback, link-local or ULA (defeats DNS-rebinding-style bypasses where a public name resolves to
///    an internal IP).
/// 2. <see cref="IsBlockedAddress"/> is exposed so the HttpClient's <c>SocketsHttpHandler.ConnectCallback</c>
///    can re-validate the ACTUAL dialed IP at connect time. That also defeats redirect-based bypasses and
///    the TOCTOU gap between resolve and connect.
/// </summary>
public static class SalesChannelUrlValidator
{
    private static readonly string[] BlockedHosts =
    [
        "localhost",
        "metadata.google.internal",
        "169.254.169.254"
    ];

    /// <summary>
    /// True when https is required for outbound channel/image requests — the case everywhere except a
    /// local Development host (where a plain-http test shop is convenient). Read once from the environment
    /// so the static validator needs no DI wiring at its many call sites.
    /// </summary>
    private static readonly bool RequireHttps = !IsDevelopmentEnvironment();

    private static bool IsDevelopmentEnvironment()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        return string.Equals(env, "Development", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Validates that a sales channel / image URL is safe for outbound HTTP requests.
    /// Blocks private/internal network addresses and (outside Development) non-https schemes.
    /// </summary>
    public static void Validate(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("Sales channel URL must not be empty.");
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            throw new ArgumentException($"Sales channel URL is not a valid absolute URI: {url}");
        }

        if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException($"Sales channel URL must use http or https scheme, got: {uri.Scheme}");
        }

        if (RequireHttps && uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException($"Sales channel URL must use https, got: {uri.Scheme}");
        }

        var host = uri.Host.ToLowerInvariant();

        foreach (var blocked in BlockedHosts)
        {
            if (host == blocked)
            {
                throw new ArgumentException($"Sales channel URL must not point to internal host: {host}");
            }
        }

        // A literal IP is checked directly; a DNS name is resolved and EVERY returned address is checked,
        // so a public name that resolves to an internal IP is rejected (classic DNS-SSRF).
        if (IPAddress.TryParse(host, out var literalIp))
        {
            if (IsBlockedAddress(literalIp))
            {
                throw new ArgumentException($"Sales channel URL must not point to a private or reserved IP address: {host}");
            }

            return;
        }

        IPAddress[] resolved;
        try
        {
            resolved = Dns.GetHostAddresses(host);
        }
        catch (SocketException ex)
        {
            throw new ArgumentException($"Sales channel URL host could not be resolved: {host}", ex);
        }

        if (resolved.Length == 0)
        {
            throw new ArgumentException($"Sales channel URL host resolved to no addresses: {host}");
        }

        foreach (var ip in resolved)
        {
            if (IsBlockedAddress(ip))
            {
                throw new ArgumentException(
                    $"Sales channel URL host {host} resolves to a private or reserved address ({ip}) and is blocked.");
            }
        }
    }

    /// <summary>
    /// True when the address is private, loopback, link-local, ULA or otherwise reserved. Exposed for the
    /// HttpClient ConnectCallback so the actually-dialed IP can be re-validated at connect time.
    /// </summary>
    public static bool IsBlockedAddress(IPAddress ip)
    {
        // IPv4-mapped IPv6 (e.g. ::ffff:10.0.0.1) would otherwise slip past the IPv4 checks — normalize it.
        if (ip.IsIPv4MappedToIPv6)
        {
            ip = ip.MapToIPv4();
        }

        if (IPAddress.IsLoopback(ip))
        {
            return true;
        }

        if (ip.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (ip.IsIPv6LinkLocal || ip.IsIPv6SiteLocal || ip.IsIPv6Multicast)
            {
                return true;
            }

            // Unique-local addresses fc00::/7 (the high 7 bits are 1111 110x).
            var v6 = ip.GetAddressBytes();
            if ((v6[0] & 0xFE) == 0xFC)
            {
                return true;
            }

            return false;
        }

        if (ip.AddressFamily != AddressFamily.InterNetwork)
        {
            return false;
        }

        byte[] bytes = ip.GetAddressBytes();

        return bytes[0] switch
        {
            10 => true,                                          // 10.0.0.0/8
            127 => true,                                         // 127.0.0.0/8
            172 => bytes[1] >= 16 && bytes[1] <= 31,             // 172.16.0.0/12
            192 => bytes[1] == 168,                              // 192.168.0.0/16
            169 => bytes[1] == 254,                              // 169.254.0.0/16 (link-local)
            0 => true,                                           // 0.0.0.0/8
            _ => false
        };
    }
}
