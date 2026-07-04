using asToolkit.Domain.Enums;

namespace asToolkit.Client.Features.Shippings.Models;

/// <summary>x:Bind functions for the shipment tracking-timeline templates.
/// History entries carry status names as strings — parse them back to the enum so
/// <c>StatusBadge</c>/<c>StatusVisuals</c> resolve localized text and colors.</summary>
public static class ShippingTimelineVisuals
{
    /// <summary>Parsed <see cref="ShippingStatus"/> for the badge, or the raw string when
    /// the value is not a known enum name (StatusVisuals falls back to plain text).</summary>
    public static object? BadgeStatus(string? status) =>
        Enum.TryParse<ShippingStatus>(status, out var parsed) ? parsed : status;

    public static Visibility HasStatus(string? status) =>
        string.IsNullOrWhiteSpace(status) ? Visibility.Collapsed : Visibility.Visible;

    /// <summary>System-generated entries (tracking poller etc.) are dimmed.</summary>
    public static double EntryOpacity(bool isSystemGenerated) => isSystemGenerated ? 0.6 : 1.0;

    /// <summary>Local date + time of a timeline entry.</summary>
    public static string FormatTimestamp(DateTime value) =>
        value.ToLocalTime().ToString("g");
}
