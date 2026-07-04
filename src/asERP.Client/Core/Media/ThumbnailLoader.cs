using System.IO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

namespace asERP.Client.Core.Media;

/// <summary>
/// Attached helper that loads a product thumbnail into an <see cref="Image"/> asynchronously,
/// after the list row is shown. Combined with a virtualized ListView this gives lazy
/// thumbnail loading for free: only realized containers trigger a load.
/// Pending loads are cancelled when the container is recycled (Request changes), and the
/// decode is capped via <see cref="BitmapImage.DecodePixelWidth"/> instead of decoding the
/// full-size image for a ~36px slot.
///
/// Usage: &lt;Image media:ThumbnailLoader.Request="{x:Bind ThumbnailRequest}" /&gt;
/// </summary>
public static class ThumbnailLoader
{
    /// <summary>2x the 36px list slot, for high-DPI screens.</summary>
    private const int DecodeWidth = 72;

    public static readonly DependencyProperty RequestProperty =
        DependencyProperty.RegisterAttached(
            "Request", typeof(ThumbnailRequest), typeof(ThumbnailLoader),
            new PropertyMetadata(null, OnRequestChanged));

    public static ThumbnailRequest? GetRequest(DependencyObject obj)
        => (ThumbnailRequest?)obj.GetValue(RequestProperty);

    public static void SetRequest(DependencyObject obj, ThumbnailRequest? value)
        => obj.SetValue(RequestProperty, value);

    private static readonly DependencyProperty PendingLoadProperty =
        DependencyProperty.RegisterAttached(
            "PendingLoad", typeof(CancellationTokenSource), typeof(ThumbnailLoader),
            new PropertyMetadata(null));

    private static async void OnRequestChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Image image)
        {
            return;
        }

        // Recycled container: stop the previous load so a slow response cannot
        // flash the wrong product's image into this row.
        if (image.GetValue(PendingLoadProperty) is CancellationTokenSource previous)
        {
            previous.Cancel();
        }

        image.Source = null;

        if (e.NewValue is not ThumbnailRequest request)
        {
            return;
        }

        var cts = new CancellationTokenSource();
        image.SetValue(PendingLoadProperty, cts);

        try
        {
            var cache = App.Current.Services.GetRequiredService<IThumbnailCache>();
            var bytes = await cache.GetOrLoadAsync(request, cts.Token);

            // Only apply if this Image still targets the same request.
            if (bytes is { Length: > 0 } && !cts.IsCancellationRequested && Equals(GetRequest(image), request))
            {
                var bitmap = new BitmapImage { DecodePixelWidth = DecodeWidth };
                using var stream = new MemoryStream(bytes);
                bitmap.SetSource(stream.AsRandomAccessStream());
                image.Source = bitmap;
            }
        }
        catch
        {
            // A missing thumbnail must not break the list.
        }
    }
}
