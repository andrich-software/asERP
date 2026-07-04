using System.Security.Cryptography;
using System.Text;

namespace asERP.Domain.Services;

/// <summary>
/// Helpers for the per-channel web-analytics tracking token. The token is the single secret the shop
/// plugin holds; the server stores it encrypted plus a non-reversible SHA-256 hash for the hot-path
/// lookup. Generation and hashing live here so the token-rotation command and the ingest resolver agree.
/// </summary>
public static class TrackingTokenHasher
{
    /// <summary>Generates a new opaque, URL-safe tracking token (256 bits of entropy).</summary>
    public static string GenerateToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        // URL-safe base64 without padding — pasteable into plugin settings without escaping.
        return Convert.ToBase64String(bytes)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }

    /// <summary>Lower-case hex SHA-256 of the token — the indexed lookup key stored in TrackingTokenHash.</summary>
    public static string Hash(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return string.Empty;
        }
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}
