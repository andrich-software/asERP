using asERP.Domain.Dtos.ServerInfo;

namespace asERP.Client.Features.Auth.Services;

public interface IServerInfoService
{
    Task<ServerInfoResponseDto?> GetServerInfoAsync(string serverUrl, CancellationToken cancellationToken = default);
}
