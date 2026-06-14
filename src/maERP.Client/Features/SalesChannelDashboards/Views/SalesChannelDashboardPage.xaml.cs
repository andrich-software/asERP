using maERP.Client.Features.Dashboard.Models;
using maERP.Client.Features.SalesChannelDashboards.Models;

namespace maERP.Client.Features.SalesChannelDashboards.Views;

public sealed partial class SalesChannelDashboardPage : Page
{
    private static readonly TimeSpan AutoRefreshInterval = TimeSpan.FromSeconds(30);
    private readonly DispatcherTimer _refreshTimer;

    public SalesChannelDashboardPage()
    {
        this.InitializeComponent();

        _refreshTimer = new DispatcherTimer { Interval = AutoRefreshInterval };
        _refreshTimer.Tick += RefreshTimer_Tick;

        Loaded += (_, _) => _refreshTimer.Start();
        Unloaded += (_, _) => _refreshTimer.Stop();
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
}
