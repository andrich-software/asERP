using System.Security.Cryptography;
using System.Text;

namespace asToolkit.Analytics.Enrichment;

/// <summary>
/// Plausible-style cookieless sessionisation: <c>session_id = hash(daily_salt + host + ip + user_agent)</c>.
/// The salt is a random 32-byte value rotated every UTC day, so sessions are distinguishable within a day
/// but the data anonymises overnight — the raw IP/User-Agent are never stored. Singleton; thread-safe.
/// </summary>
internal sealed class SessionHasher : ISessionHasher
{
    private readonly object _lock = new();
    private byte[] _salt = RandomNumberGenerator.GetBytes(32);
    private DateOnly _saltDate = DateOnly.FromDateTime(DateTime.UtcNow);

    public string Compute(string host, string visitorIp, string userAgent)
    {
        var salt = CurrentSalt();

        // salt || host || ip || ua  — separators avoid field-boundary collisions.
        var input = new StringBuilder()
            .Append(Convert.ToHexString(salt)).Append('|')
            .Append(host).Append('|')
            .Append(visitorIp).Append('|')
            .Append(userAgent)
            .ToString();

        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        // 16 hex chars (64 bits) is ample to separate sessions within a day per channel.
        return Convert.ToHexString(hash, 0, 8).ToLowerInvariant();
    }

    private byte[] CurrentSalt()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        lock (_lock)
        {
            if (today != _saltDate)
            {
                _salt = RandomNumberGenerator.GetBytes(32);
                _saltDate = today;
            }
            return _salt;
        }
    }
}
