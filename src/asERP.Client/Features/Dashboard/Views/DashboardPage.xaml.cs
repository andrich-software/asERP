using asERP.Client.Features.Dashboard.Models;

namespace asERP.Client.Features.Dashboard.Views;

public sealed partial class DashboardPage : Page
{
    public DashboardPage()
    {
        this.InitializeComponent();
    }

    private async void PeriodOption_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuFlyoutItem item &&
            int.TryParse(item.Tag as string, out var hours) &&
            DataContext is DashboardModel model)
        {
            PeriodLabel.Text = item.Text;
            await model.SetPeriod(hours);
        }
    }

    private async void SalesRow_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button &&
            button.DataContext is RecentSalesItem sales &&
            DataContext is DashboardModel model)
        {
            await model.ViewSales(sales);
        }
    }

    private async void ViewAllSaless_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is DashboardModel model)
        {
            await model.NavigateToSalesList();
        }
    }

    private async void ViewAllProducts_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is DashboardModel model)
        {
            await model.NavigateToProductList();
        }
    }
}
