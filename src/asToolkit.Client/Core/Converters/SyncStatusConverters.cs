using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace asToolkit.Client.Presentation;

/// <summary>
/// Converts boolean sync status to background brush color.
/// Only used by the dashboard's Active/Paused chip (custom wording); regular
/// enabled/disabled chips use the StatusBadge control.
/// </summary>
public class BoolToSyncStatusBackgroundConverter : IValueConverter
{
    private static readonly SolidColorBrush EnabledBrush = new(Color.FromArgb(255, 220, 252, 231)); // #DCFCE7 (green background)
    private static readonly SolidColorBrush DisabledBrush = new(Color.FromArgb(255, 243, 244, 246)); // #F3F4F6 (gray background)

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool isEnabled)
        {
            return isEnabled ? EnabledBrush : DisabledBrush;
        }
        return DisabledBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts boolean sync status to foreground brush color.
/// </summary>
public class BoolToSyncStatusForegroundConverter : IValueConverter
{
    private static readonly SolidColorBrush EnabledBrush = new(Color.FromArgb(255, 22, 163, 74)); // #16A34A (green text)
    private static readonly SolidColorBrush DisabledBrush = new(Color.FromArgb(255, 107, 114, 128)); // #6B7280 (gray text)

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool isEnabled)
        {
            return isEnabled ? EnabledBrush : DisabledBrush;
        }
        return DisabledBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Maps a <see cref="ChannelSyncRunStatus"/> (or null = never run) to a status-badge brush. Use
/// ConverterParameter="Background" for the soft fill and "Foreground" for the saturated text colour.
/// </summary>
public class SyncRunStatusToBrushConverter : IValueConverter
{
    // Background (soft) / Foreground (saturated) per status.
    private static readonly SolidColorBrush RunningBg = new(Color.FromArgb(255, 219, 234, 254));     // #DBEAFE
    private static readonly SolidColorBrush RunningFg = new(Color.FromArgb(255, 37, 99, 235));        // #2563EB
    private static readonly SolidColorBrush SuccessBg = new(Color.FromArgb(255, 220, 252, 231));      // #DCFCE7
    private static readonly SolidColorBrush SuccessFg = new(Color.FromArgb(255, 22, 163, 74));        // #16A34A
    private static readonly SolidColorBrush PartialBg = new(Color.FromArgb(255, 254, 243, 199));      // #FEF3C7
    private static readonly SolidColorBrush PartialFg = new(Color.FromArgb(255, 217, 119, 6));        // #D97706
    private static readonly SolidColorBrush FailedBg = new(Color.FromArgb(255, 254, 226, 226));       // #FEE2E2
    private static readonly SolidColorBrush FailedFg = new(Color.FromArgb(255, 220, 38, 38));         // #DC2626
    private static readonly SolidColorBrush NeutralBg = new(Color.FromArgb(255, 243, 244, 246));      // #F3F4F6
    private static readonly SolidColorBrush NeutralFg = new(Color.FromArgb(255, 107, 114, 128));      // #6B7280

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var foreground = string.Equals(parameter as string, "Foreground", StringComparison.OrdinalIgnoreCase);

        var status = value switch
        {
            ChannelSyncRunStatus s => (ChannelSyncRunStatus?)s,
            int i => (ChannelSyncRunStatus?)i,
            _ => null,
        };

        return status switch
        {
            ChannelSyncRunStatus.Running => foreground ? RunningFg : RunningBg,
            // Queued shares the Running palette: the user pressed the button and work is on its way.
            ChannelSyncRunStatus.Queued => foreground ? RunningFg : RunningBg,
            ChannelSyncRunStatus.Success => foreground ? SuccessFg : SuccessBg,
            ChannelSyncRunStatus.PartialFailure => foreground ? PartialFg : PartialBg,
            ChannelSyncRunStatus.Failed => foreground ? FailedFg : FailedBg,
            _ => foreground ? NeutralFg : NeutralBg,
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
