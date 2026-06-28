#if __WASM__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Uno.Extensions.Authentication;
using Windows.Storage;

namespace asToolkit.Client.Features.Auth.Services;

/// <summary>
/// WASM-only <see cref="ITokenCache"/> that persists tokens directly in
/// <c>ApplicationData.Current.LocalSettings</c>.
///
/// Uno's default token cache routes through <c>ApplicationDataKeyValueStorage</c>
/// (serialized values keyed with an <c>_ADCSSS</c> suffix). On the WebAssembly target those
/// writes do <b>not</b> survive a page reload — verified empirically: after a reload
/// <see cref="HasTokenAsync"/> returns false and the cache is empty, even though a raw value
/// written straight to <c>LocalSettings</c> at the same point <i>does</i> persist. The empty
/// cache makes <c>AuthenticationService.RefreshAsync</c> report the user as unauthenticated and
/// it never invokes the refresh-token flow, so silent auto-login is impossible.
///
/// Writing straight to <c>LocalSettings</c> (which persists reliably on WASM) sidesteps the
/// broken layer. This type is registered only for <c>__WASM__</c> in
/// <see cref="asToolkit.Client.Features.Auth.AuthModule"/>; other targets keep Uno's
/// platform-native secure cache (Keychain / Keystore / PasswordVault / Encrypted).
///
/// Semantics mirror Uno's <c>TokenCache</c>: a single current provider plus a flat token
/// dictionary, with <see cref="Cleared"/> raised only when tokens were actually removed.
/// WASM is single-threaded and every operation here is synchronous, so no locking is needed.
/// </summary>
public sealed class WasmLocalSettingsTokenCache : ITokenCache
{
    private const string Prefix = "astoolkit_tokencache_";
    private const string ProviderKey = Prefix + "__provider";

    public event EventHandler? Cleared;

    private static ApplicationDataContainer Settings => ApplicationData.Current.LocalSettings;

    public ValueTask<string?> GetCurrentProviderAsync(CancellationToken ct)
    {
        var provider = Settings.Values.TryGetValue(ProviderKey, out var value) ? value?.ToString() : null;
        return new ValueTask<string?>(provider);
    }

    public ValueTask<bool> HasTokenAsync(CancellationToken cancellationToken)
        => new ValueTask<bool>(TokenKeys().Length > 0);

    public ValueTask<IDictionary<string, string>> GetAsync(CancellationToken cancellationToken)
    {
        IDictionary<string, string> tokens = TokenKeys()
            .ToDictionary(
                key => key.Substring(Prefix.Length),
                key => Settings.Values[key]?.ToString() ?? string.Empty);
        return new ValueTask<IDictionary<string, string>>(tokens);
    }

    public ValueTask SaveAsync(string provider, IDictionary<string, string>? tokens, CancellationToken cancellationToken)
    {
        RemoveTokenKeys();
        Settings.Values[ProviderKey] = provider;

        if (tokens is not null)
        {
            foreach (var token in tokens)
            {
                Settings.Values[Prefix + token.Key] = token.Value;
            }
        }

        return default;
    }

    public ValueTask ClearAsync(CancellationToken cancellationToken)
    {
        var hadTokens = TokenKeys().Length > 0;
        RemoveTokenKeys();
        Settings.Values.Remove(ProviderKey);

        if (hadTokens)
        {
            Cleared?.Invoke(this, EventArgs.Empty);
        }

        return default;
    }

    private static string[] TokenKeys()
        => Settings.Values.Keys
            .Where(key => key.StartsWith(Prefix, StringComparison.Ordinal) && key != ProviderKey)
            .ToArray();

    private static void RemoveTokenKeys()
    {
        foreach (var key in TokenKeys())
        {
            Settings.Values.Remove(key);
        }
    }
}
#endif
