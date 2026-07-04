using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Collapses when the value is null (or an empty/whitespace string), visible otherwise.
/// Used by the shared controls to hide empty template slots.
/// </summary>
public class ObjectToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, string language)
    {
        var visible = value switch
        {
            null => false,
            string s => !string.IsNullOrWhiteSpace(s),
            _ => true,
        };
        return visible ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
