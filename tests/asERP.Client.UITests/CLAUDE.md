# CLAUDE.md — asERP.Client.UITests

**Placeholder scaffolding — provides no real coverage.** This is the unmodified Uno template UI-test harness (NUnit + Xamarin.UITest + Uno.UITest.Helpers) driving the app over WASM.

- The only test, `Given_MainPage.When_SmokeTest`, taps the stock template marker `SecondPageButton`, which does not exist in the asERP UI. Do not treat it as evidence the UI works.
- Running requires launching the WASM target without a debugger and updating the port in `Constants.cs` (`WebAssemblyDefaultUri`).
- Real client logic tests live in `tests/asERP.Client.Tests`; API integration tests in `tests/asERP.Server.Tests`.

If you write real UI tests here: use the app's actual automation markers, keep `TestBase.cs` (screenshot harness) intact, and update `Constants.cs` deliberately.
