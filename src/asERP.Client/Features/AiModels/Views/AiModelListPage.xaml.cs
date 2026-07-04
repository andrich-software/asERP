using asERP.Client.Controls;
using asERP.Client.Features.AiModels.Models;
using asERP.Domain.Dtos.AiModel;

namespace asERP.Client.Features.AiModels.Views;

public sealed partial class AiModelListPage : Page
{
    private bool _isInitializing = true;

    public AiModelListPage()
    {
        this.InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _isInitializing = false;
    }

    private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is AiModelListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is AiModelListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateAiModel_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiModelListModel model)
        {
            await model.CreateAiModel();
        }
    }

    private async void AiModelRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is AiModelListDto aiModel &&
            DataContext is AiModelListModel model)
        {
            await model.ViewAiModel(aiModel.Id);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiModelListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiModelListModel model)
        {
            await model.GoToNextPage();
        }
    }

    private async void PageSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox comboBox &&
            comboBox.SelectedItem is ComboBoxItem selectedItem &&
            selectedItem.Tag is string pageSizeStr &&
            int.TryParse(pageSizeStr, out var pageSize) &&
            DataContext is AiModelListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
