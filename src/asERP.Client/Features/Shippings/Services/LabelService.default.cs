#if !__DESKTOP__ && !__WASM__
namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// Fallback for heads without label handling (Android/iOS/plain net10.0): no capabilities,
/// all actions are no-ops. Must compile on every TFM; real support is a follow-up feature.
/// </summary>
public partial class LabelService
{
    public LabelCapabilities Capabilities => LabelCapabilities.None;

    public Task<IReadOnlyList<string>> GetPrinterNamesAsync() =>
        Task.FromResult<IReadOnlyList<string>>(Array.Empty<string>());

    public Task<bool> SaveAsync(LabelFile label) => Task.FromResult(false);

    public Task<bool> SaveAllAsync(IReadOnlyList<LabelFile> labels) => Task.FromResult(false);

    public Task PrintAsync(LabelFile label, string? printerName) => Task.CompletedTask;

    public Task OpenWithSystemDefaultAsync(LabelFile label) => Task.CompletedTask;
}
#endif
