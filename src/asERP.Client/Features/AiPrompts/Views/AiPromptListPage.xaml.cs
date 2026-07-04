using asERP.Client.Controls;
using asERP.Client.Features.AiPrompts.Models;
using asERP.Domain.Dtos.AiPrompt;

namespace asERP.Client.Features.AiPrompts.Views;

public sealed partial class AiPromptListPage : Page
{
    private bool _isInitializing = true;

    public AiPromptListPage()
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
        if (sender is TextBox textBox && DataContext is AiPromptListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is AiPromptListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateAiPrompt_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiPromptListModel model)
        {
            await model.CreateAiPrompt();
        }
    }

    private async void AiPromptRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is AiPromptListDto aiPrompt &&
            DataContext is AiPromptListModel model)
        {
            await model.ViewAiPromptDetail(aiPrompt.Id);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiPromptListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is AiPromptListModel model)
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
            DataContext is AiPromptListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
