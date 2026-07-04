# CLAUDE.md — asToolkit.Client

Cross-platform Uno Platform app. Single-project, multi-target: `net10.0-android`, `net10.0-browserwasm`, `net10.0-desktop`, `net10.0` (iOS temporarily disabled — see comment in `.csproj`).

Refer to the root `/CLAUDE.md` for cross-cutting rules. This file covers Client-specific conventions.

## Stack

| Concern | Choice |
|---|---|
| UI framework | Uno Platform 6.5.x (WinUI-flavored XAML) |
| Presentation pattern | **MVUX** (Model-View-Update-eXtended) — records with `IFeed`, `IListFeed`, `IState` |
| Markup | XAML |
| Theme | **Material** (via `Uno.Toolkit.UI.Material`) — Theme Service + DSP |
| Renderer | Skia (all platforms) |
| Navigation | `Uno.Extensions.Navigation` (`NavigateViewModelAsync<T>`, RouteMap, ViewMap) |
| HTTP | Kiota + named `HttpClient` "MaErpApi" |
| Auth | Web (Uno authentication) |
| Localization | `IStringLocalizer` with `.resw` resource files |
| Logging | Serilog (`LoggingSerilog` Uno feature) |
| DI / Config | Uno Hosting + Configuration |

The active Uno features are declared in `asToolkit.Client.csproj` under `<UnoFeatures>` — bumping/changing them is the canonical way to enable new capabilities.

> The Client has **no DB access**. All data goes through the Server's REST API.

## Feature-Based Architecture

Every business capability is a **module** under `Features/`. Module pattern is required for new features — copy an existing one (`Customers/`, `Sales/` — note: the Sales feature's *namespace* is `Features.Saless`, a legacy of the Order→Sales rename).

```
Features/{Feature}/
├── {Feature}Module.cs      # static: RegisterServices / RegisterViews / GetRoutes
├── Models/                 # MVUX records (one per page: List/Detail/Edit)
│   ├── {Feature}ListModel.cs
│   ├── {Feature}DetailModel.cs
│   └── {Feature}EditModel.cs
├── Views/                  # XAML pages + code-behind
│   ├── {Feature}ListPage.xaml(.cs)
│   ├── {Feature}DetailPage.xaml(.cs)
│   └── {Feature}EditPage.xaml(.cs)
└── Services/               # I{Feature}Service + {Feature}Service (HTTP calls)
```

`App.xaml.cs` calls each module's static `RegisterServices(services)`, `RegisterViews(views)`, `GetRoutes(views)` — **don't register views or routes globally**, do it in the module.

### Models (MVUX)

Models are `partial record` types injected with services via primary constructor. They expose state through MVUX feeds:

```csharp
public partial record CustomerListModel(ICustomerService Service)
{
    public IState<string> SearchQuery => State<string>.Value(this, () => string.Empty);
    public IListFeed<CustomerListDto> Customers =>
        ListFeed.Async(async ct => await Service.GetAllAsync(ct));
}
```

- `IFeed<T>` — read-only async value
- `IListFeed<T>` — read-only async list
- `IState<T>` — two-way bindable state (search input, selected item, etc.)

XAML binds with the Uno `Bindings` extension. `ViewMap<{Page}, {Model}>` connects them in the module.

## API Calls & Error Handling

Use the established pipeline — do not add new HTTP plumbing.

**In services** — let exceptions propagate by extending the response check:

```csharp
var response = await _http.GetAsync("api/v1/customers", ct);
await response.EnsureSuccessOrThrowApiExceptionAsync(ct);
return await response.Content.ReadFromJsonAsync<...>(ct);
```

**In models** — catch `ApiException` (in `Core/Exceptions/`) and surface server-side validation:

```csharp
try { /* call service */ }
catch (ApiException ex) { ErrorMessage = ex.CombinedMessage; }
```

`ApiException.CombinedMessage` already aggregates RFC 7807 messages from the Server.

## Localization

- German resources: `Strings/de/Resources.resw`
- English resources: `Strings/en/Resources.resw`
- **Critical**: `ResourceLoader.GetString()` uses **dots** as separators, not slashes:
  - ✅ `resourceLoader.GetString("Page.Section.Key")`
  - ❌ `resourceLoader.GetString("Page/Section/Key")` returns `null`

Inject `IStringLocalizer<T>` into models; for code-behind use a `ResourceLoader` instance.

### `IStringLocalizer` keys must be single-dot (2-segment)

Strings resolved at runtime via `_localizer["..."]` (model properties, code-behind) **must use a single-dot, 2-segment, PascalCase key** — e.g. `SalesChannelEditPage.ConnUrlLabel`, mirroring the proven pattern (`AddressDialog.CityPlaceholder`, `Common.Save`, `*.TitleNew`).

- ❌ **Multi-dot keys (`Page.Section.Key`) silently break.** The `.resw` → resource indexing turns only the *first* dot into the `/` section separator and keeps the rest literal (`Page.Section.Key` → stored as `Page/Section.Key`), while the lookup converts *all* dots to `/` (`Page/Section/Key`). The mismatch makes the localizer return the **raw key**, which renders in the UI with slashes. (Some 3-segment `*.Error.SaveFailed` keys exist in the codebase — they are silently broken too; don't copy them. Verified by inspecting the built DLL with `strings`.)
- ❌ **Never end a localizer key with `.Header` / `.Text` / `.PlaceholderText`** — those are reserved x:Uid property suffixes, consumed by the x:Uid mechanism and not flat-lookupable.
- ✅ **Prefer `x:Uid` for static XAML labels.** It uses the working resw resolution (`Name.Header`, `Name.PlaceholderText`). Only switch a control's `Header`/`PlaceholderText`/`Text` to a model-bound `_localizer[...]` property when the value must change at runtime (e.g. WooCommerce showing *Consumer Key* / *Consumer Secret* instead of *Username* / *Password*) — and then use single-dot keys.

## Styling

The app follows a **asERP design language**: white flat surfaces, 1px hairline borders (`OutlineVariantBrush`) instead of shadows, corner radius 8 (12 for dialogs), asERP blue `#3A5BE0` as primary, Inter as the app font (bundled in `Assets/Fonts/InterVariable.ttf`, wired via `MaterialToolkitTheme.FontOverrideDictionary` in App.xaml). **Do not add `ThemeShadow`/`Translation` elevation to new UI** — use a hairline border.

Styles live in `Styles/`:
- `ColorPaletteOverride.xaml` — Material color tokens. **Generated on build from `ColorPaletteOverride.json` (Uno Dsp) — edit the JSON only, never the XAML.**
- `AppTheme.xaml` — app tokens on top of Material: `AppLinkForegroundBrush`, `SidebarActiveBackgroundBrush`, `TableRowHoverBrush`, NavigationBar lightweight-styling overrides, Material shape overrides (button/input radius 8). Merged last in App.xaml so its shape overrides win.
- `InputControls.xaml` — compact input styling
- `TenantSwitcher.xaml` — tenant-selector specific
- `StatusColors.xaml` — semantic status brushes (`Status{Kind}Background/ForegroundBrush`), theme-aware Light + Dark
- `SharedComponents.xaml` — implicit styles for the shared controls below, shared responsive breakpoints (`BreakpointMedium`=800, `BreakpointWide`=1200 as `x:Double` for `AdaptiveTrigger`), `TableCardStyle`, `PageTitleTextStyle`/`PageDescriptionTextStyle`

### Design rules for new or changed UI (mandatory)

Any new page, card, dialog or control must blend into the asERP-style design. The rules:

**Colors — only `{ThemeResource}` brushes, never hex values in pages:**

| Use | Brush |
|---|---|
| Body text / icons that carry meaning | `OnSurfaceBrush` |
| Secondary text, descriptions, decorative icons | `OnSurfaceVariantBrush` |
| Page & card surfaces | `SurfaceBrush` (white) / `BackgroundBrush` |
| Hover bands, active nav, neutral chips, icon-chip fills | `SurfaceVariantBrush` (#F2F2F2) / `TableRowHoverBrush` for row hover |
| Hairline separators & card borders | `OutlineVariantBrush` (1px) |
| Input borders | `OutlineBrush` |
| Primary actions, focus, selected tabs | `PrimaryBrush` (asERP blue) |
| Hyperlinks / first-column table links | `AppLinkForegroundBrush` |
| Status colors (badges, alerts, deltas) | `Status*` brushes from `StatusColors.xaml` |

New app-level tokens go into `AppTheme.xaml` (both `Light` **and** `Default` ThemeDictionaries); Material-level color changes go into `ColorPaletteOverride.json` (both schemes). Never invent a page-local `SolidColorBrush`.

**Shape & elevation:** corner radius **8** everywhere (cards, buttons, inputs, table corners `8,8,0,0`), **12** for dialogs, full-round only for pill badges. **No `ThemeShadow`/`Translation`** — separation comes exclusively from 1px `OutlineVariantBrush` borders on white. Buttons and inputs get radius 8 automatically via the shape overrides in `AppTheme.xaml` — don't set `CornerRadius` on them manually.

**Typography:** Inter is applied globally via the font override — never set `FontFamily` manually. Use the existing ramp: `PageTitleTextStyle` (34px SemiBold, only via `PageHeader`/page headers), `TitleMedium` for card headers, `HeadlineLarge` for big KPI values, `BodyMedium` for body text, `LabelMedium`/`LabelSmall` for meta text, 11px SemiBold + `CharacterSpacing=60` for sidebar section headers.

**Buttons:** one `FilledButtonStyle` (blue) primary action per page, placed top-right in the `PageHeader.Actions` slot ("«Entität» erstellen" / "Create «entity»"). Everything else is `OutlinedButtonStyle` (white, 1px border; icon-only allowed) or `TextButtonStyle` inline. No `AppBarButton`s for page actions anymore.

**Page skeletons:** list/overview pages start with `controls:PageHeader` (Title + Description resw keys in **both** `de`/`en`, no `utu:NavigationBar`); detail/edit pages keep `utu:NavigationBar` (back only) + `DetailPageHeader`. Copy `CustomerListPage` / `SalesDetailPage` as references.

**Theme-awareness traps (cost us real bugs):**
- Use `{ThemeResource}` for every brush (never `{StaticResource}`) and check dark mode via the user-menu toggle.
- `Application.Current.Resources["SomeBrush"]` in code-behind does **not** resolve ThemeDictionaries theme-aware (it can return the dark value in light mode). To change a brush from code, switch between two styles whose setters use `{ThemeResource}` — see `SidebarNavItemActiveStyle` in `Shell.xaml(.cs)`.
- Converters returning brushes can't be theme-aware with static colors. For sign/state-dependent colors (e.g. +/- change indicators) use the dual-element pattern instead: two elements with `{ThemeResource}` brushes, toggled via a model bool + `BoolToVisibilityConverter`/`BoolToInverseVisibilityConverter` — see the KPI change indicators in `DashboardPage.xaml` (glyphs `&#xE74A;` up/green, `&#xE74B;` down/red).

### Shared UI components (mandatory pattern)

Custom controls live in `Controls/` (namespace `asToolkit.Client.Controls`, xmlns `controls`). **Use these instead of hand-building cards, badges, field blocks or empty states:**

| Control | Purpose | Localization |
|---|---|---|
| `DetailPageHeader` | Detail page header: icon chip, `Title`/`Subtitle` (string or UI), `Badges`, `Actions` slots; `Content` = extra slot (e.g. related-entity link). Renders as a plain (transparent, chrome-less) page header | actions/labels via child x:Uid |
| `PageHeader` | List/overview page header: big 34px `Title`, gray `Description`, optional `Glyph`, `Actions` slot top-right (primary button = `FilledButtonStyle`). Replaces the `NavigationBar` on list pages | x:Uid with `.Title`/`.Description` suffix keys |
| `SectionCard` | Elevated card with icon + title header row and 16px content padding | x:Uid with `.Header` suffix key |
| `StatusBadge` | Pill badge for any status enum or bool sync flag: `Status="{Binding ...}"` — text + colors resolved centrally in `Core/Status/StatusVisuals.cs` | automatic (`{EnumType}.{Value}` resw keys) |
| `LabeledField` | Icon + label + value with built-in "N/A" fallback; `LabeledFieldKeyValueStyle` for label-left/value-right rows | x:Uid with `.Text` suffix key |
| `EmptyState` | Centered icon/title/message placeholder, optional `ActionContent` | x:Uid with `.Title`/`.Message` suffix keys |

x:Uid on custom control properties is resolved **at compile time** by the Uno XAML generator — a typo'd resw key silently produces an empty string, so verify new keys exist in **both** `de` and `en` resw.

New status enums: add the mapping in `StatusVisuals.Resolve` (text key + semantic `Kind`) — do **not** create new `*To{Text,Background,Foreground}Converter` triples.

### Detail pages (mandatory layout)

Detail pages use the **Header + Tabs** layout (see `Features/Sales/Views/SalesDetailPage.xaml` as the reference):
- `utu:NavigationBar` (back only) → `mvux:FeedView` → root Grid (`MaxWidth="1400"`, rows `Auto,Auto,*`)
- Row 0: `DetailPageHeader` (badges + Edit/Delete actions live here, not in the AppBar)
- Row 1: `utu:TabBar` with `MaterialTopTabBarStyle` / items with `MaterialTopTabBarItemStyle`
- Row 2: one `ScrollViewer` **per tab**, toggled via `Visibility` in ~15 lines of code-behind (`DetailTabs_Loaded`/`DetailTabs_SelectionChanged`; keep the selected index in a page field so it survives FeedView refreshes)
- Expensive per-tab feeds (sub-lists, images) are gated on an `IState<bool>` the tab handler sets on first selection

### Cards

Cards use `SectionCard` (flat: `SurfaceBrush` background, 1px `OutlineVariantBrush` border, `CornerRadius="8"` — no shadow). Tables and list rows use `TableCardStyle` (same border-outline look). `ThemeShadow` is not used anywhere anymore; do not reintroduce it (per-element cost on Skia and off-design).

### List pages (mandatory performance rules)

See `Features/Products/Views/ProductListPage.xaml` as the reference:
- **Virtualization:** table bodies are a `ListView` (`TableListViewStyle` + `TableItemContainerStyle`, default `ItemsStackPanel`). **Never** wrap it in a `ScrollViewer` or `StackPanel` and never use `ScrollViewer + ItemsRepeater` for long lists — that materializes every row and killed scroll performance.
- **Rows:** one shallow `Grid` per row with a bottom hairline (`BorderThickness="0,0,0,1"`), **no Button wrapper** — row click via `IsItemClickEnabled` + `ItemClick`; hover/press come from the item container. Row min-height is 52 (`TableItemContainerStyle`); table header rows are white (`SurfaceBrush`) with `CornerRadius="8,8,0,0"`.
- **Compiled bindings:** row `DataTemplate`s declare `x:DataType` and use `{x:Bind}` for leaf values. Do NOT x:Bind against FeedView's `Data.*` outside typed item templates.
- **Sortable headers:** the header Grid sits *outside* the FeedView (page DataContext) and duplicates the row template's ColumnDefinitions (accepted duplication). Use `controls:SortHeaderButton` bound to `ActiveSortField`/`SortAscending` model states + a `ToggleSort` model method — no imperative icon juggling.
- **Thumbnails:** never load image bytes inside the list feed (blocks the whole list). Expose a `ThumbnailRequest` on the row model and let `media:ThumbnailLoader.Request` (Core/Media) load lazily per realized row — cached via `IThumbnailCache`, cancellation-safe on container recycling, decode capped via `DecodePixelWidth`.

## Dialogs

`ContentDialog` quirks under Uno + Material:

- A programmatically created `ContentDialog` does **not** receive an implicit style. Set it explicitly:
  `dialog.Style = (Style)Application.Current.Resources["ContentDialogStyle"];`
- `ContentDialogStyle` is the Material key (per `material-controls-styles.md`). `DefaultContentDialogStyle` (Fluent) and `MaterialContentDialogStyle` do **not** work.
- Set `XamlRoot = this.XamlRoot` before `ShowAsync()`.
- Do **not** put a `ContentDialog` into the visual tree — it would auto-show on page load.

## Navigation

- Routes are aggregated from each module's `GetRoutes()` and registered in `App.xaml.cs`.
- Navigate via `_navigator.NavigateViewModelAsync<TModel>()`.
- When adding a new XAML page, also add the matching `ViewMap<TPage, TModel>` in the module — and verify if any `DataTemplate` needs to land in `MainView.axaml`.

## Cross-Platform Considerations

When adding UI, think about all four runtimes (Desktop / WASM / Android / iOS):
- Skia renderer evens out a lot, but platform quirks remain (file pickers, secure storage, deep links).
- Performance matters on WASM — avoid large eager loads; prefer `Feed.Async` + virtualization.
- Test layouts at multiple sizes — phone, tablet, desktop.

## Common Tasks

| Task | Where to look first |
|---|---|
| Add a feature | Copy an existing module (`Features/Customers/`) |
| Add a new endpoint call | Add method to `I{Feature}Service` + implementation; reuse `MaErpApi` `HttpClient` |
| Translate a string | Add the same key to **both** `de` and `en` `Resources.resw` |
| Add a converter | `Core/Converters` (or local to a module) and reference in App.xaml `<Application.Resources>` |
| Page-level error display | Catch `ApiException` in the model, bind `ErrorMessage` to a `TextBlock` |
| Change a color/design token | Material palette → `Styles/ColorPaletteOverride.json` (both schemes; XAML is generated); app tokens → `Styles/AppTheme.xaml` (Light + Default); status colors → `Styles/StatusColors.xaml` |
| Add a new page header | List page → `controls:PageHeader`; detail/edit page → `DetailPageHeader` (see "Design rules") |
