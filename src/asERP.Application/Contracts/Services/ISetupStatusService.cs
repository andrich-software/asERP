namespace asERP.Application.Contracts.Services;

public interface ISetupStatusService
{
    /// <summary>
    /// True while the initial server setup (first Superadmin + first tenant) is still
    /// pending: no user account exists yet and the System.SetupCompleted flag is not set.
    /// </summary>
    Task<bool> IsSetupRequiredAsync();
}
