using maERP.Client.Features.Saless.Models;
using Microsoft.UI.Xaml.Controls;

namespace maERP.Client.Features.Saless.Views;

public sealed partial class SalesDetailPage : Page
{
    public SalesDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesDetailModel model)
        {
            await model.EditSales();
        }
    }

    private async void CustomerLink_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid customerId } &&
            DataContext is SalesDetailModel model)
        {
            await model.NavigateToCustomer(customerId);
        }
    }
}
