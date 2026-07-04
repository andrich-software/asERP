using asERP.Client.Core.Formatting;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Converts decimal values to currency string format.
/// </summary>
public class CurrencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value switch
        {
            decimal decimalValue => CurrencyFormatter.Format(decimalValue),
            double doubleValue => CurrencyFormatter.Format(doubleValue),
            float floatValue => CurrencyFormatter.Format(floatValue),
            int intValue => CurrencyFormatter.Format(intValue),
            _ => value?.ToString() ?? string.Empty
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
