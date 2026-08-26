using asERP.Domain.Dtos.Setup;

namespace asERP.Client.Features.Auth.Services;

public interface ISetupService
{
    /// <summary>
    /// Runs the initial server setup (first Superadmin + first tenant) against the given
    /// server. Throws an <see cref="asERP.Client.Core.Exceptions.ApiException"/> with the
    /// server's problem details when the request is rejected.
    /// </summary>
    Task RunInitialSetupAsync(string serverUrl, InitialSetupInputDto input, CancellationToken cancellationToken = default);
}
