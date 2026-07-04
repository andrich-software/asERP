using asToolkit.Client.Features.Shippings.Models;
using asToolkit.Client.Features.Shippings.Services;
using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asToolkit.Client.Features.Shippings;

/// <summary>
/// Converts a nullable DateTime to a local date + time string ("g"); null stays empty so
/// LabeledField shows its "N/A" placeholder. (The global DateTimeOffsetToStringConverter
/// only handles DateTimeOffset.)
/// </summary>
public class NullableDateTimeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is DateTime dateTime ? dateTime.ToLocalTime().ToString("g") : string.Empty;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the cancel-shipment action while <see cref="SalesShipmentRules.CanCancelShipment"/>
/// allows it (delegates to the tested rule instead of duplicating status lists in XAML).
/// </summary>
public class CanCancelShipmentToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ShippingStatus status && SalesShipmentRules.CanCancelShipment(status)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the "Versenden" order action while <see cref="SalesShipmentRules.CanShip"/> allows it.
/// </summary>
public class SalesStatusToShipVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SalesStatus status && SalesShipmentRules.CanShip(status)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the "Stornieren" order action while <see cref="SalesShipmentRules.CanCancel"/> allows it.
/// </summary>
public class SalesStatusToCancelVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SalesStatus status && SalesShipmentRules.CanCancel(status)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the label-retry action only when the label-outbox row dead-lettered.
/// </summary>
public class DeadLetterToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ShippingOutboxStatus.DeadLetter ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the label-queue warning card while a label-outbox row exists and is not done.
/// </summary>
public class OutboxWarningToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ShippingOutboxStatus status && status != ShippingOutboxStatus.Done
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows a label action button when the shipment has a label (bound value) AND the current
/// platform supports the capability named in the converter parameter ("Save", "Download",
/// "Print" — or "Open" for the fallback button shown when no capability is available).
/// Capabilities are fixed per platform, so a static lookup is safe.
/// </summary>
public class LabelCapabilityToVisibilityConverter : IValueConverter
{
    private static readonly Lazy<LabelCapabilities> _capabilities = new(() =>
        (Application.Current as App)?.Host?.Services.GetService<ILabelService>()?.Capabilities
        ?? LabelCapabilities.None);

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is not true)
        {
            return Visibility.Collapsed;
        }

        var capabilities = _capabilities.Value;
        var supported = parameter as string switch
        {
            "Save" => capabilities.HasFlag(LabelCapabilities.Save),
            "Download" => capabilities.HasFlag(LabelCapabilities.Download),
            "Print" => capabilities.HasFlag(LabelCapabilities.Print),
            "Open" => capabilities == LabelCapabilities.None,
            _ => false,
        };

        return supported ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}
