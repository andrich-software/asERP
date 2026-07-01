using asToolkit.Domain.Entities.Common;
using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Entities;

public class SalesChannel : BaseEntity, IBaseEntity
{
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
    public bool InitialProductImportCompleted { get; set; }
    public bool InitialProductExportCompleted { get; set; }
    public bool InitialCustomerImportCompleted { get; set; }

    /// <summary>
    /// True once the resumable, oldest-first order backfill has walked the whole remote history. Until then,
    /// scheduled sales imports run in backfill mode; afterwards they switch to the lighter incremental
    /// (modified_after) mode. Clear this to force a fresh full backfill.
    /// </summary>
    public bool InitialSalesImportCompleted { get; set; }

    /// <summary>
    /// Resume point for the order backfill: the UTC <c>date_created</c> of the furthest order imported so far.
    /// The next backfill run continues from here (WooCommerce <c>after=</c>) instead of restarting, so an
    /// interrupted sweep never loses ground. Null means "start from the beginning of history".
    /// </summary>
    public DateTime? SalesImportBackfillCursor { get; set; }

    /// <summary>
    /// Resume point for the customer import: the last fully imported page (1-based, id-ordered). A time-boxed
    /// run persists its progress here so the next run continues from the following page instead of re-walking
    /// from the start. Reset to 0 once the whole customer base is in (and <see cref="InitialCustomerImportCompleted"/>
    /// flips). 0 means "start from the first page".
    /// </summary>
    public int CustomerImportPageCursor { get; set; }

    /// <summary>Polling interval used by the orchestrator. Defaults to 60s.</summary>
    public int SyncIntervalSeconds { get; set; } = 60;

    /// <summary>UTC time of the last sync attempt — orchestrator schedules the next dispatch from this.</summary>
    public DateTime? LastSyncStartedAt { get; set; }

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

    public ICollection<Warehouse> Warehouses { get; set; } = null!;
}
