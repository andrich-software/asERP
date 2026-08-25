using asERP.Client.Features.Categories.Models;

namespace asERP.Client.Features.Categories.Views;

public sealed partial class CategoryEditPage : Page
{
    public CategoryEditPage()
    {
        InitializeComponent();
    }

    private CategoryEditModel? Model => DataContext as CategoryEditModel;

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.SaveAsync();
        }
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.CancelAsync();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.DeleteAsync(XamlRoot);
        }
    }
}
