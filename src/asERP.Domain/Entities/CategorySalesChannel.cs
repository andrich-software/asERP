using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Per-channel activation and remote mapping of a <see cref="Category"/> — the category-side
/// counterpart of <see cref="ProductSalesChannel"/>. For channels with a remote API
/// (Shopware 6, WooCommerce) an active row is exported and <see cref="RemoteCategoryId"/> tracks
/// the channel-side id; for AsShop the row itself is the activation (the shop reads it directly).
/// </summary>
public class CategorySalesChannel : BaseEntity, IBaseEntity
{
    // Navigations must NOT be auto-initialized to new() — same phantom-insert trap as documented
    // on ProductSalesChannel. Leave them unset; EF binds via the FK scalars below.
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public Guid SalesChannelId { get; set; }
    public SalesChannel SalesChannel { get; set; } = null!;

    /// <summary>Whether the category is active (visible/synced) on this channel.</summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Channel-side identifier (WooCommerce numeric term id, Shopware 6 UUID). Cleared after the
    /// category has been deleted remotely on deactivation.
    /// </summary>
    public string? RemoteCategoryId { get; set; }

    public DateTime? LastSyncedAt { get; set; }

    public string? LastErrorMessage { get; set; }
}
