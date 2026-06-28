using asToolkit.Client.Features.Auth.Models;

namespace asToolkit.Client.Features.Auth.Services;

/// <summary>
/// Persists the list of known asToolkit servers locally and tracks which one was used last.
/// The built-in asToolkit Cloud entry (<see cref="ServerProfile.BuiltInId"/>) is always present
/// and cannot be edited or deleted.
/// </summary>
public interface IServerProfileStore
{
    /// <summary>
    /// Returns all known servers, built-in first, remaining ordered by last use (newest first).
    /// Guarantees the built-in asToolkit Cloud entry is present and migrates a legacy single
    /// <c>server_url</c> value into a profile on first run.
    /// </summary>
    Task<IReadOnlyList<ServerProfile>> GetAllAsync();

    /// <summary>Adds a new server or updates an existing one (matched by <see cref="ServerProfile.Id"/>).</summary>
    Task UpsertAsync(ServerProfile profile);

    /// <summary>Deletes a server. The built-in entry cannot be deleted (call is ignored).</summary>
    Task DeleteAsync(Guid id);

    /// <summary>The server selected by default on the login screen (last used, falling back to built-in).</summary>
    Task<ServerProfile> GetLastUsedAsync();

    /// <summary>Records the last successful login: marks the server as last used and stores the email.</summary>
    Task SetLastUsedAsync(Guid id, string? email);
}
