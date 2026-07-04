using System.Windows.Input;
using asToolkit.Client.Core.Helpers;
using asToolkit.Client.Features.Shippings.Models;
using asToolkit.Client.Features.Shippings.Services;

namespace asToolkit.Client.Features.Shippings.Views;

public sealed partial class ShippingDetailPage : Page
{
    public ShippingDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShippingDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void SalesLink_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid salesId } &&
            DataContext is ShippingDetailModel model)
        {
            await model.NavigateToSales(salesId);
        }
    }

    private async void OpenTracking_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: string url } &&
            Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }

    private async void SaveLabel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            await LabelActionRunner.RunAsync(shippingId, LabelAction.Save, printerName: null);
        }
    }

    private async void DownloadLabel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            await LabelActionRunner.RunAsync(shippingId, LabelAction.Download, printerName: null);
        }
    }

    private async void PrintLabel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button { CommandParameter: Guid shippingId } || this.XamlRoot is not { } xamlRoot)
        {
            return;
        }

        // Desktop-Windows shows a printer picker (remembered printer preselected);
        // on WASM the browser's print dialog handles printer selection itself.
        var (confirmed, printerName) = await LabelActionRunner.PickPrinterAsync(xamlRoot);
        if (confirmed)
        {
            await LabelActionRunner.RunAsync(shippingId, LabelAction.Print, printerName);
        }
    }

    private async void OpenLabel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            // No platform capability — RunAsync falls back to the system default app.
            await LabelActionRunner.RunAsync(shippingId, LabelAction.Save, printerName: null);
        }
    }

    private async void PackingSlip_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            await PackingSlipActionRunner.RunAsync(shippingId, this.XamlRoot);
        }
    }

    private async void RetryLabel_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShippingDetailModel model && await model.RetryLabel())
        {
            RefreshFeed();
        }
    }

    private async void CancelShipment_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ShippingDetailModel model || this.XamlRoot is not { } xamlRoot)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "ShippingDetailPage.CancelConfirmTitle",
            "ShippingDetailPage.CancelConfirmMessage",
            confirmKey: "Common.Confirm");

        if (confirmed && await model.CancelShipment())
        {
            RefreshFeed();
        }
    }

    private void RefreshFeed()
    {
        if (ShippingFeedView.Refresh is ICommand command && command.CanExecute(null))
        {
            command.Execute(null);
        }
    }
}
