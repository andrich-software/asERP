using asToolkit.Client.Features.Auth.Models;
using asToolkit.Client.Features.Auth.Services;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Auth.Views;

/// <summary>
/// Programmatically built dialog for managing the local list of asToolkit servers
/// (add / edit / delete) with live version + reachability badges. Follows the codebase's
/// code-behind <see cref="ContentDialog"/> convention (see Customers/Views/CustomerEditPage).
/// </summary>
public sealed class ServerManagementDialog
{
    private readonly IServerProfileStore _store;
    private readonly IServerInfoService _serverInfo;
    private readonly XamlRoot _xamlRoot;
    private readonly ResourceLoader _resources = ResourceLoader.GetForViewIndependentUse();

    private ContentDialog _dialog = null!;
    private StackPanel _listPanel = null!;
    private FrameworkElement _listView = null!;
    private FrameworkElement _editView = null!;

    private TextBlock _editTitle = null!;
    private TextBox _nameBox = null!;
    private TextBox _urlBox = null!;
    private TextBlock _editError = null!;
    private TextBlock _testResult = null!;

    private ServerProfile? _editing;       // null => adding a new server
    private Guid _pendingDeleteId = Guid.Empty;

    public ServerManagementDialog(IServerProfileStore store, IServerInfoService serverInfo, XamlRoot xamlRoot)
    {
        _store = store;
        _serverInfo = serverInfo;
        _xamlRoot = xamlRoot;
    }

    public async Task ShowAsync()
    {
        Build();
        _dialog.XamlRoot = _xamlRoot;
        ShowList();
        await RefreshListAsync();
        await _dialog.ShowAsync();
    }

    private void Build()
    {
        _listView = BuildListView();
        _editView = BuildEditView();

        var root = new Grid { MinWidth = 440 };
        root.Children.Add(_listView);
        root.Children.Add(_editView);

        _dialog = new ContentDialog
        {
            Title = L("ServerDialog.Title", "Server verwalten"),
            Content = root,
            CloseButtonText = L("ServerDialog.Close", "Schließen"),
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };
    }

    #region List view

    private FrameworkElement BuildListView()
    {
        var panel = new StackPanel { Spacing = 12 };

        _listPanel = new StackPanel { Spacing = 8 };
        var scroller = new ScrollViewer
        {
            Content = _listPanel,
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            MaxHeight = 380
        };

        var addButton = new Button
        {
            Content = MakeIconText("", L("ServerDialog.Add", "Server hinzufügen")),
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        addButton.Click += (_, _) => ShowEdit(null);

        panel.Children.Add(scroller);
        panel.Children.Add(addButton);
        return panel;
    }

    private async Task RefreshListAsync()
    {
        var servers = await _store.GetAllAsync();
        _listPanel.Children.Clear();

        foreach (var server in servers)
        {
            _listPanel.Children.Add(BuildRow(server));
        }

        // Probe each server's version/reachability concurrently and fill its badge.
        foreach (var child in _listPanel.Children)
        {
            if (child is FrameworkElement fe && fe.Tag is ServerRow row)
            {
                _ = UpdateRowStatusAsync(row);
            }
        }
    }

    private FrameworkElement BuildRow(ServerProfile server)
    {
        var status = new TextBlock
        {
            FontSize = 12,
            Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"],
            Margin = new Thickness(0, 2, 0, 0)
        };

        var info = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
        info.Children.Add(new TextBlock { Text = server.Name, FontWeight = FontWeights.SemiBold, FontSize = 14 });
        info.Children.Add(new TextBlock
        {
            Text = server.Url,
            FontSize = 12,
            Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"]
        });
        info.Children.Add(status);
        Grid.SetColumn(info, 0);

        var actions = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 4,
            VerticalAlignment = VerticalAlignment.Center
        };

        if (server.Id == _pendingDeleteId)
        {
            // Inline delete confirmation — a nested ContentDialog cannot be shown on top of this one.
            var confirm = new TextBlock
            {
                Text = L("ServerDialog.DeleteConfirm", "Entfernen?"),
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 12,
                Margin = new Thickness(0, 0, 4, 0)
            };
            var yes = MakeIconButton("", L("ServerDialog.Delete", "Löschen"));
            yes.Click += async (_, _) => { await _store.DeleteAsync(server.Id); _pendingDeleteId = Guid.Empty; await RefreshListAsync(); };
            var no = MakeIconButton("", L("ServerDialog.Cancel", "Abbrechen"));
            no.Click += async (_, _) => { _pendingDeleteId = Guid.Empty; await RefreshListAsync(); };
            actions.Children.Add(confirm);
            actions.Children.Add(yes);
            actions.Children.Add(no);
        }
        else if (server.IsBuiltIn)
        {
            actions.Children.Add(new FontIcon
            {
                Glyph = "",
                FontSize = 14,
                Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"],
                VerticalAlignment = VerticalAlignment.Center
            });
            ToolTipService.SetToolTip(actions, L("ServerDialog.BuiltInHint", "Standardserver (fest hinterlegt)"));
        }
        else
        {
            var edit = MakeIconButton("", L("ServerDialog.Edit", "Bearbeiten"));
            edit.Click += (_, _) => ShowEdit(server);
            var delete = MakeIconButton("", L("ServerDialog.Delete", "Löschen"));
            delete.Click += async (_, _) => { _pendingDeleteId = server.Id; await RefreshListAsync(); };
            actions.Children.Add(edit);
            actions.Children.Add(delete);
        }
        Grid.SetColumn(actions, 1);

        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = GridLength.Auto }
            }
        };
        grid.Children.Add(info);
        grid.Children.Add(actions);

        var card = new Border
        {
            Background = (Brush)Application.Current.Resources["SurfaceVariantBrush"],
            CornerRadius = new CornerRadius(8),
            Padding = new Thickness(14, 12, 14, 12),
            Child = grid,
            Tag = new ServerRow(server, status)
        };
        return card;
    }

    private async Task UpdateRowStatusAsync(ServerRow row)
    {
        row.Status.Text = L("ServerDialog.StatusChecking", "prüfe …");
        row.Status.Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"];

        var info = await _serverInfo.GetServerInfoAsync(row.Server.Url);
        if (info != null)
        {
            row.Status.Text = string.Format(L("ServerDialog.StatusConnectedFormat", "asToolkit v{0} · verbunden"), info.Version);
            row.Status.Foreground = new SolidColorBrush(Colors.SeaGreen);
        }
        else
        {
            row.Status.Text = L("ServerDialog.StatusOffline", "offline");
            row.Status.Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"];
        }
    }

    #endregion

    #region Edit view

    private FrameworkElement BuildEditView()
    {
        var panel = new StackPanel { Spacing = 14, Visibility = Visibility.Collapsed };

        _editTitle = new TextBlock { FontWeight = FontWeights.SemiBold, FontSize = 16 };

        _nameBox = new TextBox
        {
            Header = L("ServerDialog.NameLabel", "Name"),
            PlaceholderText = L("ServerDialog.NamePlaceholder", "z. B. Mein Server")
        };

        _urlBox = new TextBox
        {
            Header = L("ServerDialog.UrlLabel", "Server-URL"),
            PlaceholderText = L("ServerDialog.UrlPlaceholder", "https://...")
        };

        var testRow = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 12, VerticalAlignment = VerticalAlignment.Center };
        var testButton = new Button { Content = L("ServerDialog.TestConnection", "Verbindung testen") };
        testButton.Click += async (_, _) => await TestConnectionAsync();
        _testResult = new TextBlock { FontSize = 12, VerticalAlignment = VerticalAlignment.Center, TextWrapping = TextWrapping.Wrap };
        testRow.Children.Add(testButton);
        testRow.Children.Add(_testResult);

        _editError = new TextBlock
        {
            FontSize = 12,
            Foreground = (Brush)Application.Current.Resources["ErrorBrush"],
            Visibility = Visibility.Collapsed,
            TextWrapping = TextWrapping.Wrap
        };

        var buttons = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, HorizontalAlignment = HorizontalAlignment.Right };
        var cancel = new Button { Content = L("ServerDialog.Cancel", "Abbrechen") };
        cancel.Click += (_, _) => ShowList();
        var save = new Button
        {
            Content = L("ServerDialog.Save", "Speichern"),
            Style = Application.Current.Resources["FilledButtonStyle"] as Style
        };
        save.Click += async (_, _) => await SaveAsync();
        buttons.Children.Add(cancel);
        buttons.Children.Add(save);

        panel.Children.Add(_editTitle);
        panel.Children.Add(_nameBox);
        panel.Children.Add(_urlBox);
        panel.Children.Add(testRow);
        panel.Children.Add(_editError);
        panel.Children.Add(buttons);
        return panel;
    }

    private void ShowList()
    {
        _listView.Visibility = Visibility.Visible;
        _editView.Visibility = Visibility.Collapsed;
        _dialog.Title = L("ServerDialog.Title", "Server verwalten");
    }

    private void ShowEdit(ServerProfile? server)
    {
        _editing = server;
        _nameBox.Text = server?.Name ?? string.Empty;
        _urlBox.Text = server?.Url ?? "https://";
        _editError.Visibility = Visibility.Collapsed;
        _testResult.Text = string.Empty;
        _editTitle.Text = server == null
            ? L("ServerDialog.AddTitle", "Server hinzufügen")
            : L("ServerDialog.EditTitle", "Server bearbeiten");

        _listView.Visibility = Visibility.Collapsed;
        _editView.Visibility = Visibility.Visible;
        _dialog.Title = _editTitle.Text;
    }

    private async Task TestConnectionAsync()
    {
        var url = ServerUrlUtil.Normalize(_urlBox.Text);
        if (!ServerUrlUtil.IsValid(url))
        {
            _testResult.Text = L("ServerDialog.ValidationUrl", "Bitte eine gültige URL eingeben.");
            _testResult.Foreground = (Brush)Application.Current.Resources["ErrorBrush"];
            return;
        }

        _testResult.Text = L("ServerDialog.TestChecking", "Verbinde …");
        _testResult.Foreground = (Brush)Application.Current.Resources["OnSurfaceVariantBrush"];

        var info = await _serverInfo.GetServerInfoAsync(url);
        if (info != null)
        {
            _testResult.Text = string.Format(L("ServerDialog.TestSuccessFormat", "Verbindung erfolgreich · asToolkit v{0}"), info.Version);
            _testResult.Foreground = new SolidColorBrush(Colors.SeaGreen);
        }
        else
        {
            _testResult.Text = L("ServerDialog.TestFailed", "Server nicht erreichbar");
            _testResult.Foreground = (Brush)Application.Current.Resources["ErrorBrush"];
        }
    }

    private async Task SaveAsync()
    {
        var name = _nameBox.Text?.Trim();
        var url = ServerUrlUtil.Normalize(_urlBox.Text);

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowEditError(L("ServerDialog.ValidationName", "Bitte einen Namen eingeben."));
            return;
        }
        if (!ServerUrlUtil.IsValid(url))
        {
            ShowEditError(L("ServerDialog.ValidationUrl", "Bitte eine gültige URL eingeben."));
            return;
        }

        var profile = _editing ?? new ServerProfile { Id = Guid.NewGuid() };
        profile.Name = name;
        profile.Url = url;

        await _store.UpsertAsync(profile);
        ShowList();
        await RefreshListAsync();
    }

    private void ShowEditError(string message)
    {
        _editError.Text = message;
        _editError.Visibility = Visibility.Visible;
    }

    #endregion

    #region Helpers

    private static FrameworkElement MakeIconText(string glyph, string text)
    {
        var panel = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, HorizontalAlignment = HorizontalAlignment.Center };
        panel.Children.Add(new FontIcon { Glyph = glyph, FontSize = 14, VerticalAlignment = VerticalAlignment.Center });
        panel.Children.Add(new TextBlock { Text = text, VerticalAlignment = VerticalAlignment.Center });
        return panel;
    }

    private static Button MakeIconButton(string glyph, string tooltip)
    {
        var button = new Button
        {
            Content = new FontIcon { Glyph = glyph, FontSize = 15 },
            Background = new SolidColorBrush(Colors.Transparent),
            BorderThickness = new Thickness(0),
            Padding = new Thickness(8),
            MinWidth = 0
        };
        ToolTipService.SetToolTip(button, tooltip);
        return button;
    }

    private string L(string key, string fallback)
    {
        try
        {
            var value = _resources.GetString(key);
            return string.IsNullOrEmpty(value) ? fallback : value;
        }
        catch
        {
            return fallback;
        }
    }

    private sealed record ServerRow(ServerProfile Server, TextBlock Status);

    #endregion
}
