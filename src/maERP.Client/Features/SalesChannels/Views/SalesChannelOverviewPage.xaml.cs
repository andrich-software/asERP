using System.Windows.Input;
using maERP.Client.Features.SalesChannels.Models;

namespace maERP.Client.Features.SalesChannels.Views;

public sealed partial class SalesChannelOverviewPage : Page
{
    private static readonly TimeSpan AutoRefreshInterval = TimeSpan.FromSeconds(60);
    private readonly DispatcherTimer _refreshTimer;

    public SalesChannelOverviewPage()
    {
        this.InitializeComponent();

        _refreshTimer = new DispatcherTimer { Interval = AutoRefreshInterval };
        _refreshTimer.Tick += RefreshTimer_Tick;

        Loaded += (_, _) => _refreshTimer.Start();
        Unloaded += (_, _) => _refreshTimer.Stop();
    }

    private void RefreshTimer_Tick(object? sender, object e)
    {
        // Reuse the FeedView's built-in Refresh command — the same one the manual button triggers.
        if (OverviewFeedView.Refresh is ICommand command && command.CanExecute(null))
        {
            command.Execute(null);
        }
    }

    private async void ChannelCard_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button &&
            button.DataContext is SalesChannelOverviewItem item &&
            DataContext is SalesChannelOverviewModel model)
        {
            await model.OpenChannel(item);
        }
    }

    private async void ManageList_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelOverviewModel model)
        {
            await model.OpenChannelList();
        }
    }
}
