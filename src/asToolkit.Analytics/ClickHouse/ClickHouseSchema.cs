namespace asToolkit.Analytics.ClickHouse;

/// <summary>
/// ClickHouse DDL for the web-analytics store. Applied idempotently at startup
/// (<see cref="ClickHouseSchemaBootstrapper"/>); ClickHouse is NOT EF-migrated.
/// </summary>
internal static class ClickHouseSchema
{
    /// <summary>The list of columns written by the batch writer, in bulk-copy order (event_date is defaulted).</summary>
    internal static readonly string[] EventColumns =
    {
        "tenant_id", "sales_channel_id", "event_time", "event_type", "event_name",
        "session_id", "vid", "cid", "url", "path", "title", "referrer", "hostname",
        "screen_width", "screen_height", "viewport_width", "viewport_height", "scroll_depth",
        "language", "country", "ip_masked", "ua_browser", "ua_os", "ua_device",
        "utm_source", "utm_medium", "utm_campaign", "utm_term", "utm_content",
        "gclid", "gbraid", "wbraid", "gad_source", "msclkid", "fbclid",
        "product_ref", "product_name", "value", "currency"
    };

    internal static readonly string[] IdentityColumns =
    {
        "tenant_id", "sales_channel_id", "vid", "cid", "last_seen"
    };

    internal static string CreateDatabase(string database) =>
        $"CREATE DATABASE IF NOT EXISTS {database}";

    internal static string CreateEventsTable(string database) => $@"
CREATE TABLE IF NOT EXISTS {database}.web_events
(
    tenant_id        UUID,
    sales_channel_id UUID,
    event_time       DateTime64(3, 'UTC'),
    event_date       Date DEFAULT toDate(event_time),
    event_type       LowCardinality(String),
    event_name       String DEFAULT '',
    session_id       String,
    vid              String DEFAULT '',
    cid              String DEFAULT '',
    url              String DEFAULT '',
    path             String DEFAULT '',
    title            String DEFAULT '',
    referrer         String DEFAULT '',
    hostname         String DEFAULT '',
    screen_width     UInt16 DEFAULT 0,
    screen_height    UInt16 DEFAULT 0,
    viewport_width   UInt16 DEFAULT 0,
    viewport_height  UInt16 DEFAULT 0,
    scroll_depth     UInt8  DEFAULT 0,
    language         LowCardinality(String) DEFAULT '',
    country          LowCardinality(String) DEFAULT '',
    ip_masked        String DEFAULT '',
    ua_browser       LowCardinality(String) DEFAULT '',
    ua_os            LowCardinality(String) DEFAULT '',
    ua_device        LowCardinality(String) DEFAULT '',
    utm_source       String DEFAULT '',
    utm_medium       String DEFAULT '',
    utm_campaign     String DEFAULT '',
    utm_term         String DEFAULT '',
    utm_content      String DEFAULT '',
    gclid            String DEFAULT '',
    gbraid           String DEFAULT '',
    wbraid           String DEFAULT '',
    gad_source       String DEFAULT '',
    msclkid          String DEFAULT '',
    fbclid           String DEFAULT '',
    product_ref      String DEFAULT '',
    product_name     String DEFAULT '',
    value            Decimal(18, 4) DEFAULT 0,
    currency         LowCardinality(String) DEFAULT ''
)
ENGINE = MergeTree
PARTITION BY toYYYYMM(event_date)
ORDER BY (tenant_id, sales_channel_id, event_date, event_type, session_id)
TTL event_date + INTERVAL 24 MONTH DELETE
SETTINGS index_granularity = 8192";

    internal static string CreateIdentitiesTable(string database) => $@"
CREATE TABLE IF NOT EXISTS {database}.web_identities
(
    tenant_id        UUID,
    sales_channel_id UUID,
    vid              String,
    cid              String,
    last_seen        DateTime64(3, 'UTC')
)
ENGINE = ReplacingMergeTree(last_seen)
PARTITION BY tenant_id
ORDER BY (tenant_id, sales_channel_id, vid)";
}
