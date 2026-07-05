namespace asERP.Server.Tray.Forms;

/// <summary>
/// Modal progress dialog with a marquee bar and a log box. Used for service restarts,
/// backup/restore runs and update downloads.
/// </summary>
internal sealed class ProgressForm : Form
{
    private readonly ProgressBar _progressBar;
    private readonly TextBox _logBox;
    private readonly Button _closeButton;

    private ProgressForm(string title)
    {
        Text = title;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(520, 300);
        ControlBox = false;

        _progressBar = new ProgressBar
        {
            Style = ProgressBarStyle.Marquee,
            Location = new Point(12, 12),
            Size = new Size(496, 20)
        };
        _logBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Location = new Point(12, 44),
            Size = new Size(496, 210)
        };
        _closeButton = new Button
        {
            Text = "Close",
            Enabled = false,
            DialogResult = DialogResult.OK,
            Location = new Point(421, 264),
            Size = new Size(87, 27)
        };

        Controls.AddRange([_progressBar, _logBox, _closeButton]);
        AcceptButton = _closeButton;
    }

    private void AppendLine(string line)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => AppendLine(line));
            return;
        }
        _logBox.AppendText(line + Environment.NewLine);
    }

    private void MarkFinished(bool succeeded)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => MarkFinished(succeeded));
            return;
        }
        _progressBar.Style = ProgressBarStyle.Continuous;
        _progressBar.Value = succeeded ? 100 : 0;
        _closeButton.Enabled = true;
        ControlBox = true;
    }

    /// <summary>
    /// Shows the dialog while running <paramref name="work"/> on a background task.
    /// Returns true when the work completed without throwing.
    /// </summary>
    public static bool Run(IWin32Window? owner, string title, Func<IProgress<string>, Task> work)
    {
        using var form = new ProgressForm(title);
        var succeeded = false;
        var progress = new Progress<string>(form.AppendLine);

        form.Shown += async (_, _) =>
        {
            try
            {
                await work(progress);
                succeeded = true;
                form.AppendLine("Done.");
            }
            catch (Exception ex)
            {
                form.AppendLine($"Error: {ex.Message}");
            }
            form.MarkFinished(succeeded);
        };

        form.ShowDialog(owner);
        return succeeded;
    }
}
