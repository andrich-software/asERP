using asERP.Server.Tray.Models;
using asERP.Server.Tray.Services;

namespace asERP.Server.Tray.Forms;

/// <summary>
/// Edits the server settings the tray owns: database provider + connection string,
/// image/file storage path, HTTP port and tray autostart. Saving patches
/// %ProgramData%\asERP\settings.json; the caller offers a service restart.
/// </summary>
internal sealed class SettingsForm : Form
{
    private static readonly string[] Providers = ["Sqlite", "PostgreSQL", "MSSQL"];

    private readonly ComboBox _providerBox;
    private readonly TextBox _connectionStringBox;
    private readonly Button _testConnectionButton;
    private readonly TextBox _storagePathBox;
    private readonly NumericUpDown _portBox;
    private readonly CheckBox _autostartBox;

    private string _lastProvider;

    public bool SettingsChanged { get; private set; }

    public SettingsForm(ServerSettings settings)
    {
        // The layout below uses fixed 96-DPI pixel coordinates; declare that baseline so WinForms
        // auto-scales the whole dialog (and its fonts) on high-DPI displays (e.g. a 150 % laptop).
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;

        Text = "asERP Server Settings";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(760, 262);

        _lastProvider = settings.Provider;

        var providerLabel = NewLabel("Database provider:", 12);
        _providerBox = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Location = new Point(170, 12),
            Size = new Size(180, 24)
        };
        _providerBox.Items.AddRange([.. Providers]);
        _providerBox.SelectedItem = Providers.FirstOrDefault(p =>
            p.Equals(settings.Provider, StringComparison.OrdinalIgnoreCase)) ?? "Sqlite";
        _providerBox.SelectedIndexChanged += OnProviderChanged;

        var connectionLabel = NewLabel("Connection string:", 48);
        _connectionStringBox = new TextBox
        {
            Location = new Point(170, 48),
            Size = new Size(578, 24),
            Text = settings.ConnectionString
        };
        _testConnectionButton = new Button
        {
            Text = "Test connection",
            Location = new Point(170, 80),
            Size = new Size(130, 27)
        };
        _testConnectionButton.Click += OnTestConnection;

        var storageLabel = NewLabel("Image storage path:", 120);
        _storagePathBox = new TextBox
        {
            Location = new Point(170, 120),
            Size = new Size(540, 24),
            Text = settings.FileStorageRootPath
        };
        var browseButton = new Button
        {
            Text = "…",
            Location = new Point(716, 119),
            Size = new Size(32, 26)
        };
        browseButton.Click += OnBrowseStoragePath;

        var portLabel = NewLabel("Server port:", 156);
        _portBox = new NumericUpDown
        {
            Minimum = 1,
            Maximum = 65535,
            Value = Math.Clamp(settings.Port, 1, 65535),
            Location = new Point(170, 156),
            Size = new Size(90, 24)
        };

        _autostartBox = new CheckBox
        {
            Text = "Start tray at login",
            Location = new Point(170, 190),
            Size = new Size(250, 24),
            Checked = AutostartManager.IsEnabled()
        };

        var saveButton = new Button
        {
            Text = "Save",
            Location = new Point(574, 224),
            Size = new Size(87, 27)
        };
        saveButton.Click += OnSave;
        var cancelButton = new Button
        {
            Text = "Cancel",
            DialogResult = DialogResult.Cancel,
            Location = new Point(667, 224),
            Size = new Size(87, 27)
        };

        Controls.AddRange([
            providerLabel, _providerBox,
            connectionLabel, _connectionStringBox, _testConnectionButton,
            storageLabel, _storagePathBox, browseButton,
            portLabel, _portBox,
            _autostartBox,
            saveButton, cancelButton
        ]);
        AcceptButton = saveButton;
        CancelButton = cancelButton;
    }

    private static Label NewLabel(string text, int top) => new()
    {
        Text = text,
        Location = new Point(12, top + 3),
        Size = new Size(152, 20)
    };

    private void OnProviderChanged(object? sender, EventArgs e)
    {
        var provider = (string)_providerBox.SelectedItem!;
        // Swap in the new provider's template unless the user already customized the value.
        if (string.IsNullOrWhiteSpace(_connectionStringBox.Text)
            || _connectionStringBox.Text == ServerSettings.ConnectionStringTemplate(_lastProvider))
        {
            _connectionStringBox.Text = ServerSettings.ConnectionStringTemplate(provider);
        }
        _lastProvider = provider;
    }

    private void OnBrowseStoragePath(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select the folder for stored images/files",
            UseDescriptionForTitle = true,
            SelectedPath = Directory.Exists(_storagePathBox.Text) ? _storagePathBox.Text : AppPaths.DataDirectory
        };
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _storagePathBox.Text = dialog.SelectedPath;
        }
    }

    private async void OnTestConnection(object? sender, EventArgs e)
    {
        _testConnectionButton.Enabled = false;
        try
        {
            var (exitCode, output) = await ServerCliRunner.RunAsync(
                progress: null,
                "test-connection",
                "--provider", (string)_providerBox.SelectedItem!,
                "--connection-string", _connectionStringBox.Text);

            MessageBox.Show(this,
                exitCode == 0 ? "Connection successful." : output,
                "Test connection",
                MessageBoxButtons.OK,
                exitCode == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Test connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _testConnectionButton.Enabled = true;
        }
    }

    private void OnSave(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_connectionStringBox.Text))
        {
            MessageBox.Show(this, "Connection string must not be empty.", "Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            Directory.CreateDirectory(_storagePathBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Image storage path is not usable: {ex.Message}", "Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            SettingsStore.Save(new ServerSettings
            {
                Provider = (string)_providerBox.SelectedItem!,
                ConnectionString = _connectionStringBox.Text.Trim(),
                FileStorageRootPath = _storagePathBox.Text.Trim(),
                Port = (int)_portBox.Value
            });
            AutostartManager.SetEnabled(_autostartBox.Checked);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Could not save settings: {ex.Message}", "Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SettingsChanged = true;
        DialogResult = DialogResult.OK;
        Close();
    }
}
