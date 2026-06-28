using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace asToolkit.Client.Presentation;

/// <summary>
/// Converts a <see cref="ChannelSyncLogLevel"/> to a foreground brush so the log explorer can
/// colour-code severity (errors red, warnings amber, info neutral).
/// </summary>
public class SyncLogLevelToForegroundConverter : IValueConverter
{
    private static readonly SolidColorBrush ErrorBrush = new(Color.FromArgb(255, 220, 38, 38));   // #DC2626
    private static readonly SolidColorBrush WarningBrush = new(Color.FromArgb(255, 217, 119, 6));  // #D97706
    private static readonly SolidColorBrush InfoBrush = new(Color.FromArgb(255, 107, 114, 128));   // #6B7280

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var level = value switch
        {
            ChannelSyncLogLevel l => l,
            int i => (ChannelSyncLogLevel)i,
            _ => ChannelSyncLogLevel.Information,
        };

        return level switch
        {
            ChannelSyncLogLevel.Error or ChannelSyncLogLevel.Critical => ErrorBrush,
            ChannelSyncLogLevel.Warning => WarningBrush,
            _ => InfoBrush,
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
