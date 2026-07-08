# CLAUDE.md — asERP.Client.Tests

NUnit tests for **pure client logic** — static helpers, `x:Bind` visual functions, model logic. No UI instantiation: despite the Uno/WinUI/Skia references, these tests run headless because they deliberately target logic that needs no visual tree.

Refer to the root `/CLAUDE.md` for cross-cutting test rules.

## Rules

- **Framework: NUnit** (`[Test]`, `[TestCase]`), assertion style `Assert.That(actual, Is.EqualTo(expected))`.
- The project still references FluentAssertions and one legacy file uses `.Should()` — **do not copy that**; the project rule is plain NUnit assertions.
- **Test pure logic, not views.** If something is hard to test because it lives in XAML/code-behind, extract it into a static helper (see `StatusVisuals`, `BatchShipmentLogic`, `SalesShipmentRules`) and test the helper. Do not instantiate pages or controls here.
- Each test file carries a `/// <summary>` explaining intent — keep that up for new files.

## What Lives Here (orientation)

| Area | Files |
|---|---|
| Shipping feature logic | `SalesShipmentRulesTests`, `ShipmentDraftLogicTests`, `BatchShipmentLogicTests`, `LabelContentTypesTests`, `LabelPreferenceTests` |
| `x:Bind` visual helpers | `ShippingRowVisualsTests`, `ShippingTimelineVisualsTests`, `StatusVisualsTests` (central status→kind mapping for `StatusBadge`) |
| Superadmin GlobalSettings | `GlobalSettingEntryTests`, `GlobalSettingsLogicTests` |
| Platform workarounds | `CurrencyFormatterTests` (WASM/ICU `¤` currency-symbol substitution), `ServerUrlUtilTests` (auth URL normalization) |

## Run

```bash
dotnet test tests/asERP.Client.Tests/asERP.Client.Tests.csproj
```

UI automation lives in `tests/asERP.Client.UITests` — currently placeholder scaffolding only (see its `CLAUDE.md`).
