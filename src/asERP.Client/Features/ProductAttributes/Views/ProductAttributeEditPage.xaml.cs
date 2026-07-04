using asERP.Client.Features.ProductAttributes.Models;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.ProductAttributes.Views;

public sealed partial class ProductAttributeEditPage : Page
{
    public ProductAttributeEditPage()
    {
        this.InitializeComponent();
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductAttributeEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductAttributeEditModel model)
        {
            await model.SaveAsync();
        }
    }

    private void AddValue_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductAttributeEditModel model)
        {
            model.AddValue();
        }
    }

    private void RemoveValue_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { DataContext: ProductAttributeValueRow row } &&
            DataContext is ProductAttributeEditModel model)
        {
            model.RemoveValue(row);
        }
    }
}
