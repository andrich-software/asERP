using System.Text.Json;
using System.Text.Json.Serialization;
using asERP.Server.Tray.Services;

namespace asERP.Server.Tray.Forms;

/// <summary>
/// Small user-management window for Superadmin accounts. All CRUD runs against the
/// database configured in the Settings window by shelling out to
/// <c>asERP.Server.exe cli superadmin …</c> via <see cref="ServerCliRunner"/> — it never
/// goes through the running server's HTTP API and works whether or not the service is up.
/// </summary>
internal sealed class SuperadminsForm : Form
{
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    private readonly DataGridView _grid;
    private readonly Button _newButton;
    private readonly Button _editButton;
    private readonly Button _deleteButton;
    private readonly Button _refreshButton;

    public SuperadminsForm()
    {
        // Fixed 96-DPI pixel layout — declare the baseline so WinForms auto-scales on high-DPI displays.
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;

        Text = "Manage superadmins";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.Sizable;
        MinimizeBox = false;
        MinimumSize = new Size(560, 320);
        ClientSize = new Size(640, 380);

        _grid = new DataGridView
        {
            Location = new Point(12, 12),
            Size = new Size(616, 320),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            RowHeadersVisible = false,
            AutoGenerateColumns = false,
            BackgroundColor = SystemColors.Window,
            BorderStyle = BorderStyle.FixedSingle
        };
        _grid.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Email",
            DataPropertyName = nameof(SuperadminRow.Email),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 50
        });
        _grid.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "First name",
            DataPropertyName = nameof(SuperadminRow.Firstname),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 25
        });
        _grid.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Last name",
            DataPropertyName = nameof(SuperadminRow.Lastname),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 25
        });
        _grid.SelectionChanged += (_, _) => UpdateButtonState();
        _grid.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
            {
                EditSelected();
            }
        };

        _newButton = new Button
        {
            Text = "New…",
            Location = new Point(12, 342),
            Size = new Size(90, 27),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left
        };
        _newButton.Click += (_, _) => CreateNew();

        _editButton = new Button
        {
            Text = "Edit…",
            Location = new Point(108, 342),
            Size = new Size(90, 27),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left
        };
        _editButton.Click += (_, _) => EditSelected();

        _deleteButton = new Button
        {
            Text = "Delete",
            Location = new Point(204, 342),
            Size = new Size(90, 27),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left
        };
        _deleteButton.Click += (_, _) => DeleteSelected();

        _refreshButton = new Button
        {
            Text = "Refresh",
            Location = new Point(444, 342),
            Size = new Size(90, 27),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right
        };
        _refreshButton.Click += async (_, _) => await LoadAsync();

        var closeButton = new Button
        {
            Text = "Close",
            DialogResult = DialogResult.OK,
            Location = new Point(540, 342),
            Size = new Size(88, 27),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right
        };

        Controls.AddRange([_grid, _newButton, _editButton, _deleteButton, _refreshButton, closeButton]);
        CancelButton = closeButton;

        UpdateButtonState();
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        await LoadAsync();
    }

    private SuperadminRow? SelectedRow => _grid.CurrentRow?.DataBoundItem as SuperadminRow;

    private void UpdateButtonState()
    {
        var hasSelection = SelectedRow is not null;
        _editButton.Enabled = hasSelection;
        _deleteButton.Enabled = hasSelection;
    }

    private async Task LoadAsync()
    {
        UseWaitCursor = true;
        Enabled = false;
        try
        {
            var (exitCode, output) = await ServerCliRunner.RunAsync(progress: null, "superadmin", "list");
            if (exitCode != 0)
            {
                ShowError("Could not load superadmins", output);
                return;
            }

            var rows = new List<SuperadminRow>();
            foreach (var line in output.Split('\n'))
            {
                var trimmed = line.Trim();
                if (!trimmed.StartsWith('{'))
                {
                    continue;
                }

                try
                {
                    var row = JsonSerializer.Deserialize<SuperadminRow>(trimmed, JsonOptions);
                    if (row is not null)
                    {
                        rows.Add(row);
                    }
                }
                catch (JsonException)
                {
                    // Skip any non-JSON diagnostic line the CLI may have interleaved.
                }
            }

            _grid.DataSource = rows;
        }
        catch (Exception ex)
        {
            ShowError("Could not load superadmins", ex.Message);
        }
        finally
        {
            Enabled = true;
            UseWaitCursor = false;
            UpdateButtonState();
        }
    }

    private void CreateNew()
    {
        using var dialog = new SuperadminEditForm();
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var environment = new Dictionary<string, string>
        {
            ["ASERP_CLI_EMAIL"] = dialog.Email,
            ["ASERP_CLI_PASSWORD"] = dialog.Password,
            ["ASERP_CLI_FIRSTNAME"] = dialog.Firstname,
            ["ASERP_CLI_LASTNAME"] = dialog.Lastname
        };
        _ = RunMutationAsync("Create superadmin", environment, "superadmin", "create");
    }

    private void EditSelected()
    {
        var row = SelectedRow;
        if (row is null)
        {
            return;
        }

        using var dialog = new SuperadminEditForm(row);
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var environment = new Dictionary<string, string>
        {
            ["ASERP_CLI_FIRSTNAME"] = dialog.Firstname,
            ["ASERP_CLI_LASTNAME"] = dialog.Lastname
        };
        if (!string.Equals(dialog.Email, row.Email, StringComparison.OrdinalIgnoreCase))
        {
            environment["ASERP_CLI_NEW_EMAIL"] = dialog.Email;
        }
        if (!string.IsNullOrEmpty(dialog.Password))
        {
            environment["ASERP_CLI_PASSWORD"] = dialog.Password;
        }

        // The user is identified by its current email; changes flow through the env vars above.
        _ = RunMutationAsync("Update superadmin", environment, "superadmin", "update", row.Email);
    }

    private void DeleteSelected()
    {
        var row = SelectedRow;
        if (row is null)
        {
            return;
        }

        var confirmed = MessageBox.Show(this,
            $"Delete the superadmin '{row.Email}'?\n\nThis permanently removes the account from the database.",
            "Delete superadmin", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        if (confirmed != DialogResult.Yes)
        {
            return;
        }

        _ = RunMutationAsync("Delete superadmin", environment: null, "superadmin", "delete", row.Email);
    }

    private async Task RunMutationAsync(
        string title, IReadOnlyDictionary<string, string>? environment, params string[] cliArguments)
    {
        UseWaitCursor = true;
        Enabled = false;
        try
        {
            var (exitCode, output) = await ServerCliRunner.RunAsync(progress: null, environment, cliArguments);
            if (exitCode != 0)
            {
                ShowError(title, output);
            }
        }
        catch (Exception ex)
        {
            ShowError(title, ex.Message);
        }
        finally
        {
            Enabled = true;
            UseWaitCursor = false;
        }

        await LoadAsync();
    }

    // The CLI host prints EF Core diagnostics ("info: …") to stdout; drop those so an
    // error dialog shows only the CLI's own "error: …" message and any plain text.
    private static readonly string[] LogLinePrefixes =
        ["info: ", "warn: ", "fail: ", "crit: ", "dbug: ", "trce: "];

    private void ShowError(string title, string message)
    {
        var cleaned = string.Join(Environment.NewLine, message
            .Split('\n')
            .Select(line => line.TrimEnd('\r'))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Where(line => !LogLinePrefixes.Any(prefix =>
                line.StartsWith(prefix, StringComparison.Ordinal))));

        MessageBox.Show(this,
            string.IsNullOrWhiteSpace(cleaned) ? "The operation failed." : cleaned,
            title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // Deserialization target for the CLI's `superadmin list` JSONL output.
    private sealed class SuperadminRow
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;
    }

    /// <summary>
    /// Modal editor for a single superadmin. In edit mode the email is prefilled and an empty
    /// password field means "leave the current password unchanged".
    /// </summary>
    private sealed class SuperadminEditForm : Form
    {
        private readonly TextBox _emailBox;
        private readonly TextBox _firstnameBox;
        private readonly TextBox _lastnameBox;
        private readonly TextBox _passwordBox;
        private readonly bool _isEdit;

        public string Email => _emailBox.Text.Trim();
        public string Firstname => _firstnameBox.Text.Trim();
        public string Lastname => _lastnameBox.Text.Trim();
        public string Password => _passwordBox.Text;

        public SuperadminEditForm(SuperadminRow? existing = null)
        {
            _isEdit = existing is not null;

            // Fixed 96-DPI pixel layout — declare the baseline so WinForms auto-scales on high-DPI displays.
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;

            Text = _isEdit ? "Edit superadmin" : "New superadmin";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(430, 210);

            var emailLabel = NewLabel("Email:", 12);
            _emailBox = new TextBox
            {
                Location = new Point(130, 12),
                Size = new Size(288, 24),
                Text = existing?.Email ?? string.Empty
            };

            var firstnameLabel = NewLabel("First name:", 48);
            _firstnameBox = new TextBox
            {
                Location = new Point(130, 48),
                Size = new Size(288, 24),
                Text = existing?.Firstname ?? string.Empty
            };

            var lastnameLabel = NewLabel("Last name:", 84);
            _lastnameBox = new TextBox
            {
                Location = new Point(130, 84),
                Size = new Size(288, 24),
                Text = existing?.Lastname ?? string.Empty
            };

            var passwordLabel = NewLabel(_isEdit ? "New password:" : "Password:", 120);
            _passwordBox = new TextBox
            {
                Location = new Point(130, 120),
                Size = new Size(288, 24),
                UseSystemPasswordChar = true
            };

            var passwordHint = new Label
            {
                Text = _isEdit ? "Leave blank to keep the current password." : string.Empty,
                Location = new Point(130, 146),
                Size = new Size(288, 18),
                ForeColor = SystemColors.GrayText
            };

            var okButton = new Button
            {
                Text = "OK",
                Location = new Point(244, 172),
                Size = new Size(87, 27)
            };
            okButton.Click += OnOk;
            var cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(331, 172),
                Size = new Size(87, 27)
            };

            Controls.AddRange([
                emailLabel, _emailBox,
                firstnameLabel, _firstnameBox,
                lastnameLabel, _lastnameBox,
                passwordLabel, _passwordBox, passwordHint,
                okButton, cancelButton
            ]);
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private static Label NewLabel(string text, int top) => new()
        {
            Text = text,
            Location = new Point(12, top + 3),
            Size = new Size(112, 20)
        };

        private void OnOk(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                Warn("Email must not be empty.");
                return;
            }
            if (!_isEdit && string.IsNullOrEmpty(Password))
            {
                Warn("A password is required for a new superadmin.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Warn(string message) =>
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
