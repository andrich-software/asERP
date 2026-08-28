using asERP.Domain.Dtos.Sales;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Renders a <see cref="SalesHistoryDto"/> as localized timeline text. Bound to the entry itself
/// ({Binding Converter=...}) because the text is assembled from the key, its arguments and the
/// English fallback description together.
/// </summary>
public class SalesHistoryToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is SalesHistoryDto entry)
        {
            return HistoryMessageFormatter.Format(entry.MessageKey, entry.MessageArgs, entry.Description);
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
