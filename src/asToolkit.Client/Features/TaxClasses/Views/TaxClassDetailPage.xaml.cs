using asToolkit.Client.Features.TaxClasses.Models;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Features.TaxClasses.Views;

public sealed partial class TaxClassDetailPage : Page
{
    public TaxClassDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaxClassDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaxClassDetailModel model)
        {
            await model.EditTaxClass();
        }
    }
}
