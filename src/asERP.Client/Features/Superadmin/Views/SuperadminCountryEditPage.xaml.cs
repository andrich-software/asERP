using asERP.Client.Features.Superadmin.Models;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.Superadmin.Views;

public sealed partial class SuperadminCountryEditPage : Page
{
    public SuperadminCountryEditPage()
    {
        this.InitializeComponent();
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminCountryEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminCountryEditModel model)
        {
            await model.SaveAsync();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SuperadminCountryEditModel model)
        {
            return;
        }

        var dialog = new ContentDialog
        {
            Title = model.DeleteConfirmTitle,
            Content = model.DeleteConfirmMessage,
            PrimaryButtonText = model.DeleteConfirmAccept,
            CloseButtonText = model.DeleteConfirmCancel,
            DefaultButton = ContentDialogButton.Close,
            XamlRoot = this.XamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            await model.DeleteAsync();
        }
    }
}
