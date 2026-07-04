using asERP.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Converts PaymentStatus enum to localized display text.
/// Used by enum ComboBox item templates on edit pages. Status CHIPS use the
/// StatusBadge control instead (colors + text via StatusVisuals).
/// </summary>
public class PaymentStatusToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is PaymentStatus status)
        {
            return StatusVisuals.Resolve(status).Text;
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
