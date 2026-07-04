using asToolkit.Client.Features.GlobalSettings.Models;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace asToolkit.Client.Features.GlobalSettings.Views;

public sealed partial class GlobalSettingsPage : Page
{
    private static readonly string[] TabPanelNames =
        ["OAuthTab", "GeneralTab", "EmailTab", "AuthenticationTab", "ObservabilityTab"];

    private int _selectedTabIndex;

    public GlobalSettingsPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is GlobalSettingsModel model) await model.GoBackAsync();
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is GlobalSettingsModel model) await model.SaveAsync();
    }

    private void SettingsTabs_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TabBar tabBar)
        {
            tabBar.SelectedIndex = _selectedTabIndex;
            ApplySelectedTab();
        }
    }

    private void SettingsTabs_SelectionChanged(object? sender, TabBarSelectionChangedEventArgs args)
    {
        if (sender is TabBar { SelectedIndex: >= 0 } tabBar)
        {
            _selectedTabIndex = tabBar.SelectedIndex;
            ApplySelectedTab();
        }
    }

    private void ApplySelectedTab()
    {
        for (var i = 0; i < TabPanelNames.Length; i++)
        {
            if (FindName(TabPanelNames[i]) is UIElement panel)
            {
                panel.Visibility = i == _selectedTabIndex ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
