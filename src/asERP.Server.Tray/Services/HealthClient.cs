namespace asERP.Server.Tray.Services;

internal sealed class HealthClient
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(2) };

    /// <summary>Returns true when GET /health answers 200 on the given port.</summary>
    public async Task<bool> IsHealthyAsync(int port)
    {
        try
        {
            using var response = await Http.GetAsync($"http://localhost:{port}/health");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            return false;
        }
    }

    /// <summary>Polls /health until it answers 200 or the timeout elapses.</summary>
    public async Task<bool> WaitUntilHealthyAsync(int port, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            if (await IsHealthyAsync(port))
            {
                return true;
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
        return false;
    }
}
