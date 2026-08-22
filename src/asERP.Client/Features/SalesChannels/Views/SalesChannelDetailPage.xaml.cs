using System.Windows.Input;
using asERP.Client.Core.Helpers;
using asERP.Client.Features.SalesChannels.Models;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace asERP.Client.Features.SalesChannels.Views;

public sealed partial class SalesChannelDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["SettingsTab", "LogTab"];

    private int _selectedTabIndex;
    private bool _isInitializing = true;

    public SalesChannelDetailPage()
    {
        this.InitializeComponent();
        this.Loaded += (_, _) => _isInitializing = false;
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelDetailModel model)
        {
            await model.EditSalesChannel();
        }
    }

    private async void DetailTabs_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TabBar tabBar)
        {
            tabBar.SelectedIndex = _selectedTabIndex;
            await ApplySelectedTabAsync(tabBar);
        }
    }

    private async void DetailTabs_SelectionChanged(object? sender, TabBarSelectionChangedEventArgs args)
    {
        if (sender is TabBar { SelectedIndex: >= 0 } tabBar)
        {
            _selectedTabIndex = tabBar.SelectedIndex;
            await ApplySelectedTabAsync(tabBar);
        }
    }

    private async Task ApplySelectedTabAsync(TabBar tabBar)
    {
        TabPanelSwitcher.Apply(tabBar, TabPanelNames, _selectedTabIndex);

        // The log query is gated until the tab is opened the first time — no log traffic
        // for users who only look at the settings.
        if (_selectedTabIndex == 1 && DataContext is SalesChannelDetailModel model)
        {
            await model.ActivateLogTab();
        }
    }

    private async void LogSearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is SalesChannelDetailModel model)
        {
            await model.SetLogSearch(textBox.Text);
        }
    }

    private async void LogLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox comboBox && DataContext is SalesChannelDetailModel model)
        {
            var minLevel = comboBox.SelectedIndex switch
            {
                1 => "Information",
                2 => "Warning",
                3 => "Error",
                _ => string.Empty,
            };
            await model.SetLogLevel(minLevel);
        }
    }

    private void RefreshLogs_Click(object sender, RoutedEventArgs e)
    {
        if (LogsFeedView.Refresh is ICommand command && command.CanExecute(null))
        {
            command.Execute(null);
        }
    }

    private async void PreviousLogPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelDetailModel model)
        {
            await model.GoToPreviousLogPage();
        }
    }

    private async void NextLogPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelDetailModel model)
        {
            await model.GoToNextLogPage();
        }
    }

    private async void LogPageSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox comboBox &&
            comboBox.SelectedItem is ComboBoxItem { Tag: string pageSizeStr } &&
            int.TryParse(pageSizeStr, out var pageSize) &&
            DataContext is SalesChannelDetailModel model)
        {
            await model.SetLogPageSize(pageSize);
        }
    }
}
