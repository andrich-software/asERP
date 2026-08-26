using asERP.Client.Core.Exceptions;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Setup;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.Shell.Views;

/// <summary>
/// Overlay for the initial server setup, opened from the login overlay's
/// "Einrichtung starten" button when the selected server reports SetupRequired.
/// Creates the first Superadmin account together with the first tenant; afterwards
/// the Shell returns to the login overlay with the new email prefilled.
/// </summary>
public sealed partial class SetupOverlay : UserControl
{
    /// <summary>
    /// Raised after the setup completed on the server. The Shell returns to the login
    /// overlay and prefills <see cref="CreatedEmail"/>.
    /// </summary>
    public event Func<Task>? SetupCompleted;

    /// <summary>Raised when the user cancels and wants to return to the login overlay.</summary>
    public event EventHandler? BackToLoginRequested;

    /// <summary>
    /// URL of the server to set up — set by the Shell from the login overlay's selected
    /// profile before showing this overlay. Ignored when the runtime config pins the
    /// server URL.
    /// </summary>
    public string? ServerUrl { get; set; }

    /// <summary>Email of the Superadmin created by the last successful setup run.</summary>
    public string? CreatedEmail { get; private set; }

    public SetupOverlay()
    {
        this.InitializeComponent();
    }

    /// <summary>Clears the form, error banner and progress state.</summary>
    public void Reset()
    {
        SetupFirstname.Text = string.Empty;
        SetupLastname.Text = string.Empty;
        SetupEmail.Text = string.Empty;
        SetupPassword.Password = string.Empty;
        SetupPasswordConfirm.Password = string.Empty;
        SetupTenantName.Text = string.Empty;
        SetupTenantDescription.Text = string.Empty;
        SetupErrorBanner.Visibility = Visibility.Collapsed;
        SetupErrorText.Text = string.Empty;
        SetupProgress.Visibility = Visibility.Collapsed;
        SetupProgress.IsActive = false;
        SetupSubmitButton.IsEnabled = true;
        SetupCancelButton.IsEnabled = true;
        CreatedEmail = null;
    }

    private void SetupCancel_Click(object sender, RoutedEventArgs e)
    {
        BackToLoginRequested?.Invoke(this, EventArgs.Empty);
    }

    private async void SetupSubmit_Click(object sender, RoutedEventArgs e)
    {
        var firstname = SetupFirstname.Text?.Trim();
        var lastname = SetupLastname.Text?.Trim();
        var email = SetupEmail.Text?.Trim();
        var password = SetupPassword.Password;
        var passwordConfirm = SetupPasswordConfirm.Password;
        var tenantName = SetupTenantName.Text?.Trim();

        if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(tenantName))
        {
            SetupErrorText.Text = "Bitte füllen Sie alle Felder aus.";
            SetupErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        if (password != passwordConfirm)
        {
            SetupErrorText.Text = "Die Passwörter stimmen nicht überein.";
            SetupErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        var serverUrl = asERP.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asERP.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : ServerUrl;

        if (string.IsNullOrWhiteSpace(serverUrl))
        {
            SetupErrorText.Text = "Server-URL fehlt.";
            SetupErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        serverUrl = ServerUrlUtil.Normalize(serverUrl);

        SetupSubmitButton.IsEnabled = false;
        SetupCancelButton.IsEnabled = false;
        SetupProgress.Visibility = Visibility.Visible;
        SetupProgress.IsActive = true;
        SetupErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var setupService = app.Host.Services.GetRequiredService<ISetupService>();

            var input = new InitialSetupInputDto
            {
                Email = email,
                Password = password,
                Firstname = firstname,
                Lastname = lastname,
                TenantName = tenantName,
                TenantDescription = SetupTenantDescription.Text?.Trim() ?? string.Empty
            };

            await setupService.RunInitialSetupAsync(serverUrl, input);

            CreatedEmail = email;

            if (SetupCompleted is { } setupCompleted)
            {
                await setupCompleted();
            }
        }
        catch (ApiException ex)
        {
            SetupErrorText.Text = ex.CombinedMessage;
            SetupErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            SetupErrorText.Text = ex.Message;
            SetupErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            SetupProgress.Visibility = Visibility.Collapsed;
            SetupProgress.IsActive = false;
            SetupSubmitButton.IsEnabled = true;
            SetupCancelButton.IsEnabled = true;
        }
    }
}
