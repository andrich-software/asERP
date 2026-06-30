using asToolkit.Client.Features.Dashboard.Models;
using asToolkit.Client.Features.SalesChannelDashboards.Models;
using Windows.ApplicationModel.DataTransfer;

namespace asToolkit.Client.Features.SalesChannelDashboards.Views;

public sealed partial class SalesChannelDashboardPage : Page
{
    private static readonly TimeSpan AutoRefreshInterval = TimeSpan.FromSeconds(30);
    private readonly DispatcherTimer _refreshTimer;

    public SalesChannelDashboardPage()
    {
        this.InitializeComponent();

        _refreshTimer = new DispatcherTimer { Interval = AutoRefreshInterval };
        _refreshTimer.Tick += RefreshTimer_Tick;

        DataContextChanged += OnDataContextChanged;
        Loaded += (_, _) => _refreshTimer.Start();
        Unloaded += (_, _) => _refreshTimer.Stop();
    }

    /// <summary>
    /// The Web-Statistics tab only applies to channel types that ship a tracking plugin.
    /// It is removed from the Pivot here rather than collapsed via a bound Visibility on the
    /// PivotItem — Uno's Pivot mis-arranges its items when a PivotItem carries a Visibility,
    /// causing all tab contents to overlap.
    /// </summary>
    private void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (args.NewValue is SalesChannelDashboardModel model
            && !model.ShowWebStatistics
            && DashboardPivot.Items.Contains(WebStatisticsTab))
        {
            DashboardPivot.Items.Remove(WebStatisticsTab);
        }
    }

    private async void RefreshTimer_Tick(object? sender, object e)
    {
        if (this.DataContext is SalesChannelDashboardModel model)
        {
            await model.RefreshAsync();
        }
    }

    private async void SalesRow_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is RecentSalesItem sales)
        {
            if (this.DataContext is SalesChannelDashboardModel model)
            {
                await model.ViewSales(sales);
            }
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is SalesChannelDashboardModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is SalesChannelDashboardModel model)
        {
            await model.GoToNextPage();
        }
    }

    private async void SyncNow_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button
            && button.DataContext is SyncOperationCardData card
            && this.DataContext is SalesChannelDashboardModel model)
        {
            await model.TriggerSync(card.OperationToken);
        }
    }

    private async void RetryDeadLetter_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is SalesChannelDashboardModel model)
        {
            await model.RetryDeadLetters();
        }
    }

    private async void CopyLog_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is SalesChannelDashboardModel model)
        {
            var text = await model.BuildLogClipboardTextAsync();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var package = new DataPackage();
            package.SetText(text);
            Clipboard.SetContent(package);
        }
    }
}
