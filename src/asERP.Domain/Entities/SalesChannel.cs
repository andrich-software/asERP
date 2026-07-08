using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

public class SalesChannel : BaseEntity, IBaseEntity, IConcurrencyStamped
{
    /// <summary>Optimistic-concurrency token; refreshed on every insert/update in SaveChangesAsync.</summary>
    public Guid ConcurrencyToken { get; set; }

    public SalesChannelType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    /// <summary>Encrypted at rest via <c>EncryptedStringConverter</c>.</summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>OAuth access token (encrypted at rest). Refreshed by the connector before each call when expired.</summary>
    public string? AccessToken { get; set; }

    /// <summary>OAuth refresh token (encrypted at rest). Persisted across server restarts.</summary>
    public string? RefreshToken { get; set; }

    /// <summary>UTC expiry of the current access token. Connector refreshes when within ~60 seconds of this.</summary>
    public DateTime? TokenExpiresAt { get; set; }

    /// <summary>
    /// Channel-specific marketplace identifier (eBay marketplace like <c>EBAY_DE</c>, Amazon marketplace id, ...).
    /// Single SalesChannel = single marketplace; multi-marketplace sellers create one row per marketplace.
    /// </summary>
    public string? MarketplaceId { get; set; }

    /// <summary>Free-form connector configuration (sandbox flag, policy IDs, seller id, ...). Schema is owned by the connector.</summary>
    public string? AdditionalConfigJson { get; set; }

    public bool ImportProducts { get; set; }
    public bool ImportCustomers { get; set; }
    public bool ImportSaless { get; set; }
    public bool ExportProducts { get; set; }
    public bool ExportCustomers { get; set; }
    public bool ExportSaless { get; set; }

    /// <summary>
    /// Push stock levels to this channel whenever the mirrored warehouse stock changes. Finer gate than
    /// <see cref="ExportProducts"/> — a channel can receive stock updates without full product exports.
    /// </summary>
    public bool ExportStock { get; set; }

    /// <summary>
    /// Push local order cancellations back to this channel (dedicated <c>CancelSales</c> export).
    /// Opt-in per channel, default off — without it a local cancel stays local and the shop keeps
    /// showing the order as open. Independent of <see cref="ExportSaless"/>.
    /// </summary>
    public bool PushSalesCancellations { get; set; }

    /// <summary>
    /// This channel is the stock master: its stock levels are mirrored into the linked warehouse
    /// (scheduled pull + webhook nudge). Orders imported FROM the master do not book ledger movements —
    /// the shop already decremented itself and the mirror follows. Orders from every other channel (and
    /// POS) book movements against the mirror and are forwarded to the master as stock updates.
    /// </summary>
    public bool ImportStock { get; set; }

    /// <summary>Polling interval used by the orchestrator. Defaults to 60s.</summary>
    public int SyncIntervalSeconds { get; set; } = 60;

    /// <summary>Kill-switch independent of the per-direction Import/Export flags.</summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Enables web-analytics tracking for this channel. The shop-side plugin only forwards beacons
    /// when a token is configured; the server additionally ignores beacons for channels with this off.
    /// </summary>
    public bool TrackingEnabled { get; set; }

    /// <summary>
    /// Secret per-channel tracking token (encrypted at rest via <c>EncryptedStringConverter</c>).
    /// Held only server-side in the shop plugin and added to each beacon there — it never reaches the
    /// browser. The server maps it to this channel + tenant. Rotatable; rotation invalidates historical
    /// pseudonymised customer (cid) matching. Kept for display/rotation in the admin UI.
    /// </summary>
    public string? TrackingToken { get; set; }

    /// <summary>
    /// SHA-256 (hex) of <see cref="TrackingToken"/>. Indexed, non-reversible lookup key used on the hot,
    /// anonymous ingest path — the encrypted <see cref="TrackingToken"/> cannot be queried directly.
    /// </summary>
    public string? TrackingTokenHash { get; set; }

    /// <summary>
    /// Shared secret for inbound shop webhooks (encrypted at rest via <c>EncryptedStringConverter</c>).
    /// WooCommerce signs the raw body with HMAC-SHA256 (<c>X-WC-Webhook-Signature</c>); Shopware sends it
    /// as a header token. The channel id is part of the webhook URL, so no hash-lookup column is needed —
    /// the secret is loaded via the channel row and verified in constant time.
    /// </summary>
    public string? WebhookSecret { get; set; }

    public ICollection<Warehouse> Warehouses { get; set; } = null!;

    /// <summary>
    /// 1:1 synchronization bookkeeping (import cursors, initial-import flags, last poll time). Held on a
    /// SEPARATE, non-concurrency-stamped entity so the sync machinery's concurrent per-operation updates
    /// (order backfill cursor vs. customer import cursor, etc.) don't collide on this channel's optimistic-
    /// concurrency token. The sync paths always load it via <c>Include(s =&gt; s.SyncState)</c>; new channels
    /// must initialize it (a fresh <see cref="SalesChannelSyncState"/>).
    /// </summary>
    public SalesChannelSyncState SyncState { get; set; } = null!;
}
