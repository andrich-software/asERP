namespace asERP.Client.UITests;

/// <summary>
/// Playwright harness: one Chromium instance per fixture, a fresh context/page per test,
/// console/page-error capture and the screenshot-attachment helper. The app renders through
/// Skia into a single canvas, so tests observe boot markers, console output and screenshots —
/// there are no per-control DOM elements to query.
/// </summary>
public abstract class TestBase
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;

    protected IPage Page { get; private set; } = null!;

    /// <summary>console.error output — informational; the offline server-status probe logs here too.</summary>
    protected List<string> ConsoleErrors { get; } = new();

    /// <summary>
    /// Uno 6.5 requests the first render frame during startup before the root element exists;
    /// the resulting NullReferenceException in the framework's own RenderFrame is benign (the
    /// next frame renders fine) and fires on every WASM boot — filter exactly that one.
    /// </summary>
    private const string KnownBenignUnoStartupFrame = "Uno.UI.Runtime.Skia.BrowserRenderer.RenderFrame";

    /// <summary>
    /// Unhandled page errors with their managed stacks, minus the known-benign Uno startup race.
    /// Collected via window error/unhandledrejection hooks (an init script) because Playwright's
    /// PageError event only carries the message ("ManagedError: ...") without the stack — too
    /// little to tell a real app crash from the known framework race.
    /// </summary>
    protected async Task<IReadOnlyList<string>> GetPageErrorsAsync()
    {
        var errors = await Page.EvaluateAsync<string[]>("window.__unhandledErrors ?? []");
        return errors.Where(e => !e.Contains(KnownBenignUnoStartupFrame)).ToList();
    }

    [OneTimeSetUp]
    public async Task LaunchBrowserAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = Constants.Headless });
    }

    [OneTimeTearDown]
    public async Task CloseBrowserAsync()
    {
        if (_browser != null)
        {
            await _browser.DisposeAsync();
        }
        _playwright?.Dispose();
    }

    [SetUp]
    public async Task OpenPageAsync()
    {
        ConsoleErrors.Clear();

        _context = await _browser!.NewContextAsync(new()
        {
            ViewportSize = new() { Width = 1280, Height = 800 }
        });

        // Stash unhandled errors WITH their stacks — see GetPageErrorsAsync.
        await _context.AddInitScriptAsync(
            "window.__unhandledErrors = [];" +
            "window.addEventListener('error', e => window.__unhandledErrors.push(" +
            "  'error: ' + (e.error && e.error.stack || e.message)));" +
            "window.addEventListener('unhandledrejection', e => window.__unhandledErrors.push(" +
            "  'rejection: ' + (e.reason && e.reason.stack || String(e.reason))));");

        Page = await _context.NewPageAsync();
        Page.Console += (_, message) =>
        {
            if (message.Type == "error")
            {
                ConsoleErrors.Add(message.Text);
            }
        };
    }

    [TearDown]
    public async Task ClosePageAsync()
    {
        await TakeScreenshotAsync("teardown");
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    /// <summary>
    /// Navigates to the app and waits for the two boot markers: the Skia canvas appears (the app
    /// has a render surface) and the bootstrapper's persistent loader goes away (the first frame
    /// was rendered). Everything the app shows afterwards lives inside the canvas.
    /// </summary>
    protected async Task BootAppAsync()
    {
        await Page.GotoAsync(Constants.TargetUri, new()
        {
            WaitUntil = WaitUntilState.DOMContentLoaded,
            Timeout = Constants.BootTimeoutMs
        });

        await Page.Locator("canvas").First.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible,
            Timeout = Constants.BootTimeoutMs
        });

        await Page.Locator("#loading").WaitForAsync(new()
        {
            State = WaitForSelectorState.Hidden,
            Timeout = Constants.BootTimeoutMs
        });
    }

    /// <summary>
    /// Saves a screenshot into the screenshot directory (env <c>ASERP_UITEST_SCREENSHOT_DIR</c>,
    /// default: test work directory) and attaches it to the NUnit result.
    /// </summary>
    protected async Task<string> TakeScreenshotAsync(string stepName)
    {
        var directory = Environment.GetEnvironmentVariable("ASERP_UITEST_SCREENSHOT_DIR")
            ?? Path.Combine(TestContext.CurrentContext.WorkDirectory, "uitest-screenshots");
        Directory.CreateDirectory(directory);

        var title = $"{TestContext.CurrentContext.Test.Name}_{stepName}"
            .Replace(" ", "_")
            .Replace(".", "_");
        var path = Path.Combine(directory, title + ".png");

        await Page.ScreenshotAsync(new() { Path = path });
        TestContext.AddTestAttachment(path, stepName);
        return path;
    }
}
