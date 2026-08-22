using System.Globalization;

namespace asERP.Domain.Services;

/// <summary>
/// Canonical hostname normalization for shop host bindings. Applied on write (domain CRUD)
/// AND on lookup (request routing) so host comparisons are exact string matches:
/// lowercase, ASCII/punycode (IDN), no scheme, no port, no path, no trailing dot.
/// Pure static helper — no I/O (same rules as the storage side, usable from validators).
/// </summary>
public static class ShopHostNormalizer
{
    /// <summary>
    /// Normalizes user/request input to the canonical host form. Tolerates a pasted scheme
    /// prefix and a single trailing slash; rejects anything with a path, port, whitespace or
    /// invalid IDN. IPv6 literals are rejected (they require a port-separator-ambiguous
    /// bracket syntax — bind shops to hostnames or IPv4 in v1).
    /// </summary>
    public static bool TryNormalize(string? input, out string normalized)
    {
        normalized = string.Empty;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        var host = input.Trim();

        // Users paste URLs — strip the scheme and a single trailing slash, nothing more.
        if (host.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
        {
            host = host["http://".Length..];
        }
        else if (host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            host = host["https://".Length..];
        }

        if (host.EndsWith('/'))
        {
            host = host[..^1];
        }

        // Port belongs in the separate Port field; paths/whitespace are never part of a host.
        if (host.Length == 0 || host.Contains('/') || host.Contains(':') || host.Any(char.IsWhiteSpace))
        {
            return false;
        }

        host = host.TrimEnd('.');
        if (host.Length == 0)
        {
            return false;
        }

        try
        {
            // IDN → punycode; also rejects labels that are not valid hostnames at all.
            host = new IdnMapping().GetAscii(host);
        }
        catch (ArgumentException)
        {
            return false;
        }

        host = host.ToLowerInvariant();

        if (host.Length > 255 || Uri.CheckHostName(host) == UriHostNameType.Unknown)
        {
            return false;
        }

        normalized = host;
        return true;
    }
}
