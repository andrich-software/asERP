using System.Net;
using System.Net.Sockets;

namespace asToolkit.Analytics.Enrichment;

/// <summary>
/// Masks a visitor IP for at-rest storage: IPv4 → last octet zeroed (/24), IPv6 → first 48 bits kept,
/// the rest zeroed. The full IP is used only transiently (session hashing) and never persisted raw.
/// </summary>
internal static class IpMasker
{
    public static string Mask(string? ip)
    {
        if (string.IsNullOrWhiteSpace(ip) || !IPAddress.TryParse(ip.Trim(), out var address))
        {
            return string.Empty;
        }

        var bytes = address.GetAddressBytes();

        if (address.AddressFamily == AddressFamily.InterNetwork && bytes.Length == 4)
        {
            bytes[3] = 0;
            return new IPAddress(bytes).ToString();
        }

        if (address.AddressFamily == AddressFamily.InterNetworkV6 && bytes.Length == 16)
        {
            // Keep the first 48 bits (network prefix), zero the remaining 80.
            for (var i = 6; i < bytes.Length; i++)
            {
                bytes[i] = 0;
            }
            return new IPAddress(bytes).ToString();
        }

        return string.Empty;
    }
}
