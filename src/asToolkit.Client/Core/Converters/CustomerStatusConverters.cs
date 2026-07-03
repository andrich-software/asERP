using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asToolkit.Client.Presentation;

/// <summary>
/// Converts CustomerStatus enum to localized display text.
/// Used by enum ComboBox item templates on edit pages. Status CHIPS use the
/// StatusBadge control instead (colors + text via StatusVisuals).
/// </summary>
public class CustomerStatusToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is CustomerStatus status)
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
