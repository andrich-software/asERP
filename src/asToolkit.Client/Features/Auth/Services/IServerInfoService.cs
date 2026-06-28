using asToolkit.Domain.Dtos.ServerInfo;

namespace asToolkit.Client.Features.Auth.Services;

public interface IServerInfoService
{
    Task<ServerInfoResponseDto?> GetServerInfoAsync(string serverUrl, CancellationToken cancellationToken = default);
}
