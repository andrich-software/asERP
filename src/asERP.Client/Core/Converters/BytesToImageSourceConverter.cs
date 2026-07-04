using System.IO;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;

namespace asERP.Client.Presentation;

/// <summary>
/// Converts a <see cref="byte"/>[] (raw PNG image bytes) into an <see cref="ImageSource"/>.
/// Runs on the UI thread during binding, which is where a BitmapImage must be materialized.
/// Used to display authed product images fetched via the token-attaching HttpClient.
/// </summary>
public class BytesToImageSourceConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is byte[] { Length: > 0 } bytes)
        {
            var bitmap = new BitmapImage();
            var stream = new MemoryStream(bytes);
            bitmap.SetSource(stream.AsRandomAccessStream());
            return bitmap;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
