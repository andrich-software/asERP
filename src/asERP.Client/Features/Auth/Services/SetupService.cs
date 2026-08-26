using System.Net.Http.Json;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;
using asERP.Domain.Dtos.Setup;

namespace asERP.Client.Features.Auth.Services;

/// <summary>
/// Pre-login call to the anonymous /api/v1/setup endpoint. Uses the default HttpClient
/// with an explicit base address (like ServerInfoService / MaErpAuthenticationService)
/// because the "MaErpApi" pipeline requires a stored server URL, which only exists after
/// the first login.
/// </summary>
public class SetupService : ISetupService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<SetupService> _logger;

    public SetupService(IHttpClientFactory httpClientFactory, ILogger<SetupService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task RunInitialSetupAsync(string serverUrl, InitialSetupInputDto input, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Running initial server setup against {Server}", serverUrl);

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(serverUrl.TrimEnd('/'));

        var response = await httpClient.PostAsJsonAsync("/api/v1/setup", input,
            AppJsonSerializerContext.Default.InitialSetupInputDto, cancellationToken);

        // Surface server-side problem details (e.g. 403 when setup was already completed,
        // 400 on weak password or duplicate tenant name).
        await response.EnsureSuccessOrThrowApiExceptionAsync(cancellationToken);
    }
}
