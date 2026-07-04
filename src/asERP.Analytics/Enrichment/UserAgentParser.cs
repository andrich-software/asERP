namespace asERP.Analytics.Enrichment;

/// <summary>
/// Minimal, dependency-free User-Agent classification into coarse browser / OS / device buckets. The
/// raw User-Agent is intentionally never stored — only these low-cardinality derived labels are kept.
/// </summary>
internal static class UserAgentParser
{
    public readonly record struct UserAgentInfo(string Browser, string Os, string Device);

    public static UserAgentInfo Parse(string? userAgent)
    {
        if (string.IsNullOrWhiteSpace(userAgent))
        {
            return new UserAgentInfo("Unknown", "Unknown", "Unknown");
        }

        var ua = userAgent.ToLowerInvariant();

        if (IsBot(ua))
        {
            return new UserAgentInfo("Bot", DetectOs(ua), "Bot");
        }

        return new UserAgentInfo(DetectBrowser(ua), DetectOs(ua), DetectDevice(ua));
    }

    public static bool IsBot(string uaLower) =>
        uaLower.Contains("bot") || uaLower.Contains("crawl") || uaLower.Contains("spider") ||
        uaLower.Contains("slurp") || uaLower.Contains("headless") || uaLower.Contains("preview") ||
        uaLower.Contains("monitor") || uaLower.Contains("python-requests") || uaLower.Contains("curl") ||
        uaLower.Contains("wget") || uaLower.Contains("facebookexternalhit");

    private static string DetectBrowser(string ua)
    {
        // Order matters: Edge/Opera/Chrome share tokens.
        if (ua.Contains("edg/") || ua.Contains("edge")) return "Edge";
        if (ua.Contains("opr/") || ua.Contains("opera")) return "Opera";
        if (ua.Contains("samsungbrowser")) return "Samsung";
        if (ua.Contains("firefox") || ua.Contains("fxios")) return "Firefox";
        if (ua.Contains("chrome") || ua.Contains("crios")) return "Chrome";
        if (ua.Contains("safari")) return "Safari";
        return "Other";
    }

    private static string DetectOs(string ua)
    {
        if (ua.Contains("windows")) return "Windows";
        if (ua.Contains("iphone") || ua.Contains("ipad") || ua.Contains("ipod")) return "iOS";
        if (ua.Contains("mac os") || ua.Contains("macintosh")) return "macOS";
        if (ua.Contains("android")) return "Android";
        if (ua.Contains("linux")) return "Linux";
        return "Other";
    }

    private static string DetectDevice(string ua)
    {
        if (ua.Contains("ipad") || (ua.Contains("tablet") && !ua.Contains("mobile"))) return "Tablet";
        if (ua.Contains("mobile") || ua.Contains("iphone") || ua.Contains("android")) return "Mobile";
        return "Desktop";
    }
}
