using System.Text.Json;
using asERP.Client.Core.Json;
using asERP.Client.Features.Auth.Models;
using Windows.Storage;

namespace asERP.Client.Features.Auth.Services;

public class ServerProfileStore : IServerProfileStore
{
    private const string ProfilesKey = "server_profiles";
    private const string LastUsedIdKey = "last_used_server_id";
    private const string LegacyServerUrlKey = "server_url";

    private readonly ILogger<ServerProfileStore> _logger;

    public ServerProfileStore(ILogger<ServerProfileStore> logger)
    {
        _logger = logger;
    }

    public Task<IReadOnlyList<ServerProfile>> GetAllAsync()
    {
#if DEBUG
        EnsureLocalDevProfile();
#endif
        var profiles = LoadProfiles();
        EnsureBuiltIn(profiles);
        Migrate(profiles);

        var ordered = profiles
            .OrderByDescending(p => p.IsBuiltIn)
            .ThenByDescending(p => p.LastUsedAt ?? DateTimeOffset.MinValue)
            .ThenBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        return Task.FromResult<IReadOnlyList<ServerProfile>>(ordered);
    }

#if DEBUG
    /// <summary>
    /// Dev convenience: DEBUG builds (debugger / <c>dotnet run</c>) always carry a server profile
    /// pointing at the local dev Server (https://localhost:8443). Matched by URL, not id — a
    /// profile the developer created or renamed for the same URL counts, so no duplicate appears
    /// and edits stick. On a fresh client the entry is also pre-selected so the prefilled dev
    /// credentials log in against localhost instead of the built-in asERP Cloud entry.
    /// (Deleting it only lasts until the next load; use a Release build to get rid of it.)
    /// </summary>
    private void EnsureLocalDevProfile()
    {
        var profiles = LoadProfiles();
        // The id check covers a Local-Dev entry the developer re-pointed at another URL —
        // re-adding would duplicate the fixed LocalDevId; respect the edit instead.
        if (profiles.Any(p => p.Id == ServerProfile.LocalDevId
                || string.Equals(ServerUrlUtil.Normalize(p.Url), ServerProfile.LocalDevUrl, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        profiles.Add(ServerProfile.CreateLocalDev());
        SaveProfiles(profiles);

        // Pre-select the local dev server unless the user has already chosen one.
        var values = ApplicationData.Current.LocalSettings.Values;
        if (!values.ContainsKey(LastUsedIdKey))
        {
            values[LastUsedIdKey] = ServerProfile.LocalDevId.ToString();
        }
    }
#endif

    public Task UpsertAsync(ServerProfile profile)
    {
        if (profile == null)
        {
            return Task.CompletedTask;
        }

        var profiles = LoadProfiles();
        EnsureBuiltIn(profiles);

        var existing = profiles.FirstOrDefault(p => p.Id == profile.Id);
        if (existing?.IsBuiltIn == true)
        {
            // The built-in asERP Cloud entry is immutable — ignore attempts to change it.
            return Task.CompletedTask;
        }

        if (profile.Id == Guid.Empty)
        {
            profile.Id = Guid.NewGuid();
        }

        profile.Url = ServerUrlUtil.Normalize(profile.Url);

        if (existing != null)
        {
            existing.Name = profile.Name;
            existing.Url = profile.Url;
            existing.LastUsedEmail = profile.LastUsedEmail;
            existing.LastUsedAt = profile.LastUsedAt;
        }
        else
        {
            profiles.Add(profile);
        }

        SaveProfiles(profiles);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var profiles = LoadProfiles();
        var target = profiles.FirstOrDefault(p => p.Id == id);
        if (target == null || target.IsBuiltIn)
        {
            return Task.CompletedTask;
        }

        profiles.Remove(target);
        SaveProfiles(profiles);

        // Drop a saved login password stored for this profile (written by the Windows desktop
        // client's SavedPasswordStore — key prefix kept in sync there; no-op elsewhere).
        try
        {
            ApplicationData.Current.LocalSettings.Values.Remove($"saved_password_{id}");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not remove saved password for deleted server profile {Id}", id);
        }

        return Task.CompletedTask;
    }

    public async Task<ServerProfile> GetLastUsedAsync()
    {
        var profiles = await GetAllAsync();
        var lastUsedId = GetLastUsedId();

        if (lastUsedId.HasValue)
        {
            var match = profiles.FirstOrDefault(p => p.Id == lastUsedId.Value);
            if (match != null)
            {
                return match;
            }
        }

        // Fall back to the built-in entry (always present after GetAllAsync).
        return profiles.First(p => p.IsBuiltIn);
    }

    public Task SetLastUsedAsync(Guid id, string? email)
    {
        var profiles = LoadProfiles();
        EnsureBuiltIn(profiles);

        var target = profiles.FirstOrDefault(p => p.Id == id);
        if (target != null)
        {
            target.LastUsedAt = DateTimeOffset.UtcNow;
            if (!string.IsNullOrWhiteSpace(email))
            {
                target.LastUsedEmail = email;
            }
            SaveProfiles(profiles);
        }

        ApplicationData.Current.LocalSettings.Values[LastUsedIdKey] = id.ToString();
        return Task.CompletedTask;
    }

    public Task SetLastSelectedAsync(Guid id)
    {
        // Selection only — the profile's LastUsedAt/LastUsedEmail stay untouched (those mean
        // "logged in successfully here", which drives ordering and the email prefill).
        try
        {
            ApplicationData.Current.LocalSettings.Values[LastUsedIdKey] = id.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error persisting selected server id");
        }
        return Task.CompletedTask;
    }

    private List<ServerProfile> LoadProfiles()
    {
        try
        {
            var values = ApplicationData.Current.LocalSettings.Values;
            if (values.TryGetValue(ProfilesKey, out var raw) && raw is string json && !string.IsNullOrWhiteSpace(json))
            {
                var list = JsonSerializer.Deserialize(json, AppJsonSerializerContext.Default.ListServerProfile);
                if (list != null)
                {
                    return list;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading server profiles from local storage");
        }

        return new List<ServerProfile>();
    }

    private void SaveProfiles(List<ServerProfile> profiles)
    {
        try
        {
            var json = JsonSerializer.Serialize(profiles, AppJsonSerializerContext.Default.ListServerProfile);
            ApplicationData.Current.LocalSettings.Values[ProfilesKey] = json;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving server profiles to local storage");
        }
    }

    private static void EnsureBuiltIn(List<ServerProfile> profiles)
    {
        var builtIn = profiles.FirstOrDefault(p => p.Id == ServerProfile.BuiltInId);
        if (builtIn == null)
        {
            profiles.Insert(0, ServerProfile.CreateBuiltIn());
        }
        else
        {
            // Keep the built-in entry's identity authoritative regardless of stored values.
            builtIn.Name = ServerProfile.BuiltInName;
            builtIn.Url = ServerProfile.BuiltInUrl;
            builtIn.IsBuiltIn = true;
        }
    }

    /// <summary>
    /// On first run, fold a pre-existing single <c>server_url</c> value (used by the old free-form
    /// login field) into a profile so existing users keep their server. Runs once.
    /// </summary>
    private void Migrate(List<ServerProfile> profiles)
    {
        try
        {
            var values = ApplicationData.Current.LocalSettings.Values;
            if (values.ContainsKey(ProfilesKey))
            {
                return; // Profiles already initialized — nothing to migrate.
            }

            if (values.TryGetValue(LegacyServerUrlKey, out var raw) && raw is string legacy)
            {
                var url = ServerUrlUtil.Normalize(legacy);
                if (ServerUrlUtil.IsValid(url) &&
                    !string.Equals(url, ServerProfile.BuiltInUrl, StringComparison.OrdinalIgnoreCase) &&
                    !profiles.Any(p => string.Equals(p.Url, url, StringComparison.OrdinalIgnoreCase)))
                {
                    var profile = new ServerProfile
                    {
                        Id = Guid.NewGuid(),
                        Name = new Uri(url).Host,
                        Url = url,
                        LastUsedAt = DateTimeOffset.UtcNow
                    };
                    profiles.Add(profile);
                    ApplicationData.Current.LocalSettings.Values[LastUsedIdKey] = profile.Id.ToString();
                }
            }

            // Persist the initialized list so this migration only runs once.
            SaveProfiles(profiles);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error migrating legacy server URL into profiles");
        }
    }

    private Guid? GetLastUsedId()
    {
        try
        {
            var values = ApplicationData.Current.LocalSettings.Values;
            if (values.TryGetValue(LastUsedIdKey, out var raw) && Guid.TryParse(raw?.ToString(), out var id))
            {
                return id;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading last-used server id");
        }
        return null;
    }
}
