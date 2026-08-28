namespace asERP.SalesChannels.Abstractions;

/// <summary>
/// Channel-agnostic payload shapes drained from <c>ChannelExportOutbox</c> and translated by
/// each connector to its native API DTO. The orchestrator hydrates these from the stored
/// JSON before invoking the connector method.
/// </summary>
public sealed record ProductExportPayload(
    Guid ProductId,
    Guid ProductSalesChannelId,
    string Sku,
    string Name,
    string? Description,
    decimal Price,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? Currency,
    int Stock,
    string? Ean,
    string? Gtin,
    string? Mpn,
    string? Brand,
    string? RemoteProductId,
    string? ExternalListingId,
    string? MetadataJson);

public sealed record StockUpdatePayload(
    Guid ProductId,
    Guid ProductSalesChannelId,
    string Sku,
    int Quantity,
    string? RemoteProductId,
    string? ParentRemoteProductId = null);

public sealed record PriceUpdatePayload(
    Guid ProductId,
    Guid ProductSalesChannelId,
    string Sku,
    decimal Price,
    string? Currency,
    string? RemoteProductId,
    string? ExternalListingId,
    string? ParentRemoteProductId = null);

public sealed record SalesUpdatePayload(
    Guid SalesId,
    string? RemoteSalesId,
    string Status,
    string? TrackingNumber,
    string? ShippingProvider);

public sealed record DelistPayload(
    Guid ProductSalesChannelId,
    string Sku,
    string? RemoteProductId,
    string? ExternalListingId);

public sealed record CancelSalesPayload(
    Guid SalesId,
    string? RemoteSalesId,
    string? Reason = null);

/// <summary>
/// Create-or-update of a single category. <paramref name="ParentRemoteCategoryId"/> is the
/// channel-side id of the parent (null for roots) — the dispatcher fails the row while the parent
/// is still unexported, so the outbox backoff naturally orders parents before children.
/// </summary>
public sealed record CategoryExportPayload(
    Guid CategoryId,
    Guid CategorySalesChannelId,
    string Name,
    string Slug,
    string? Description,
    int SortOrder,
    string? RemoteCategoryId,
    string? ParentRemoteCategoryId);

public sealed record CategoryDeletePayload(
    Guid CategoryId,
    Guid SalesChannelId,
    string? RemoteCategoryId);

/// <summary>
/// Push of an order's complete tracking-number set. A shop order carries one tracking field, not one
/// per parcel, so the payload transports every number of the order at once and the connector decides
/// how to render them (WooCommerce: comma-separated in the shipment-number order meta).
/// <paramref name="CarrierCode"/> is the channel-side code resolved through the channel's carrier
/// mappings; empty when the providers involved have no mapping.
/// </summary>
public sealed record ShipmentPushPayload(
    Guid SalesId,
    string? RemoteSalesId,
    IReadOnlyList<string> TrackingNumbers,
    string? CarrierCode);

/// <summary>Push of a product's full category assignment set as a partial product update.</summary>
public sealed record ProductCategoriesUpdatePayload(
    Guid ProductId,
    string? RemoteProductId,
    string? ParentRemoteProductId,
    IReadOnlyList<string> RemoteCategoryIds);
