using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Features.ShippingProviders.Services;
using asERP.Domain.Enums;

namespace asERP.Client.Features.ShippingProviders.Models;

/// <summary>A carrier row on the shipping-methods overview.</summary>
public partial record ShippingProviderRow(
    Guid Id,
    string Name,
    string TypeDisplay,
    bool IsEnabled,
    bool UseSandbox,
    int RateCount);

public class ShippingProviderListModel : AsyncInitializableModel
{
    private readonly IShippingProviderAdminService _providerService;
    private readonly INavigator _navigator;

    private List<ShippingProviderRow> _rows = new();
    private bool _isRefreshing;
    private string _errorMessage = string.Empty;

    public ShippingProviderListModel(
        IShippingProviderAdminService providerService,
        INavigator navigator,
        ILogger<ShippingProviderListModel> logger)
        : base(logger)
    {
        _providerService = providerService;
        _navigator = navigator;

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        await LoadAsync(ct);
    }

    public List<ShippingProviderRow> Rows
    {
        get => _rows;
        private set
        {
            if (SetProperty(ref _rows, value))
            {
                OnPropertyChanged(nameof(ShowEmptyState));
            }
        }
    }

    public bool IsLoading => IsInitializing || _isRefreshing;

    public bool ShowEmptyState => !IsLoading && Rows.Count == 0;

    public string ErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value);
    }

    public async Task RefreshAsync(CancellationToken ct = default)
    {
        if (_isRefreshing)
        {
            return;
        }

        _isRefreshing = true;
        OnPropertyChanged(nameof(IsLoading));
        OnPropertyChanged(nameof(ShowEmptyState));

        try
        {
            await LoadAsync(ct);
        }
        finally
        {
            _isRefreshing = false;
            OnPropertyChanged(nameof(IsLoading));
            OnPropertyChanged(nameof(ShowEmptyState));
        }
    }

    private async Task LoadAsync(CancellationToken ct)
    {
        try
        {
            ErrorMessage = string.Empty;
            var providers = await _providerService.GetProvidersAsync(ct);

            Rows = providers
                .Select(p => new ShippingProviderRow(
                    p.Id, p.Name, TypeDisplayFor(p.Type), p.IsEnabled, p.UseSandbox, p.RateCount))
                .ToList();
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            Rows = new List<ShippingProviderRow>();
        }
    }

    private static string TypeDisplayFor(ShippingProviderType type) => type switch
    {
        ShippingProviderType.Dhl => "DHL",
        ShippingProviderType.Dpd => "DPD",
        ShippingProviderType.Gls => "GLS",
        ShippingProviderType.Ups => "UPS",
        _ => type.ToString()
    };

    public async Task CreateProviderAsync()
    {
        await _navigator.NavigateDataAsync(this, new ShippingProviderEditData());
    }

    public async Task EditProviderAsync(ShippingProviderRow row)
    {
        await _navigator.NavigateDataAsync(this, new ShippingProviderEditData(row.Id));
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        // Load continuations resume on a background thread — classic {Binding} updates raised
        // there are dropped on Desktop/Skia, so marshal onto the UI thread.
        RunOnUi(() =>
        {
            RaisePropertyChanged(propertyName);

            if (propertyName is nameof(IsInitializing))
            {
                RaisePropertyChanged(nameof(IsLoading));
                RaisePropertyChanged(nameof(ShowEmptyState));
            }
        });
    }

    // base.OnPropertyChanged cannot be called from inside a lambda, hence the trampoline.
    private void RaisePropertyChanged(string? propertyName) => base.OnPropertyChanged(propertyName);

    private static void RunOnUi(Action action)
    {
        var dispatcher = App.UiDispatcher;
        if (dispatcher is null || dispatcher.HasThreadAccess)
        {
            action();
        }
        else
        {
            dispatcher.TryEnqueue(() => action());
        }
    }
}
