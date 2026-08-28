using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Formats a <see cref="DateTimeOffset"/> or <see cref="DateTime"/> for display.
/// Pass a standard/custom format string as ConverterParameter (default: "d").
/// </summary>
public class DateTimeOffsetToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var format = parameter as string ?? "d";

        return value switch
        {
            DateTimeOffset dateTimeOffset => dateTimeOffset.LocalDateTime.ToString(format),

            // Server timestamps are stored as "timestamp with time zone" and arrive as Kind.Utc.
            // Anything else (a plain date such as InvoiceDate) is rendered as-is — shifting a
            // date of unknown origin could move it across midnight.
            DateTime { Kind: DateTimeKind.Utc } utc => utc.ToLocalTime().ToString(format),
            DateTime dateTime => dateTime.ToString(format),

            _ => string.Empty
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
