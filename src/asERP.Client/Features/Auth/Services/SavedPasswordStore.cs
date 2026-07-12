#if __DESKTOP__
using System.Security.Cryptography;
using System.Text;
using Windows.Storage;

namespace asERP.Client.Features.Auth.Services;

/// <summary>
/// Opt-in per-server password storage for the Windows desktop client ("Passwort speichern" on the
/// login overlay). Passwords are encrypted with DPAPI (CurrentUser scope — the protection level
/// desktop browsers use for their password stores) and kept in ApplicationData.LocalSettings under
/// <c>saved_password_{serverProfileId}</c>; <c>ServerProfileStore.DeleteAsync</c> removes the entry
/// together with its profile.
///
/// Other platforms: <see cref="IsSupported"/> is false and the login overlay hides the checkbox —
/// WASM uses the browser's credential store (BrowserCredentialService) instead.
/// </summary>
internal static class SavedPasswordStore
{
    // Key prefix is duplicated in ServerProfileStore.DeleteAsync (profile deletion cleanup).
    private const string KeyPrefix = "saved_password_";

    // Fixed additional entropy: ties the DPAPI blob to this purpose so other CurrentUser-scoped
    // callers can't transparently decrypt it by accident.
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("asERP.Client.SavedPassword.v1");

    public static bool IsSupported => OperatingSystem.IsWindows();

    /// <summary>Returns the stored password for the profile, or null when none/undecryptable.</summary>
    public static string? TryGet(Guid serverProfileId)
    {
        if (!OperatingSystem.IsWindows())
        {
            return null;
        }

        try
        {
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(KeyPrefix + serverProfileId, out var raw)
                && raw is string base64 && !string.IsNullOrEmpty(base64))
            {
                var plain = ProtectedData.Unprotect(Convert.FromBase64String(base64), Entropy,
                    DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plain);
            }
        }
        catch (Exception ex)
        {
            // Blob from another Windows user/machine or corrupted — treat as "nothing stored".
            Console.WriteLine($"[SavedPasswordStore] TryGet failed: {ex.Message}");
            Remove(serverProfileId);
        }

        return null;
    }

    public static void Set(Guid serverProfileId, string password)
    {
        if (!OperatingSystem.IsWindows() || string.IsNullOrEmpty(password))
        {
            return;
        }

        try
        {
            var cipher = ProtectedData.Protect(Encoding.UTF8.GetBytes(password), Entropy,
                DataProtectionScope.CurrentUser);
            ApplicationData.Current.LocalSettings.Values[KeyPrefix + serverProfileId] =
                Convert.ToBase64String(cipher);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SavedPasswordStore] Set failed: {ex.Message}");
        }
    }

    public static void Remove(Guid serverProfileId)
    {
        try
        {
            ApplicationData.Current.LocalSettings.Values.Remove(KeyPrefix + serverProfileId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SavedPasswordStore] Remove failed: {ex.Message}");
        }
    }
}
#endif
