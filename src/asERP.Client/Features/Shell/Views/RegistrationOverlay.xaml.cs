using asERP.Client.Core.Exceptions;
using asERP.Client.Features.Auth.Services;
using asERP.Domain.Dtos.Auth;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.Shell.Views;

/// <summary>
/// Registration overlay opened from the login overlay's register link. Owns form
/// validation, the registration request and error display. The hosting Shell switches
/// visibility and provides the server URL selected on the login overlay.
/// </summary>
public sealed partial class RegistrationOverlay : UserControl
{
    /// <summary>
    /// Raised after a successful registration. The Shell updates the authentication state,
    /// checks for tenants and navigates to the dashboard (or shows the first-tenant overlay).
    /// </summary>
    public event Func<Task>? RegistrationSucceeded;

    /// <summary>Raised when the user cancels and wants to return to the login overlay.</summary>
    public event EventHandler? BackToLoginRequested;

    /// <summary>
    /// URL of the server to register against — set by the Shell from the login overlay's
    /// selected profile before showing this overlay. Ignored when the runtime config pins
    /// the server URL.
    /// </summary>
    public string? ServerUrl { get; set; }

    public RegistrationOverlay()
    {
        this.InitializeComponent();
    }

    /// <summary>Clears the form, error banner and progress state.</summary>
    public void Reset()
    {
        RegisterFirstname.Text = string.Empty;
        RegisterLastname.Text = string.Empty;
        RegisterEmail.Text = string.Empty;
        RegisterPassword.Password = string.Empty;
        RegisterPasswordConfirm.Password = string.Empty;
        RegisterErrorBanner.Visibility = Visibility.Collapsed;
        RegisterErrorText.Text = string.Empty;
        RegisterProgress.Visibility = Visibility.Collapsed;
        RegisterProgress.IsActive = false;
        RegisterSubmitButton.IsEnabled = true;
        RegisterCancelButton.IsEnabled = true;
    }

    private void RegisterCancel_Click(object sender, RoutedEventArgs e)
    {
        BackToLoginRequested?.Invoke(this, EventArgs.Empty);
    }

    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Interoperability", "CA1416", Justification = "Browser-specific calls are guarded by #if __WASM__")]
    private async void RegisterSubmit_Click(object sender, RoutedEventArgs e)
    {
        var firstname = RegisterFirstname.Text?.Trim();
        var lastname = RegisterLastname.Text?.Trim();
        var email = RegisterEmail.Text?.Trim();
        var password = RegisterPassword.Password;
        var passwordConfirm = RegisterPasswordConfirm.Password;

        if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            RegisterErrorText.Text = "Bitte füllen Sie alle Felder aus.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        if (password != passwordConfirm)
        {
            RegisterErrorText.Text = "Die Passwörter stimmen nicht überein.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        var serverUrl = asERP.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asERP.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : ServerUrl;

        if (string.IsNullOrWhiteSpace(serverUrl))
        {
            RegisterErrorText.Text = "Server-URL fehlt.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        serverUrl = ServerUrlUtil.Normalize(serverUrl);

        RegisterSubmitButton.IsEnabled = false;
        RegisterCancelButton.IsEnabled = false;
        RegisterProgress.Visibility = Visibility.Visible;
        RegisterProgress.IsActive = true;
        RegisterErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var maErpAuth = app.Host.Services.GetRequiredService<IMaErpAuthenticationService>();

            var request = new RegisterRequestDto
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Username = email,
                Password = password
            };

            var response = await maErpAuth.RegisterAsync(serverUrl, request);

            if (response?.Succeeded == true && !string.IsNullOrEmpty(response.Token))
            {
#if __WASM__
                // Same as after login: offer the browser's "save password?" prompt.
                _ = BrowserCredentialService.TryStoreAsync(email, password);
#endif

                if (RegistrationSucceeded is { } registrationSucceeded)
                {
                    await registrationSucceeded();
                }
            }
            else
            {
                RegisterErrorText.Text = response?.Message ?? "Registrierung fehlgeschlagen.";
                RegisterErrorBanner.Visibility = Visibility.Visible;
            }
        }
        catch (ApiException ex)
        {
            RegisterErrorText.Text = ex.CombinedMessage;
            RegisterErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            RegisterErrorText.Text = ex.Message;
            RegisterErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            RegisterProgress.Visibility = Visibility.Collapsed;
            RegisterProgress.IsActive = false;
            RegisterSubmitButton.IsEnabled = true;
            RegisterCancelButton.IsEnabled = true;
        }
    }
}
