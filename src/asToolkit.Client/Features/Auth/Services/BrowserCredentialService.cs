#if __WASM__
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Threading.Tasks;

namespace asToolkit.Client.Features.Auth.Services;

/// <summary>
/// Bridges the browser's Credential Management API (<c>navigator.credentials</c>) for the
/// WASM login flow.
///
/// With the Skia renderer the whole UI is drawn onto a canvas — there is no DOM
/// <c>&lt;form&gt;</c>/<c>&lt;input type="password"&gt;</c> the browser's password manager could
/// detect, so classic autofill can never work. This service talks to the browser's credential
/// store directly instead: <see cref="TryStoreAsync"/> triggers the native "save password?"
/// prompt after a successful login, and <see cref="TryGetAsync"/> retrieves a stored credential
/// (with the browser's account chooser where required) to prefill the login form.
///
/// <c>PasswordCredential</c> is Chromium-only (Chrome, Edge, Brave, …); on Firefox/Safari
/// <see cref="IsSupported"/> is false and every method is a silent no-op.
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("browser")]
internal static partial class BrowserCredentialService
{
    // "Email" instead of the API's "id" — a property named Id would trigger Uno's
    // IKeyEquatable source generator (KE0001) on this plain DTO.
    internal sealed record BrowserCredential(string Email, string Password);

    private static readonly Lazy<bool> _isSupported = new(DetectSupport);

    public static bool IsSupported => _isSupported.Value;

    private static bool DetectSupport()
    {
        try
        {
            using var navigator = JSHost.GlobalThis.GetPropertyAsJSObject("navigator");
            using var credentials = navigator?.GetPropertyAsJSObject("credentials");
            return credentials is not null && JSHost.GlobalThis.HasProperty("PasswordCredential");
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Asks the browser for a stored password credential. Depending on mediation state the
    /// browser may resolve silently or show its non-modal account chooser. Returns null when
    /// unsupported, nothing is stored, or the user dismisses the chooser.
    /// </summary>
    public static async Task<BrowserCredential?> TryGetAsync()
    {
        if (!IsSupported)
        {
            return null;
        }

        try
        {
            using var options = JsonParse("""{"password":true,"mediation":"optional"}""");
            var credential = await CredentialsGetAsync(options);
            if (credential is null)
            {
                return null;
            }

            using (credential)
            {
                if (credential.GetPropertyAsString("type") != "password")
                {
                    return null;
                }

                var email = credential.GetPropertyAsString("id");
                var password = credential.GetPropertyAsString("password");
                return string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)
                    ? null
                    : new BrowserCredential(email, password);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BrowserCredentialService] TryGetAsync error: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Hands the credentials to the browser's password store after a successful login —
    /// Chromium shows its native "save password?" prompt (or updates silently when unchanged).
    /// </summary>
    public static async Task TryStoreAsync(string id, string password)
    {
        if (!IsSupported || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
        {
            return;
        }

        try
        {
            // PasswordCredential construction goes through credentials.create() so no JS "new"
            // is needed; the option object is built via JSON.parse to avoid custom JS glue.
            var json = $"{{\"password\":{{\"id\":{Quote(id)},\"password\":{Quote(password)}}}}}";
            using var options = JsonParse(json);
            var credential = await CredentialsCreateAsync(options);
            if (credential is null)
            {
                return;
            }

            using (credential)
            {
                (await CredentialsStoreAsync(credential))?.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BrowserCredentialService] TryStoreAsync error: {ex.Message}");
        }
    }

    /// <summary>
    /// After an explicit logout the browser must not hand the password back silently — the next
    /// <c>credentials.get()</c> should require the account chooser again.
    /// </summary>
    public static async Task TryPreventSilentAccessAsync()
    {
        if (!IsSupported)
        {
            return;
        }

        try
        {
            await PreventSilentAccessJsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BrowserCredentialService] TryPreventSilentAccessAsync error: {ex.Message}");
        }
    }

    // JsonEncodedText instead of JsonSerializer keeps this trim/AOT-safe on WASM.
    private static string Quote(string value) => $"\"{JsonEncodedText.Encode(value)}\"";

    [JSImport("globalThis.JSON.parse")]
    private static partial JSObject JsonParse(string json);

    [JSImport("globalThis.navigator.credentials.get")]
    private static partial Task<JSObject?> CredentialsGetAsync(JSObject options);

    [JSImport("globalThis.navigator.credentials.create")]
    private static partial Task<JSObject?> CredentialsCreateAsync(JSObject options);

    [JSImport("globalThis.navigator.credentials.store")]
    private static partial Task<JSObject?> CredentialsStoreAsync(JSObject credential);

    [JSImport("globalThis.navigator.credentials.preventSilentAccess")]
    private static partial Task PreventSilentAccessJsAsync();
}
#endif
