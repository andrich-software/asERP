using System.Text.Json;

namespace asERP.Domain.Entities;

/// <summary>
/// Resource keys and argument encoding for localized <see cref="SalesHistory"/> entries.
///
/// The server never stores display text for the timeline: it stores a key plus its arguments and
/// the client resolves both against its own resources. <see cref="SalesHistory.Description"/> stays
/// the English audit text and doubles as the fallback for entries written before this existed.
///
/// Every argument is looked up as a resource key with itself as the fallback, so an argument may be
/// either literal text (a channel or carrier name) or an enum token such as "SalesStatus.Processing"
/// — the same key shape the client's StatusVisuals builds for status chips. Literal text only fails
/// this if it happens to equal a resource key verbatim, which no realistic channel name does.
/// </summary>
public static class SalesHistoryMessage
{
    public const string OrderImported = "SalesHistory.OrderImported";
    public const string ChannelOrderStatusChanged = "SalesHistory.ChannelOrderStatusChanged";
    public const string ChannelPaymentStatusChanged = "SalesHistory.ChannelPaymentStatusChanged";
    public const string ChannelOrderAndPaymentStatusChanged = "SalesHistory.ChannelOrderAndPaymentStatusChanged";
    public const string OrderCancelled = "SalesHistory.OrderCancelled";
    public const string OrderStatusAutoFromShipment = "SalesHistory.OrderStatusAutoFromShipment";
    public const string OrderFullyReturned = "SalesHistory.OrderFullyReturned";
    public const string ShipmentCreated = "SalesHistory.ShipmentCreated";
    public const string ShippingStatusChanged = "SalesHistory.ShippingStatusChanged";
    public const string ShippingStatusChangedWithCarrierNote = "SalesHistory.ShippingStatusChangedWithCarrierNote";
    public const string ReturnRequested = "SalesHistory.ReturnRequested";
    public const string ReturnStatusChanged = "SalesHistory.ReturnStatusChanged";
    public const string ReturnStatusChangedWithNote = "SalesHistory.ReturnStatusChangedWithNote";

    /// <summary>Resource key for an enum value, matching the client's status resources.</summary>
    public static string Enum<TEnum>(TEnum value) where TEnum : struct, System.Enum
        => $"{typeof(TEnum).Name}.{value}";

    /// <summary>Resource key for a status already persisted as its enum name (ShippingStatusOld/New).</summary>
    public static string Enum(string enumTypeName, string value) => $"{enumTypeName}.{value}";

    public static string? EncodeArgs(params string[] args)
        => args.Length == 0 ? null : JsonSerializer.Serialize(args);

    public static List<string> DecodeArgs(string? encoded)
    {
        if (string.IsNullOrEmpty(encoded))
        {
            return new List<string>();
        }

        try
        {
            return JsonSerializer.Deserialize<List<string>>(encoded) ?? new List<string>();
        }
        catch (JsonException)
        {
            // A malformed payload must never break the timeline — the caller falls back to Description.
            return new List<string>();
        }
    }
}
