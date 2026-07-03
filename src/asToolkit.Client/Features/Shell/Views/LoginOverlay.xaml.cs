using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Features.Auth.Models;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Client.Features.Auth.Views;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Features.Shell.Views;

/// <summary>
/// Login overlay shown while the user is not authenticated. Owns server selection
/// (incl. dev-environment defaults and the remembered last-used server), email prefill,
/// the server status badge, registration-link visibility and the login request itself.
/// The hosting Shell only switches visibility and reacts to the events below.
/// </summary>
public sealed partial class LoginOverlay : UserControl
{
    /// <summary>
    /// Raised after a successful login. The Shell updates the authentication state,
    /// checks for tenants and navigates to the dashboard (or shows the first-tenant overlay).
    /// </summary>
    public event Func<Task>? LoginSucceeded;

    /// <summary>Raised when the user clicks the registration link.</summary>
    public event EventHandler? RegistrationRequested;

    public LoginOverlay()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// URL of the currently selected server profile. The registration overlay registers
    /// against the same server the user picked here.
    /// </summary>
    public string? SelectedServerUrl => (LoginServerSelector.SelectedItem as ServerProfile)?.Url;

    /// <summary>
    /// Clears the form and re-applies the initial state (dev credentials, browser
    /// credential prefill, server selector / restricted server URL).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Interoperability", "CA1416", Justification = "Browser-specific calls are guarded by #if __WASM__")]
    public void Reset()
    {
        LoginEmail.Text = string.Empty;
        LoginPassword.Password = string.Empty;
        LoginErrorBanner.Visibility = Visibility.Collapsed;
        LoginErrorText.Text = string.Empty;
        LoginProgress.Visibility = Visibility.Collapsed;
        LoginProgress.IsActive = false;
        LoginButton.IsEnabled = true;
        LoginServerPanel.Visibility = Visibility.Visible;
        LoginServerStatus.Visibility = Visibility.Collapsed;
        RegisterLink.Visibility = Visibility.Collapsed;

        // Dev convenience credentials (per-server last-used email overrides the email below
        // via the selector's SelectionChanged once a server has been used).
        try
        {
            var app = Application.Current as App;
            var hostEnvironment = app?.Host?.Services?.GetService<IHostEnvironment>();
            if (hostEnvironment?.IsDevelopment() == true)
            {
                LoginEmail.Text = "admin@localhost.com";
                LoginPassword.Password = "P@ssword1";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] Reset error: {ex.Message}");
        }

#if __WASM__
        // Canvas rendering hides the login form from the browser's password manager, so ask
        // the Credential Management API for a stored credential instead (Chromium only).
        _ = PrefillLoginFromBrowserCredentialsAsync();
#endif

        // Runtime config (WASM: /config.json from nginx env var) may pin the server URL —
        // hide the whole server selector and use the configured value.
        if (asToolkit.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted)
        {
            LoginServerPanel.Visibility = Visibility.Collapsed;
            _ = RefreshRegistrationLinkAsync(asToolkit.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!);
            return;
        }

        _ = InitializeServerSelectorAsync();
    }

#if __WASM__
    [System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private async Task PrefillLoginFromBrowserCredentialsAsync()
    {
        try
        {
            var credential = await BrowserCredentialService.TryGetAsync();
            if (credential == null)
            {
                return;
            }

            // The browser chooser is async — don't clobber a password the user typed meanwhile
            // (also skips the DEBUG dev-convenience credentials).
            if (!string.IsNullOrEmpty(LoginPassword.Password))
            {
                return;
            }

            LoginEmail.Text = credential.Email;
            LoginPassword.Password = credential.Password;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] PrefillLoginFromBrowserCredentialsAsync error: {ex.Message}");
        }
    }
#endif

    private async Task InitializeServerSelectorAsync()
    {
        try
        {
            var app = Application.Current as App;
            var store = app?.Host?.Services?.GetService<IServerProfileStore>();
            if (store == null) return;

            var servers = await store.GetAllAsync();
            var lastUsed = await store.GetLastUsedAsync();

            LoginServerSelector.ItemsSource = servers;
            // Setting SelectedItem raises SelectionChanged, which applies the email prefill,
            // status badge and registration-link refresh for the chosen server.
            LoginServerSelector.SelectedItem =
                servers.FirstOrDefault(s => s.Id == lastUsed.Id) ?? servers.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] InitializeServerSelectorAsync error: {ex.Message}");
        }
    }

    private void LoginServerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (LoginServerSelector.SelectedItem is not ServerProfile profile)
        {
            return;
        }

        // Auto-fill the last email used for this server (don't clear an existing entry otherwise).
        if (!string.IsNullOrWhiteSpace(profile.LastUsedEmail))
        {
            LoginEmail.Text = profile.LastUsedEmail;
        }

        _ = RefreshServerStatusAsync(profile.Url);
        _ = RefreshRegistrationLinkAsync(profile.Url);
    }

    private async Task RefreshServerStatusAsync(string serverUrl)
    {
        try
        {
            LoginServerStatus.Visibility = Visibility.Visible;
            LoginServerStatus.Text = Localize("ServerDialog.StatusChecking", "prüfe …");

            var app = Application.Current as App;
            var serverInfo = app?.Host?.Services?.GetService<IServerInfoService>();
            if (serverInfo == null)
            {
                LoginServerStatus.Visibility = Visibility.Collapsed;
                return;
            }

            var info = await serverInfo.GetServerInfoAsync(serverUrl);
            LoginServerStatus.Text = info != null
                ? string.Format(Localize("ServerDialog.StatusConnectedFormat", "asToolkit v{0} · verbunden"), info.Version)
                : Localize("ServerDialog.StatusOffline", "offline");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] RefreshServerStatusAsync error: {ex.Message}");
            LoginServerStatus.Text = Localize("ServerDialog.StatusOffline", "offline");
        }
    }

    private async void ManageServers_Click(object sender, RoutedEventArgs e)
    {
        var app = Application.Current as App;
        var store = app?.Host?.Services?.GetService<IServerProfileStore>();
        var serverInfo = app?.Host?.Services?.GetService<IServerInfoService>();
        if (store == null || serverInfo == null || this.XamlRoot == null)
        {
            return;
        }

        var currentId = (LoginServerSelector.SelectedItem as ServerProfile)?.Id;

        var dialog = new ServerManagementDialog(store, serverInfo, this.XamlRoot);
        await dialog.ShowAsync();

        // Reload the selector after management; keep the current selection if it still exists.
        var servers = await store.GetAllAsync();
        LoginServerSelector.ItemsSource = servers;
        LoginServerSelector.SelectedItem =
            servers.FirstOrDefault(s => s.Id == currentId) ?? servers.FirstOrDefault();
    }

    private static string Localize(string key, string fallback)
    {
        try
        {
            var value = Windows.ApplicationModel.Resources.ResourceLoader
                .GetForViewIndependentUse().GetString(key);
            return string.IsNullOrEmpty(value) ? fallback : value;
        }
        catch
        {
            return fallback;
        }
    }

    private async Task RefreshRegistrationLinkAsync(string serverUrl)
    {
        try
        {
            // Skip half-typed URLs like "https://" — Uri.TryCreate would
            // accept them but the request is guaranteed to fail.
            if (!Uri.TryCreate(serverUrl, UriKind.Absolute, out var uri) ||
                string.IsNullOrWhiteSpace(uri.Host))
            {
                RegisterLink.Visibility = Visibility.Collapsed;
                return;
            }

            var app = Application.Current as App;
            var serverInfoService = app?.Host?.Services?.GetService<IServerInfoService>();
            if (serverInfoService == null) return;

            var info = await serverInfoService.GetServerInfoAsync(serverUrl);
            RegisterLink.Visibility = info?.RegistrationEnabled == true
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] RefreshRegistrationLinkAsync error: {ex.Message}");
            RegisterLink.Visibility = Visibility.Collapsed;
        }
    }

    private void LoginInput_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            e.Handled = true;
            LoginButton_Click(LoginButton, new RoutedEventArgs());
        }
    }

    private void RegisterLink_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
    {
        RegistrationRequested?.Invoke(this, EventArgs.Empty);
    }

    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Interoperability", "CA1416", Justification = "Browser-specific calls are guarded by #if __WASM__")]
    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedProfile = LoginServerSelector.SelectedItem as ServerProfile;
        var serverUrl = asToolkit.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asToolkit.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : selectedProfile?.Url;
        var email = LoginEmail.Text?.Trim();
        var password = LoginPassword.Password;

        if (string.IsNullOrWhiteSpace(serverUrl) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            LoginErrorText.Text = "Please fill in all fields";
            LoginErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        serverUrl = ServerUrlUtil.Normalize(serverUrl);

        // If the user typed the URL and clicked Login without leaving the
        // field first, LostFocus may not have fired — refresh the registration
        // link visibility now (fire-and-forget; do not block login).
        _ = RefreshRegistrationLinkAsync(serverUrl);

        LoginButton.IsEnabled = false;
        LoginProgress.Visibility = Visibility.Visible;
        LoginProgress.IsActive = true;
        LoginErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var auth = app.Host.Services.GetRequiredService<IAuthenticationService>();

            var rememberMe = LoginRememberMe.IsChecked == true;

            var credentials = new Dictionary<string, string>
            {
                ["Email"] = email,
                ["Password"] = password,
                ["ServerUrl"] = serverUrl,
                ["RememberMe"] = rememberMe.ToString()
            };

            var success = await auth.LoginAsync(dispatcher: null, credentials);

            if (success)
            {
#if __WASM__
                // Hand the credentials to the browser's password store (native "save
                // password?" prompt) — the canvas-rendered form can't trigger it itself.
                _ = BrowserCredentialService.TryStoreAsync(email, password);
#endif

                // Remember the server used and its email so it becomes the default next time.
                if (selectedProfile != null)
                {
                    var profileStore = app.Host.Services.GetService<IServerProfileStore>();
                    if (profileStore != null)
                    {
                        await profileStore.SetLastUsedAsync(selectedProfile.Id, email);
                    }
                }

                if (LoginSucceeded is { } loginSucceeded)
                {
                    await loginSucceeded();
                }
            }
            else
            {
                LoginErrorText.Text = "Login failed. Please check your credentials and server URL.";
                LoginErrorBanner.Visibility = Visibility.Visible;
            }
        }
        catch (ApiException ex)
        {
            LoginErrorText.Text = ex.CombinedMessage;
            LoginErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            LoginErrorText.Text = $"An error occurred: {ex.Message}";
            LoginErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            LoginProgress.Visibility = Visibility.Collapsed;
            LoginProgress.IsActive = false;
            LoginButton.IsEnabled = true;
        }
    }
}
