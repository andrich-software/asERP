using System.Net;
using System.Net.Sockets;

namespace asERP.Application.Services;

/// <summary>
/// The one predicate that decides whether an IP address belongs to the deployment's own network and
/// must therefore never be dialled on behalf of a caller: loopback, link-local, private (RFC 1918),
/// unique-local and the other reserved ranges an SSRF payload aims at.
///
/// It lives in the Application layer because there must be exactly one such list and every outbound
/// guard has to reach it: <c>SalesChannelUrlValidator</c> (channel URLs, product images, the direct
/// MySQL host) delegates here, and so does the SMTP endpoint guard in Infrastructure, which cannot
/// reference the sales-channel assembly at all. A second copy would drift, and the range one copy
/// forgets is the one an attacker looks for.
///
/// Widening it is never the caller's decision. An exception is operator configuration
/// (<c>SalesChannelHostPolicyOptions.AllowedPrivateNetworks</c>,
/// <c>SmtpHostPolicyOptions.AllowedPrivateNetworks</c>) and is applied on top of this answer, never
/// inside it.
/// </summary>
public static class OutboundAddressGuard
{
    /// <summary>
    /// True when the address is private, loopback, link-local, ULA or otherwise reserved.
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
