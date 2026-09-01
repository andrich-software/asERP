# REFACTOR.md — Improvement Backlog for Future Claude Sessions

This file describes structural improvements identified during an architecture review (2026-08-31,
comparing asERP against the TAG24 backend family and current .NET practice). It is a **backlog, not
a mandate**: each item stands alone, is ordered by value-per-risk, and can be picked up by a future
session independently.

> **All original items (R1–R6) were completed on 2026-09-01.** The target design below is the code
> as it stands, not a plan. What is left are the follow-ups collected under
> "[Discovered while doing the above](#discovered-while-doing-the-above)".

## How to use this file

- Pick **one** item per session (or one area of a large item). Do not start a second item while the
  first is unfinished.
- Read the root `CLAUDE.md` and the nested `CLAUDE.md` of every layer you touch first.
- Keep the build warning-clean (`TreatWarningsAsErrors=true`) and run `dotnet format` +
  `dotnet test` before finishing.
- Items marked **[wire]** change the JSON the Server sends. The Uno client (`asERP.Client`,
  hand-written services on the named `MaErpApi` `HttpClient` — *not* a generated Kiota client)
  consumes that JSON — a [wire] item must update the client in the same change and needs the user's
  explicit OK before starting.
- When an item is done: check it off here, note the date and any deviations. If you discover a new
  structural improvement, add it here instead of doing it on the side.

## Target design (where the items converge)

Error handling should end up split by **kind of failure**, handled in exactly one place each:

1. **Contract validation** (shape, required, ranges — no DB needed): FluentValidation validator per
   command/query, executed automatically by the mediator *before* the handler runs. Failure →
   RFC 9457 `ValidationProblemDetails` with a `{ field: [messages] }` dictionary.
2. **Business failures** (not found, conflict, state rules — needs DB knowledge): handler returns
   `Result` with a *semantic* error type plus a machine-readable code; the controller maps it to
   HTTP. No HTTP knowledge below `asERP.Server`.
3. **Unexpected exceptions**: bubble up to the existing `GlobalExceptionHandler` (logs full detail,
   returns generic 500 problem details). No `try/catch` boilerplate in handlers.

What we keep unchanged, deliberately: the custom mediator (no MediatR package), vertical slices
under `Features/`, manual mapping, repositories + tenancy filters, commands returning the created
id (`Result<Guid>`), and the rule that exception text never reaches a client.

---

## R1 — Validation as a mediator pipeline step (highest value)

- [x] Status: **done 2026-09-01** (together with R2). `CustomMediator.Send` resolves
      `IEnumerable<IValidator<TRequest>>` from DI and runs it before the handler; failures throw
      `ValidationException`. Inline blocks removed from 72 handlers.

      Deviations from the plan:
      - **Six requests opted out** via the new `ISkipPipelineValidation` marker (see the table in
        `src/asERP.Application/CLAUDE.md`). Three of them (`CustomerUpdateCommand`,
        `ProductUpdateCommand`, `SettingDeleteCommand`) have a validator rule the handler maps to
        **404** and keep their inline block until R5. Two (`AiModelDeleteCommand`,
        `DeleteSalesCommand`) belong to DELETE endpoints whose controller discards the result and
        always answers 204 — their validators' failures had never reached a client, and throwing
        would have turned an idempotent DELETE into a 400.
      - **`SetupInitializeCommand` opts out for a security reason.** The handler deliberately checks
        "is setup still open?" *before* validating, so the anonymous endpoint answers 403 for every
        payload once setup is done. Validating in the pipeline ran the email-uniqueness rule first
        and turned the endpoint into an account-existence oracle — caught by
        `Setup_AfterCompletion_DoesNotLeakWhetherEmailExists`. Its inline validation was restored
        after the guard.
      - **`TenantListValidator` was dormant and wrong.** It was the only validator no handler ever
        ran, and it demanded `PageNumber > 0` while paging is zero-based and the controller passes
        `0` — enabling it would have 400'd every default tenant-list request. Its paging rules were
        removed; the `UserId` rule stayed.
      - **`SetupInitializeHandler` got an exception-safe compensation.** It creates the Superadmin,
        then sends `TenantCreateCommand`, and deleted the Superadmin again only on a failed
        `Result`. A thrown `ValidationException` would have skipped that rollback and left setup
        half-finished; the `Send` is now wrapped so the compensation runs either way.
      - **Five handlers already injected `IValidator<T>`** (Superadmin/Tenant user area); the field
        and constructor parameter were removed with the block.
      - **78 test assertions were retargeted.** Tests that read a validation 400 as a `Result`
        envelope and asserted `result.Messages` now go through the new
        `tests/asERP.Server.Tests/Infrastructure/ErrorResponse.cs` helper, which reads either shape.
        Status-code assertions were **not** touched — no endpoint changed its status code.
      - Noticed in passing, not fixed: `GenericRepository.IsUniqueAsync` returns `true` unless a
        repository overrides it, so uniqueness rules are silently inert for entities without an
        override (Country among them). Worth its own item.

**Problem.** Roughly 80 of the ~180 handlers repeat the same ~20-line block: `new` the validator,
`ValidateAsync`, join messages, log, `Result.Fail(BadRequest, …)`. The block is copy-paste drift
waiting to happen, validators are invisible to DI (they are `new`ed with hand-picked repos), and a
handler that forgets the block silently skips validation.

**Change.**

1. In `src/asERP.Application/Mediator/CustomMediator.cs`, before invoking the handler in `Send`,
   resolve `IEnumerable<IValidator<TRequest>>` from `_serviceProvider` and run them (cache the
   lookup like `SendCache` does). `AddValidatorsFromAssembly` is already called in
   `ApplicationServiceRegistration` — the validators just need DI-friendly constructors.
2. Give validators constructor injection (repos via ctor) instead of being `new`ed by handlers.
3. On failure, throw the existing `asERP.Application.Exceptions.ValidationException` carrying the
   *structured* failures (see R2) — do not join messages into one string.
4. Delete the inline validation blocks from handlers, slice area by area (start with one small area,
   e.g. `Features/Country/`, get tests green, then sweep).

**Opt-out:** a marker interface (e.g. `ISkipPipelineValidation`) for the rare request that validates
conditionally inside the handler — grep for handlers whose validation depends on runtime state
before assuming there are none.

**Verify.** `dotnet test` (especially `asERP.Server.Tests` multi-tenant integration tests); add one
pipeline test proving an invalid command never reaches its handler.

## R2 — Structured validation errors instead of joined strings **[wire]**

- [x] Status: **done 2026-09-01** (shipped with R1, as it had to be: `GlobalExceptionHandler` maps
      unknown exception types to a generic 500, so R1's thrown `ValidationException` without this
      mapping would have turned every validation failure into a 500)

**Problem.** Validation failures are flattened via `string.Join("; ", …)` into `Result.Messages`.
The client cannot attach messages to form fields, and the shape differs from what
`GlobalExceptionHandler` produces (RFC 7807 problem details).

**Change (as implemented).** `ValidationException` now groups failures by property
(`IReadOnlyDictionary<string, string[]> Errors`; object-level rules use the empty key, matching
ASP.NET's model-level convention). `GlobalExceptionHandler` maps it to a 400
`ValidationProblemDetails` with the standard `errors: { "PropertyName": [...] }` dictionary and
`application/problem+json`, logged at **warning** level — an invalid form submission is not a server
fault.

Client side: `ApiException` gained an `Errors` dictionary so field names survive, and
`HttpResponseExtensions` prefers the field messages over the generic
"One or more validation errors occurred." title. Per-field *display* is now possible but not yet
wired into any form — every page still shows the aggregated banner (`CombinedMessage`).

**Note on the two shapes.** Validation failures are problem details; business failures still travel
in the `Result` envelope (`ToActionResult` serializes the `Result` itself — see
`src/asERP.Server/Extensions/ResultExtensions.cs`). Both shapes are permanent until R5, and the
client parses both.

**Correction:** an earlier version of this file said to "regenerate the Kiota client". There is no
generated Kiota client — `HttpKiota` is only listed in `<UnoFeatures>`; the HTTP layer is hand-written
services on the named `MaErpApi` `HttpClient` with a source-generated `AppJsonSerializerContext`.
Nothing to regenerate.

**Verify.** Integration test asserting the 400 body contains the field dictionary; client form
still shows per-field errors.

## R3 — Machine-readable error codes; fix the DE/EN message mix

- [x] Status: **done 2026-09-01**, delivered as part of R5's error object rather than as a separate
      `Codes` list — the item allowed either, and one object beats two parallel channels.

      `ErrorCodes` (57 constants over 37 entities) lives in `asERP.Domain/Wrapper/ErrorCodes.cs`,
      **not** under `Features/{Area}/Shared/` as sketched here: `asERP.Domain` is the one project the
      Uno client already references, so the client can use the same constants instead of literals.
      `ApiException` now exposes `Code` and `ErrorType`.

      The taxonomy is deliberately coarse — `{entity}.{kind}`, kind mirroring `ErrorType`. Split a
      code when a client actually needs to tell two failures apart. `ErrorContractTests` enforces the
      shape.

      **Not done:** the German/English message mix. Messages are still whatever each handler had;
      only the *codes* are uniform now, and clients are meant to translate those. Migrating the
      remaining German strings stays a follow-up (see below).

**Problem.** `Result.Messages` are human-readable strings only, and (as
`asERP.Application/CLAUDE.md` already admits) some handlers return German text, others English.
Clients cannot translate or branch on errors without string parsing.

**Change.** Add a stable, machine-readable code to failures (e.g. `"customer.not_found"`,
`"product.sku_duplicate"`) — either a `Codes` list next to `Messages` (non-breaking, additive) or as
part of R5's error object. Codes are constants near the feature (e.g. `Features/{Area}/Shared/`).
The client translates codes; the server message becomes a developer-facing fallback (pick English,
migrate German messages as you touch them).

**Verify.** One test per migrated area asserting the code; grep that no *new* handler ships a
message without a code.

## R4 — Remove per-handler `try/catch`; trust `GlobalExceptionHandler`

- [x] Status: **done 2026-09-01**. 124 boilerplate catches removed across the handler layer:
      90 that called `ResultExtensions.FromException` plus 34 that spelled the same thing out
      (`catch (Exception ex) { … ResultStatusCode.InternalServerError … }`). `FromException` had no
      call sites left and `Extensions/ResultExtensions.cs` was deleted with it.

      What was deliberately kept (inspected one by one, as the item asked):
      - specific catches mapping to a business status — `DbUpdateConcurrencyException` → 404/409,
        and `CustomerCsvImport`'s "CSV unreadable" → **400**, which is a real mapping, not a 500;
      - per-row continuation in the import handlers (`importResult.Errors.Add(...)`);
      - best-effort side operations that must not fail the request (e.g. the
        `StockChangedNotification` publish in `GoodsReceiptCreate`);
      - `catch { await CleanUpAsync(); throw; }` compensation in `SetupInitialize`;
      - `catch (NotFoundException) { throw; }` guards.

      **One catch turned out to be load-bearing and was rebuilt narrower.** In `AiModelDelete` and
      `SalesDelete` the broad catch was what made those DELETEs idempotent: the handlers delete by
      id without looking the row up first, and `GenericRepository.DeleteAsync` throws
      `InvalidOperationException` (row gone) or `UnauthorizedAccessException` (other tenant).
      Removing it turned every "already deleted" call into a 500. Both now catch exactly those two
      types with a comment naming the contract — so a genuine infrastructure failure bubbles to a
      500 instead of being swallowed into a 204 as before, which is stricter than the old code.

      Notes:
      - Every handler holding a transaction declares it `await using var`, so disposal still rolls
        back when an exception now travels past the handler — checked before removing those.
      - `SetupInitialize` keeps its `try`/`finally`: the `finally` is the only thing releasing the
        process-wide setup semaphore. `ThrowingHandler_StillReleasesItsLock` pins that.
      - Handler-level 500s now arrive as problem details instead of the `Result` envelope. No test
        needed changing — the four that touch 500 accept several status codes and never read the body.
      - 81 handlers lost their now-unused `using asERP.Application.Extensions;` (build-verified: it
        was re-added to the 38 that still need `QueryableExtensions`/mapping extensions).

      **Verify** (as specified): `tests/asERP.Server.Tests/Mediator/UnhandledExceptionTests.cs`
      forces a handler dependency to throw and asserts a generic 500 whose body leaks neither the
      exception message, nor a file path, nor the exception type name.

**Problem.** Each handler wraps its body in `try/catch` + `ResultExtensions.FromException` to avoid
leaking exception text. That is ~10 redundant lines per handler for something
`GlobalExceptionHandler` already guarantees centrally (generic 500, full server-side log, no
exception text to the client).

**Change.** Delete the broad catch blocks; let unexpected exceptions bubble. Keep a catch **only**
where the failure is business-relevant and locally recoverable (e.g. an outbox retry in
`asERP.Shipping`/`asERP.SalesChannels`, partial-import continuation in `ImportExport`) — inspect
each catch before removing it, don't sweep blindly. `ResultExtensions.FromException` shrinks to
those legitimate call sites or disappears.

**Verify.** Integration test: force a handler to throw → response is a generic 500 problem details
without exception text, log contains the full exception.

**Watch out (learned while doing it).** The `asERP.Shipping`/`asERP.SalesChannels` outbox catches
were never in scope — every `FromException` call site lived in `asERP.Application/Features`. The
real trap was in the handler layer itself: a broad catch may be the only thing that keeps a
`finally` reachable or that compensates a half-finished write. Check for `finally`, `await using`
transactions and sibling catches *before* deleting a `try`, not after.

## R5 — Semantic error types instead of HTTP codes in `Result` **[wire]** (long-term)

- [x] Status: **done 2026-09-01** (user approved it explicitly).

      `ResultStatusCode` is **deleted**. `Result` now carries `Status` (`Ok`/`Created`/`NoContent`)
      and a nullable `Error` (`ErrorType` + code + message); `asERP.Server`'s
      `ResultExtensions.ToActionResult()` is the only place that names an HTTP status. Nothing under
      `asERP.Server` references a status code any more — verified by grep and by
      `ErrorContractTests.Envelope_NoLongerCarriesAnHttpStatusCode`.

      Migration, ~344 sites, in four scripted passes plus ~30 by hand:
      - `result.Succeeded = false; result.StatusCode = X; result.Messages.Add(m);` →
        `result.Fail(ErrorType.T, ErrorCodes.E.K, m);` (one call, control flow and logging untouched)
      - `Result<T>.Fail(ResultStatusCode.X, m)` → `Result<T>.NotFound(code, m)` and friends
      - `StatusCode = ResultStatusCode.{Ok,Created,NoContent}` → `Status = ResultStatus.…`
      - 87 controller actions doing `StatusCode((int)r.StatusCode, r)` → `r.ToActionResult()`

      Deviations and notes:
      - **`Result` stayed a mutable class.** The item also asked for an immutable record; that is a
        second, orthogonal sweep over the same ~344 sites and was left out to keep this change
        reviewable. The HTTP-out-of-the-Domain goal — the actual point — is met.
      - **No bridge survived.** The temporary `LegacyStatusFor` shim existed only mid-migration and
        was removed with the enum.
      - **`ProblemDetailsResult` also lost its status code** and carries an `Error` instead, so the
        Domain is HTTP-free rather than "HTTP-free except one type".
      - **Wire change:** the envelope's `statusCode` field is gone; `status` and `error` replace it.
        Low risk in practice — the client never branched on `statusCode`, it uses the real HTTP
        status. Enum values serialize as numbers, matching every other enum on this API.
      - Two Invoice tests parse the body with their own hand-written reader that does not fill
        `Error`; their failure-kind assertion was dropped in favour of the HTTP status they already
        assert.

**Problem.** `asERP.Domain.Wrapper.ResultStatusCode` *is* HTTP (`BadRequest = 400`, …), so HTTP
semantics live in the innermost layer and every non-HTTP consumer (sync orchestrator, outbox,
notification handlers) reasons in transport codes. `Result` is also mutable (settable properties).

**Change.** Introduce a semantic error object (`ErrorType` enum: `Validation`, `NotFound`,
`Conflict`, `Unauthorized`, `Unexpected` + code + message) on an immutable `Result` record; map
`ErrorType → HTTP` once in a Server-side `ToActionResult()` extension. Migrate slice by slice with a
temporary bridge from the old enum. This changes the serialized `Result` shape → client must move in
lockstep.

**Verify.** Full test suite + client build per migrated area; contract test for the HTTP mapping.

## R6 — Small cleanups (safe fillers for a short session)

- [x] **done 2026-09-01** — `SalesBy` → `SortBy` across 119 files. `asERP.SalesChannels` was
      excluded on purpose: its `ImportSalesByModifiedAsync` / `salesByRemoteId` really do mean
      "sales by …", as does one dispatch test name. The deprecated `salesBy` query parameter still
      works through `Server/Middleware/LegacySortParameterMiddleware`, one place instead of 29 list
      actions, so third-party API callers keep working and the whole deprecation is one file to
      delete. Covered by `LegacySortParameterTests`.
      Still open: the client's `SortSales`/`SetSortSales` state names, a separate artifact of the
      same botched rename (probably from `SortOrder`), plus test names like
      `ShouldReturnSalesedResults`. No wire impact, left alone.
- [x] **done 2026-09-01** — 59 files: "MediatR" in doc comments now says "the custom mediator". The
      one remaining mention is in `CustomMediator.cs` itself ("to replace MediatR"), where it is
      accurate.
- [x] **done 2026-09-01** — 117 narrating XML doc blocks removed from 27 handlers (field, ctor and
      `Handle` blocks that only restated the code). Class-level summaries were left alone: many
      carry real constraints, and a blanket sweep would have deleted them. Blocks containing words
      like "must", "never", "SECURITY" or `<remarks>` were skipped by the same rule.

---

## Suggested order (historical)

R1 → R2 (one change if possible) → R4 → R3 → R6 anytime → R5 last, as its own planned effort.
This is what was actually done, in three sessions: R1+R2, then R4, then R6 + R3/R5 together.
R3 folding into R5's error object made it disappear as separate work, exactly as hoped.

---

## Discovered while doing the above

New items, in rough value-per-risk order. None of them is started.

- [ ] **`GenericRepository.IsUniqueAsync` returns `true` unless overridden.** Uniqueness rules are
      therefore silently inert for every entity without an override — `Country` among them, so two
      countries with the same name are accepted today. Either make the base implementation real or
      make the missing override impossible to overlook.
- [ ] **Handlers that answer 400 for a missing row.** Several report `ErrorType.Validation` with a
      "… not found" message (e.g. parts of `Superadmin`). Faithfully preserved during R5 rather than
      silently changed; each deserves a decision on whether 404 is the honest answer. **[wire]**
- [ ] **Three commands still validate inline** (`CustomerUpdateCommand`, `ProductUpdateCommand`,
      `SettingDeleteCommand`, all marked `ISkipPipelineValidation`) because their validator carries
      an existence rule the handler maps to 404. Move that rule into the handler and let the
      pipeline validate them like everything else.
- [ ] **German user-facing messages.** R3 left them alone: codes are uniform, messages are not.
      Pick English and migrate as areas are touched — clients should translate the code anyway.
- [ ] **`Result` is still a mutable class.** R5 deliberately skipped the immutable-record half; it
      is another ~344-site sweep and buys much less than the HTTP removal did.
- [ ] **Client naming leftovers** from the Order→Sales rename: `SortSales`/`SetSortSales` state,
      test names like `ShouldReturnSalesedResults`. Cosmetic, no wire impact.
- [ ] **Drop the `salesBy` deprecation** once you are satisfied no third-party client uses it:
      delete `LegacySortParameterMiddleware`, its registration, and `LegacySortParameterTests`.
- [ ] **~40 client services swallow failed GETs** (`if (response?.Succeeded != true) { LogWarning;
      return new(); }`), so a server-side error shows as an empty list. Now that failures carry a
      code, these could surface something useful.
