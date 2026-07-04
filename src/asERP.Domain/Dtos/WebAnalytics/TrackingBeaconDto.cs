using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.WebAnalytics;

/// <summary>
/// The JSON body the shop-side plugin forwards to the server for a single tracking beacon.
/// It carries only browser-collected values plus the server-side-computed pseudonymised customer
/// reference (<see cref="Cid"/>). The visitor IP and User-Agent are NOT in the body — the plugin
/// forwards them as the <c>X-Forwarded-For</c> and <c>User-Agent</c> headers respectively, and the
/// secret token travels in a dedicated header. Nothing here is trusted for tenant resolution.
/// </summary>
public class TrackingBeaconDto
{
    /// <summary>The funnel/behaviour event. Unknown values are rejected by the strict enum converter.</summary>
    public WebAnalyticsEventType EventType { get; set; } = WebAnalyticsEventType.PageView;

    /// <summary>Concrete event name for <see cref="WebAnalyticsEventType.Custom"/> events.</summary>
    public string? EventName { get; set; }

    /// <summary>Full page URL (query string is dropped server-side before storage).</summary>
    public string? Url { get; set; }

    /// <summary>Page path (without host/query).</summary>
    public string? Path { get; set; }

    /// <summary>Document title.</summary>
    public string? Title { get; set; }

    /// <summary>Document referrer as seen by the browser.</summary>
    public string? Referrer { get; set; }

    /// <summary>Hostname the page was served from (the shop's storefront host).</summary>
    public string? Hostname { get; set; }

    /// <summary>Persistent first-party visitor id (random, from localStorage) — enables retroactive stitching.</summary>
    public string? Vid { get; set; }

    /// <summary>
    /// Pseudonymised customer reference, computed server-side by the plugin as
    /// <c>HMAC-SHA256(channel salt, remote customer number)</c>. Present only when a customer is logged in.
    /// </summary>
    public string? Cid { get; set; }

    // --- Device / viewport ---
    public int ScreenWidth { get; set; }
    public int ScreenHeight { get; set; }
    public int ViewportWidth { get; set; }
    public int ViewportHeight { get; set; }

    /// <summary>Maximum scroll depth reached on the page, 0–100 (%).</summary>
    public int ScrollDepth { get; set; }

    /// <summary>Browser UI language (e.g. <c>de-DE</c>).</summary>
    public string? Language { get; set; }

    // --- Traffic source (full UTM set) ---
    public string? UtmSource { get; set; }
    public string? UtmMedium { get; set; }
    public string? UtmCampaign { get; set; }
    public string? UtmTerm { get; set; }
    public string? UtmContent { get; set; }

    // --- Ad click identifiers ---
    /// <summary>Google Ads click id.</summary>
    public string? Gclid { get; set; }
    /// <summary>Google Ads iOS/app click id (post-ATT).</summary>
    public string? Gbraid { get; set; }
    /// <summary>Google Ads iOS/web click id (post-ATT).</summary>
    public string? Wbraid { get; set; }
    /// <summary>Google Ads source signal (e.g. came from a Google property).</summary>
    public string? GadSource { get; set; }
    /// <summary>Microsoft Ads click id.</summary>
    public string? Msclkid { get; set; }
    /// <summary>Meta (Facebook) click id.</summary>
    public string? Fbclid { get; set; }

    // --- Commerce context ---
    /// <summary>Product id/SKU for product / cart / checkout events.</summary>
    public string? ProductRef { get; set; }

    /// <summary>Human-readable product name (kept for the most-visited-products table).</summary>
    public string? ProductName { get; set; }

    /// <summary>Unit price (product view) or basket/order value (checkout/purchase).</summary>
    public decimal? Value { get; set; }

    /// <summary>ISO currency code for <see cref="Value"/>.</summary>
    public string? Currency { get; set; }
}
