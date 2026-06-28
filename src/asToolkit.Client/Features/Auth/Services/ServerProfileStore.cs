using System.Text.Json;
using asToolkit.Client.Core.Json;
using asToolkit.Client.Features.Auth.Models;
using Windows.Storage;

namespace asToolkit.Client.Features.Auth.Services;

public class ServerProfileStore : IServerProfileStore
{
    private const string ProfilesKey = "server_profiles";
    private const string LastUsedIdKey = "last_used_server_id";
    private const string LegacyServerUrlKey = "server_url";
#if DEBUG
    private const string DevProfileSeededKey = "dev_profile_seeded";
#endif

    private readonly ILogger<ServerProfileStore> _logger;

    public ServerProfileStore(ILogger<ServerProfileStore> logger)
    {
        _logger = logger;
    }

    public Task<IReadOnlyList<ServerProfile>> GetAllAsync()
    {
#if DEBUG
        SeedDevProfileOnce();
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
    /// Dev convenience: on a fresh client, seed a "Local Dev" server profile pointing at the local
    /// Server and pre-select it, so the prefilled dev credentials log in against localhost instead of
    /// the built-in asToolkit Cloud entry. Runs once (guarded by a flag) so a developer can still edit or
    /// delete the profile without it reappearing.
    /// </summary>
    private void SeedDevProfileOnce()
    {
        var values = ApplicationData.Current.LocalSettings.Values;
        if (values.TryGetValue(DevProfileSeededKey, out var seeded) && seeded is bool already && already)
        {
            return;
        }

        var profiles = LoadProfiles();
        if (profiles.All(p => p.Id != ServerProfile.LocalDevId))
        {
            profiles.Add(ServerProfile.CreateLocalDev());
            SaveProfiles(profiles);
        }

        // Pre-select the local dev server unless the user has already chosen one.
        if (!values.ContainsKey(LastUsedIdKey))
        {
            values[LastUsedIdKey] = ServerProfile.LocalDevId.ToString();
        }

        values[DevProfileSeededKey] = true;
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
            // The built-in asToolkit Cloud entry is immutable — ignore attempts to change it.
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
