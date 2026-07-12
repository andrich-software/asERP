# CLAUDE.md — asERP.Client.UITests

Playwright + NUnit browser smoke tests driving the **WASM head**. They verify the app actually
boots in a real browser — a failure class (startup exceptions, missing embedded resources,
broken bootstrap) that the headless logic tests in `tests/asERP.Client.Tests` cannot catch.

## Why no per-control queries

The app uses the **Skia renderer** on every platform: the whole UI is drawn into a single
`<canvas>`, so there are no per-control DOM elements. Uno.UITest/Selenium `Marked()` queries
cannot work against this app (the docs list Skia backends as unsupported) — the original Uno
template scaffolding (Xamarin.UITest + Uno.UITest.Helpers) was removed for that reason.
Tests assert boot markers (canvas presence, splash removal), unhandled page errors and take
screenshots; they do not click or read individual controls.

## Running locally

1. Serve the WASM head — publish and serve statically (matches CI):
   `dotnet publish src/asERP.Client/asERP.Client.csproj -f net10.0-browserwasm -c Release`
   then `dotnet serve --directory src/asERP.Client/bin/Release/net10.0-browserwasm/publish/wwwroot --port 5001`.
   **Use Release**: Debug bundles the Uno DevServer/Hot-Reload client whose failing `ws://…/rc`
   connection throws an unhandled `NullReferenceException` — that trips the page-error assertion.
2. One-time browser install: `pwsh tests/asERP.Client.UITests/bin/Debug/net10.0/playwright.ps1 install chromium`
   (build the project first so the script exists).
3. `dotnet test tests/asERP.Client.UITests/asERP.Client.UITests.csproj`

Environment variables: `ASERP_UITEST_TARGET_URI` (default `http://localhost:5001`),
`ASERP_UITEST_HEADED=1` (watch the browser), `ASERP_UITEST_SCREENSHOT_DIR` (default: NUnit work dir).

## CI

`.github/workflows/aserp-client-uitest.yml`: publishes the WASM head (Release,
`-p:WasmOnlyBuild=true`), serves it via `dotnet serve`, runs this project and uploads the
screenshots as artifacts. **Manual-only** (`workflow_dispatch`, Actions tab) — the Release
WASM publish makes the job too expensive to run on every push/PR.

## Conventions

- `console.error` output is informational only — the login overlay probes the (absent) backend,
  so network errors are expected. Tests fail on **unhandled page errors**
  (`TestBase.GetPageErrorsAsync()`), not on console noise.
- Page errors are collected via `window` error/unhandledrejection hooks (init script) so the
  **managed stack** is available — Playwright's own `PageError` event only carries the message.
- One known-benign error is filtered in `GetPageErrorsAsync`: Uno 6.5 requests the first render
  frame before the root element exists (`Uno.UI.Runtime.Skia.BrowserRenderer.RenderFrame` throws
  a NullReferenceException once per boot, harmless). Re-check when bumping Uno and drop the
  filter once fixed upstream.
- Keep `TestBase.cs` (browser lifecycle + screenshot attachment) as the shared harness.
- Real client logic tests live in `tests/asERP.Client.Tests`; API integration tests in
  `tests/asERP.Server.Tests`.
