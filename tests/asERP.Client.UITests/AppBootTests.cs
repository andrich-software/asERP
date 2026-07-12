namespace asERP.Client.UITests;

/// <summary>
/// Boot smoke tests for the WASM head: the .NET runtime starts, the Skia canvas appears with a
/// real layout size, the persistent loader disappears and no unhandled page errors occur — the
/// failure class (startup exception, missing embedded resource, broken bootstrap) that headless
/// logic tests cannot catch. The first screen is the login overlay; it needs no backend, its
/// server-status probe fails gracefully to "offline" (console noise only, never a page error).
/// </summary>
public class AppBootTests : TestBase
{
    [Test]
    public async Task App_Boots_To_A_Rendered_Canvas()
    {
        await BootAppAsync();
        await TakeScreenshotAsync("booted");

        var canvasBox = await Page.Locator("canvas").First.BoundingBoxAsync();
        var pageErrors = await GetPageErrorsAsync();
        Assert.Multiple(() =>
        {
            Assert.That(canvasBox, Is.Not.Null, "the Skia canvas should have a layout box");
            Assert.That(canvasBox!.Width, Is.GreaterThan(0), "canvas width");
            Assert.That(canvasBox.Height, Is.GreaterThan(0), "canvas height");
            Assert.That(pageErrors, Is.Empty,
                "unhandled page errors during boot:\n" + string.Join("\n---\n", pageErrors));
        });

        TestContext.Out.WriteLine($"document.title: '{await Page.TitleAsync()}'");
        TestContext.Out.WriteLine($"console errors (informational): {ConsoleErrors.Count}");
    }

    [Test]
    public async Task Keyboard_Input_On_The_Login_Overlay_Does_Not_Crash()
    {
        await BootAppAsync();

        // Push input through the Skia input pipeline: focus the app, tab through the login
        // form, type an email and submit the (incomplete) form — the overlay answers with a
        // validation banner drawn onto the canvas. Any unhandled exception on that path
        // surfaces via the error hooks.
        await Page.Mouse.ClickAsync(640, 400);
        await Page.Keyboard.PressAsync("Tab");
        await Page.Keyboard.TypeAsync("uitest@example.org");
        await Page.Keyboard.PressAsync("Tab");
        await Page.Keyboard.PressAsync("Enter");
        await Page.WaitForTimeoutAsync(2000);

        await TakeScreenshotAsync("after_input");
        var pageErrors = await GetPageErrorsAsync();
        Assert.That(pageErrors, Is.Empty,
            "unhandled page errors during keyboard interaction:\n" + string.Join("\n---\n", pageErrors));
    }
}
