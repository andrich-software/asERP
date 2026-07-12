using System.Reflection;
using asERP.Application.Contracts.Services;

namespace asERP.Infrastructure.Services;

public class ServerInfoService : IServerInfoService
{
    private const string RegistrationEnabledVar = "SERVER_REGISTRATION_ENABLED";
    private const string MinimumClientVersionVar = "SERVER_MINIMUM_CLIENT_VERSION";

    public ServerInfoService()
    {
        var raw = Environment.GetEnvironmentVariable(RegistrationEnabledVar);
        IsRegistrationEnabled = bool.TryParse(raw, out var parsed) && parsed;
        Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0";

        var rawMinimum = Environment.GetEnvironmentVariable(MinimumClientVersionVar);
        MinimumClientVersion = System.Version.TryParse(rawMinimum, out var minimum) ? minimum : null;
    }

    public bool IsRegistrationEnabled { get; }

    public string Version { get; }

    public Version? MinimumClientVersion { get; }
}
