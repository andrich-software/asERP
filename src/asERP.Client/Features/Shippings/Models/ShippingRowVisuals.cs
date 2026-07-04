namespace asERP.Client.Features.Shippings.Models;

/// <summary>x:Bind functions for shipping list row templates — avoids per-row converter instances.</summary>
public static class ShippingRowVisuals
{
    public static Visibility ProblemVisibility(bool isProblem) =>
        isProblem ? Visibility.Visible : Visibility.Collapsed;

    public static Visibility HasText(string? value) =>
        string.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;

    public static Visibility NoText(string? value) =>
        string.IsNullOrWhiteSpace(value) ? Visibility.Visible : Visibility.Collapsed;

    public static Visibility Visible(bool value) =>
        value ? Visibility.Visible : Visibility.Collapsed;

    /// <summary>Short local date or empty — ShippedAt is null until the carrier accepts the parcel.</summary>
    public static string FormatDate(DateTime? value) =>
        value?.ToLocalTime().ToString("d") ?? string.Empty;

    public static string FormatDateTime(DateTime? value) =>
        value?.ToLocalTime().ToString("g") ?? string.Empty;
}
