using asToolkit.Client.Features.Customers.Models;
using asToolkit.Domain.Dtos.Sales;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Customers.Views;

public sealed partial class CustomerDetailPage : Page
{
    public CustomerDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            await model.EditCustomer();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            var confirmed = await ShowDeleteConfirmationAsync();
            if (confirmed)
            {
                await model.DeleteCustomer(CancellationToken.None);
            }
        }
    }

    private async void SalesRow_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model &&
            sender is FrameworkElement { DataContext: SalesListDto sales })
        {
            await model.ViewSales(sales);
        }
    }

    private async Task<bool> ShowDeleteConfirmationAsync()
    {
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        var dialog = new ContentDialog
        {
            Title = resourceLoader.GetString("CustomerDetailPage.DeleteConfirmation.Title"),
            Content = resourceLoader.GetString("CustomerDetailPage.DeleteConfirmation.Message"),
            PrimaryButtonText = resourceLoader.GetString("Common.Delete"),
            CloseButtonText = resourceLoader.GetString("Common.Cancel"),
            DefaultButton = ContentDialogButton.Close,
            XamlRoot = this.XamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };

        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}
