namespace asERP.Application.Contracts.Services;

public interface IServerInfoService
{
    bool IsRegistrationEnabled { get; }
    string Version { get; }

    /// <summary>Minimum client version required to connect, or null when not enforced.</summary>
    Version? MinimumClientVersion { get; }
}
