using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Helpers;
using asERP.Client.Features.Auth.Models;
using asERP.Client.Features.Auth.Services;
using asERP.Client.Features.Auth.Views;
using asERP.Domain.Dtos.ServerInfo;
using Microsoft.UI.Xaml.Controls;
#if __DESKTOP__
using asERP.Client.Core.Updates;
#endif

namespace asERP.Client.Features.Shell.Views;

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

    /// <summary>Portable/zip and mobile builds can't self-update — send them here instead.</summary>
    private static readonly Uri DownloadPageUri = new("https://github.com/andrich-software/asERP/releases");

    /// <summary>True while the selected server requires a newer client version — login is blocked.</summary>
    private bool _updateRequired;

    public LoginOverlay()
    {
        this.InitializeComponent();

        // The horizontal wordmark has a dark-text and a white-text variant; pick the one
        // matching the current theme (the theme is fixed while the login overlay is shown,
        // but ActualThemeChanged keeps it correct if it ever switches underneath us).
        this.Loaded += (_, _) => UpdateBrandLogo();
        this.ActualThemeChanged += (_, _) => UpdateBrandLogo();
    }

    private void UpdateBrandLogo()
    {
        var isDark = this.ActualTheme == ElementTheme.Dark;
        BrandLogoDark.Visibility = isDark ? Visibility.Visible : Visibility.Collapsed;
        BrandLogoLight.Visibility = isDark ? Visibility.Collapsed : Visibility.Visible;
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
        _updateRequired = false;
        UpdateRequiredBanner.Visibility = Visibility.Collapsed;
        LoginProgress.Visibility = Visibility.Collapsed;
        LoginProgress.IsActive = false;
        LoginButton.IsEnabled = true;
        LoginServerPanel.Visibility = Visibility.Visible;
        LoginServerStatus.Visibility = Visibility.Collapsed;
        RegisterLink.Visibility = Visibility.Collapsed;

        // Credential prefill (saved password, dev convenience) happens per selected server in
        // ApplyCredentialPrefill — a blanket prefill here left a stale dev password in the box
        // when another server was selected, which then failed with "invalid credentials".
        LoginSavePassword.IsChecked = false;

#if __WASM__
        // Canvas rendering hides the login form from the browser's password manager, so ask
        // the Credential Management API for a stored credential instead (Chromium only).
        _ = PrefillLoginFromBrowserCredentialsAsync();
#endif

        // Runtime config (WASM: /config.json from nginx env var) may pin the server URL —
        // hide the whole server selector and use the configured value.
        if (asERP.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted)
        {
            LoginServerPanel.Visibility = Visibility.Collapsed;
            _ = RefreshRegistrationLinkAsync(asERP.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!);
            return;
        }

#if __DESKTOP__
        // Opt-in password saving is only available where DPAPI protects it (Windows desktop).
        LoginSavePassword.Visibility = SavedPasswordStore.IsSupported
            ? Visibility.Visible
            : Visibility.Collapsed;
#endif

        _ = InitializeServerSelectorAsync();
    }

    /// <summary>
    /// Per-server credential prefill, applied whenever the selected server changes:
    /// a saved password (Windows desktop, opt-in) wins; the Local-Dev profile gets the
    /// well-known dev credentials in Development; otherwise the password box is cleared —
    /// a password belonging to a previously selected server never matches this one, and a
    /// filled-looking box would fake a "saved" password that fails with 401.
    /// </summary>
    private void ApplyCredentialPrefill(ServerProfile profile)
    {
#if __DESKTOP__
        if (SavedPasswordStore.IsSupported && SavedPasswordStore.TryGet(profile.Id) is { } savedPassword)
        {
            LoginPassword.Password = savedPassword;
            LoginSavePassword.IsChecked = true;
            return;
        }
        LoginSavePassword.IsChecked = false;
#endif

        if (profile.Id == ServerProfile.LocalDevId && IsDevelopmentEnvironment())
        {
            if (string.IsNullOrWhiteSpace(LoginEmail.Text))
            {
                LoginEmail.Text = "admin@localhost.com";
            }
            LoginPassword.Password = "P@ssword1";
            return;
        }

#if !__WASM__
        // On WASM the browser-credential prefill is origin-scoped, not per server profile —
        // leave it alone there. Everywhere else, drop leftovers from the previous selection.
        LoginPassword.Password = string.Empty;
#endif
    }

    private static bool IsDevelopmentEnvironment()
    {
        try
        {
            var app = Application.Current as App;
            return app?.Host?.Services?.GetService<IHostEnvironment>()?.IsDevelopment() == true;
        }
        catch
        {
            return false;
        }
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

        ApplyCredentialPrefill(profile);

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
                ? string.Format(Localize("ServerDialog.StatusConnectedFormat", "asERP v{0} · verbunden"), info.Version)
                : Localize("ServerDialog.StatusOffline", "offline");
            ApplyServerCompatibility(info);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] RefreshServerStatusAsync error: {ex.Message}");
            LoginServerStatus.Text = Localize("ServerDialog.StatusOffline", "offline");
        }
    }

    /// <summary>
    /// Shows or clears the update-required banner depending on the server's minimum client
    /// version, and blocks login while the client is too old. Unstamped builds (dev, no CI
    /// version) are never blocked client-side.
    /// </summary>
    private void ApplyServerCompatibility(ServerInfoResponseDto? info)
    {
        var current = ClientVersionInfo.Stamped;
        _updateRequired = ClientVersionGate.IsUpdateRequired(current, info?.MinimumClientVersion);

        if (_updateRequired)
        {
            UpdateRequiredText.Text = string.Format(
                Localize("AppUpdate.RequiredMessage",
                    "Dieser Server benötigt mindestens Client-Version {0} (installiert: {1})."),
                info!.MinimumClientVersion, current);

            var canSelfUpdate = false;
#if __DESKTOP__
            canSelfUpdate = ClientUpdater.IsInstalled;
#endif
            UpdateRequiredButton.Content = canSelfUpdate
                ? Localize("AppUpdate.UpdateNow", "Jetzt aktualisieren")
                : Localize("AppUpdate.OpenDownloadPage", "Download-Seite öffnen");
        }

        UpdateRequiredBanner.Visibility = _updateRequired ? Visibility.Visible : Visibility.Collapsed;
        LoginButton.IsEnabled = !_updateRequired;
    }

    /// <summary>
    /// One-click update from the login overlay. Installed desktop clients update in place
    /// (download → silent install → automatic relaunch); everyone else gets the download page.
    /// </summary>
    private async void UpdateRequired_Click(object sender, RoutedEventArgs e)
    {
#if __DESKTOP__
        if (ClientUpdater.IsInstalled)
        {
            UpdateRequiredButton.IsEnabled = false;
            try
            {
                await ClientUpdater.UpdateNowAsync(this);
            }
            finally
            {
                UpdateRequiredButton.IsEnabled = true;
            }
            return;
        }
#endif
        try
        {
            await Windows.System.Launcher.LaunchUriAsync(DownloadPageUri);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LoginOverlay] Could not open download page: {ex.Message}");
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

            // Also runs for the restricted-URL case (WASM), where the server selector —
            // and with it RefreshServerStatusAsync — is hidden.
            ApplyServerCompatibility(info);
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
        var serverUrl = asERP.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asERP.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : selectedProfile?.Url;
        var email = LoginEmail.Text?.Trim();
        var password = LoginPassword.Password;

        if (string.IsNullOrWhiteSpace(serverUrl) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            LoginErrorText.Text = "Please fill in all fields";
            LoginErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        // Belt-and-braces: the login button is disabled while an update is required, but an
        // Enter keypress in the form still routes here.
        if (_updateRequired)
        {
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

#if __DESKTOP__
                    // Opt-in password saving: persist only after the server accepted the
                    // credentials; unchecking removes a previously saved password.
                    if (SavedPasswordStore.IsSupported)
                    {
                        if (LoginSavePassword.IsChecked == true)
                        {
                            SavedPasswordStore.Set(selectedProfile.Id, password);
                        }
                        else
                        {
                            SavedPasswordStore.Remove(selectedProfile.Id);
                        }
                    }
#endif
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
