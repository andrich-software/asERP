using asERP.Client.Features.Categories.Models;

namespace asERP.Client.Features.Categories.Views;

public sealed partial class CategoryListPage : Page
{
    public CategoryListPage()
    {
        InitializeComponent();
    }

    private CategoryListModel? Model => DataContext as CategoryListModel;

    private async void Refresh_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.RefreshAsync();
        }
    }

    private async void Save_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.SaveAsync();
        }
    }

    private void Discard_Click(object sender, RoutedEventArgs e)
    {
        Model?.DiscardChanges();
    }

    private async void CreateCategory_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.CreateCategoryAsync();
        }
    }

    private async void CategoryRow_Click(object sender, ItemClickEventArgs e)
    {
        if (Model is { } model && e.ClickedItem is CategoryRow row)
        {
            await model.EditCategoryAsync(row);
        }
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Model is { } model && sender is TextBox textBox)
        {
            model.SearchText = textBox.Text;
        }
    }
}
